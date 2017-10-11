using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MG.Entity;
using MG.Infrastructure.Repositories;
using MG.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MG.Service.Impl
{
    public class SysRoleService : ISysRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IBaseRepository<SysRole> _roleRepository;

        private readonly IRepository<SysRole> _uroleRepository;

        public SysRoleService(IUnitOfWork unitOfWork, IBaseRepository<SysRole> roleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._roleRepository = roleRepository;
            _uroleRepository = _unitOfWork.GetRepository<SysRole>();
        }

        public int GetCount()
        {
            return _roleRepository.LoadAll(a => true).Count();
        }

        public int GetCountBySql(string sql)
        {
            int count = _unitOfWork.FromSql<SysRole>(sql).Count();
            return count;
        }

        public int AddRole(SysRole model)
        {
            model.GuidId = Guid.NewGuid().ToString("N");
            _unitOfWork.GetRepository<SysRole>().Insert(model);
            _unitOfWork.SaveChanges();
            //_roleRepository.Save(model);
            return model.Id;
            //var res =_unitOfWork.SaveChanges();
            //return res;
        }

        public SysRole GetRole(int key)
        {
            var model = _uroleRepository.Find(key);
            return model;
        }

        public bool Update(int key)
        {
            //var model = _uroleRepository.Find(key);
            //model.RoleName = "修改了rolename";
            //bool res = _unitOfWork.SaveChanges() > 0;
            //return res;

            var model = _uroleRepository.Find(key);
            model.RoleName = "修改了rolename112233";
            model.ModifyTime=DateTime.Now;
            model.ModifyUser = "admin";
            _uroleRepository.Update(model);
            bool res = _unitOfWork.SaveChanges() > 0;
            return res;
        }
    }
}
