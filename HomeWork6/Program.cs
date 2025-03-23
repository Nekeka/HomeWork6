namespace HomeWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // play test
            using (ThePlay Hamlet = new("Hamlet", "William Shakespeare", 1600, "Tragedy"));

            // store test

            using (Shop Rozetka = new("Rozetra", "mall Fontan Sky", TypeOfShop.Goods)) ;
        }
    }
}
