using MG.Entity;

namespace MG.Service.Interface
{
    public interface ISysRoleService
    {
        int AddRole(SysRole model);

        int GetCount();

        int GetCountBySql(string sql);

        SysRole GetRole(int key);

        bool Update(int key);
    }
}