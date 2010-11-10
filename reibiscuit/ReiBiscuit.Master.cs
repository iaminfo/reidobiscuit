using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace reibiscuit
{
    public partial class ReiBiscuit : System.Web.UI.MasterPage
    {
        public HtmlGenericControl DivMensagem { get { return divMensagem; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}