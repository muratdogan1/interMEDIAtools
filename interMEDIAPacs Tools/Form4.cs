using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace interMEDIAPacs_Tools
{
    public partial class Form4 : Form
    {

        string ip;
        string database;
        string kullanici;
        string sifre;
      
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] veriByteDizisi = System.Text.ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
            byte[] veriByteDizisi2 = System.Text.ASCIIEncoding.ASCII.GetBytes(textBox2.Text);
            byte[] veriByteDizisi3 = System.Text.ASCIIEncoding.ASCII.GetBytes(textBox3.Text);
            byte[] veriByteDizisi4 = System.Text.ASCIIEncoding.ASCII.GetBytes(textBox4.Text);
            string ccc = System.Convert.ToBase64String(veriByteDizisi);
            string ccc2 = System.Convert.ToBase64String(veriByteDizisi2);
            string ccc3 = System.Convert.ToBase64String(veriByteDizisi3);
            string ccc4 = System.Convert.ToBase64String(veriByteDizisi4);

            //SHA1 sifrele = new SHA1CryptoServiceProvider();
            //string SifrelenecekVeri = textBox1.Text;
            //string SifreliVeri = Convert.ToBase64String(sifrele.ComputeHash(Encoding.UTF8.GetBytes(SifrelenecekVeri)));
            //string SifreliVeri2 = Convert.ToBase64String(sifrele.ComputeHash(Encoding.UTF8.GetBytes(textBox2.Text)));
            //string SifreliVeri3 = Convert.ToBase64String(sifrele.ComputeHash(Encoding.UTF8.GetBytes(textBox3.Text)));
            //string SifreliVeri4 = Convert.ToBase64String(sifrele.ComputeHash(Encoding.UTF8.GetBytes(textBox4.Text)));
            XDocument x = XDocument.Load(@"veri.xml");

            x.Element("ayarlar").Add(
            new XElement("sunucu",
            new XElement("ip", ccc),
            new XElement("database", ccc2),
            new XElement("kullanici", ccc3),
            new XElement("sifre", ccc4)
            ));
            x.Save(@"veri.xml");
            label5.Text = ccc;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextReader oku = new XmlTextReader("veri.xml");
            try
            {
                while (oku.Read())
                {
                    if (oku.NodeType == XmlNodeType.Element)
                    {
                        switch (oku.Name)
                        {
                            case "ip": ip = Convert.ToString(oku.ReadString()); break;
                            case "database": database = Convert.ToString(oku.ReadString()); break;
                            case "kullanici": kullanici = Convert.ToString(oku.ReadString()); break;
                            case "sifre": sifre = Convert.ToString(oku.ReadString()); break;
                        }
                    }
                }
                oku.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("XML Okunamadı");
            }
            byte[] cozByteDizi = System.Convert.FromBase64String(ip);
            byte[] db = System.Convert.FromBase64String(database);
            byte[] kul = System.Convert.FromBase64String(kullanici);
            byte[] sif = System.Convert.FromBase64String(sifre);
            string orjinalVeri = System.Text.ASCIIEncoding.ASCII.GetString(cozByteDizi);
            string orjinalVeri1 = System.Text.ASCIIEncoding.ASCII.GetString(db);
            string orjinalVeri2 = System.Text.ASCIIEncoding.ASCII.GetString(kul);
            string orjinalVeri3 = System.Text.ASCIIEncoding.ASCII.GetString(sif);
            label5.Text = orjinalVeri;
            label6.Text = orjinalVeri1;
            label7.Text = orjinalVeri2;
            label8.Text = orjinalVeri3;
        

        }
    }
}
