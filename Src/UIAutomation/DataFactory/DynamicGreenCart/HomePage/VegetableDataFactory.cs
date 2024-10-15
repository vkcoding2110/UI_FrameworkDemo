using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.DataObjects.DynamicGreenCart.HomePage;

namespace UIAutomation.DataFactory.DynamicGreenCart.HomePage
{
    class VegetableDataFactory
    {
        public static HomePageForm EnterItemQuantity()
        {
            return new HomePageForm
            {
                ProductName = "Brocolli - 1 Kg",
                ProductQuantity = "10"
            };
        }
    }
}
