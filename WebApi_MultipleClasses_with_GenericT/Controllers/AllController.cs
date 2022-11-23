using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_MultipleClasses_with_GenericT.Models;
using WebApi_MultipleClasses_with_GenericT.Repository;

namespace WebApi_MultipleClasses_with_GenericT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllController<TModel, TRepository> : ControllerBase where TModel : class where TRepository:IRepository<TModel>
    {
        private readonly TRepository _repository;

        public AllController(TRepository repository)
        {
            _repository=repository;  
        }

        [HttpGet,Route("GetAllData")]
        public IEnumerable<TModel> GetAllDeatils()
        {
        return  _repository.GetAll();
        }

        [HttpPost, Route("Insert")]
        public IActionResult DataAdd(TModel employee)
        {
          _repository.AddData(employee);
            return Ok("Data is Added succsfully");
        }
        [HttpGet,Route("id")]
        public IActionResult GetDetails(int id)
        {
           var emp= _repository.GetById(id);
            if(emp is null) return NotFound("No Data");  
            return Ok(emp);
        }

        [HttpDelete, Route("Delete")]
        public IActionResult DeleteData(int id)
        {
          if(_repository.DeleteData(id))
            {
                return Ok("Succsfully Deleted");
            }

            return Ok("No Data");

        }
        [HttpPut, Route("Update")]
        public IActionResult Update(TModel employee)
        {
           var emp= _repository.UpdateData(employee);
            return Ok(emp);

        }

    }
}
