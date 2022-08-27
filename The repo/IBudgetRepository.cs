using System.Collections.Generic;

namespace Repository
{
    /// <summary>
    /// Contract of what the repository have to be able to do.
    /// </summary>
    public interface IBudgetRepository
    {
        /// <summary>
        /// Adds expense to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="expenseType"></param>
        void AddExpense(string name, double cost, ExpenseType expenseType);

        /// <summary>
        /// Returns an entry from the database matching the name specified.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        BudgetEntry FindEntry(string name);

        /// <summary>
        /// Returns all entries in the database.
        /// </summary>
        /// <returns></returns>
        List<BudgetEntry> GetAllEntries();

        /// <summary>
        /// Returns all monthly entries from database.
        /// </summary>
        /// <returns></returns>
        List<BudgetEntry> GetMonthlyEntries();

        /// <summary>
        /// Returns all quarterly entries from database.
        /// </summary>
        /// <returns></returns>
        List<BudgetEntry> GetQuarterlyEntries();

        /// <summary>
        /// Returns all yearly expenses from database.
        /// </summary>
        /// <returns></returns>
        List<BudgetEntry> GetYearlyEntries();
     
        /// <summary>
        /// Opens connection to database.
        /// </summary>
        void Open();

        /// <summary>
        /// Closes connection to database.
        /// </summary>
        void Close();
    }
}
