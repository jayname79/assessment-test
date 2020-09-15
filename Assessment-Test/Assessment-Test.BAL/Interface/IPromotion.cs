
using System.Collections.Generic;

namespace Assessment_Test.BAL.Interface
{
    public interface IPromotion
    {
        decimal CheckAndApplyPromotion(IItem item,List<IItem> items, List<int> temsConsidered);
    }
}
