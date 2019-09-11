using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    //default for all classes is private
    //if an outside user of the class is to have 
    //    access to the class then you need to 
    //    make that class public

    public class FencePanel
    {
        //Properties
        //a property is associated with a single piece of data
        //a property has two sub components
        //    get: returns the data value to the outside user
        //    set: receive a data value and store it
        //a property does NOT have parameter
        //the set of the property using a keyword (value) to
        //    hold the incoming data value

        //Auto-implemented property
        //does NOT need a data member coded
        //the system will create an internal data storage element
        //    equivalent to the property return datatatype
        //no additional processing
        //public double Height { get; set; } one could put data validation inside a property

        //validation: must be greater than 0.0 and less than or equal to 8.0
        //validation requires a fully implemented property
        private double _Height;
        public double Height
        {
            get
            {
                return _Height;
            }
            set
            {
                if (value > 0.0 && value <= 8.0)
                {
                    _Height = value;
                }
                else
                {
                    throw new Exception("Invalid Height");
                }
            }
        }
        public double Width { get; set; }

        //Fully-implemented property
        //does NEED a data member coded, usually private
        //these properties usually contain additional logical processing
        //this processing could be validation, ensuring appropriate data stored

        //example: the style of fence is a string that either has characters
        //         or no data (null)
        private string _Style;
        public string Style
        {
            get
            {
                return _Style;
            }
            set
            {
                //incoming data is located in the keyword value
                if (string.IsNullOrEmpty(value))
                {
                    _Style = null;
                }
                else
                {
                    _Style = value;
                }
            }
        }

        //handling nullable numerics
        //only two possibilities: a) a numeric or b)null
        public double? Price { get; set; }

        //Constructors
        //are used to place the instance of your class in a "Known State"
        //     when it is created
        //if you do NOT code a constructor in your class then the system
        //     will initialize your data members to their natural initialized state
        //if you DO code a constructor then you are responsible for ALL 
        //     constructors within the class
        //a constructor DOES NOT have a return datatype (rdt).

        //default constructor
        //similar to the system constructor
        public FencePanel()
        {
            //optionally you could assign your own hard-code initial value
            Height = 6.0;
            Width = 8.0;
            Price = null;
        }

        //greedie constructor
        //the constructor will has a list of parameters tha will receive
        //   an argument value at the time the instance is created
        //the values will be used to set the internal data of the instance
        //   before the instance is actually return to the outside user
        public FencePanel(double height, double width, string style, double? price)
        {
            Height = height;
            Width = width;
            Style = style;
            Price = price;
        }

        //Behaviours (a.k.a. methods)
        //a class behaviour has the same syntax (grammar) as a standard programming method
        //the class behaviour is usually involved with the data of the class

        //within these examples I am NOT doing fully validation

        public double EstimatedNumberOfPanels(double linearlength)
        {
            //probably validate that Width has been set
            //you could use data members directly within your code
            //I use the properties because they ensure proper values
            double numberofpanels = linearlength / Width;
            return numberofpanels;
        }

        public double FenceArea(double linearlength)
        {
            //return linearlength * Height;
            return Width * Height * EstimatedNumberOfPanels(linearlength);
        }
    }
}
