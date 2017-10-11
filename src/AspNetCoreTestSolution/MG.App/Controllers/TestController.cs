using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Entity;
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

        public IActionResult Test3()
        {
            SysRole role = new SysRole
            {
                RoleName = "测试角色123",
                EnCode = "role123",
                Type = 1,
                CreateUser = "admin"
            };
            var res = _roleService.AddRole(role);
            return Content(res.ToString());
        }

        public IActionResult Test4()
        {
            var res = _roleService.GetRole(10);
            
            return Json(res);
        }

        public IActionResult Test5()
        {
            var res = _roleService.Update(10);

            return Json(res);
        }
    }
}