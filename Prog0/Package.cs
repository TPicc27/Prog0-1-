// Program 1A
// CIS 200-01/76
// Due: 10/11/2016
// By: C9022

// File: Package.cs

// This file inherits the addresses from the Parcel file and will find all the package dimensions
// of height, length, width, and weight
// and print them on to the applicaition.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1AFixed
{
    public abstract class Package : Parcel
    {
        private double lgth;  // length of the package
        private double wdth;   // width of the package
        private double hght;  // height of the package
        private double weht;  // weight of the package


        // Precondition: All package dimensions must be greater than or equal to 0.
        // Postcondition: The package is created with specified code of the two address types,
        //                length, width, height, and weight of package.
        public Package(Address originAddress, Address destAddress,
               double length, double width, double height, double weight) : base(originAddress, destAddress)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;

        }

        public double Length
        {
            // Precondition: None
            // Postcondition: the length of the package has been returned
            get
            {
                return lgth;
            }

            // Precondition: length >= 0
            // Postcondition: the length of the package has been set with specified value
            set
            {
                if (value >= 0)
                    lgth = value;
                else
                    throw new ArgumentOutOfRangeException("Length:", value, "needs to be greater than 0");
            }
        }

        public double Width
        {
            //Precondition: None
            //Postcondition: the width of the package has been returned.
            get
            {
                return wdth;
            }

            // Precondition: width >= 0
            // Postcondition: the width of the package has been set to specified value.
            set
            {
                if (value >= 0)
                    wdth = value;
                else
                    throw new ArgumentOutOfRangeException("Width:", value, "needs to be greater than 0");
            }
        }

        public double Height
        {
            //Precondition: None
            //Postcondition: the height of the package has been returned
            get
            {
                return hght;
            }

            //Precondition: width >= 0
            //Postcondition: the height of the package has been set to specified value
            set
            {
                if (value >= 0)
                    hght = value;
                else
                    throw new ArgumentOutOfRangeException("Height:", value, "needs to be greater than 0");
            }
        }

        public double Weight
        {
            //Precondition: None
            //Postcondition: the weight of the package has been returned.
            get
            {
                return weht;
            }

            //Precondition: weight >= 0
            //Postcondition: the weight of the package has been set to the specified value
            set
            {
                if (value >= 0)
                    weht = value;
                else
                    throw new ArgumentOutOfRangeException("Weight:", value, "needs to be greater than 0");
            }
        }

        //Precondition: None
        //Postcondition: The ToString format has been returned
        public override String ToString()
        {
            return String.Format("{0}{1}{1}{2}{1}{3}{1}{4} {5} {1}{6} {7} {1}{8} {9} {1}{10} {11}",
                                    base.ToString(), Environment.NewLine, "Package Dimensions", "---------------",
                                    "Length:", Length, "Width:", Width, "Height:", Height, "Weight:", Weight);
        }
    }
}
