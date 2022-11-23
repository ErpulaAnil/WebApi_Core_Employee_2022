using WebApi_MultipleClasses_with_GenericT.Data;
using WebApi_MultipleClasses_with_GenericT.Models;

namespace WebApi_MultipleClasses_with_GenericT.Repository
{
    public class RepositoryService<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly ApplicationDbContext _applicationDbContext;   

        public RepositoryService(ApplicationDbContext applicationDbContext )
        {
            _applicationDbContext=applicationDbContext; 
        }
        public void AddData(TModel employee)
        {
            _applicationDbContext.Set<TModel>().Add(employee);
            _applicationDbContext.SaveChanges();
        }

        public bool DeleteData(int id)
        {
            var emp=_applicationDbContext.Set<TModel>().Find(id);
            if (emp is null) return false; 
                _applicationDbContext.Set<TModel>().Remove(emp);
            _applicationDbContext.SaveChanges();
             return true;  

        }

        public IEnumerable<TModel> GetAll()
        {
           return  _applicationDbContext.Set<TModel>();
        }

        public TModel GetById(int id)
        {
            var emp=_applicationDbContext.Set<TModel>().Find(id);
            return emp;
        }

        public TModel UpdateData(TModel newemployee)
        {

            var abc = _applicationDbContext.Set<TModel>().Update(newemployee).Entity;
            _applicationDbContext.SaveChanges();
            return abc;

        }
    }
}
