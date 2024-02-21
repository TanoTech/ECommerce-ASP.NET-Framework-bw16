using System;
using System.Web.UI;

namespace BW16C
{
    public partial class Checkout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("Pagamento.aspx");
            }
        }
    }
}
