using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Najava : System.Web.UI.Page
{
    String korisnik;
    string lozinka;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["korisnik"] = txtKorisnik.Text;
    }
    protected void btnVlez_Click(object sender, EventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
        string sqlString = "SELECT * FROM Korisnik WHERE Lozinka='" + txtLozinka.Text + "' AND KorisnickoIme='" + txtKorisnik.Text + "'";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            if (citac.Read())
            {
                 korisnik = citac["Ime"].ToString();
                 Session["korisnik"] = citac["KorisnickoIme"].ToString();
                 lblPoraka.Text = korisnik;
                 Session["najava"] = "Одјави се";
                 Response.Redirect("GlavnaStranica.aspx");
               
            }           
                        
            else
            {
                lblPoraka.Text = "Погрешно корисничко име или лозинка!";
                Session["najava"] = "Најави се";
                Session["korisnik"] = null;
            }
       }
        catch (Exception err)
        {
            lblPoraka.Text = err.Message;
        }
        finally
        {
            konekcija.Close();
        }
    }
}
