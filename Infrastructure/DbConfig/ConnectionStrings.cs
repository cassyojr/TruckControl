using Infrastructure.Interfaces.DbConfig;

namespace Infrastructure.DbConfig
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string SqlServer { get; set; }
    }
}
