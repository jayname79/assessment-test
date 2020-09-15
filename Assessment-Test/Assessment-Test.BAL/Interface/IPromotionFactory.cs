using Assessment_Test.BAL.Implementation;
using Assessment_Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Test.BAL.Interface
{
    public interface IPromotionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IPromotion GetPromotionInstance(EnumPromotionRuleType enumPromotionRuleType);
    }
}
