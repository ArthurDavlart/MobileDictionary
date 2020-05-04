using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryMvcServer.Controllers
{ 
    public class AutorisationController : Controller
    {        
        public bool Check(int password)
        {
            return true;
        }
    }
}