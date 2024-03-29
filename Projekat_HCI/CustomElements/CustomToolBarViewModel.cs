using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.CustomElements
{
    class CustomToolBarViewModel
    {
        public static List<double> FontSizeList { get; set; } = Enumerable.Range(12, 48).Select(i => (double)i).ToList();

        public CustomToolBarViewModel()
        {
          
        }
    }
}
