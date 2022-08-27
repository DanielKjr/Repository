using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Reads from SQLite database
    /// </summary>
    public class BudgetMapper : IBudgetMapper
    {
        public List<BudgetEntry> MapExpensesFromReader(SQLiteDataReader reader)
        {
            var result = new List<BudgetEntry>();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var cost = reader.GetDouble(2);
                var type = reader.GetInt32(3);

                result.Add(new BudgetEntry() { ID = id, Name = name, Cost = cost, Type = (ExpenseType)type});

            }


            return result;
        }
    }
}
