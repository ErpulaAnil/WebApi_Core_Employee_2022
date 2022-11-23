using Categories_MvcCore_With_BusinessLayer_6._0.Data;
using Categories_MvcCore_With_BusinessLayer_6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Categories_MvcCore_With_BusinessLayer_6._0.CategoryRepoSitory
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryService:ICategoryService
    {
        public readonly ApplicationDbContext _applicationtionDbcontext;

        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            _applicationtionDbcontext = applicationDbContext;
        }

       [HttpGet]
        public IEnumerable<Categories> GetData()
        {
            return _applicationtionDbcontext.CategoryTable;
        }

       [HttpGet,Route("Id")]
        public Categories GetDataById(int id)
        {
            Categories data = _applicationtionDbcontext.CategoryTable.Find(id);
            return data;
        }

        [HttpPost]
        public bool InsertData(Categories category)
        {
            var data = _applicationtionDbcontext.CategoryTable.Add(category);
            _applicationtionDbcontext.SaveChanges();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       [HttpDelete]
        public bool DeleteData(int id)
        {
            var data = _applicationtionDbcontext.CategoryTable.Find(id);
            _applicationtionDbcontext.Remove(data);
            _applicationtionDbcontext.SaveChanges();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut]
        public IEnumerable<Categories> UpdateData(Categories category)
        {
            //var data = _applicationtionDbcontext.Category.Find(category.Id);
            _applicationtionDbcontext.CategoryTable.Update(category);
            _applicationtionDbcontext.SaveChanges();
            return _applicationtionDbcontext.CategoryTable;
        }
    }
}
