using System;
using System.Collections.Generic;
using System.Text;

namespace VenderMachine
{
    public class VendingMachine
    {
        int quantityOfCoke = 5;
        int quantityOfDietCoke = 5;
        int quantityOfTea = 5;
        int numberOf100Yen = 10;
        int charge = 0;

        /// <summary>
        /// ジュースを購入する
        /// </summary>
        /// <param name="i">投入金額</param>
        /// <param name="kindOfDrink">ジュースの種類</param>
        /// <returns>指定したジュース</returns>
        public Drink Buy(int i, int kindOfDrink)
        {
            
            // 100円と500円だけ受け付ける
            if ((i != 100) && (i != 500))
            {
                charge += i;
                return null;
            }

            if ((kindOfDrink == Drink.COKE) && (quantityOfCoke == 0))
            {
                charge += i;
                return null;
            }
            else if ((kindOfDrink == Drink.DIET_COKE) && (quantityOfDietCoke == 0))
            {
                charge += i;
                return null;
            }
            else if ((kindOfDrink == Drink.TEA) && (quantityOfTea == 0))
            {
                charge += i;
                return null;

            }

            // 釣銭不足
            if (i == 500 && numberOf100Yen < 4)
            {
                charge += i;
                return null;

            }

            if (i == 100)
            {
                // 100円玉を釣銭に使える
                numberOf100Yen++;
            }
            else if (i == 500)
            {
                // 400円のお釣り
                charge += (i - 100);
                // 100円玉を釣銭に使える
                numberOf100Yen -= (i - 100) / 100;
            }

            if (kindOfDrink == Drink.COKE)
            {
                quantityOfCoke--;
            }
            else if (kindOfDrink == Drink.DIET_COKE)
            {
                quantityOfDietCoke--;
            }
            else
            {
                quantityOfTea--;
            }

            return new Drink(kindOfDrink);
        }

        /// <summary>
        /// お釣りを出す
        /// </summary>
        /// <returns>お釣りの金額</returns>
        public int Refund()
        {
            int result = charge;
            charge = 0;
            return result;
        }
    }
}
