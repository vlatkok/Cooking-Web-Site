using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    String korisnik;
    string lozinka;
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnNajaviSe.Text = (string)Session["najava"];
        if (!Page.IsPostBack)
        {
            //   Session["najava"] = "Најави се";
            //btnNajaviSe.Text = (string)Session["najava"];
            if (Session["korisnik"] != null)
            {
                lblKorisnik.Text = (string)Session["korisnik"];
                btnNajaviSe.Text = (string)Session["najava"];
                btnNajaviSe.Text = "Одјави се";

             if (btnNajaviSe.Text == "Одјави се")
             {
                    btnDodadi.Enabled = true;
                    btnDodadi.Visible = true;
             }
         }
            else
            {
                btnNajaviSe.Text = "Најави се";
                btnDodadi.Enabled = false;
                btnDodadi.Visible = false;
            }

            
        }
        
    }        
        
    protected void btnRegistrirajSe_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registracija.aspx");
    }
    protected void btnNajaviSe_Click(object sender, EventArgs e)
    {
        if ((btnNajaviSe.Text == "Најави се"))
        {
            Response.Redirect("Najava.aspx");
            btnNajaviSe.Visible = false;
            btnDodadi.Enabled = false;
            btnDodadi.Visible = false;

        }
        else
        {
            Session.Clear();
            //Session["korisnik"] = null;
            lblKorisnik.Text = "";
            btnNajaviSe.Text = "Најави се";
            btnDodadi.Enabled = false;
            btnDodadi.Visible = false;
            Response.Redirect("GlavnaStranica.aspx");
        }

         }
    
    protected void btnDodadi_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dodadi.aspx");
    }
}
