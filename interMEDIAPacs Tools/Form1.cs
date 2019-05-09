using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace interMEDIAPacs_Tools
{

    public partial class AnaFrom : Form
    {
      
        string constring = ConfigurationManager.ConnectionStrings["Dbcon"].ConnectionString;

        string patientid;
        int ptid;
        //string PartitionGUID;
        //string StorageGUID;
        void veridoldur()

        {
            if (checkBox1.Checked == true)
            {
                string donustur = dateTimePicker1.Value.ToString("yyyyMMdd");
                string donustur2 = dateTimePicker2.Value.ToString("yyyyMMdd");
                patientid = $"select p.ServerPartitionGUID,p.StudyStorageGUID,p.PatientId,p.PatientsName,p.StudyDate,p.AccessionNumber,p.StudyInstanceUid From Study p where p.StudyDate between {donustur} and {donustur2} order by StudyDate DESC";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(patientid, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                PatientList.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else if (textBox1.Text.Length == 0 && textBox4.Text.Length == 0)
            {
                textBox1.BackColor = Color.Red;textBox1.ForeColor = Color.White;textBox4.BackColor = Color.Red;textBox4.ForeColor = Color.White;
                MessageBox.Show("Lütfen bir Patient ID veya Accession Number Girin");
                
            }
              else  if (textBox1.Text.Length > 0)
            {
                ptid = Convert.ToInt32(textBox1.Text);
                patientid = $"select p.ServerPartitionGUID,p.StudyStorageGUID,p.PatientId,p.PatientsName,p.StudyDate,p.AccessionNumber,p.StudyInstanceUid From Study p where p.PatientId='{ptid}'";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(patientid, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                PatientList.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else if (textBox4.Text.Length > 0)
            {
                ptid = Convert.ToInt32(textBox4.Text);
                patientid = $"select p.ServerPartitionGUID,p.StudyStorageGUID,p.PatientId,p.PatientsName,p.StudyDate,p.AccessionNumber,p.StudyInstanceUid From Study p where p.AccessionNumber='{textBox4.Text}'";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(patientid, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                PatientList.DataSource = dt;
                            }
                        }
                    }
                }
            }
           


        }
       
        public AnaFrom()
        {
            InitializeComponent();
        }

        private void Bul_Click(object sender, EventArgs e)
        {

            veridoldur();
            button1.Enabled = true;
        }

        private void AnaFrom_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            DataGridViewCheckBoxColumn sec = new DataGridViewCheckBoxColumn();
            sec.HeaderText = "Seç";
            PatientList.Columns.Add(sec);
            PatientList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PatientList.AllowUserToAddRows = false;
            SqlConnection Baglantim = new SqlConnection(constring);
            try
            {
                Baglantim.Open();
                
                label1.Text = "Uzak Bağlantı Kuruldu";
            }
            catch(Exception ex)
            {
                label1.Text = "Uzak Bağlantı Kurulamadı";
                MessageBox.Show("SQL Bağlantısı Yapılamadı !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Baglantim = new SqlConnection(constring);

            Baglantim.Open();

            SqlCommand dosyakonumu = new SqlCommand();
            dosyakonumu.Connection = Baglantim;
            SqlCommand komut = new SqlCommand("DeleteStudyStorage", Baglantim);
            komut.CommandType = CommandType.StoredProcedure;
            SqlCommand dosyasil = new SqlCommand("DeleteFilesystemStudyStorage", Baglantim);
            dosyasil.CommandType = CommandType.StoredProcedure;
            List<string> secim = new List<string>();
            DataGridViewRow kayitlar = new DataGridViewRow();
            for (int i = 0; i <= PatientList.Rows.Count - 1; i++)
            {
                kayitlar = PatientList.Rows[i];
                if (Convert.ToBoolean(kayitlar.Cells[1].Value) == true) //checkbox seçiliyse 
                {
                    string PartitionGUID = kayitlar.Cells[2].Value.ToString();
                    string StorageGUID = kayitlar.Cells[3].Value.ToString();
                    string tarih = kayitlar.Cells[6].Value.ToString();
                    string klasor = kayitlar.Cells[8].Value.ToString();
                    int StatusEnum = 101;
                    string FilesystemPath;
                    secim.Add(PartitionGUID); //seçiliyse listeye ekle
                    secim.Add(StorageGUID); //seçiliyse listeye ekle                     


                    SqlParameter ServerPartitionGUID = new SqlParameter("@ServerPartitionGUID", SqlDbType.VarChar, 255);
                    ServerPartitionGUID.Direction = ParameterDirection.Input;
                    ServerPartitionGUID.Value = PartitionGUID;
                    komut.Parameters.Add(ServerPartitionGUID);

                    SqlParameter StudyStorageGUID = new SqlParameter("@StudyStorageGUID", SqlDbType.VarChar, 255);
                    StudyStorageGUID.Direction = ParameterDirection.Input;
                    StudyStorageGUID.Value = StorageGUID;
                    komut.Parameters.Add(StudyStorageGUID);

                    komut.ExecuteNonQuery();

                    SqlParameter t = new SqlParameter("@ServerPartitionGUID", SqlDbType.VarChar, 255);
                    t.Direction = ParameterDirection.Input;
                    t.Value = PartitionGUID;
                    dosyasil.Parameters.Add(t);

                    SqlParameter y = new SqlParameter("@StudyStorageGUID", SqlDbType.VarChar, 255);
                    y.Direction = ParameterDirection.Input;
                    y.Value = StorageGUID;
                    dosyasil.Parameters.Add(y);

                    SqlParameter StudyStatusEnum = new SqlParameter("@StudyStatusEnum", SqlDbType.Int, 255);
                    StudyStatusEnum.Direction = ParameterDirection.Input;
                    StudyStatusEnum.Value = StatusEnum;
                    dosyasil.Parameters.Add(StudyStatusEnum);

                    dosyakonumu.CommandText = $"SELECT FilesystemPath FROM [ImageServer].[dbo].[Filesystem]";
                    dosyakonumu.ExecuteNonQuery();
                    SqlDataReader vericek = dosyakonumu.ExecuteReader();
                    if (vericek.Read())
                    {
                        FilesystemPath = vericek["FilesystemPath"].ToString();
                        Directory.Exists(@"" + FilesystemPath + "/" + tarih + "/" + klasor);
                       // Directory.Exists(@"" + FilesystemPath + "/" + tarih + "/" + klasor) == true;
                        
                           // File.Delete(@"" + FilesystemPath + "/" + tarih + "/" + klasor);                  
                            Directory.Delete(@"" + FilesystemPath + "/Primary/" + tarih + "/" + klasor, true);
                            
                        
                        
                    }
                    vericek.Close();
                    dosyasil.ExecuteNonQuery();

                }
                komut.Parameters.Clear();
                dosyasil.Parameters.Clear();
            }
            MessageBox.Show("Kayıt Silindi");
            veridoldur();
            Baglantim.Close();
        }

        private void PatientList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;      
            }
            else if(checkBox1.Checked==false)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void cosİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 cosislemleri = new Form3();
            cosislemleri.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                veridoldur();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                veridoldur();
            }
        }

        private void baglantıAyarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 baglantiayarlari = new Form4();
            baglantiayarlari.Show();
        }
    }
}

