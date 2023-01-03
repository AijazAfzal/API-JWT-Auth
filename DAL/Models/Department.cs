using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Department
    {
        [Key] 
        public int Dep_Id { get; set; }

        public string? Dep_Name { get; set; }

        public String? Dep_Hod { get; set; }  

    }
}