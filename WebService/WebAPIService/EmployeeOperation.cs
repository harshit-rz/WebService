using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.WebAPIService
{
    public  class EmployeeOperation
    {

        private List<Employee> _employeeList = new List<Employee>();
        public List<Employee> AddEmployee(Employee employee)
        {
            _employeeList.Add(employee);
            return _employeeList;

        }

        public List<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(string employeeId)
        {
            Employee employee= null; ;
            foreach (var emp in _employeeList)
            {
                if (emp.Id.Equals(employeeId))
                {
                    employee = emp;
                }
            }
            return employee;
        }

        public Employee EditEmployee(Employee employeeModifiedDetail)
        {
            Employee employee = null; ;
            foreach (var emp in _employeeList)
            {
                if (emp.Id.Equals(employeeModifiedDetail.Id))
                {
                    employee = emp;
                }
            }
            employee.Name = employeeModifiedDetail.Name;
           
            return employee;
        }


    }

}

