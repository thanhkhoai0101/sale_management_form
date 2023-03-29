using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BEL;
namespace BAL
{
    public class BAL_Category
    {
        public DataTable showListCategory()
        {
            DAL_Category category = new DAL_Category();
            return category.showListCategory();
        }

        public string createCategory(Category category)
        {
            DAL_Category _Category = new DAL_Category();
            return _Category.createCategory(category);
        }

        public string updateCategory(Category category)
        {
            DAL_Category _Category = new DAL_Category();
            return _Category.updateCategory(category);
        }
        public bool deleteCategory(int id)
        {
            DAL_Category _Category = new DAL_Category();
            return _Category.deleteCategory(id);
        }
        public DataTable searchCategory(string name)
        {
            DAL_Category _Category = new DAL_Category();
            return _Category.searchCategory(name);
        }
    }
}
