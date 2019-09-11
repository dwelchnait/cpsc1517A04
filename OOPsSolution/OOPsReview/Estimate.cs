using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Estimate
    {
        public double TotalPrice { get; private set; }
        public double LinearLength { get; set; }

        public FencePanel Panel { get; set; }

        public List<Gate> Gates { get; set; }

        public void CalculateTotalPrice()
        {
            //assumption: you would put appropriate validation
            //            at required points in your logic
            //            to ensure data is present before using
            double numberofpanels = Panel.EstimatedNumberOfPanels(LinearLength);
            if((int)(numberofpanels * 10.0) > ((int)numberofpanels * 10))
            {
                numberofpanels = (int)numberofpanels + 1;
            }
            if(Panel.Price == null)
            {
                throw new Exception("Panel price is needed to calculate estimate");
            }
            else
            {
                TotalPrice += numberofpanels * (double)Panel.Price;
                foreach(var item in Gates)
                {
                    TotalPrice += item.Price;
                }
            }
            //return TotalPrice;
        }

    }
}
