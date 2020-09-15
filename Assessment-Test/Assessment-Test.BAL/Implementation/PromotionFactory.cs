using Assessment_Test.BAL.Interface;
using Assessment_Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Test.BAL.Implementation
{
    public class PromotionFactory : IPromotionFactory
    {
        public IPromotion GetPromotionInstance(EnumPromotionRuleType enumPromotionRuleType)
        {
            if (EnumPromotionRuleType.Comb == enumPromotionRuleType)
                return new ComboPromotion();
            else
                return new OnePlusOnePromotion();
        }
    }
}
