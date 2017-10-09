namespace MG.Service.Interface
{
    public interface ISysRoleService
    {
        int GetCount();

        int GetCountBySql(string sql);
    }
}