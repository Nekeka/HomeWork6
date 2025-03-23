
using ShopGenericsExmpale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    internal class Shop : IDisposable
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public TypeOfShop Type { get; set; }

        private bool disposed = false;

        public Shop(string name, string adress, TypeOfShop type)
        {
            Name = name;
            Adress = adress;
            Type = type;
          
            Console.WriteLine($"The {Name} on {Adress} has open!");
        }
        public void StartShoping()
        {
            Console.WriteLine($"Start shoping!");
        }
        public void Dispose()
        {
            //CloseShop();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void CloseShop()
        {
            Console.WriteLine($"The {Name} on {Adress} has closed.");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                CloseShop();
            }
            disposed = true;
        }

        ~Shop()
        {
            Dispose(false);
        }

    }


    public enum TypeOfShop
    {
        Grocery = 0,
        Household,
        Goods,
        Clothing,
        Footwear
    }
}
