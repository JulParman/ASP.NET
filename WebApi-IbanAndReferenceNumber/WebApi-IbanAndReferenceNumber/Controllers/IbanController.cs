using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_IbanAndReferenceNumber.Controllers
{
    public class IbanController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Check(string ibanNumber)
        {
            var iban = new WebApi_IbanAndReferenceNumber.Models.Iban();
            var result = iban.CheckIbanValidation(ibanNumber);
            return View("Index", result);
        }
    }
}
