using BAL.Interface;
using DAL.ApiDbContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Data_Manager
{
    public class DepartmentDataManager : IDataRepository<Department>
    {
        readonly DepartmentDbContext _departmentDbContext;
        public DepartmentDataManager(DepartmentDbContext departmentDbContext)
        {
            _departmentDbContext = departmentDbContext;
        }

        public void AddDepartment(Department entity)
        {
            _departmentDbContext.Add(entity);
            _departmentDbContext.SaveChanges();
            
            
        }

        public void DeleteDepartmentById(int id)
        {
            var obj = _departmentDbContext.Departments.FirstOrDefault(x=>x.Dep_Id==id);
            if (obj != null) 
            {
                _departmentDbContext.Remove(obj);
                _departmentDbContext.SaveChanges();
            }
           
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            var list = _departmentDbContext.Departments.ToList();
            return list; 
           
        }

        public Department GetDepartmentById(int id)
        {
            var obj = _departmentDbContext.Departments.FirstOrDefault(x => x.Dep_Id == id);
            return obj; 
           
        }
            

       
    }
}
