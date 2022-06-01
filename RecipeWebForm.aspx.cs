using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace Shavuot
{
    public partial class RecipeWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]//כותבים את השורה הזאת כדי שיכיר את הפעולה מהג'ווה סקריפט
        public static string getRecipes()
        {
            OleDbConnection myCon = new OleDbConnection(Connect.GetConnectionString());
            OleDbCommand cmd = new OleDbCommand("spGetRecipe", myCon);
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(""); //StringBuilder חוסך מקום בזיכרון ואז יהיה יותר מהיר
            try
            {
                da.Fill(ds, "DataSet-Recipes");
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0]; //יש רק טבלה אחת
                    sb.Append("<table dir='rtl'><tr>");
                    foreach (DataRow dr in dt.Rows)
                    {
                        sb.Append("<td>");
                        sb.Append("<img src='" + dr["ImageUrl"].ToString() + "' border='0'>");
                        sb.Append("<br/>" + dr["RecipeName"].ToString());
                        sb.Append("</td>");
                    }
                    sb.Append("</tr></table>");
                }
            }
           
            catch (Exception ex)
            {
                throw ex;
            }

            return sb.ToString();
        }
    }
}