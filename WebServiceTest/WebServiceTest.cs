using System.Text;
using System.Text.Json;
using WebService.WebAPIService;
using WebService;
namespace WebServiceTest
{
    public class WebServiceTest
    {
        [Fact]
        public void It_should_Add_the_Employee()
        {
            Employee employee = new Employee()
            {
                Id = "2",
                Name = "WebServer"
            };

            var app = new ApiApplication(new MyService());

            var httprq = new HttpRq()
            {
                Method = "POST",
                Url = "/postEmployee",
                Content = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(employee)),

            };


            var httpRs = app.Handle(httprq);
            var ActualEmployeeList = JsonSerializer.Deserialize(httpRs.Content, typeof(List<Employee>)) as List<Employee>;
            Assert.Equal(ActualEmployeeList.Count, 2);
            Assert.Equal(ActualEmployeeList[1].Id, employee.Id);
            Assert.Equal(ActualEmployeeList[1].Name, employee.Name);
        }

        [Fact]
        public void It_should_Get_the_Employee_By_Id()
        {
            // Add the employeee into the list through API calls
            Employee employee = new Employee()
            {
                Id = "2",
                Name = "WebServer"
            };
            var httprq = new HttpRq()
            {
                Method = "POST",
                Url = "/postEmployee",
                Content = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(employee)),

            };
            var app = new ApiApplication(new MyService());
            app.Handle(httprq);

            // Get the Employee by its EmployeeID


            var httprq1 = new HttpRq()
            {
                Method = "GET",
                Url = "/getEmployeeById",
                Content = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes("2")),

            };
           


            var httpRs = app.Handle(httprq1);
            var EmployeeResponse = JsonSerializer.Deserialize(httpRs.Content, typeof(Employee)) as Employee;

            Assert.Equal(EmployeeResponse.Name, employee.Name);

        }


        [Fact]
        public void It_should_Modify_the_details_Employee_By_Id()
        {
            // Adding the Details of the Employee
            Employee employee = new Employee()
            {
                Id = "2",
                Name = "WebServer"
            };
            var httprq = new HttpRq()
            {
                Method = "POST",
                Url = "/postEmployee",
                Content = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(employee)),

            };
            var app = new ApiApplication(new MyService());
            app.Handle(httprq);


            // Modify the deails of existing Employee 

            Employee ModifiedEmployeeDetails = new Employee()
            {
                Id = "2",
                Name = "NewWebServer"
            };


            var httprq1 = new HttpRq()
            {
                Method = "PUT",
                Url = "/putEmployee",
                Content = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(ModifiedEmployeeDetails)),

            };

            var httpRs = app.Handle(httprq1);
            var EmployeeResponse = JsonSerializer.Deserialize(httpRs.Content, typeof(Employee)) as Employee;

            Assert.Equal(EmployeeResponse.Name, ModifiedEmployeeDetails.Name);
            Assert.Equal(EmployeeResponse.Id, employee.Id);
            Assert.NotEqual(ModifiedEmployeeDetails.Name, employee.Name);


        }
    }
}