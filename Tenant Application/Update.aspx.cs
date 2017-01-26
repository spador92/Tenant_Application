//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: App for Rental Properties that is web based. This program is used to update an element 
//to the array and collection.
//Language: C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tenant_Application
{
    public partial class Update : System.Web.UI.Page
    {
        static int propNum;

        //Load update page
        protected void Page_Load(object sender, EventArgs e)
        {
            //Error label setup
            lblFamilySizeError.ForeColor = System.Drawing.Color.Red;
            lblPropError.ForeColor = System.Drawing.Color.Red;
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        //Shows the tenant information when given the property number
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            //Check if array is empty
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
                //Update tenant information
                propNum = (Convert.ToInt32(TextBoxProp.Text) - 1);

                TextBoxFirst.Text = Start.properties[propNum].FirstName;
                TextBoxLast.Text = Start.properties[propNum].LastName;
                TextBoxFamilySize.Text = Convert.ToString(Start.properties[propNum].FamilySize);

                btnUpdate.Enabled = true;
            }
        }

        //Redirects back to menu page
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx", true);
        }

        //Updates information on tenant based on user input
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            lblError.Text = "";

            //Checks if all fields are filled
            if (TextBoxProp.Text == String.Empty || TextBoxFirst.Text == String.Empty ||
                TextBoxLast.Text == String.Empty || TextBoxFamilySize.Text == String.Empty)
            {
                lblError.Text = "All fields must be filled";
                lblSuccess.Text = "Update was unsuccessful";
                return;
            }
            if (checkPropInput(TextBoxProp.Text) && checkFamilySizeInput(TextBoxFamilySize.Text))
            {
                //Update information 
                Start.properties[propNum].FirstName = TextBoxFirst.Text;
                Start.properties[propNum].LastName = TextBoxLast.Text;
                Start.properties[propNum].FamilySize = Convert.ToInt32(TextBoxFamilySize.Text);

                lblSuccess.Text = "Update was successful";

                //Clear textboxes
                TextBoxProp.Text = "";
                TextBoxFirst.Text = "";
                TextBoxLast.Text = "";
                TextBoxFamilySize.Text = "";
            }
            else
            {
                lblSuccess.Text = "Update was unsuccessful";
            }
        }

        //This method holds the value of the amount to be paid and automatically deducts rentPay from it
        Boolean checkPropInput(String input)
        {
            lblPropError.Text = "";
            try
            {
                int prop = (Convert.ToInt32(input) - 1);

                //Checks if input is within range
                if (prop < 0 || prop > Start.maxProperties)
                {
                    lblPropError.Text = "Input must be greater than zero";
                    return false;
                }
                //Checks if property is occupied
                else if (Start.properties[prop].Occupied == false)
                {
                    lblPropError.Text = "Property is unoccupied";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //Catches if format is incorrect
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

                //Checks if input is within range
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
            //Catches if format is incorrect
            catch (FormatException)
            {
                lblFamilySizeError.Text = "Input must be integer";
                return false;
            }
        }
    }
}