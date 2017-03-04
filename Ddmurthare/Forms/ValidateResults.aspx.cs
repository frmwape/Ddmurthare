using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ddmurthare.App_Code.PeriodicTable;

namespace Ddmurthare.Forms
{
    public partial class ValidateResults : System.Web.UI.Page
    {
        private string strElement;
        private string strSymbol;
        private string strValidateResult;

        public string ValidateResult { get { return strValidateResult; } }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            strElement = Request.Form["elementVal"];
            strSymbol = Request.Form["symbolVal"];

            if (strElement == null)
                strElement = "";

            if (strSymbol == null)
                strSymbol = "";

            /*
             Display results if desired, output display is irrelevant as one can choose a windows form, web form etc. I’ve chosen to use a quick put together web form to test and see my results - FCM
             */
            clsValidateRules objValidateRules = new clsValidateRules(strElement, strSymbol);
            objValidateRules.ProcessValidation();

            strValidateResult = "Element: (" + objValidateRules.OutputElement + "), Symbol: (" + objValidateRules.OutputSymbol + ") -> Valid: (" + objValidateRules.ValidOutputResult.ToString().ToLower() + ")<br />" + objValidateRules.OutputValidateErrors;

            objValidateRules.Dispose();
            objValidateRules = null;


        }
    }
}