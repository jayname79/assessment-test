using System;
using System.Collections.Generic;
using System.Linq;

#region Project Reference
using Assessment_Test.BAL.Interface;
using Assessment_Test.DAL.Implementation;
using Assessment_Test.DAL.Interface;
#endregion

namespace Assessment_Test.BAL.Implementation
{
    public class ItemBAL : IItemBAL
    {
        private readonly IPromotionFactory _promotionFactory;
        private IPromotion _promotion;
        // Created singletone object
        private readonly IItemDAL _itemDAL;

        /// <summary>
        /// Constructior 
        /// </summary>
        /// <param name="promotion"></param>
        public ItemBAL(IPromotionFactory promotionFactory)
        {
            _promotionFactory = promotionFactory;
            _itemDAL = ItemHardCodedDAL.getInstance(); // Singleton
        }

        /// <summary>
        /// Check And Apply Promotion 
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public Decimal CheckAndApplyPromotion(List<IItem> Items)
        {
            Decimal result = 0;
            List<int> itemsConsidered= new List<int>();
            Guid TransactionId = Guid.NewGuid();

            try
            {
                var activePromotionRules = _itemDAL.GetActivePromotionRules();
                foreach (var item in Items)
                {
                    if (!itemsConsidered.Contains(item.ID))
                    {
                        var currRule = activePromotionRules.FirstOrDefault(rule => rule.ItemId == item.ID);

                        _promotion = _promotionFactory.GetPromotionInstance(currRule.PromotionRuleTypeId);
                        result += _promotion.CheckAndApplyPromotion(item, Items, itemsConsidered);
                    }
                }
            }
            catch
            {
                //TBI Error Log 
            }
            finally
            {
                itemsConsidered = null;
                TransactionId = Guid.Empty;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            return result;
        }
    }
}
