using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Car_Rental_Automation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select araba_id,ama.a_marka_adi,amo.a_model_adi,r.renk_adi,att.a_arac_tipi,arac_yasi,yt.yakit_turu,a_kira_id from arabalar ar inner join araba_markalari ama on ar.a_marka_id=ama.a_marka_id inner join araba_modelleri amo on ar.a_model_id=amo.a_model_id inner join renkler r on ar.renk_id=r.renk_id inner join araba_tipi att on ar.a_tipi_id=att.a_tipi_id inner join yakit_turu yt on ar.yakit_id=yt.yakit_id";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (marka_combo.SelectedIndex == 0)
            {
                model_combo.Items.Clear();
                model_combo.Items.Insert(0, "A3");
                model_combo.Items.Insert(1, "A4");
            }
            else if (marka_combo.SelectedIndex == 1)
            {
                model_combo.Items.Clear();
                model_combo.Items.Insert(0, "-----");
                model_combo.Items.Insert(1, "-----");
                model_combo.Items.Insert(2, "320");
                model_combo.Items.Insert(3, "520");
            }
            else if (marka_combo.SelectedIndex == 2)
            {
                model_combo.Items.Clear();
                model_combo.Items.Insert(0, "-----");
                model_combo.Items.Insert(1, "-----");
                model_combo.Items.Insert(2, "-----");
                model_combo.Items.Insert(3, "-----");
                model_combo.Items.Insert(4, "CLA 200");
                model_combo.Items.Insert(5, "A180");
            }
            else if (marka_combo.SelectedIndex == 3)
            {
                model_combo.Items.Clear();
                model_combo.Items.Insert(0, "-----");
                model_combo.Items.Insert(1, "-----");
                model_combo.Items.Insert(2, "-----");
                model_combo.Items.Insert(3, "-----");
                model_combo.Items.Insert(4, "-----");
                model_combo.Items.Insert(5, "-----");
                model_combo.Items.Insert(6, "Egea");
                model_combo.Items.Insert(7, "Fiorino");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "insert into arabalar values(DEFAULT,"+(marka_combo.SelectedIndex+1)+","+(model_combo.SelectedIndex+1)+","+(renk_combo.SelectedIndex+1)+","+(tipi_combo.SelectedIndex+1)+","+Convert.ToInt32(yili_combo.Value)+","+(yakit_combo.SelectedIndex+1)+")";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
            groupBox1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select araba_id,ama.a_marka_adi,amo.a_model_adi,r.renk_adi,att.a_arac_tipi,arac_yasi,yt.yakit_turu,a_kira_id from arabalar ar inner join araba_markalari ama on ar.a_marka_id=ama.a_marka_id inner join araba_modelleri amo on ar.a_model_id=amo.a_model_id inner join renkler r on ar.renk_id=r.renk_id inner join araba_tipi att on ar.a_tipi_id=att.a_tipi_id inner join yakit_turu yt on ar.yakit_id=yt.yakit_id";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
            groupBox1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select * from personel";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
            groupBox1.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select scooter_id,sma.s_marka_adi,smo.s_model_adi,r.renk_adi,yt.yakit_turu,s_kira_id from scooterlar sc inner join scooter_markalari sma on sc.s_marka_id=sma.s_marka_id inner join scooter_modelleri smo on sc.s_model_id=smo.s_model_id inner join renkler r on sc.renk_id=r.renk_id inner join yakit_turu yt on sc.yakit_id=yt.yakit_id";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
            groupBox1.Visible = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
                baglanti.Open();
                NpgsqlCommand baglantiCommand = new NpgsqlCommand();
                baglantiCommand.Connection = baglanti;
                baglantiCommand.CommandType = CommandType.Text;
                baglantiCommand.CommandText = "delete from arabalar where araba_id=" + Convert.ToInt32(sil_numeric_id.Value);
                NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select * from personel where p_id=" + Convert.ToInt32(numericUpDown1.Value);
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count>0)
            {
                label15.Visible = false;
                textBox1.Text = dt.Rows[0]["p_ad_soyad"].ToString();
                textBox2.Text = dt.Rows[0]["p_tc_no"].ToString();
                textBox3.Text = dt.Rows[0]["gorev_id"].ToString();
                textBox6.Text = dt.Rows[0]["p_telefon"].ToString();
                textBox5.Text = dt.Rows[0]["p_kullaniciadi"].ToString();
                textBox4.Text = dt.Rows[0]["p_sifre"].ToString();
            }
            else
            {
                label15.Visible = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "update personel set p_ad_soyad='"+textBox1.Text+"', p_tc_no="+textBox2.Text+", gorev_id="+textBox3.Text+", p_telefon='"+textBox6.Text+"', p_kullaniciadi='"+textBox5.Text+"', p_sifre='"+textBox4.Text+"' where p_id="+Convert.ToInt32(numericUpDown1.Value)+";";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.CommandText = "select*from personel where p_id=" + Convert.ToInt32(numericUpDown1.Value);
            reader=baglantiCommand.ExecuteReader();
            dt.Rows.Clear();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
            groupBox3.Visible = false;

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Insert(0, "PCX 150");
                comboBox4.Items.Insert(1, "PCX 125");
            }
            else if (comboBox5.SelectedIndex == 1)
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Insert(0, "--");
                comboBox4.Items.Insert(1, "--");
                comboBox4.Items.Insert(2, "Tricity 155");
                comboBox4.Items.Insert(3, "X-MAX 250");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "insert into scooterlar values(DEFAULT," + (comboBox5.SelectedIndex + 1) + "," + (comboBox4.SelectedIndex + 1) + "," + (comboBox3.SelectedIndex + 1) + "," + (comboBox1.SelectedIndex + 1) +")";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
            groupBox4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void kirala_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kirala_button_Click(object sender, EventArgs e)
        {
            if (kirala_combo.SelectedIndex==0)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
                baglanti.Open();
                NpgsqlCommand baglantiCommand = new NpgsqlCommand();
                baglantiCommand.Connection = baglanti;
                baglantiCommand.CommandType = CommandType.Text;
                baglantiCommand.CommandText = "update arabalar set a_kira_id=1 where araba_id=" + Convert.ToInt32(arac_id_kirala.Value) + ";";
                NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                baglantiCommand.CommandText = "select araba_id,ama.a_marka_adi,amo.a_model_adi,r.renk_adi,att.a_arac_tipi,arac_yasi,yt.yakit_turu,a_kira_id from arabalar ar inner join araba_markalari ama on ar.a_marka_id=ama.a_marka_id inner join araba_modelleri amo on ar.a_model_id=amo.a_model_id inner join renkler r on ar.renk_id=r.renk_id inner join araba_tipi att on ar.a_tipi_id=att.a_tipi_id inner join yakit_turu yt on ar.yakit_id=yt.yakit_id";
                reader = baglantiCommand.ExecuteReader();
                dt.Rows.Clear();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                baglantiCommand.Dispose();
                baglanti.Close();
                groupBox5.Visible = false;
            }
            else if (kirala_combo.SelectedIndex==1)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
                baglanti.Open();
                NpgsqlCommand baglantiCommand = new NpgsqlCommand();
                baglantiCommand.Connection = baglanti;
                baglantiCommand.CommandType = CommandType.Text;
                baglantiCommand.CommandText = "update scooterlar set s_kira_id=1 where scooter_id=" + Convert.ToInt32(arac_id_kirala.Value) + ";";
                NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                baglantiCommand.CommandText = "select scooter_id,sma.s_marka_adi,smo.s_model_adi,r.renk_adi,yt.yakit_turu,s_kira_id from scooterlar sc inner join scooter_markalari sma on sc.s_marka_id=sma.s_marka_id inner join scooter_modelleri smo on sc.s_model_id=smo.s_model_id inner join renkler r on sc.renk_id=r.renk_id inner join yakit_turu yt on sc.yakit_id=yt.yakit_id";
                reader = baglantiCommand.ExecuteReader();
                dt.Rows.Clear();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                baglantiCommand.Dispose();
                baglanti.Close();
                groupBox5.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select aracsayisi()";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select scootersayisi()";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select totalarac()";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;Database=kiralama_sistemi;User Id=postgres;Password=12345;");
            baglanti.Open();
            NpgsqlCommand baglantiCommand = new NpgsqlCommand();
            baglantiCommand.Connection = baglanti;
            baglantiCommand.CommandType = CommandType.Text;
            baglantiCommand.CommandText = "select benzinliarac()";
            NpgsqlDataReader reader = baglantiCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            baglantiCommand.Dispose();
            baglanti.Close();
        }
    }
}
