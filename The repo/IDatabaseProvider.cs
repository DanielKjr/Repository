using System.Data;

namespace Repository
{
    /// <summary>
    /// Defines what the provider needs
    /// </summary>
    public interface IDatabaseProvider
    {
        IDbConnection CreateConnection();
    }
}
