// Program 1A
// CIS 200-01/76
// Due: 10/11/2016
// By: C9022

// File: NextDayAirPackage.cs

// This file takes the package dimensions it inherited from the AirPackage file
// and finds the cost of an overweight and/or oversized package. Takes those costs
// and adds it to the base cost of the package.  It also returns a Express fee for 
// the next day package.  The express fee, total cost, additional overweight cost, and additional oversized cost
// is printed on to the application.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1AFixed
{
   public class NextDayAirPackage : AirPackage
    {
        private decimal fee;  // express fee value
        private decimal totalCost;  // base cost of package
        private decimal weightCost;  // overweight cost of package
        private decimal overSizeCost; // oversized cost of package

        public const decimal COST_HELPER25 = .25m; // constant variable for cost
        public const decimal COST_HELPER40 = .40m;  // constant variable for cost 
        public const decimal COST_HELPER30 = .30m; // constant variable for cost

        // Precondition: All package values are greater than or equal to 0. ExpressFee >= 0
        // Postcondition: Next Day Air Package type is specified with values of two addresses, all the 
        //                package dimensions, and the express fee of the air package. 
        public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width,
                                    double height, double weight, decimal expressFee) :
            base(originAddress, destAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }


        public decimal ExpressFee
        {
            //Precondition: None
            //Postcondition: the express fee value is returned.
            get
            {
                return fee;
            }

            //Precondition: express fee >= 0
            //Postcondtion: The express fee value is set to specified value. 
            private set
            {
                if (value >= 0)
                    fee = value;
                else
                    throw new ArgumentOutOfRangeException("The Express Fee:", value, "must be greater than 0");

            }
        }

        // Precondition: None
        // Postcondition: If the package is overweight or not a cost is returned.
        private decimal WeightCost()
        {
            if (Weight >= MAX_WEIGHT) // is the package oversized?
            {
                return weightCost = COST_HELPER25 * (decimal)(Weight); // if true return cost

            }
            else
            {
                return weightCost = 0; // if false return no cost
            }
        }

        // Precondition: None
        // Precondition: If the package is oversized or not than the specific oversize cost is returned.
        private decimal OverSizeCost()
        {
            if ((Width + Height + Length) >= MAX_DIMENSIONS)  // is package oversized?
            {
                return overSizeCost = COST_HELPER25 * Convert.ToDecimal((Length + Height + Width)); // if true return cost
            }
            else
            {
                return overSizeCost = 0; // if false return no cost.
            }
        }

        //Precondition: None
        //Postcondition: The cost value is returned, if package is heavy than weight cost is added,
        //               and if package is large than large cost is add.
        public override decimal CalcCost()
        {
            totalCost = COST_HELPER40 * Convert.ToDecimal((Length + Width + Height)) + COST_HELPER30 * (decimal)(Weight) + ExpressFee; // normal base cost

            if (IsHeavy()) //is the package overweight?
                totalCost += COST_HELPER25 * (decimal)(Weight); // add to base cost if true

            if (IsLarge()) // is the package oversized?
                totalCost += COST_HELPER25 * Convert.ToDecimal(Length + Height + Width); // add to base cost if true

            return totalCost; // return the base cost

        }

        // Precondition: None
        // Postcondition: The ToString format is returned.
        public override String ToString()
        {
            return String.Format("{0}{1}{1}{2}{1}{3}{1}{4}{5:C}{1}{6}{7:C}{1}{8}{9:C}{1}{10}{11:C}{1}{12}",
                                  base.ToString(), Environment.NewLine, "Package Fees", "------------", "Express Fee:", fee,
                                  "Base Cost:", totalCost, "Over Weight Additional Cost:", WeightCost(),
                                  "Oversized Additional Cost:", OverSizeCost(), "-----------------------------------");
        }
    }
}
