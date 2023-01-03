namespace BAL.Interface
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllDepartment();  

        TEntity GetDepartmentById(int id);  
        
        void DeleteDepartmentById(int id);

        void AddDepartment(TEntity entity);

        


       

    }
}