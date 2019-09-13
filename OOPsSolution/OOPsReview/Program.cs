using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Program
    {
        //assuming you know how to obtain user entered data
        static void Main(string[] args)
        {
            double height = 6.5;
            double width = 8.0;
            double linearlength = 135.0;
            string style = "Neighbour Friendly: Spruce";
            double price = 108.00;

            //store the panel data
            //declare a storage area for the panel data

            //create a non-static instance of a class
            //use the new command to create the class instance
            //the new command references the class constructor
            FencePanel panelInfo = new FencePanel(height, width,  style, price);  //greedie constructor

            //obtain and store gate data
            Gate gateInfo;
            List<Gate> gateList = new List<Gate>();

            //assume looping to obtain all gate data
            //each loop is one gate
            //pass 1
            height = 6.25;
            width = 4.0;
            style = "Neighbour Friendly 1/2 Picket: Spruce";
            price = 86.45;
            gateInfo = new Gate(); // default constructor OR system constructor

            //name of the instance  dotoperator the Propertyname = value
            gateInfo.Height = height;  //set of the property
            gateInfo.Width = width;
            gateInfo.Style = style;
            gateInfo.Price = price;
            gateList.Add(gateInfo);

            //pass 2
            height = 6.25;
            width = 3.0;
            style = "Neighbour Friendly: Spruce";
            price =72.95;
            gateInfo = new Gate(height, width, style, price); 
            gateList.Add(gateInfo);

            //assume end of looping

            // create the Estimate
            Estimate theEstimate = new Estimate();
            theEstimate.LinearLength = linearlength;
            theEstimate.Panel = panelInfo;
            theEstimate.Gates = gateList;
            theEstimate.CalculateTotalPrice();

            //client wishes a output of the estimate
            Console.WriteLine("The fence is to be a " + theEstimate.Panel.Style + " style");
            Console.WriteLine("The total cost of the estimate is {0:0.00}", theEstimate.TotalPrice);  //get
            Console.WriteLine("Number of required panels: {0}",
                theEstimate.Panel.EstimatedNumberOfPanels(theEstimate.LinearLength));
            Console.WriteLine("Number of gates: {0}", theEstimate.Gates.Count);
            double fenceArea = theEstimate.Panel.FenceArea(theEstimate.LinearLength);
            foreach(var item in theEstimate.Gates)
            {
                fenceArea += item.GateArea();   //item represents a single Gate instance in the collection
            }
            Console.WriteLine(string.Format("Total fence surface area {0:0.0}", fenceArea * 2));
            Console.ReadKey();


        }
    }
}
