using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCore_Net5.Models
{
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }
        [Required(ErrorMessage ="DeptName is Must")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Location is Must")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Capacity is Must")]
        public int Capacity { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is Must")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Designation is Must")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Salary is Must")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "DeptNo is Must")]
        public int DeptNo { get; set; }
        public Department Department { get; set; }
    }
}
