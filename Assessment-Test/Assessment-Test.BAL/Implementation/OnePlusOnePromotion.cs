using Assessment_Test.BAL.Interface;
using Assessment_Test.DAL.DBEntites;
using Assessment_Test.DAL.Implementation;
using Assessment_Test.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Test.BAL.Implementation
{
    public class OnePlusOnePromotion : IPromotion
    {
        // Created singletone object
        private IItemDAL _itemDAL = ItemHardCodedDAL.getInstance();

        public decimal CheckAndApplyPromotion(IItem item, List<IItem> items, List<int> itemsConsidered)
        {
            decimal result = 0.0m;
            var activePromotionRules = _itemDAL.GetActivePromotionRules();
            var currRule = activePromotionRules.FirstOrDefault(rule => rule.ItemId == item.ID);

            var currItem = _itemDAL.GetItemMasters().FirstOrDefault(i => i.Id == item.ID);
            if (currRule != null)
            {
                var dependentItem = items.FirstOrDefault(i => i.ID == int.Parse(currRule.Param1));
                itemsConsidered.Add(item.ID);
                itemsConsidered.Add(int.Parse(currRule.Param1));
                var Items = _itemDAL.GetItemMasters().Where(x => x.Id == item.ID || x.Id == int.Parse(currRule.Param1)).ToList();
                return calculateOnePluOne(item, dependentItem, int.Parse(currRule.Param2), Items);

            }
            else
            {
                result = item.Qty * currItem.UnitPrice;
                itemsConsidered.Add(item.ID);
            }

            return result;
        }


        /// <summary>
        /// Calculation one plus pne offer
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="dependentItem"></param>
        /// <param name="onePlusOnePrice"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private decimal calculateOnePluOne(IItem itemId, IItem dependentItem, decimal onePlusOnePrice, List<ItemMaster> items)
        {
            if (dependentItem == null)
            {
                var uPrice = items.FirstOrDefault(up => up.Id == itemId.ID)?.UnitPrice ?? 0;
                return itemId.Qty * uPrice;
            }
            else if (itemId.Qty == dependentItem.Qty)
            {
                return itemId.Qty * onePlusOnePrice;
            }
            else if (itemId.Qty > dependentItem.Qty)
            {
                var uPrice = items.FirstOrDefault(up => up.Id == itemId.ID)?.UnitPrice ?? 0;
                return ((itemId.Qty - dependentItem.Qty) * uPrice) + dependentItem.Qty * onePlusOnePrice;
            }
            else if (itemId.Qty < dependentItem.Qty)
            {
                var uPrice = items.FirstOrDefault(up => up.Id == dependentItem.ID)?.UnitPrice ?? 0;
                return ((dependentItem.Qty - itemId.Qty) * uPrice) + itemId.Qty * onePlusOnePrice;
            }
            return 0.0m;
        }
    }
}
