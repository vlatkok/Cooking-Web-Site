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

public partial class Registracija : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected bool VekjePostoecki(string ime, string email)
    {
        lblErrorKIme.Text = "";
        lblErrorEmail.Text = "";
        string username;
        string emaila;
        bool PostoeckiKorisnik = false;
        SqlConnection konekcija2 = new SqlConnection();
        konekcija2.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
        SqlCommand komanda2 = new SqlCommand();
        komanda2.Connection = konekcija2;
        komanda2.CommandText = "SELECT * FROM Korisnik WHERE KorisnickoIme='" + ime + "' OR Email='" + email + "'";
        try
        {
            konekcija2.Open();
            komanda2.ExecuteNonQuery();
            SqlDataReader citac = komanda2.ExecuteReader();
            if (citac.Read())
            {
                PostoeckiKorisnik = true;
                emaila = citac["Email"].ToString();
                username = citac["KorisnickoIme"].ToString();
                citac.Close();
                emaila = emaila.Trim();
                username = username.Trim();
                if (username == ime)
                    lblErrorKIme.Text = "Веќе постоечко корисничко име!";
                if (emaila == email)
                    lblErrorEmail.Text = "Веќе постоечка адреса";
            }

        }

        catch (Exception err)
        {
            lblPoraka.Text = err.Message;
        }

        finally
        {
            konekcija2.Close();

        }
        return PostoeckiKorisnik;
    }

    protected void btnRegistrirajMe_Click(object sender, EventArgs e)
    {
        lblPoraka.Text = "";
        bool VPK = VekjePostoecki(txtKIme.Text, txtEmail.Text);
        if (!VPK)
        {
            SqlConnection konekcija = new SqlConnection();
            //SqlConnection konekcija2 = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            //konekcija2.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();

            komanda.Connection = konekcija;

            komanda.CommandText = "INSERT INTO Korisnik (KorisnickoIme,Ime,Prezime,Lozinka,Email) VALUES(@KorisnickoIme,@Ime,@Prezime,@Lozinka,@Email)";
            komanda.Parameters.AddWithValue("@KorisnickoIme", txtKIme.Text);
            komanda.Parameters.AddWithValue("@Ime", txtIme.Text);
            komanda.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            komanda.Parameters.AddWithValue("@Email", txtEmail.Text);
            komanda.Parameters.AddWithValue("@Lozinka", txtLozinka.Text);
            
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();

            }

            catch (Exception err)
            {
                lblPoraka.Text = err.Message;
            }

            finally
            {
                konekcija.Close();
                lblPoraka.Text = "Успешна Регистрација";
                lblErrorEmail.Text = "Честито!!!!";
                txtKIme.Text = "";
                txtLozinka.Text = "";
                txtLozinka2.Text = "";
                txtIme.Text = "";
                txtPrezime.Text = "";
                txtEmail.Text = "";
            }

        }
        //else
        // lblErrorEmail.Text = "Aman vise";
    }
}
