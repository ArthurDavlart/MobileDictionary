using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DictionaryServer.Controllers
{
    public class AutorisationController : Controller
    {
        private static string _login = "Arthur";
        private static string _password = "12345";
        public bool Check(string login, string password)
        {
            return _login == login && _password == password;
        }
    }
}
