#region Project reference
using Assessment_Test.Common;
using Assessment_Test.DAL.DBEntites;
using Promotion_Engine_DAL.Interface;
using System.Collections.Generic;
#endregion

namespace Assessment_Test.DAL.Implementation
{
    public sealed class ItemHardCodedDAL : IItemDAL
    {
        private static ItemHardCodedDAL itemHardCodedDAL = null;
        private static readonly object _lock = new object();

        private ItemHardCodedDAL()
        {
            
        }

        public static ItemHardCodedDAL getInstance()
        {
            lock (_lock)
            {
                if (itemHardCodedDAL == null)
                {
                    lock (_lock)
                    {
                        itemHardCodedDAL = new ItemHardCodedDAL();
                    }
                }
            }
            return itemHardCodedDAL;
        }

        public List<ActivePromotionRule> GetActivePromotionRules()
        {
            return new List<ActivePromotionRule>()
            {
                new ActivePromotionRule()
                {
                    Id = 1,
                    ItemId =1,
                    PromotionRuleTypeId =EnumPromotionRuleType.Comb,
                    Param1 = "3",
                    Param2 = "130"
                },
                 new ActivePromotionRule()
                {
                    Id = 2,
                    ItemId =2,
                    PromotionRuleTypeId =EnumPromotionRuleType.Comb,
                    Param1 = "2",
                    Param2 = "45"
                },
                  new ActivePromotionRule()
                {
                    Id = 3,
                    ItemId =3,
                    PromotionRuleTypeId =EnumPromotionRuleType.OnePlusOne,
                    Param1 = "4",
                    Param2 = "30"
                }
            };
        }

        public List<ItemMaster> GetItemMasters()
        {
            return new List<ItemMaster>() 
            { 
                new ItemMaster()
                {
                    Id=1,
                    ItemName = "A",
                    UnitPrice = 50
                },
                new ItemMaster()
                {
                    Id=2,
                    ItemName = "B",
                    UnitPrice = 30
                },
                new ItemMaster()
                {
                    Id=3,
                    ItemName = "C",
                    UnitPrice = 20
                }, 
                new ItemMaster()
                {
                    Id=4,
                    ItemName = "D",
                    UnitPrice = 15
                }
            };
        }

        public List<PromotionRuleType> GetPromotionRuleTypes()
        {
            return new List<PromotionRuleType>()
            {
                new PromotionRuleType()
                {
                    Id = 1,
                    RuleName= "Combo"
                },
                new PromotionRuleType()
                {
                    Id = 2,
                    RuleName= "OnePlusOne"
                }
            };
        }

    }
}
