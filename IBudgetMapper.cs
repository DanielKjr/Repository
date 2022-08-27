using System.Collections.Generic;
using System.Data.SQLite;

namespace Repository
{
    /// <summary>
    /// Defines what the BudgetMapper needs
    /// </summary>
    public interface IBudgetMapper
    {
        List<BudgetEntry> MapExpensesFromReader(SQLiteDataReader reader);
    }
}
