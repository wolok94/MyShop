using Shop.Application.Functions.Products.GetProductsList;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.SendingEmail
{
    public static class FileReader
    {
        private static  string REGISTRATION_PATH = @"E:\Programowanie\Projekty\Shop\Shop.Persistence.EF\Email\Registration.txt";
        private static string ORDER_PATH = @"E:\Programowanie\Projekty\Shop\Shop.Persistence.EF\Email\Order.txt";
        public static async Task<string> ReadRegistrationFile(string password, string nickName)
        {
            var text = await File.ReadAllTextAsync(REGISTRATION_PATH);
            var newText = text.Replace("{name}", nickName);
            newText = newText.Replace("{password}", password);
            return newText;
        }
        public static async Task<string> ReadOrderFile(string nickName, List<Product> products, double price)
        {
            var text = await File.ReadAllTextAsync(ORDER_PATH);
            var newText = text.Replace("{name}", nickName);
            newText = newText.Replace("{products}", GetProducts(products));
            newText = newText.Replace("{price}", price.ToString());
            return newText;
        }
        private static string GetProducts(List<Product> products)
        {
            var productsDescription = new StringBuilder();
            foreach(var product in products)
            {
                productsDescription.Append(product.Title + " ");
                productsDescription.Append(product.Price + " ");
            }
            return productsDescription.ToString();
        }
    }
}
