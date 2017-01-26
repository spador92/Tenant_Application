//Name: Sean Pador
//Project Name: Tenant Application
//Project Info: App for Rental Properties that is web based. This program displays the tenants.
//Language: C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tenant_Application
{
    public partial class Display : System.Web.UI.Page
    {
        //Purpose: Load display page
        protected void Page_Load(object sender, EventArgs e)
        {
            //displays the tenants of the collection
            foreach (var x in Start.myTenants)
            {
                ListBoxTenants.Items.Add(string.Format("Name: {0} {1} Current Due: {2:c}", x.FirstName, x.LastName, x.CurrentDue));
            }
        }

        //Purpose: Redirects back to menu page
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx", true);
        }
    }
}