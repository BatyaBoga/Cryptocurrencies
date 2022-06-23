using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.Models
{
    class DataArr<T>
    {
        public T[]? data { get; set; }
        public decimal timestamp { get; set; }
    }
}
