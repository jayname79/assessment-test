using Assessment_Test.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Test.NUnit.FluentClass
{
    public interface IFluentItem : IItem
    {
        IFluentItem NoOfQty(int q);
        IFluentItem ForItemId(int id);
    }
}
