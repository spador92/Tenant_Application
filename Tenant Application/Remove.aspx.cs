//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: App for Rental Properties that is web based. This program is used to remove from the array
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

    public partial class Remove : System.Web.UI.Page
    {
        static int propNum;

        //Load remove page
        protected void Page_Load(object sender, EventArgs e)
        {
            //Displays the current number of properties and number of tenants
            lblPropNum.Text = ("The number of properties is " + Start.maxProperties);
            lblTentNum.Text = ("The number of tenants is " + Start.myTenants.Count);

            //Makes all Display textboxes out of user control
            TextBoxFirst.Enabled = false;
            TextBoxLast.Enabled = false;
            TextBoxFamilySize.Enabled = false;
            TextBoxMonths.Enabled = false;
            TextBoxCurrentDue.Enabled = false;

            btnRemove.Enabled = false;

            lblPropError.ForeColor = System.Drawing.Color.Red;
            lblPropError.Text = "";
        }


        //Shows the tenant information when given the property number
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            //Check if box is empty
            if (TextBoxProp.Text == String.Empty)
            {
                lblPropError.Text = "Input must be made";
                return;
            }
            //Check if input is valid
            else if (!checkPropInput(TextBoxProp.Text))
            {
                return;
            }
            else
            {
                //Shows information in textboxes
                TextBoxFirst.Text = Start.properties[propNum].FirstName;
                TextBoxLast.Text = Start.properties[propNum].LastName;
                TextBoxFamilySize.Text = Convert.ToString(Start.properties[propNum].FamilySize);
                TextBoxMonths.Text = Convert.ToString(Start.properties[propNum].Months);
                TextBoxCurrentDue.Text = Convert.ToString(Start.properties[propNum].CurrentDue);

                btnRemove.Enabled = true;
            }
        }

        //Removes the tenant from the array and collection
        protected void btnRemove_Click(object sender, EventArgs e)
        {

            //Take tenant out of property and remove from collection
            Start.properties[propNum].FirstName = "";
            Start.properties[propNum].LastName = "";
            Start.properties[propNum].FamilySize = 0;
            Start.properties[propNum].Months = 0;
            Start.properties[propNum].CurrentDue = 0;
            Start.properties[propNum].RentPay = 0;
            Start.properties[propNum].Occupied = false;
            Start.myTenants.Remove(Start.properties[propNum]);

            //Make fields blank again
            TextBoxProp.Text = "";
            TextBoxFirst.Text = "";
            TextBoxLast.Text = "";
            TextBoxFamilySize.Text = "";
            TextBoxMonths.Text = "";
            TextBoxCurrentDue.Text = "";
            lblTentNum.Text = ("The number of properties is " + Start.myTenants.Count);

            btnRemove.Enabled = false;
        }


        //Redirects back to menu page
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx", true);
        }

        //Checks whether the string is valid for input
        Boolean checkPropInput(String input)
        {
            try
            {
                propNum = (Convert.ToInt32(input) - 1);

                //Check if input is within range
                if (propNum < 0 || propNum >= Start.maxProperties)
                {
                    lblPropError.Text = "Input must be within range";
                    return false;
                }
                //Check if current property is occupied
                else if (Start.properties[propNum].Occupied == false)
                {
                    lblPropError.Text = "Property is unoccupied";
                    return false;
                }
                else
                {
                    //Clear textboxes
                    TextBoxProp.Text = "";
                    TextBoxFirst.Text = "";
                    TextBoxLast.Text = "";
                    TextBoxFamilySize.Text = "";
                    return true;
                }
            }
            //Catches when format is incorrect
            catch (FormatException)
            {
                lblPropError.Text = "Input must be integer";
                return false;
            }
        }
    }
}