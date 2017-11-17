// Program 1A
// CIS 200-01/76
// Due: 10/11/2016
// By: C9022

//File: AirPackage.cs

// This file inherits the package dimensions from the Package file
// Sees if the package is overweight and/or oversized.  It is
// printed as true or false on the application.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1AFixed
{
    public abstract class AirPackage : Package
    {
        public const int MAX_WEIGHT = 75;  // Maximum weight before called heavy
        public const int MAX_DIMENSIONS = 100;  // Maximum dimensions before called large.
        bool heavy = true;  // determines if package is heavy
        bool large = true;  // determines if package is large

        // Precondition: All package dimenisions must be greater than or equal to 0
        // Postcondition: Airpackage type is specified with values of the two addresses, the length, 
        //                the width, the height, and the weight.
        public AirPackage(Address originAddress, Address destAddress,
            double length, double width, double height, double weight) : base(originAddress, destAddress, length,
                width, height, weight)
        {

        }

        // Precondition: None
        // Postcondition: The package is found to be heavy or not and is returned.
        public bool IsHeavy()
        {
            if (Weight <= MAX_WEIGHT)  // Weight is less than Maximum weight of 75.
            {
                return heavy = false;  // if weight is less than its the value is returned false.
            }
            else
            {
                return heavy; // else the package is returned true.
            }
        }

        // Precondition: None
        // Postcondition: The package is found to be large or not and is returned.
        public bool IsLarge()
        {
            if ((Width + Height + Length) <= MAX_DIMENSIONS)  // if weight plus height plus length are less than 100.
            {
                return large = false; // the package is returned to not be large
            }
            else
            {
                return large; // else the package is returned large.
            }

        }

        // Precondtion: None
        // Postcondition: ToString format is returned.  
        public override String ToString()
        {
            return String.Format("{0}{1}{2} {3}{1}{4} {5}", base.ToString(), Environment.NewLine, "Is the package heavy:", IsHeavy(),
                                  "Is the package large:", IsLarge());
        }

    }
}
