//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: App for Rental Properties that is web based. This program displays search results for
//the tenants of the collection
//Language: C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tenant_Application
{
    public partial class Search : System.Web.UI.Page
    {

        //Purpose: Load search page
        protected void Page_Load(object sender, EventArgs e)
        {

            lblResults.Visible = false;
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        //Purpose: Uses user input to find relevant results
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String searchName = TextBoxFirst.Text;

            ListBoxTenants.Items.Clear();
            lblResults.Visible = true;

            //If user chose to search by first name
            if (DropDownListSearch.SelectedValue == "0")
            {
                //Creates query for specific number
                var Sorted =
                    from element in Start.myTenants
                    where element.FirstName.ToLower() == searchName.ToLower()
                    select element;

                //outputs narrowed results onto listbox
                foreach (var x in Sorted)
                {
                    ListBoxTenants.Items.Add(String.Format("Name: {0} {1} Current Due: {2:c}", x.FirstName, x.LastName, x.CurrentDue));
                }

                lblResults.Text = "results: " + ListBoxTenants.Items.Count;
            }
            //search by last name
            else
            {
                //Creates query for specific number
                var Sorted =
                    from element in Start.myTenants
                    where element.LastName.ToLower() == searchName.ToLower()
                    select element;

                //outputs narrowed results onto listbox
                foreach (var x in Sorted)
                {
                    ListBoxTenants.Items.Add(String.Format("Name: {0} {1} Current Due: {2:c}", x.FirstName, x.LastName, x.CurrentDue));
                }

                lblResults.Text = "results: " + ListBoxTenants.Items.Count;
            }
        }

        //Purpose: Redirects back to menu page
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx", true);
        }

        protected void DropDownListSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}