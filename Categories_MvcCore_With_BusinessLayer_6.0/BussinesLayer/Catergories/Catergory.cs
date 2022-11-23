using Categories_MvcCore_With_BusinessLayer_6._0.CategoryRepoSitory;
using Categories_MvcCore_With_BusinessLayer_6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Categories_MvcCore_With_BusinessLayer_6._0.BussinesLayer.Catergories
{
    
    public class Catergory:ICatergory
    {
        private readonly ICategoryService _categoryService;

        public Catergory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<Categories> GetData()
        {
            return _categoryService.GetData();
        }

     
        public Categories GetDataById(int id)
        {
            return _categoryService.GetDataById(id);
        }

        public bool InsertData(Categories category)
        {
            if (_categoryService.InsertData(category))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteData(int id)
        {
            if (_categoryService.DeleteData(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public IEnumerable<Categories> UpdateData(Categories category)
        {
            return _categoryService.UpdateData(category);
        }
    }
}
