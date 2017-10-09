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
    public class SysRoleService: ISysRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IBaseRepository<SysRole> _roleRepository;

        public SysRoleService(IUnitOfWork unitOfWork, IBaseRepository<SysRole> roleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._roleRepository = roleRepository;
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
    }
}
