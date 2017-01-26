//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: Assignment 4, App for Rental Properties that is web based. This program is update the tenats current 
//due
//Language: C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tenant_Application
{
    public partial class PayRent : System.Web.UI.Page
    {
        static int propNum = -1;

        //Purpose: Load payRent page
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxFirst.Enabled = false;
            TextBoxLast.Enabled = false;
            TextBoxCurrentDue.Enabled = false;
            TextBoxMonths.Enabled = false;

            //Sets up error labels
            lblPropError.ForeColor = System.Drawing.Color.Red;
            lblPayError.ForeColor = System.Drawing.Color.Red;
            lblPayError.Text = "";
            lblPropError.Text = "";

        }

        //Purpose: Shows the tenant information when given the property number
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
                TextBoxMonths.Text = Convert.ToString(Start.properties[propNum].Months);
                TextBoxCurrentDue.Text = Convert.ToString(Start.properties[propNum].CurrentDue);
            }
        }

        //Purpose: Allows user to give the amount the tenant paye and update the current due
        //Any remaing payment is used for the next month's rent
        protected void btnPay_Click(object sender, EventArgs e)
        {
            //checks if input string is empty or
            if (TextBoxPay.Text == String.Empty)
            {
                lblPayError.Text = "Input must be made";
                return;
            }

            //checks if current property is set
            if (propNum == -1)
            {
                return;
            }

            //Pays rent
            Start.properties[propNum].payRent(Convert.ToInt32(TextBoxPay.Text));
            TextBoxCurrentDue.Text = Start.properties[propNum].CurrentDue.ToString();
            TextBoxPay.Text = "";
        }

        //Purpose: Will go back to main menu
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx", true);
        }

        //Purpose: Checks whether the string is valid for input
        Boolean checkPropInput(String input)
        {
            try
            {
                propNum = (Convert.ToInt32(input) - 1);

                //Check if input is within range
                if (propNum < 0 || propNum >= Start.maxProperties)
                {
                    lblPropError.Text = "Input is out of range";
                    return false;
                }
                //Check if current property is occupied
                else if (Start.properties[propNum].Occupied == false)
                {
                    lblPropError.Text = "Property is unoccupied";
                    btnPay.Enabled = false;
                    return false;
                }
                else
                {
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

        //Method: checkPayInput
        //Input: String from user input
        //Output: Boolean value depending on result
        //Purpose: Checks whether the string is valid for input
        Boolean checkPayInput(String input)
        {
            try
            {
                int prop = Convert.ToInt32(input);

                //Check if input is within range
                if (prop <= 0)
                {
                    lblPayError.Text = "Input must be greater than zero";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //Catches when format is incorrect
            catch (FormatException)
            {
                lblPayError.Text = "Input must be integer";
                return false;
            }
        }
    }
}