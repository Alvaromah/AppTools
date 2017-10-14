using System;
using System.Linq;
using System.Collections.Generic;

namespace Win32Tools
{
    static public class SampleJsonDb
    {
        static public void Run()
        {
            using (var db = new CatalogDb())
            {
                db.Id = 1234;
                db.Name = "Catalog";
                db.DateTime = DateTime.Now;

                db.ProductTypes.Add("Type 1");
                db.ProductTypes.Add("Type 2");
                db.ProductTypes.Add("Type 3");

                db.ProductItems.Add(new ProductItem { Id = 1, Name = "Product 1" });
                db.ProductItems.Add(new ProductItem { Id = 2, Name = "Product 2" });
                db.ProductItems.Add(new ProductItem { Id = 3, Name = "Product 3" });

                db.SaveChanges();
            }

            using (var db = new CatalogDb())
            {
                var productType = db.ProductItems.Where(r => r.Id == 2).FirstOrDefault();
                if (productType != null)
                {
                    db.ProductItems.Remove(productType);
                }
                db.SaveChanges();
            }

            using (var db = new CatalogDb())
            {
                Console.WriteLine(db.Id);
                Console.WriteLine(db.Name);
                Console.WriteLine(db.DateTime);

                foreach (var item in db.ProductTypes)
                {
                    Console.WriteLine(item);
                }

                foreach (var item in db.ProductItems)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

    public class CatalogDb : JsonDb
    {
        public CatalogDb() : base("..\\..\\CatalogDb.json")
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public List<string> ProductTypes { get; set; }
        public List<ProductItem> ProductItems { get; set; }
    }

    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"[{Id}, {Name}]";
        }
    }
}
