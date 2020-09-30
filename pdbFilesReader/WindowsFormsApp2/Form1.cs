using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            button1.Click += new System.EventHandler(HandeAras);//butona tıklandığında bu metoda git.
            
        }
        public void HandeAras(object sender,EventArgs e)
        {
            MessageBox.Show("Verileriniz Derlendi.");
            button1.Enabled = false;//butonu etkisiz kıl
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDB Dosyası(*.pdb) |*.pdb";//pdb dosyası ile gözat ı filtrele
            if(openFileDialog1.ShowDialog() == DialogResult.OK) //eğer dosya seçildiyse
            {
                FileInfo eskişehir = new FileInfo(openFileDialog1.FileName.ToString());//dosya bilgisini al 
                StreamReader oku = eskişehir.OpenText();//dosyayı oku
                string satır = oku.ReadLine();//dosyayı satır satır oku ve satıra eşitle
                string ara = "ATOM";//atom ile başlayan metin kısmını bulmak için değişken

                while (satır != null)//satır doluysa gir
                {

                    if(satır.StartsWith(ara))//eğer ara yani ATOM  ile başlarsa gir
                    {
                        string gecici = satır.Replace(ara, "");//string döndür
                        string[] yapraksarma = gecici.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//şu boşlukta şu kadar böl ve diziye at

                            string numara = yapraksarma[0].ToString();//Atom numaralarının dizideki yeri
                            string isim = yapraksarma[1].ToString();
                            string koor = yapraksarma[5].ToString();
                            
                            listBox1.Items.Add("Atom Numarası=" + yapraksarma[0] + "   " + "Proteinin İsmi= " + yapraksarma[1] + "  " + "X koordinatı" +  yapraksarma[5] + "/n" );
                            textBox1.Text = "En Büyük X koordinatına sahip atom = " + yapraksarma[5].Max() + "  " + "Atom Adı= " + yapraksarma[1] + "  " + "Numarası= " + yapraksarma[0] ;
                        

                    }
                    satır = oku.ReadLine();//döngü için tekrar oku
                }
                
                
                oku.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
