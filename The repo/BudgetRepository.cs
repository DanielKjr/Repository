using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly IDatabaseProvider provider;
        private readonly IBudgetMapper mapper;
        private  IDbConnection connection;

        public BudgetRepository(IDatabaseProvider provider, IBudgetMapper mapper)
        {
            this.provider = provider;
            this.mapper = mapper;

        }

        /// <summary>
        /// Creates table used for Expense entries if the table doesn't exist.
        /// </summary>
        private void CreateDBTable()
        {
            var cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS Expenses (Id INTEGER PRIMARY KEY, Name STRING, Cost REAL, Type INTEGER);", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();

        }

        /// <inheritdoc/>
        public void AddExpense(string name, double cost, ExpenseType expenseType)
        {
            var cmd = new SQLiteCommand($"INSERT INTO Expenses (Id, Name, Cost, Type) VALUES (null, '{name}', {cost}, {(int)expenseType})", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();
        }


        /// <inheritdoc/>
        public BudgetEntry FindEntry(string name)
        {
            var cmd = new SQLiteCommand($"SELECT * FROM Expenses WHERE Name='{name}'", (SQLiteConnection)connection);
            var reader = cmd.ExecuteReader();

            var result = mapper.MapExpensesFromReader(reader).First();

            return result;
        }

        /// <inheritdoc/>
        public List<BudgetEntry> GetAllEntries()
        {
            var cmd = new SQLiteCommand("SELECT * FROM Expenses", (SQLiteConnection)connection);
            var reader = cmd.ExecuteReader();

            var result = mapper.MapExpensesFromReader(reader);

            return result;
        }

        /// <inheritdoc/>
        public List<BudgetEntry> GetMonthlyEntries()
        {
            var cmd = new SQLiteCommand($"SELECT * FROM Expenses WHERE Type={(int)ExpenseType.Monthly}", (SQLiteConnection)connection);
            var reader = cmd.ExecuteReader();

            var result = mapper.MapExpensesFromReader(reader);

            return result;
        }

        /// <inheritdoc/>
        public List<BudgetEntry> GetQuarterlyEntries()
        {
            var cmd = new SQLiteCommand($"SELECT * FROM Expenses WHERE Type={(int)ExpenseType.Quarterly}", (SQLiteConnection)connection);
            var reader = cmd.ExecuteReader();

            var result = mapper.MapExpensesFromReader(reader);

            return result;
        }

        /// <inheritdoc/>
        public List<BudgetEntry> GetYearlyEntries()
        {
            var cmd = new SQLiteCommand($"SELECT * FROM Expenses WHERE Type={(int)ExpenseType.Yearly}", (SQLiteConnection)connection);
            var reader = cmd.ExecuteReader();

            var result = mapper.MapExpensesFromReader(reader);

            return result;
        }

        /// <inheritdoc/>
        public void Open()
        {
            
            if (connection == null)
            {
                connection = provider.CreateConnection();
            }
            connection.Open();
            CreateDBTable();


        }

        /// <inheritdoc/>
        public void Close()
        {
            connection.Close();
        }
    }
}
