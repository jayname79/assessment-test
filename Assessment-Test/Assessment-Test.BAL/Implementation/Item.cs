#region Project reference
using Assessment_Test.BAL.Interface;
#endregion

namespace Assessment_Test.BAL.Implementation
{
    public class Item : IItem
    {
        public int ID { set; get; }
        public int Qty { set; get; }        

    }
}
