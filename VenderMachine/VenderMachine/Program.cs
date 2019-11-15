using System;

namespace VenderMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();

            Drink drink = vm.Buy(500, Drink.COKE);
            int charge = vm.Refund();

            if (drink != null && drink.GetKind() == Drink.COKE)
            {
                Console.WriteLine("コーラを購入しました。");
                Console.WriteLine("お釣りは" + charge + "円です。");
            }
            else
            {
                throw new Exception("コーラを買えませんでした。");
            }
        }
    }
}
