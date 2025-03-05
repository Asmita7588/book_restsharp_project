using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRestSharp
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public bool available { get; set; }
    }
}
