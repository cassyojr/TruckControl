namespace Infrastructure.Context
{
    public interface IApplicationContext
    {
        void CreateDatabaseOnStart();
    }
}
