using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

using System.Drawing.Imaging;
using PQScan.PDFToImage;
using Spire.Pdf;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace Show_Drawing
{
    public partial class _Default : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd;
        private OleDbCommand oleDbCmd = new OleDbCommand();
        String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\access\Tablas.mdb";
        OleDbDataAdapter da;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
            TextBox1.Attributes["onfocus"] = "javascript:this.select();";
            con = new OleDbConnection(connParam);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                string script = "alert('Please Enter UID!!!')";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button1, this.GetType(), "Test", script, true);
            }
            else
            {
                DataTable dt = new DataTable();
                //currency_check(dt);
                System.Data.OleDb.OleDbDataAdapter da;

                OleDbCommand oleDbCmd = con.CreateCommand();
                con.Open();
                oleDbCmd = new OleDbCommand("SELECT ArtOrd FROM [Ordenes de fabricación] WHERE NumOrd = " + TextBox1.Text + "", con);

                OleDbDataReader reader;
                reader = oleDbCmd.ExecuteReader();
                if (reader.Read() && reader.FieldCount > 0)
                {
                    string UID = TextBox1.Text;
                    string Article = reader["ArtOrd"].ToString();
                    try
                    {

                        //string Article = Request.QueryString["Article"];
                        if (Article.Length > 6)
                        {

                            string pdfpath = "W:\\test\\Access\\Planos\\" + Article.Substring(0, 6) + "\\" + Article + ".PC.pdf";
                            if (File.Exists(pdfpath))
                            {
                                PdftoIMG(pdfpath);
                                Image1.ImageUrl = "~/Images/UIDimage/New.jpg";
                            }

                            else
                            {
                                Image1.ImageUrl = "~/Images/draft.jpg";

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
                else
                {
                    string script = "alert('UID does not exist!!!')";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button1, this.GetType(), "Test", script, true);
                }
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string UID = Request.QueryString["UID"];
            string Drawing = Request.QueryString["Drawing"];
            PdfDocument doc = new PdfDocument();
            PdfSection section = doc.Sections.Add();
            PdfPageBase page = doc.Pages.Add();
            Spire.Pdf.Graphics.PdfImage image = Spire.Pdf.Graphics.PdfImage.FromFile(Server.MapPath("~/Images/UIDimage/New.jpg"));


            float widthFitRate = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width;
            float heightFitRate = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height;
            float fitRate = Math.Max(widthFitRate, heightFitRate);
            float fitWidth = image.PhysicalDimension.Width / fitRate;
            float fitHeight = image.PhysicalDimension.Height / fitRate;

            //page.Canvas.DrawImage(image, 0, 0, fitWidth, fitHeight);
            page.Canvas.DrawImage(image, -6, 0, fitWidth + 20, fitHeight + 70);

            doc.SaveToFile(Server.MapPath("~/Images/New.pdf"));
            doc.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + TextBox1.Text + ".pdf");
            Response.TransmitFile(Server.MapPath("~/Images/New.pdf"));
            Response.End();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                string script = "alert('Please Enter UID!!!')";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button2, this.GetType(), "Test", script, true);
            }
            else
            {
                DataTable dt = new DataTable();
                System.Data.OleDb.OleDbDataAdapter da;

                OleDbCommand oleDbCmd = con.CreateCommand();
                con.Open();
                oleDbCmd = new OleDbCommand("SELECT ArtOrd FROM [Ordenes de fabricación] WHERE NumOrd = " + TextBox1.Text + "", con);

                OleDbDataReader reader;
                reader = oleDbCmd.ExecuteReader();
                if (reader.Read() && reader.FieldCount > 0)
                {
                    string UID = TextBox1.Text;
                    string Article = reader["ArtOrd"].ToString();
                    try
                    {
                        if (Article.Length > 6)
                        {

                            string pdfpath = "W:\\test\\Access\\Planos\\" + Article.Substring(0, 6) + "\\" + Article + ".PT"+".pdf";
                            if (File.Exists(pdfpath))
                            {

                                PdftoIMG(pdfpath);
                                Image1.ImageUrl = "~/Images/UIDimage/New.jpg";
                            }

                            else
                            {
                                Image1.ImageUrl = "~/Images/draft.jpg";

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
                else
                {
                    string script = "alert('UID does not exist!!!')";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button2, this.GetType(), "Test", script, true);
                }
            }
        }

        void PdftoIMG(string pdfpath)
        {
            Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
            pdfdocument.LoadFromFile(pdfpath);
            System.Drawing.Image image = pdfdocument.SaveAsImage(0, 96, 96);
            image.Save(string.Format(Server.MapPath("~/Images/UIDimage/New.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg));
        }
    }
}
