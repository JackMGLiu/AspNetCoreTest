using System.Linq;
using MG.Entity;
using MG.Infrastructure.Repositories;
using MG.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MG.Service.Impl
{
    public class AccountService:IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IBaseRepository<Account> _accountRepository;

        public AccountService(IUnitOfWork unitOfWork, IBaseRepository<Account> accountRepository)
        {
            this._unitOfWork = unitOfWork;
            this._accountRepository = accountRepository;
        }

        public int GetCount()
        {
            return _accountRepository.LoadAll(a => true).Count();
        }

        public int GetCountBySql(string sql)
        {
            int count = _unitOfWork.FromSql<Account>(sql).Count();
            return count;
        }
    }
}