using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.SendingEmail
{
    public class MessageParams
    {
        public MessageParams(string email, string subcject, string name, string text)
        {
            Email = email;
            Subcject = subcject;
            Name = name;
            Text = text;
        }

        public string Email { get; set; }
        public string Subcject { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
