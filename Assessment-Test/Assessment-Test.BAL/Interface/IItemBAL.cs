using System;
using System.Collections.Generic;

namespace Assessment_Test.BAL.Interface
{
    public interface IItemBAL
    {
        Decimal CheckAndApplyPromotion(List<IItem> Items);
    }
}
