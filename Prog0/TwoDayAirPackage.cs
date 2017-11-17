// Program 1A
// CIS 200-01/76
// Due: 10/11/2016
// By: C9022

// File: TwoDayAirPackage.cs

// This file uses a enumaration to find if the Delivery is early or late.
// Using the package dimensions it inherited from the AirPackage file, it finds
// the delivery cost for the package.  The delivery cost is then printed on to the application.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1AFixed
{
    public class TwoDayAirPackage : AirPackage
    {
        private decimal baseCost;  // base cost of package value
        private const decimal COST_FACTOR25 = .25m; // constant variable
        private const decimal COST_FACTOR10 = .10m; // constant variable

        public enum Delivery { Early, Saver }; // enumeration with constants that represent the delivery status

        // Precondition: All package dimensions are greater than or equal to 0
        // Postcondition: TwoDayAirPackage type is specified with two addresses, length, width,
        //                height, and weight of the package.  Also the Delivery enumeration.
        public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width,
                                    double height, double weight, Delivery deliveryType) : base(originAddress, destAddress, length,
                                                                                                 width, height, weight)
        {
            DeliveryType = deliveryType;

        }

        public Delivery DeliveryType  // property that gets and sets the enum type
        {
            get;

            set;
        }

        // Precondition: None
        // Postcondition: If the delivery is early than the normal base cost is return,
        //                but if the delivery is saver than the base cost multiplied by 10 percent is returned.
        public override decimal CalcCost()
        {
            if (DeliveryType == Delivery.Saver) // is the delivery later?
            {
                return baseCost = COST_FACTOR25 * Convert.ToDecimal((Length + Width + Height)) + COST_FACTOR25 * (decimal)(Weight) * COST_FACTOR10; // return saver cost if true
            }
            else
            {
                return baseCost = COST_FACTOR25 * Convert.ToDecimal((Length + Width + Height)) + COST_FACTOR25 * (decimal)(Weight); // return early cost if false
            }
        }

        // Precondition: None
        // Postcondition: The ToString format is returned.
        public override String ToString()
        {
            return String.Format("{0}{1}{1}{2}{1}{3}{1}{4} {5:C}{1}{6}", base.ToString(), Environment.NewLine, "Delivery", "---------------",
                                 "Delivery Cost:", baseCost, "-----------------------");
        }
    }
}
