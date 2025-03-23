using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    internal class ThePlay : IDisposable
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public void Dispose()
        {
            Console.WriteLine($"The end of {Name}");
        }

        ~ThePlay()
        {
            Dispose();
        }
    }
}
