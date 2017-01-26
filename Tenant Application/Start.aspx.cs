//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: App for Rental Properties that is web based. This program is used to set up the array,
//collection and the initial rent that will be used.
//Language: C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tenant_Application
{    
    public partial class Start : System.Web.UI.Page
    {
        public static int maxProperties;
        public static Property[] properties;
        public static int rent;
        public static List<Property> myTenants = new List<Property>();

        //Load start menu
        protected void Page_Load(object sender, EventArgs e)
        {
            //Makes all warning labels read
            lblPropError.ForeColor = System.Drawing.Color.Red;
            lblError.ForeColor = System.Drawing.Color.Red;
            lblRentError.ForeColor = System.Drawing.Color.Red;

            //Clears all Warning labels
            lblPropError.Text = "";
            lblError.Text = "";
            lblRentError.Text = "";
        }

        //Redirects to menu page when all necessary inputs are made.
        protected void btnProp_Click(object sender, EventArgs e)
        {
            //Checks if input is made
            if (TextBoxProp.Text == string.Empty || TextBoxRent.Text == string.Empty)
            {
                lblError.Text = "All inputs must be filled";
                return;
            }

            //Checks if input are vaild
            if( !checkPropInput(TextBoxProp.Text) || !checkRentInput(TextBoxRent.Text))
            {
                return;
            }
                else
                {
                    //Set up size of array, set up collection, and set rent due
                    maxProperties = Convert.ToInt32(TextBoxProp.Text);                    
                    properties = new Property[maxProperties];
                    rent = Convert.ToInt32(TextBoxRent.Text);

                    //Initialize all elements of array.
                    for(int count = 0; count < maxProperties; count++)
                    {
                        properties[count] = new Property();
                    }

                    //Redirect to menu screen when all is successful
                    Server.Transfer("Menu.aspx", true);
                }
            
        }

        //Checks whether the string is valid for input
        Boolean checkPropInput(String input)
        {
            //Check if input is an integer
            try
            {
                int prop = Convert.ToInt32(input);

                //Check if current property is occupied
                if (prop <= 0)
                {
                    lblPropError.Text = "Input must be greater than zero";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                lblPropError.Text = "Input must be integer";
                return false;
            }
        }

        //Checks whether the string is valid for input
        Boolean checkRentInput(String input)
        {
            //Check if input is an integer
            try
            {
                int prop = Convert.ToInt32(input);

                if (prop < 0)
                {
                    lblRentError.Text = "Input cannot be negative";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                lblRentError.Text = "Input must be integer";
                return false;
            }
        }
    }
}