using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProductManagementSystem
{
    public class Product : IProduct
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CategoryCode { get; set; }
        public static int ProductCount { get; set; }

        public List<Product> products = new List<Product>();

        ProductOnDiscount productOnDiscountObj;
        ProductOnSale productOnSaleObj;
        public Product() 
        {
            ProductOnDiscount productOnDiscountObj= new ProductOnDiscount();
            ProductOnSale productOnSaleObj = new ProductOnSale();
            ProductCount++;
        }

        public void AddProduct()
        {
            Product product = new Product();            
            Console.WriteLine("Enter product code");
            product.ProductCode =  Console.ReadLine();
            Console.WriteLine("Enter product name");
            product.ProductName = Console.ReadLine();
            Console.WriteLine("Enter Category Code");
            product.CategoryCode = Console.ReadLine();          
            
            products.Add(product);
            
            return;
        }

        public void RemoveProduct(string code)
        {
            foreach (Product product in products) 
            { 
                if(product.ProductCode.Equals(code))
                {
                    products.Remove(product);
                    Console.WriteLine("Product removed successfully");
                }
                return;
            }
            Console.WriteLine("enter valid product code");
            return;
        }

        public void Print()
        {
            foreach (var item in products)
            {
                Console.WriteLine("{0} {1} {2}", item.ProductCode, item.ProductName, item.CategoryCode);
            }
            return;
        }

        public void ModifyProduct(string code)
        {
            foreach(Product product in products)
            {
                if(product.ProductCode.Equals(code))
                {
                    Console.WriteLine("Enter new name");
                    product.ProductName = Console.ReadLine();
                    Console.WriteLine("Enter new category code");
                    product.CategoryCode = Console.ReadLine();
                    Console.WriteLine("Details modified successfully");
                    return;
                }
            }
            Console.WriteLine("Enter valid credentials");
            return;

        }

        public string GetProductCode(string PName)
        {
            foreach (var item in products)
            {
                if(item.ProductName==PName)
                {
                    return item.ProductCode;
                }
            }
            Console.WriteLine("Enter valid product name");
            return null;
        }
        public List<string> GetAllProductCodes() 
        {
            List<string> codes = new List<string>();
            foreach(var item in products)
            {
                codes.Add(item.ProductCode);
            }
            return codes;
        }
        public string GetProductDesc(string PCode) 
        {
            foreach (var item in products) 
            {
                if(item.ProductCode.Equals(PCode))
                {
                    return item.ProductName;
                }
            }
            Console.WriteLine("Enter proper credentials");
            return null;
        }
        public string GetCategoryCode(string pCode) 
        {
            foreach (var item in products)
            {
                if (item.ProductCode.Equals(pCode))
                {
                    return item.CategoryCode;
                }
            }
            Console.WriteLine("Enter proper credentials");
            return null;
        }

        public void MoveAProduct(string PCode)
        {
            foreach (Product product in products) 
            {
                if(product.ProductCode.Equals(PCode))
                {
                    Console.WriteLine("Enter Discount Percentage");
                    product.productOnDiscountObj.DiscountPercentage = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter min pick quantity");
                    product.productOnDiscountObj.MinimumPickQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter quantity on sale");
                    product.productOnSaleObj.QuantityOnSale = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Product moved successfully");
                    return;
                }
            }
            Console.WriteLine("Enter proper credentials");
            return ;
        }

        public double GetDiscountPercent(string pCode) 
        {
            foreach (Product product in products)
            {
                if (product.ProductCode.Equals(pCode))
                {
                    return product.productOnDiscountObj.DiscountPercentage;
                }
            }
            Console.WriteLine("Enter proper credentials");
            return 0;
        }

        public float GetQuantityOnSale(string pCode) 
        {
            foreach (Product product in products)
            {
                if (product.ProductCode.Equals(pCode))
                {
                    return product.productOnSaleObj.QuantityOnSale;
                }
            }
            Console.WriteLine("Enter proper credentials");
            return 0;
        }
    }
}
