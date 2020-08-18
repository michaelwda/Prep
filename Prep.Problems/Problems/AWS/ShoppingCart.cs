using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prep.Problems.Problems.AWS
{
    public class ShoppingCart
    {
        public int Solve(List<List<string>> codeList, List<string> shoppingCart)
        {
            if (codeList == null || !codeList.Any() || (codeList.Count == 1 && !codeList[0].Any()))
                return 1;

            var groupPosition = 0;
            var itemPosition = 0;
            for (var itemIndex = 0; itemIndex < shoppingCart.Count; itemIndex++)
            {
                var item = shoppingCart[itemIndex];
                if (codeList[groupPosition][itemPosition] == item)
                {
                    itemPosition++;
                }
                else if (codeList[groupPosition][itemPosition] == "anything") 
                {
                    if (itemPosition == 0)
                    {
                        //we've matched this forever now
                        codeList[groupPosition].RemoveAt(0);
                    }
                    else
                    {
                        itemPosition++;
                    }
                }
                else
                {
                    //failure, reset
                    itemPosition = 0;
                }

                if (itemPosition >= codeList[groupPosition].Count)
                {
                    groupPosition++;
                    itemPosition = 0;
                }

                if (groupPosition >= codeList.Count)
                {
                    return 1;
                }
            }


            return 0;
        }
    }
}
