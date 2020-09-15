using Assessment_Test.BAL.Interface;
using Assessment_Test.DAL.Implementation;
using Assessment_Test.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Test.BAL.Implementation
{
    public class ComboPromotion : IPromotion
    {
        // Created singletone object
        private IItemDAL _itemDAL = ItemHardCodedDAL.getInstance();

        /// <summary>
        /// Check And Apply Promotion offer to item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="itemsConsidered"></param>
        /// <returns></returns>
        public decimal CheckAndApplyPromotion(IItem item, List<IItem> items, List<int> itemsConsidered)
        {
            decimal result = 0.0m;
            var activePromotionRules = _itemDAL.GetActivePromotionRules();
            var currRule = activePromotionRules.FirstOrDefault(rule => rule.ItemId == item.ID);

            var currItem = _itemDAL.GetItemMasters().FirstOrDefault(i => i.Id == item.ID);
            if (currRule != null)
            {
                itemsConsidered.Add(item.ID);
                return calculateCombo(item.Qty, int.Parse(currRule.Param1), Convert.ToDecimal(currRule.Param2), currItem.UnitPrice);
            }
            else
            {
                result = item.Qty * currItem.UnitPrice;
                itemsConsidered.Add(item.ID);
            }

            return result;
        }

        /// <summary>
        /// Calculating combo offer
        /// </summary>
        /// <param name="Qty"></param>
        /// <param name="ComboQty"></param>
        /// <param name="ComboPrice"></param>
        /// <param name="UnitPrice"></param>
        /// <returns></returns>
        private decimal calculateCombo(int Qty, int ComboQty, decimal ComboPrice, decimal UnitPrice)
        {
            return Convert.ToDecimal((Qty / ComboQty) * ComboPrice) + Convert.ToDecimal(Qty % ComboQty) * UnitPrice;
        }

    }
}
