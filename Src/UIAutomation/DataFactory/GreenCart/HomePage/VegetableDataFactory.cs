using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.DataObjects.GreenCart.HomePage;

namespace UIAutomation.DataFactory.GreenCart
{
    class VegetableDataFactory
    {
        public static HomePageForm EnterItemQuantity()
        {
            return new HomePageForm
            {
                Quantity = "10"
            };
        }
    }
}
