using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeMaster.Models
{
    public class EmployeeViewModel
    {

        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string EmployeePhoto { get; set; }
        public string Hobbies { get; set; }
        public bool MaritalStatus { get; set; }
        public decimal Salary { get; set; }
        public string Zipcode { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


    }
}