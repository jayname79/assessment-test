using Assessment_Test.Common;

namespace Assessment_Test.DAL.DBEntites
{
    public class ActivePromotionRule
    {
        public int Id { set; get; }
        public int ItemId { set; get; }
        public EnumPromotionRuleType PromotionRuleTypeId { set; get; }
        public string Param1 { set; get; }
        public string Param2 { set; get; }
        public string Param3 { set; get; }
        public string Param4 { set; get; }
        public string Param5 { set; get; }
    }
}
