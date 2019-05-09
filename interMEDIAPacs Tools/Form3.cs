using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.ServiceProcess;


namespace interMEDIAPacs_Tools
{
    public partial class Form3 : Form
    {
      
        string constring = ConfigurationManager.ConnectionStrings["Dbcon"].ConnectionString;
        ServiceController teletipservisi = new ServiceController("interMEDIATeletip");
        string patientid;
        int ptid;
        string domain;
        string port;
        string dizin;
        public Form3()
        {
            InitializeComponent();
        }

        void veridoldur()

        {

            string ara;
            if (checkBox1.Checked == true)
            {
                string donustur = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string donustur2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                if (checkBox2.Checked == true)//Başarılı Olanlar
                {
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where GonderimTarihi between '{donustur}' and '{donustur2}' and GonderimMesaji LIKE '%ResponseStatusType:Success%' order by PatientId DESC";
                }
                else if (checkBox3.Checked == true)//Başarısız Olanlar
                {
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where GonderimTarihi between '{donustur}' and '{donustur2}' and GonderimMesaji LIKE '%ResponseStatusType:PartialSuccess%' order by PatientId DESC";
                }
                else if (checkBox4.Checked == true) //timeout
                {
                  patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where GonderimTarihi between '{donustur}' and '{donustur2}' and GonderimMesaji LIKE '%Timeout%' order by PatientId DESC";
                }
                else if (checkBox3.Checked==true && checkBox4.Checked==true) //hem başarısız hem timeout
                {
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where GonderimTarihi between '{donustur}' and '{donustur2}' and  GonderimMesaji LIKE '%Timeout%' OR '%ResponseStatusType:PartialSuccess%' order by PatientId DESC";
                }
                else //Seçilmezse
                {     
                patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where GonderimTarihi between '{donustur}' and '{donustur2}' order by PatientId DESC";
                }
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
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                textBox1.BackColor = Color.Red; textBox1.ForeColor = Color.White; textBox2.BackColor = Color.Red; textBox2.ForeColor = Color.White;
                MessageBox.Show("Lütfen bir Patient ID veya Accession Number Girin");
            }
            else if (textBox1.Text.Length > 0)
            {
                ptid = Convert.ToInt32(textBox1.Text);
                if (checkBox2.Checked == true)//Başarılı Olanlar
                {
                    ara = "";
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where PatientId='{ptid}'  AND GonderimMesaji LIKE '%ResponseStatusType:Success%' order by PatientId DESC";
                }
                else if (checkBox3.Checked == true)//Başarısız Olanlar
                {
                    ara = "ResponseStatusType:PartialSuccess";
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where PatientId='{ptid}'  AND GonderimMesaji LIKE '%ResponseStatusType:PartialSuccess%' order by PatientId DESC";

                }
                else if (checkBox4.Checked == true)
                {
                    ara = "Timeout";
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where PatientId='{ptid}'  AND GonderimMesaji LIKE '%Timeout%' order by PatientId DESC";

                }
                else if (checkBox3.Checked==true && checkBox4.Checked==true)
                {
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where PatientId='{ptid}'  AND GonderimMesaji LIKE '%Timeout%' OR '%ResponseStatusType:PartialSuccess%' order by PatientId DESC";
                }
                else //Seçilmezse
                {
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where PatientId='{ptid}'  order by PatientId DESC";

                }


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
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else if (textBox2.Text.Length > 0)
            {
                ptid = Convert.ToInt32(textBox2.Text);
                if (checkBox2.Checked == true)//Başarılı Olanlar
                {
                    ara = "ResponseStatusType:Success";
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where AccessionNumber='{ptid}' AND GonderimMesaji LIKE '%{ara}%' order by PatienId DESC";

                }
                else if (checkBox3.Checked == true)//Başarısız Olanlar
                {
                    ara = "ResponseStatusType:PartialSuccess";
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where AccessionNumber='{ptid}' AND GonderimMesaji LIKE '%{ara}%' order by PatienId DESC";

                }
                else if (checkBox4.Checked == true)
                {
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where AccessionNumber='{ptid}' order by PatientId DESC";

                }
                else if (checkBox2.Checked == false && checkBox3.Checked == false)//Seçilmezse
                {
                    patientid = $"select AccessionNumber,StudyInstanceUid,PatientId,KosTarihi,GonderimTarihi,GonderimMesaji From Teletip_Gonderim where AccessionNumber='{ptid}' order by PatientId DESC";
                }

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
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {


            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            DataGridViewCheckBoxColumn sec = new DataGridViewCheckBoxColumn();
            secim.HeaderText = "Seç";
            dataGridView1.Columns.Add(sec);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            XmlTextReader oku = new XmlTextReader("veri.xml");
            try
            {
                while (oku.Read())
                {
                    if (oku.NodeType == XmlNodeType.Element)
                    {
                        switch (oku.Name)
                        {
                            case "domain": domain = Convert.ToString(oku.ReadString()); break;
                            case "port": port = Convert.ToString(oku.ReadString()); break;
                            case "dizin": dizin = Convert.ToString(oku.ReadString()); break;
                        }
                    }
                }
                oku.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("XML Okunamadı");
            }

            //string patientid = $"select AccessionNumber,PatientId,KosTarihi,GonderimTarihi From Teletip_Gonderim order by ID DESC";
            //using (SqlConnection con = new SqlConnection(constring))
            //{
            //    using (SqlCommand cmd = new SqlCommand(patientid, con))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
            //            using (DataTable dt = new DataTable())
            //            {
            //                sda.Fill(dt);
            //                dataGridView1.DataSource = dt;
            //            }
            //        }
            //    }
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            veridoldur();

            label4.Text = Convert.ToString(dataGridView1.RowCount);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "Lütfen Bekleyiniz ";
            button2.Enabled = false;
            button1.Enabled = false;
            teletipservisi.Stop();
            System.Threading.Thread.Sleep(5000);
            try
            {

                using (SqlConnection Baglantim = new SqlConnection(constring))
                {

                    Baglantim.Open();
                    List<string> secim = new List<string>();

                    SqlCommand wadolinki = new SqlCommand();
                    wadolinki.Connection = Baglantim;
                    DataGridViewRow kayitlar = new DataGridViewRow();
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {

                        kayitlar = dataGridView1.Rows[i];
                        if (Convert.ToBoolean(kayitlar.Cells[1].Value) == true) //checkbox seçiliyse 
                        {
                            string accession = kayitlar.Cells[2].Value.ToString();
                            string GonderimMesaj = kayitlar.Cells[7].Value.ToString();
                            string deger;
                            string sorgu;
                            string suidc;
                            string study_iuid;
                            string series_iuid;
                            string sop_iuid;
                            if (accession.Length < 1)
                            {
                                deger = kayitlar.Cells[4].Value.ToString();
                                label4.Text = deger;
                                suidc = kayitlar.Cells[3].Value.ToString();
                                sorgu = $"DELETE FROM Teletip_Gonderim WHERE PatientId='{deger}'";
                                // Eğer patient id ile aarar ve accessionnumber yoksa ????
                                label4.Text = deger.ToString();
                                secim.Add(accession); //seçiliyse listeye ekle
                                secim.Add(GonderimMesaj); //seçiliyse listeye ekle
                                using (SqlCommand command = new SqlCommand(sorgu, Baglantim))
                                {
                                    command.ExecuteNonQuery();
                                }
                                wadolinki.CommandText = $"SELECT study_iuid, accession_no, sop_iuid, series_iuid FROM [pacsdb].[dbo].[study] st join [pacsdb].[dbo].series sr on sr.study_fk = st.pk join [pacsdb].[dbo].[instance] ins on ins.series_fk =sr.pk WHERE study_iuid='{suidc}'";
                                wadolinki.ExecuteNonQuery();
                                SqlDataReader vericek = wadolinki.ExecuteReader();
                                if (vericek.Read())
                                {
                                    study_iuid = vericek["study_iuid"].ToString();
                                    series_iuid = vericek["series_iuid"].ToString();
                                    sop_iuid = vericek["sop_iuid"].ToString();
                                    textBox3.Text = "https://" + domain + ":" + port + "/wado?requestType=WADO&studyUID=" + study_iuid + "&seriesUID=" + series_iuid + "&objectUID=" + sop_iuid + "&contentType=image%2Fjpeg&token=";
                                    System.IO.File.Delete(@"" + dizin + "" + study_iuid + ".dcm");

                                }
                                else
                                {
                                    textBox3.Text = "Wado Linki Bulunamadı";
                                }
                                vericek.Close();
                            }
                            else
                            {
                                deger = kayitlar.Cells[2].Value.ToString();
                                sorgu = $"DELETE FROM Teletip_Gonderim WHERE AccessionNumber='{deger}'";
                                label4.Text = deger.ToString();
                                secim.Add(accession); //seçiliyse listeye ekle
                                secim.Add(GonderimMesaj); //seçiliyse listeye ekle
                                using (SqlCommand command = new SqlCommand(sorgu, Baglantim))
                                {
                                    command.ExecuteNonQuery();
                                }
                                wadolinki.CommandText = $"SELECT study_iuid, accession_no, sop_iuid, series_iuid FROM [pacsdb].[dbo].[study] st join [pacsdb].[dbo].series sr on sr.study_fk = st.pk join [pacsdb].[dbo].[instance] ins on ins.series_fk =sr.pk WHERE accession_no='{deger}'";
                                wadolinki.ExecuteNonQuery();
                                SqlDataReader vericek = wadolinki.ExecuteReader();
                                if (vericek.Read())
                                {
                                    study_iuid = vericek["study_iuid"].ToString();
                                    series_iuid = vericek["series_iuid"].ToString();
                                    sop_iuid = vericek["sop_iuid"].ToString();
                                    textBox3.Text = "https://" + domain + ":" + port + "/wado?requestType=WADO&studyUID=" + study_iuid + "&seriesUID=" + series_iuid + "&objectUID=" + sop_iuid + "&contentType=image%2Fjpeg&token=";
                                    System.IO.File.Delete(@"" + dizin + "" + study_iuid + ".dcm");
                                }
                                else
                                {
                                    textBox3.Text = "Wado Linki Bulunamadı";
                                }
                                vericek.Close();
                            }

                        }
                    }
                    MessageBox.Show("Kayıt Silindi");
                    veridoldur();
                    Baglantim.Close();
                }

            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("Hata: {0}", ex.Message));
            }

            teletipservisi.Start();
            System.Threading.Thread.Sleep(5000);
            teletipservisi.Refresh();
            label3.Text = "Hazır ";
            button2.Enabled = true;
            button1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox3.Enabled = false;
            }
            else
            {
                checkBox3.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                veridoldur();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                veridoldur();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "Lütfen Bekleyiniz ";
            button2.Enabled = false;
            button1.Enabled = false;
            teletipservisi.Stop();
            System.Threading.Thread.Sleep(5000);
            try
            {

                using (SqlConnection Baglantim = new SqlConnection(constring))
                {

                    Baglantim.Open();
                    List<string> secim = new List<string>();
                    DataGridViewRow kayitlar = new DataGridViewRow();
                    SqlCommand wadolinki = new SqlCommand();
                    wadolinki.Connection = Baglantim;
                    for (int i = 0; i <= dataGridView1.Rows.Count -1; i++)
                    {
                        string accession = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        string GonderimMesaj = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        string deger;
                        string sorgu;
                        string suidc;
                        string study_iuid;
                        string series_iuid;
                        string sop_iuid;
                        if (accession.Length < 1)
                        {
                            deger = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            label4.Text = deger;
                            suidc = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            sorgu = $"DELETE FROM Teletip_Gonderim WHERE PatientId='{deger}'";
                            // Eğer patient id ile aarar ve accessionnumber yoksa ????
                            label4.Text = deger.ToString();
                            secim.Add(accession); //seçiliyse listeye ekle
                            secim.Add(GonderimMesaj); //seçiliyse listeye ekle
                            using (SqlCommand command = new SqlCommand(sorgu, Baglantim))
                            {
                                command.ExecuteNonQuery();
                            }
                            wadolinki.CommandText = $"SELECT study_iuid, accession_no, sop_iuid, series_iuid FROM [pacsdb].[dbo].[study] st join [pacsdb].[dbo].series sr on sr.study_fk = st.pk join [pacsdb].[dbo].[instance] ins on ins.series_fk =sr.pk WHERE study_iuid='{suidc}'";
                            wadolinki.ExecuteNonQuery();
                            SqlDataReader vericek = wadolinki.ExecuteReader();
                            if (vericek.Read())
                            {
                                study_iuid = vericek["study_iuid"].ToString();
                                series_iuid = vericek["series_iuid"].ToString();
                                sop_iuid = vericek["sop_iuid"].ToString();
                                textBox3.Text = "https://" + domain + ":" + port + "/wado?requestType=WADO&studyUID=" + study_iuid + "&seriesUID=" + series_iuid + "&objectUID=" + sop_iuid + "&contentType=image%2Fjpeg&token=";
                                System.IO.File.Delete(@"" + dizin + "" + study_iuid + ".dcm");
                            }
                            else
                            {
                                textBox3.Text = "Wado Linki Bulunamadı";
                            }

                            vericek.Close();
                        }
                        else
                        {
                            deger = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            sorgu = $"DELETE FROM Teletip_Gonderim WHERE AccessionNumber='{deger}'";
                            label4.Text = deger.ToString();
                            secim.Add(accession); //seçiliyse listeye ekle
                            secim.Add(GonderimMesaj); //seçiliyse listeye ekle
                            using (SqlCommand command = new SqlCommand(sorgu, Baglantim))
                            {
                                command.ExecuteNonQuery();
                            }
                            wadolinki.CommandText = $"SELECT study_iuid, accession_no, sop_iuid, series_iuid FROM [pacsdb].[dbo].[study] st join [pacsdb].[dbo].series sr on sr.study_fk = st.pk join [pacsdb].[dbo].[instance] ins on ins.series_fk =sr.pk WHERE accession_no='{deger}'";
                            wadolinki.ExecuteNonQuery();
                            SqlDataReader vericek = wadolinki.ExecuteReader();
                            if (vericek.Read())
                            {
                                study_iuid = vericek["study_iuid"].ToString();
                                series_iuid = vericek["series_iuid"].ToString();
                                sop_iuid = vericek["sop_iuid"].ToString();
                                textBox3.Text = "https://" + domain + ":" + port + "/wado?requestType=WADO&studyUID=" + study_iuid + "&seriesUID=" + series_iuid + "&objectUID=" + sop_iuid + "&contentType=image%2Fjpeg&token=";
                                System.IO.File.Delete(@"" + dizin + "" + study_iuid + ".dcm");
                            }
                            else
                            {
                                textBox3.Text = "Wado Linki Bulunamadı";
                            }
                            vericek.Close();
                        }
                    }
                    MessageBox.Show("Kayıt Silindi");
                    veridoldur();
                    Baglantim.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("Hata: {0}", ex.Message));
            }

            teletipservisi.Start();
            System.Threading.Thread.Sleep(5000);
            teletipservisi.Refresh();
            label3.Text = "Hazır ";
            button2.Enabled = true;
            button1.Enabled = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }
    }
}
