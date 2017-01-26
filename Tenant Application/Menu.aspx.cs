//Name: Sean Pador
//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: App for Rental Properties that is web based. This program acts as the menu for the app
//Language: C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tenant_Application
{
    public partial class Menu : System.Web.UI.Page
    {

        // Load menu page
        protected void Page_Load(object sender, EventArgs e)
        {
            //makes options available depending on whether there are tenants
            if (Start.myTenants.Count == 0)
            {
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
                btnAdvance.Enabled = false;
                btnRent.Enabled = false;
            }

            //Removes the add option if when the maximum amount of tenants is reached
            if (Start.myTenants.Count == Start.maxProperties)
            {
                btnAdd.Enabled = false;
            }

            //Makes the controls for rent unavailable
            TextBoxRent.Visible = false;
            btnEnter.Visible = false;
            lblRent.Visible = false;
        }

        //Purpose: Redirects to add page
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("Add.aspx", true);
        }

        //Purpose: Redirects to remove page
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Server.Transfer("Remove.aspx", true);
        }

        //Purpose: Redirects to update page
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Server.Transfer("Update.aspx", true);
        }

        //Purpose: Advances the month of all tenants
        protected void btnAdvance_Click(object sender, EventArgs e)
        {
            //Advances months and adds current debt of all tenants
            for (int count = 0; count < Start.maxProperties; count++)
            {
                if (Start.properties[count].Occupied == true)
                {
                    Start.properties[count].nextMonth(Start.rent);
                }

            }
            lblEvent.Text = "Month has been advanced";
        }

        //Purpose: Redirects to rent page
        protected void btnRent_Click(object sender, EventArgs e)
        {
            Server.Transfer("PayRent.aspx", true);
        }

        //Purpose: Redirects to search page
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Server.Transfer("Search.aspx", true);
        }

        //Purpose: Redirects to display page
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            Server.Transfer("Display.aspx", true);
        }

        //Purpose: Makes visible options that will allow the player to change rent
        protected void btnChRent_Click(object sender, EventArgs e)
        {
            TextBoxRent.Visible = true;
            btnEnter.Visible = true;
            lblRent.Visible = true;
            lblRent.Text = "The current monthly Rent is " + Start.rent.ToString();
        }

        //Purpose: Confirms the value change of rent by the user
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            //Checks if textbox is empty
            if (TextBoxRent.Text != string.Empty)
            {
                //Checks if input is valid
                if (checkRentInput(TextBoxRent.Text))
                {
                    Start.rent = Convert.ToInt32(TextBoxRent.Text);
                    lblEvent.Text = "Rent has been changed";
                }

                //makes the controls exclusive to event invisible again
                TextBoxRent.Text = "";
                TextBoxRent.Visible = false;
                btnEnter.Visible = false;
                lblRent.Visible = false;
            }
        }

        //Purpose: Checks whether the string is valid for input
        Boolean checkRentInput(String input)
        {
            try
            {
                int prop = Convert.ToInt32(input);

                //Check if input is in valid range
                if (prop < 0)
                {
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
                return false;
            }
        }
    }
}