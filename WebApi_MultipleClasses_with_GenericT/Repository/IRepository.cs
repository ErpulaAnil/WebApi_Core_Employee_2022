using WebApi_MultipleClasses_with_GenericT.Models;

namespace WebApi_MultipleClasses_with_GenericT.Repository
{
    public interface IRepository<TModel> where TModel : class
    {
        void AddData(TModel employee);
        IEnumerable<TModel> GetAll();
        TModel GetById(int id);
        TModel UpdateData(TModel employee); 
        bool DeleteData(int id); 

    }
}
