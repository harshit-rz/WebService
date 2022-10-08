using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.WebAPIService
{
    
        public class MyService : Service
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            
            [WebOperation(Method = "GET", Route = "/getEmployeeById")]
            public Employee GetEmployee(string id)
            {

                return employeeOperation.GetEmployeeById(id);
            }

            [WebOperation(Method = "GET", Route = "/getAllEmployee")]
            public List<Employee> GetAllEmployee()
            {

                return employeeOperation.GetAllEmployee();
            }


            [WebOperation(Method = "POST", Route = "/postEmployee")]
                public List<Employee> AddEmployee(Employee employee)
                {

                    return employeeOperation.AddEmployee(employee);
                }
            [WebOperation(Method = "PUT", Route = "/putEmployee")]
            public  Employee EditEmployee(Employee ModifiedDetails)
            {

                return employeeOperation.EditEmployee(ModifiedDetails);
            }
    }

    
}
