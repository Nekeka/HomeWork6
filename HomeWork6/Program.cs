namespace HomeWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Used Memory: {GC.GetTotalMemory(false)} bytes");
            // store test


            using Shop Rozetka = new("Rozetka", "Fontan Sky", TypeOfShop.Goods);
            
            // play test
            using (ThePlay Hamlet = new("Hamlet", "William Shakespeare", 1600, "Tragedy"))
            {
                ;
            }

            Rozetka.StartShoping();
            Console.WriteLine($"Used Memory: {GC.GetTotalMemory(false)} bytes");
        }
    }
}
