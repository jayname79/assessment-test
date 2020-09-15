using System;
using System.Collections.Generic;
using Assessment_Test.BAL.Implementation;
using Assessment_Test.BAL.Interface;
using Assessment_Test.NUnit.FluentClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.Injection;

namespace Assessment_Test.NUnit
{
    [TestClass]
    public class PromotionTestCases
    {
        private IItemBAL _itemBAL;

        private UnityContainer _container = new UnityContainer();

        [TestInitialize]
        public void InitializeTests()
        {
            _container.RegisterType<IItemBAL, ItemBAL>(new InjectionConstructor(typeof(PromotionFactory)));

            _itemBAL = _container.Resolve<IItemBAL>();
        }

        [TestMethod]
        public void Test_Scenario_A()
        {
            List<IItem> fluentItem = new List<IItem>();
            fluentItem.Add(new FluentItem().NoOfQty(1).ForItemId(1));
            fluentItem.Add(new FluentItem().NoOfQty(1).ForItemId(2));
            fluentItem.Add(new FluentItem().NoOfQty(1).ForItemId(3));

            Decimal result = _itemBAL.CheckAndApplyPromotion(fluentItem);
            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void Test_Scenario_B()
        {
            List<IItem> fluentItem = new List<IItem>();
            fluentItem.Add(new FluentItem().NoOfQty(5).ForItemId(1));
            fluentItem.Add(new FluentItem().NoOfQty(5).ForItemId(2));
            fluentItem.Add(new FluentItem().NoOfQty(1).ForItemId(3));

            Decimal result = _itemBAL.CheckAndApplyPromotion(fluentItem);
            Assert.AreEqual(result, 370);
        }

        [TestMethod]
        public void Test_Scenario_C()
        {
            List<IItem> fluentItem = new List<IItem>();
            fluentItem.Add(new FluentItem().NoOfQty(3).ForItemId(1));
            fluentItem.Add(new FluentItem().NoOfQty(5).ForItemId(2));
            fluentItem.Add(new FluentItem().NoOfQty(1).ForItemId(3));
            fluentItem.Add(new FluentItem().NoOfQty(1).ForItemId(4));

            Decimal result = _itemBAL.CheckAndApplyPromotion(fluentItem);
            Assert.AreEqual(result, 280);
        }

        [TestMethod]
        public void Test_Scenario_D()
        {
            List<IItem> fluentItem = new List<IItem>();
            fluentItem.Add(new FluentItem().NoOfQty(3).ForItemId(1)); //130
            fluentItem.Add(new FluentItem().NoOfQty(5).ForItemId(2)); //120
            fluentItem.Add(new FluentItem().NoOfQty(1).ForItemId(3)); //0
            fluentItem.Add(new FluentItem().NoOfQty(3).ForItemId(4)); //30+30 = 130+120+60 = 310

            Decimal result = _itemBAL.CheckAndApplyPromotion(fluentItem);
            Assert.AreEqual(result, 310);
        }

        [TestMethod]
        public void Test_Scenario_E()
        {
            List<IItem> fluentItem = new List<IItem>();
            fluentItem.Add(new FluentItem().NoOfQty(3).ForItemId(1)); //130
            fluentItem.Add(new FluentItem().NoOfQty(5).ForItemId(2)); //120
            fluentItem.Add(new FluentItem().NoOfQty(5).ForItemId(3)); //40
            fluentItem.Add(new FluentItem().NoOfQty(3).ForItemId(4)); //90 = 130+120+40+90 = 380s

            Decimal result = _itemBAL.CheckAndApplyPromotion(fluentItem);
            Assert.AreEqual(result, 380);
        }

        [TestMethod]
        public void Test_Scenario_F()
        {
            List<IItem> fluentItem = new List<IItem>();
            fluentItem.Add(new FluentItem().NoOfQty(0).ForItemId(1));//0
            fluentItem.Add(new FluentItem().NoOfQty(0).ForItemId(2));//0
            fluentItem.Add(new FluentItem().NoOfQty(0).ForItemId(3));//0
            fluentItem.Add(new FluentItem().NoOfQty(0).ForItemId(4));//0

            Decimal result = _itemBAL.CheckAndApplyPromotion(fluentItem);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Test_Scenario_G()
        {
            List<IItem> fluentItem = new List<IItem>();
            fluentItem.Add(new FluentItem().NoOfQty(0).ForItemId(1));
            fluentItem.Add(new FluentItem().NoOfQty(2).ForItemId(2));//45
            fluentItem.Add(new FluentItem().NoOfQty(0).ForItemId(3));
            fluentItem.Add(new FluentItem().NoOfQty(2).ForItemId(4));//30

            Decimal result = _itemBAL.CheckAndApplyPromotion(fluentItem);
            Assert.AreEqual(result, 75);
        }
    }
}
