using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //NO DB temporary List<T>
        public static List<CEntry> Entries;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                Entries = new List<CEntry>();
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            //empty form fields

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //server side execution of your validation controls
            //   is done by using Page.IsValid
            if (Page.IsValid)
            {
                //you may have logic testing to do in code behind
                //if you have a promt line on your DDL, test for it
                //our entry form has a Terms acceptance test
                //  yes: save entry, add to collection, display
                //   no: message
                //the Term data and Check Answer data will NOT be saved
                if (Terms.Checked)
                {
                    ////create a new instance of CEntry
                    //CEntry theEntry = new CEntry();

                    ////load the form data into this instance
                    //theEntry.FirstName = FirstName.Text;
                    //theEntry.LastName = LastName.Text;
                    //theEntry.StreetAddress1 = StreetAddress1.Text;
                    //theEntry.StreetAddress2 = 
                    //    string.IsNullOrEmpty(StreetAddress2.Text) ? null:StreetAddress2.Text;
                    //theEntry.City = City.Text;
                    //theEntry.Province = Province.SelectedValue;
                    //theEntry.PostalCode = PostalCode.Text;
                    //theEntry.EmailAddress = EmailAddress.Text;

                    ////add the instance to the collection
                    //Entries.Add(theEntry);

                    //use the "greedy" constructor to load the instance and collection
                    Entries.Add(new CEntry(FirstName.Text,
                                           LastName.Text,
                                           StreetAddress1.Text,
                                           string.IsNullOrEmpty(StreetAddress2.Text) ? null : StreetAddress2.Text,
                                           City.Text,
                                           Province.SelectedValue,
                                           PostalCode.Text,
                                           EmailAddress.Text));
                    //display the collection
                    EntryList.DataSource = Entries;
                    EntryList.DataBind();
                }
                else
                {
                    Message.Text = "You did not agree to the contest terms. Entry rejected.";
                }
            }
        }
    }
}