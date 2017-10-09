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
        private readonly ISysRoleService _roleService;

        public TestController(IAccountService accountService, ISysRoleService roleService)
        {
            this._accountService = accountService;
            this._roleService = roleService;
        }

        public IActionResult Test1()
        {
            var count = _roleService.GetCount();
            return Content(count.ToString());
        }

        public IActionResult Test2()
        {
            var count = _roleService.GetCountBySql("select * from SysRole");
            return Content(count.ToString());
        }
    }
}