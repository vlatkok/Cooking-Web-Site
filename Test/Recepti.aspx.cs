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

public partial class Recepti : System.Web.UI.Page
{
  
    String ZaRecept="";
    string najava="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string tip = (string)Request.QueryString["tip"];
      
        if (!Page.IsPostBack)
        {
            Panel1.Visible = false;
            najava = (string)Session["najava"];


            if (najava != "Одјави се" || gvRecepti.SelectedIndex == -1)
            {
                PanelKomentar.Visible = false;
                //tip = (string)Request.QueryString["tip"];
                //lblTest.Text = (string)Request.QueryString["tip"];
            }




            if (najava == "Одјави се" && gvRecepti.SelectedIndex != -1)
            {
                PanelKomentar.Visible = true;
                tip = (string)Request.QueryString["tip"];
                lblTest.Text = (string)Request.QueryString["tip"];
            }


           

        }


       
          
        

     
        
        Ispolni(tip);
        
    }

    protected void Ispolni(string tip)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "SELECT Naslov, KorisnickoIme, Datum, ID FROM Recept WHERE Tip='" + tip + "'";
        //komanda.CommandText = "SELECT Naslov, KorisnickoIme, Datum FROM Recept ";
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Recepti");
            gvRecepti.DataSource = ds;
            gvRecepti.DataBind();
            ViewState["dataset"] = ds;
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
    protected void gvRecepti_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        PanelKomentar.Visible = true;
        lstListaSoKomentari.Items.Clear();
        String ID = gvRecepti.SelectedRow.Cells[1].Text;
        lblNaslov.Text = gvRecepti.SelectedRow.Cells[2].Text.ToUpper();

        ViewState["ID"] = Convert.ToInt32(gvRecepti.SelectedRow.Cells[1].Text);

      //  string naslovotNaReceptot = gvRecepti.SelectedRow.Cells[2].Text.ToString();

        lblAploader.Text = gvRecepti.SelectedRow.Cells[3].Text;
        lblDatum.Text = gvRecepti.SelectedRow.Cells[4].Text;
        lblTest.Text = gvRecepti.SelectedRow.Cells[2].Text;
        
        popolniRecept(ID);

        IspolniKomentari((int)ViewState["ID"]);


        najava = (string)Session["najava"];
        if (najava != "Одјави се" && gvRecepti.SelectedIndex != -1)
        {

            btnZacuvajKomentar.Visible = false;
            txtKomentarot.Visible = false;
            TextBox1.Visible = false;
                TextBox2.Visible=false;
            Button1.Visible = false;
        }

       // String slikaUrl = gvRecepti.SelectedRow.Cells[5].Text;
        //lblTest.Text = gvRecepti.SelectedRow.Cells[5].Text;

        //Image1.ImageUrl = slikaUrl;
     
    }
    protected void popolniRecept(string ID)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "SELECT ID,Naslov, KorisnickoIme, Slika, Datum, Tekst,Video FROM Recept WHERE ID='" + ID + "'";
        //komanda.CommandText = "SELECT Naslov, KorisnickoIme, Datum FROM Recept ";
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            if (citac.Read())
            {
                txtRecept.Text = citac["Tekst"].ToString();
                Image1.ImageUrl = citac["Slika"].ToString();
                WindowsMedia1.VideoURL = citac["Video"].ToString();
                citac.Close();
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

    protected void gvRecepti_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRecepti.PageIndex = e.NewPageIndex;
        gvRecepti.SelectedIndex = -1;
        DataSet ds = (DataSet)ViewState["dataset"];
        gvRecepti.DataSource = ds;
        gvRecepti.DataBind();
    }

    protected void IspolniKomentari(int ReceptID)
    {
        lstListaSoKomentari.Items.Clear();

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
        string sqlString = "SELECT KorisnickoIme,Tekst,Datum,ReceptID FROM Komentar WHERE ReceptID='" +ReceptID+ "'";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);

        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            
            while (citac.Read())
            {

                ListItem element1 = new ListItem();
                ListItem element2 = new ListItem();
                element1.Text = citac["KorisnickoIme"].ToString() + "  " + citac["Datum"].ToString();
                element2.Text = citac["Tekst"].ToString();
               
                lstListaSoKomentari.Items.Add(element1);
                lstListaSoKomentari.Items.Add(element2);
            }
            citac.Close();           
        }
          
        catch (Exception err)
        {
           lblPorakaKomentar.Text = err.Message;
        }
        finally
        { 
            konekcija.Close(); 
        }
    }

    protected void btnZacuvajKomentar_Click(object sender, EventArgs e)
    {
        String tekstkomentar =txtKomentarot.Text;
        String Korisnik = (string)Session["korisnik"];           
        DateTime vreme = DateTime.Now;
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "INSERT INTO Komentar (KorisnickoIme,Tekst,Datum,ReceptID)"
        + " VALUES(@KorisnickoIme, @Tekst, @Datum,@ReceptID)";
        komanda.Parameters.AddWithValue("@KorisnickoIme", Korisnik);
        komanda.Parameters.AddWithValue("@Tekst", tekstkomentar);
        komanda.Parameters.AddWithValue("@Datum", vreme);
        komanda.Parameters.AddWithValue("@ReceptID",(int)ViewState["ID"]);

        lblPorakaKomentar.Text = "Успешен уплоад на коментарот";

        try
        {
            konekcija.Open();
            komanda.ExecuteNonQuery();

        }

        catch (Exception err)
        {
            lblPorakaKomentar.Text = err.Message;
        }

        finally
        {
            konekcija.Close();
        }
        txtKomentarot.Text = "";
        IspolniKomentari((int)ViewState["ID"]);
     }

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtKomentarot.Text = "";
    }
}
