using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MG.App.Controllers
{
    public class TestController : Controller
    {
        private readonly IAccountService _accountService;

        public TestController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        public IActionResult Test1()
        {
            var count = _accountService.GetCount();
            return Content(count.ToString());
        }

        public IActionResult Test2()
        {
            var count = _accountService.GetCountBySql("select * from Account");
            return Content(count.ToString());
        }
    }
}