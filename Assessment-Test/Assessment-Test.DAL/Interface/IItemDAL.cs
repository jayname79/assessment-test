using System.Collections.Generic;

#region Project reference
using Assessment_Test.DAL.DBEntites;
#endregion

namespace Promotion_Engine_DAL.Interface
{
    public interface IItemDAL
    {
        List<ItemMaster> GetItemMasters();
        List<ActivePromotionRule> GetActivePromotionRules();
        List<PromotionRuleType> GetPromotionRuleTypes();
    }
}
