namespace MG.Service.Interface
{
    public interface IAccountService
    {
        int GetCount();

        int GetCountBySql(string sql);
    }
}