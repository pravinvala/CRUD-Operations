using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeMaster.Models
{
    public class EmployeeCreateModel
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string Address { get; set; }
        public string EmployeePhoto { get; set; }
        public bool MaritalStatus { get; set; }
        public decimal Salary { get; set; }
        public string Zipcode { get; set; }
        public string Password { get; set; }
        public string[] Hobbies { get; set; }

    }

    public class Hobby
    {
        public int HobbyID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeCreateModel> Employee { get; set; }
    }

}