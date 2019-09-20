using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

namespace Show_Drawing
{
    public partial class OpenPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\access\Tablas.mdb";
            con = new OleDbConnection(connParam);
            System.Data.OleDb.OleDbDataAdapter da;

            OleDbCommand oleDbCmd = con.CreateCommand();
            con.Open();
            oleDbCmd = new OleDbCommand("SELECT ArtOrd FROM [Ordenes de fabricación] WHERE NumOrd = " + TextBox1.Text + "", con);

            OleDbDataReader reader;
            reader = oleDbCmd.ExecuteReader();
            //con.Close();
            if (reader.Read() && reader.FieldCount > 0)
            {
                string UID = TextBox1.Text;
                string Article = reader["ArtOrd"].ToString();
                try
                {

                    //string Article = Request.QueryString["Article"];
                    if (Article.Length > 6)
                    {
                        //string strFilepath = "W:\\test\\Access\\Planos\\" + Article.Substring(0, 6) + "\\" + Article + ".PC.pdf";
                        string strFilepath = @"W:\test\Access\Planos\" + Article.Substring(0, 6) + "\\" + Article + ".PC.pdf";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "pdfwindow", "window.open('" + strFilepath + "','_blank','width=500,height=600');", true);
                    }
                }
                catch
                {

                }

            }
        }
    }
}