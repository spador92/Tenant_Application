//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: App for Rental Properties that is web based. This program is used to add to the array
//and collection.
//Language: C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tenant_Application
{
    public partial class Add : System.Web.UI.Page
    {
        //Load add page
        protected void Page_Load(object sender, EventArgs e)
        {
            //Displays the current number of properties and number of tenants
            lblPropNum.Text = ("The number of properties is " + Start.maxProperties);
            lblTentNum.Text = ("The number of tenants is " + Start.myTenants.Count);

            //Makes error labels red
            lblPropError.ForeColor = System.Drawing.Color.Red;
            lblFamilySizeError.ForeColor = System.Drawing.Color.Red;
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        //Will add a tenant and array to the collection
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //make sure any previous error messages are erased
            lblPropError.Text = "";
            lblFamilySizeError.Text = "";
            lblError.Text = "";

            //Checks if any fields are empty
            if (TextBoxProp.Text == String.Empty || TextBoxFirst.Text == String.Empty ||
                TextBoxLast.Text == String.Empty || TextBoxFamilySize.Text == String.Empty)
            {
                lblError.Text = "All fields must be filled";
                return;
            }

            //Check if input is valid
            if (checkPropInput(TextBoxProp.Text) && checkFamilySizeInput(TextBoxFamilySize.Text))
            {
                int propNum = (Convert.ToInt32(TextBoxProp.Text) - 1);

                //Make property occupied
                Start.properties[propNum].FirstName = TextBoxFirst.Text;
                Start.properties[propNum].LastName = TextBoxLast.Text;
                Start.properties[propNum].FamilySize = Convert.ToInt32(TextBoxFamilySize.Text);
                Start.properties[propNum].Occupied = true;
                Start.properties[propNum].PropertyNum = (1 + propNum);
                Start.myTenants.Add(Start.properties[propNum]);

                lblTentNum.Text = ("The number of properties is " + Start.myTenants.Count);

                //Clear textboxes to indicate success
                TextBoxFirst.Text = "";
                TextBoxLast.Text = "";
                TextBoxProp.Text = "";
                TextBoxFamilySize.Text = "";
            }
        }

        //Redirects back to menu page
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx", true);
        }

        //Checks whether the string is valid for input
        Boolean checkPropInput(String input)
        {
            try
            {
                int prop = (Convert.ToInt32(input) - 1);

                //Checks if value is within range
                if (prop < 0 || prop >= Start.maxProperties)
                {
                    lblPropError.Text = "Input is out of range";
                    return false;
                }
                //Checks if property is occupied
                else if (Start.properties[prop].Occupied != false)
                {
                    lblPropError.Text = "Property is currently occupied";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //Catches when format is not correct
            catch (FormatException)
            {
                lblPropError.Text = "Input must be integer";
                return false;
            }
        }

        //Checks whether the string is valid for input
        Boolean checkFamilySizeInput(String input)
        {
            try
            {
                int prop = Convert.ToInt32(input);

                //Check if input is within range
                if (prop <= 0)
                {
                    lblFamilySizeError.Text = "Input must be greater than zero";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //Catches when format is not correct
            catch (FormatException)
            {
                lblFamilySizeError.Text = "Input must be integer";
                return false;
            }
        }
    }
}