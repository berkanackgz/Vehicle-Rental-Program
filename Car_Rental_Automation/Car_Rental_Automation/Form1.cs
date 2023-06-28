using Npgsql;
using System.Data;

namespace Car_Rental_Automation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from personel where p_kullaniciadi='"+textBox1.Text+"' and p_sifre='"+textBox2.Text+"' and gorev_id=1";
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = sorgu;
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            if (reader.HasRows)
            {
                Form2 yonetim_ekrani = new Form2();
                this.Hide();
                yonetim_ekrani.Closed += (s, args) => this.Close();
                yonetim_ekrani.Show();
            }
            else
            {
                label4.Visible = true;
            }
        }
    }
}