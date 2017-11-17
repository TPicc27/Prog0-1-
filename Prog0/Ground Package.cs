// Program 1A
// CIS 200-01/76
// Due: 10/11/2016
// By: C9022

// File: GroundPackage.cs

// This file inherits the package dimensions from the Package file to find the cost
// also takes the zip codes from the origin and destination
// address to find the zone distances.  The Shipping cost
// and Zone Distances is printed on to the application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1AFixed
{
    public class GroundPackage : Package
    {
        private int zoneDist;  //variable for the Zone Distance method
        private decimal shippingCost;  // variable to find the shipping cost.
        public const int ZIP_FACTOR = 10000;  // first digit factor for the zone distance of the zip codes
        public const decimal COST_FACTOR20 = .20m; // constant variable for cost 
        public const decimal COST_FACTOR05 = .05m; // constant variable for cost


        // Precondition: All package dimensons must be greater than or equal to 0.
        // Postcondition: The ground package is specified with values of the two address, length
        //                width, height, and weight.
        public GroundPackage(Address originAddress, Address destAddress,
            double length, double width, double height, double weight) : base(originAddress, destAddress, length,
                width, height, weight)
        {

        }


        public int ZoneDistance
        {
            // Precondition: None
            // Postcondition: The zone distance value has been returned
            get
            {
                return zoneDist = Math.Abs((OriginAddress.Zip / ZIP_FACTOR) - (DestinationAddress.Zip / ZIP_FACTOR));


            }
        }

        // Precondition: None
        // Postcondition: the shipping cost value has been returned
        public override decimal CalcCost()
        {
            return shippingCost = COST_FACTOR20 * Convert.ToDecimal((Length + Width + Height))
                                  + COST_FACTOR05 * Convert.ToDecimal((zoneDist + 1) * (Weight));

        }

        // Precondition: None
        // Postcondition: ToString format has been returned. 
        public override String ToString()
        {
            return String.Format("{0}{1}{2}{3}{1}{4}", base.ToString(), Environment.NewLine, "Zone Distance:", ZoneDistance,
                                    "---------------------");
        }

    }
}
