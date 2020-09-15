

namespace Assessment_Test.NUnit.FluentClass
{  
    public class FluentItem  : IFluentItem
    {
        public int ID { get; set; }
        public int Qty { get ; set ; }

        public IFluentItem NoOfQty(int q)
        {
            this.Qty = q;
            return this;
        }
        public IFluentItem ForItemId(int id)
        {
            this.ID = id;
            return this;
        }
    }
}
