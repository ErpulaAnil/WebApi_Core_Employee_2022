using Categories_MvcCore_With_BusinessLayer_6._0.Models;

namespace Categories_MvcCore_With_BusinessLayer_6._0.BussinesLayer.Catergories
{
    public interface ICatergory
    {
        IEnumerable<Categories> GetData();

        bool InsertData(Categories category);

        bool DeleteData(int id);

        IEnumerable<Categories> UpdateData(Categories category);

        Categories GetDataById(int id);
    }
}
