using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTablesInDataGrid
{
    public class ViewModel
    {
        public List<string> Columns { get; set; } = new List<string>()
        {
            "Spalte 1",
            "Spalte 2",
            "Spalte 3",
        };

    }
}
