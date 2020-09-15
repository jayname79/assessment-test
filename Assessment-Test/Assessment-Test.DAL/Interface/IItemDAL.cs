using System.Collections.Generic;

#region Project reference
using Assessment_Test.DAL.DBEntites;
#endregion

namespace Assessment_Test.DAL.Interface
{
    public interface IItemDAL
    {
        IEnumerable<ItemMaster> GetItemMasters();
        IEnumerable<ActivePromotionRule> GetActivePromotionRules();
        IEnumerable<PromotionRuleType> GetPromotionRuleTypes();
    }
}
