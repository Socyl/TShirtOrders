using System;
//Byron Corbitt
//bcorbitt@cnm.edu
//TShirtOrder.cs
//quiz 2 debugging exercise

//TShirtOrder.cs
//Programmer: Rob Garner (rgarner7@cnm.edu)
//Date: 10 Mar 2020
//Purpose: Model a TShirt order.
namespace TShirtOrders
{
    /// <summary>
    /// TShirtOrder
    /// Provides a model of a shirt order.
    /// </summary>
    public class TShirtOrder
    {
        private decimal printAreaInSqIn;
        private int numColors;
        private int numShirts;
        //BC added default value to printAreaInSqIn in constructor.  Initial value is replaced in user interaction in program. 
        public TShirtOrder(string firstName = "", string lastName = "", string address = "", bool isLocalPickup = true, decimal printAreaInSqIn=1.0M, int numberOfColors = 1, int numberOfShirts = 1)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsLocalPickup = isLocalPickup;
            this.printAreaInSqIn = printAreaInSqIn;

            //BC assignments should be made to parameters that were passed in. (same issue with both of the next two statements)
            //BC numColors changed to numberOfColors, numShirts changed to numberOfShirts
            this.numColors = numberOfColors;
            this.numShirts = numberOfShirts;
            Calc();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public bool IsLocalPickup { get; set; }

        public decimal PrintAreaInSqIn
        {
            get { return printAreaInSqIn; }
            set { printAreaInSqIn = value; Calc(); }
        }


        public int NumColors
        {
            //BC this get/set should be handling the backing field for the property...changed NumColors to numColors in both get and set
            get { return numColors; }
            set { numColors = value; Calc(); }
        }

        public int NumShirts
        {
            get { return numShirts; }
            set { numShirts = value; Calc(); }
        }
        //BC Price getter needs to be public since it is used in other parts of code.  removed private from get.
        public decimal Price {  get; set; }

        private void Calc()
        {
            Price = numShirts * (numColors * 2.25M + printAreaInSqIn * .05M);
        }
        //BC adding override to stop ToString() from hiding object.ToString() method
        public override string ToString()
        {
            return FirstName + " "
                + LastName + " "
                + " Price: " + Price.ToString("c");
        }
    }
}
