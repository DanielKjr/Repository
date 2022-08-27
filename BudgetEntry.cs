using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Class for managing bank entries, cosists of:
    /// <para>int ID</para>
    /// <para>string Name</para>
    /// <para>double Cost</para>
    /// <para>ExpenseType(Enum) Type</para>
    /// </summary>
    public class BudgetEntry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public ExpenseType Type { get; set; }

    }
}
