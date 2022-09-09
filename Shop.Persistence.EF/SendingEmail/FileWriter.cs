using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.SendingEmail
{
    public static class FileWriter
    {
        private static  string REGISTRATION_PATH = @"E:\Programowanie\Projekty\Shop\Shop.Persistence.EF\Email\Registration.txt";
        public static async Task<string> WriteFile(string password, string nickName)
        {
            var text = await File.ReadAllTextAsync(REGISTRATION_PATH);
            var newText = text.Replace("{name}", nickName);
            newText = newText.Replace("{password}", password);
            return newText;
        }
    }
}
