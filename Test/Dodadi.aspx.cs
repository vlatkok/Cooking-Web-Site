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
using System.IO;

public partial class Dodadi : System.Web.UI.Page
{
    String slika_baza="";
   // String video_baza="";

    protected void Page_Load(object sender, EventArgs e)
    {
        // pnlDodadi.Visible = false;
        if (!Page.IsPostBack)
        {
            if (Session["korisnik"] != null)
                pnlDodadi.Visible = true;
        }
        //////////////////////////////////////
        string UpPath1;
        UpPath1 = Server.MapPath("~") + @"\\SlikaUpload";
        if (!Directory.Exists(UpPath1))
        {
            Directory.CreateDirectory(Server.MapPath("~") + @"\\SlikaUpload\\");
        }


        string UpPath2;
        UpPath2 = Server.MapPath("~") + @"\\VideoUpload";
        if (!Directory.Exists(UpPath2))
        {
            Directory.CreateDirectory(Server.MapPath("~") + @"\\VideoUpload\\");
        }
        //////////////





    }
    protected void btnDodadiRecept_Click(object sender, EventArgs e)
    {

        String NazivRecept = txtNazivRecept.Text;
        String Recept = txtRecept.Text;
        String Korisnik = (string)Session["korisnik"]; ;
        String Slika = "";
        String Video = "";
        String Tip = DDlistTip.SelectedValue.ToString();
        DateTime vreme = DateTime.Now;
        //Label1.Text = Tip;
       // Label2.Text = vreme.ToLongDateString();
        

        {
            SqlConnection konekcija = new SqlConnection();

            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;

            komanda.CommandText = "INSERT INTO Recept (Naslov,KorisnickoIme,Tekst,Datum,Tip,Video,Slika)"
            + " VALUES( @Naslov, @KorisnickoIme, @Tekst, @Datum, @Tip, @Video, @Slika)";
            komanda.Parameters.AddWithValue("@KorisnickoIme", Korisnik);
            komanda.Parameters.AddWithValue("@Naslov", NazivRecept);
            komanda.Parameters.AddWithValue("@Tekst", Recept);
            komanda.Parameters.AddWithValue("@Datum", vreme);
            komanda.Parameters.AddWithValue("@Tip", Tip);
            komanda.Parameters.AddWithValue("@Video", lblAdresaVideo.Text);
            komanda.Parameters.AddWithValue("@Slika", lblAdresaSlika.Text);
            lblUploadPoraka.Text = "Успешен Уплоад";
            pnlDodadi.Visible = false;

            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();

            }

            catch (Exception err)
            {
                lblUploadPoraka.Text = err.Message;
            }

            finally
            {
                konekcija.Close();
                //Label1.Text = "Успешна Регистрација";
                //lblUploadPoraka.Text = "Успешен Уплоад";
                
            }

        }
    }

    protected void btnUploadSlika_Click(object sender, EventArgs e)
    {
       // FileName.InnerHtml = FileField.PostedFile.FileName;
        //FileContent.InnerHtml = FileField.PostedFile.ContentType;
        //FileSize.InnerHtml = FileField.PostedFile.ContentLength.ToString();
        lblSlikaFileName.Text=FileField.PostedFile.FileName;
        lblSlikaFileContent.Text = FileField.PostedFile.ContentType;
        lblSlikaFileSize.Text = FileField.PostedFile.ContentLength.ToString();
       // UploadDetails.Visible = true;

        string strFileName;
        strFileName = FileField.PostedFile.FileName;
        string c = System.IO.Path.GetFileName(strFileName);
      //  slika_baza =c.ToString();
       // lblAdresaSlika.Text = slika_baza;
        lblAdresaSlika.Text = "~" + "//SlikaUpload//" + c;
        try
        {
            FileField.PostedFile.SaveAs(Server.MapPath("~") + @"\\SlikaUpload\\" + c);
            lblSlikaPoraka.Text = "Сликата беше успешно уплоадирана.";
            pnlSlikaUpload.Visible = true;
        }
        catch (Exception exp)
        {
           lblSlikaPoraka.Text = "Грешка!!! Обидете се повторно.";
           pnlSlikaUpload.Visible = true;
        }
    }
    protected void btnUploadVideo_Click(object sender, EventArgs e)
    {
       // FileName.InnerHtml = FileField1.PostedFile.FileName;
       // FileContent.InnerHtml = FileField1.PostedFile.ContentType;
        //FileSize.InnerHtml = FileField1.PostedFile.ContentLength.ToString();
       // UploadDetails.Visible = true;
        lblSlikaFileName0.Text = FileField.PostedFile.FileName;
        lblSlikaFileContent0.Text = FileField.PostedFile.ContentType;
        lblSlikaFileSize0.Text = FileField.PostedFile.ContentLength.ToString();

        string strFileName0;
        strFileName0 = FileField1.PostedFile.FileName;
        string c = System.IO.Path.GetFileName(strFileName0);
        lblAdresaVideo.Text = "~" + "//VideoUpload//" + c;
        try
        {
            FileField1.PostedFile.SaveAs(Server.MapPath("~") + @"\\VideoUpload\\" + c);
            lblSlikaPoraka0.Text = "Видеото беше успешно уплоадирано.";
            pnlSlikaUpload0.Visible = true;
        }
        catch (Exception exp)
        {
            lblSlikaPoraka0.Text = "Грешка!!! Обидете се повторно.";
            pnlSlikaUpload0.Visible = true;
        }
    }
}
