using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Product
    {
        private int id;
        private string name;
        private int salePrice;
        private int stockQuantity;
        private int categoryID;
        private string type;
        private string image;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int SalePrice { get => salePrice; set => salePrice = value; }
        public int StockQuantity { get => stockQuantity; set => stockQuantity = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string Type { get => type; set => type = value; }
        public string Image { get => image; set => image = value; }

        public Product()
        {
            this.name = null;
            this.salePrice = 0;
            this.stockQuantity = 0;
            this.categoryID = 0;
            this.type = null;
            this.image = null;
        }
        public Product(string name,int salePrice, int stockQuantity, int categoryID, string type, string image)
        {
            this.name = name;
            this.salePrice = salePrice;
            this.stockQuantity = stockQuantity;
            this.categoryID = categoryID;
            this.type = type;
            this.image = image;
        }

    }
}
