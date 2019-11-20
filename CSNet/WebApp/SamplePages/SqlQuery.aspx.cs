
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;
#endregion

namespace WebApp.SamplePages
{
    public partial class SqlQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                //you may need to refresh the list at a another place on this page
                BindCategoryList();
            }
        }

        protected void BindCategoryList()
        {
            //standard lookup
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> info = null;
                info = sysmgr.Categories_List();
                info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = info;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select...");

            }
            catch(Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (CategoryList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a category to view its products";
            }
            else
            {
                //standard lookup
                try
                {
                    ProductController sysmgr = new ProductController();
                    List<Product> info = null;
                    info = sysmgr.Products_FindByCategory(int.Parse(CategoryList.SelectedValue));
                    info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                    ProductList.DataSource = info;
                  
                    ProductList.DataBind();
                   

                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //treat the Gridview as if it were an indexd table of rows
            //columns which have ITemplates with web controls can be accessed via
            //     the web control id value

            //create a local alias to point to the table row of interest
            GridViewRow agvrow = ProductList.Rows[ProductList.SelectedIndex];

            //individual columns on a gridview can be accessed DEPENDING on how they
            //    were defined in the gridview
            //syntax   (agvrow.FindControl("xxxx") as controltype).controltypeaccess
            //   where agvrow is the selected row
            //         xxxx is the control on the gridview row using the ID attribute
            //         controltype is the control type (Label, Textbox, CheckBox, DropdownList, ...)
            //         controltypeaccess is how the particular control type is accessing
            //data is returned as a string
            string productid = (agvrow.FindControl("ProductID") as Label).Text;

            //pass the data to our ReceivingPage
            Response.Redirect("ReceivingPage.aspx?pid=" + productid);
        }

        protected void ProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //events usually come with a set of arguments
            //the particular class of arguments are found in the event header
            //different events have different argument classes

            //you must set the gridview pageindex to the new page index carried by the e instance
            ProductList.PageIndex = e.NewPageIndex;

            //you must refresh your data collection and assign it to the control
            Fetch_Click(sender, new EventArgs());

        }
    }
}