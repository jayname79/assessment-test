using System;
using System.Collections.Generic;
using System.Linq;

#region Project reference
using Assessment_Test.BAL.Interface;
using Assessment_Test.DAL.DBEntites;
using Assessment_Test.DAL.Implementation;
using Assessment_Test.Common;
using Assessment_Test.DAL.Interface;
#endregion

namespace Assessment_Test.BAL.Implementation
{
    /// <summary>
    /// Promotion class
    /// </summary>
    public class Promotion : IPromotion
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
        public decimal CheckAndApplyPromotion(IItem item, List<IItem> items,List<int> itemsConsidered)
        {
            decimal result=0.0m;
            var activePromotionRules = _itemDAL.GetActivePromotionRules();
            var currRule = activePromotionRules.FirstOrDefault(rule => rule.ItemId == item.ID);

            var currItem = _itemDAL.GetItemMasters().FirstOrDefault(i => i.Id == item.ID);
            if (currRule != null)
            {
                switch (currRule.PromotionRuleTypeId)
                {
                    case EnumPromotionRuleType.Comb:
                        itemsConsidered.Add(item.ID);
                        return calculateCombo(item.Qty, int.Parse(currRule.Param1), Convert.ToDecimal(currRule.Param2), currItem.UnitPrice);

                    case EnumPromotionRuleType.OnePlusOne:
                        var dependentItem = items.FirstOrDefault(i => i.ID == int.Parse(currRule.Param1));
                        itemsConsidered.Add(item.ID);
                        itemsConsidered.Add(int.Parse(currRule.Param1));
                        var Items = _itemDAL.GetItemMasters().Where(x => x.Id == item.ID || x.Id == int.Parse(currRule.Param1)).ToList();
                        return calculateOnePluOne(item, dependentItem, int.Parse(currRule.Param2), Items);

                    default:
                        break;
                }
            }
            else
            {
                result = item.Qty * currItem.UnitPrice;
                itemsConsidered.Add(item.ID);
            }

            return result;
        }

       
    }
}
