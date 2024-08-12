using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SiraKutucukUygulamasi
{
    public partial class Form1 : Form
    {
        //veritabanı özelliklerini bu adres içinde kendine göre düzenlemen lazım!!

        string connectionString = "Server=LAPTOP-3R78C9JA\\MSSQLSERVERS;Database=SiraKutucuk;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load += Form1_Load;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Buton özellikleri
            #region
            int totalButtons = 15; //  buton sayısı
            int columns = 5; // sütun 
            int rows = (int)Math.Ceiling(totalButtons / (double)columns); // satir
            int buttonSize = 75; // buton boyutu
            int padding = 20; // butonlar arasındaki boşluk

            // butonların kaplayacağı alan
            int totalWidth = columns * (buttonSize + padding) - padding;
            int totalHeight = rows * (buttonSize + padding) - padding;

            // butonların başlangıç noktasını hesapla (ekran ortasında )
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2 + 120;
            #endregion
            //VERİTABANINDAN ALINAN İNTLERE GÖRE RENKLERİ ATAYAN DÖNGÜ
            #region
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Durum FROM Masalar";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            int buttonNumber = i * columns + j + 1;
                            if (buttonNumber > totalButtons)
                                break;

                            DataRow[] dataRows = dataTable.Select($"ID = {buttonNumber}");
                            if (dataRows.Length == 0)
                                continue;

                            int durum = Convert.ToInt32(dataRows[0]["Durum"]);

                            Button button = new Button
                            {
                                Size = new Size(buttonSize, buttonSize),
                                Location = new Point(startX + j * (buttonSize + padding), startY + i * (buttonSize + padding)),
                                Text = buttonNumber.ToString()
                            };

                            // Renk durumuna göre buton arka plan rengini ayarla
                            switch (durum)
                            {
                                case 1:
                                    button.BackColor = Color.Red; // Kırmızı: Dolu
                                    break;
                                case 0:
                                    button.BackColor = Color.Green; // Yeşil: Boş
                                    break;
                                case -1:
                                    button.BackColor = Color.Orange; // Turuncu: Rezerve
                                    break;
                            }

                            this.Controls.Add(button);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
            #endregion

            // Etiketlerin boyutunu ve konumu
            #region
            int labelWidth = 200;
            int labelHeight = 30;
            int labelMargin = 10; 

           
            int totalLabelsWidth = (labelWidth + labelMargin) * 3 - labelMargin; 
            int startXX = (this.ClientSize.Width - totalLabelsWidth) / 2; 
            int startYY = this.ClientSize.Height - labelHeight - 10; 

            // Kırmızı 
            Label lblRed = new Label
            {
                Text = "Kırmızı: Dolu",
                ForeColor = Color.White,
                BackColor = Color.Red,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(labelWidth, labelHeight),
                BorderStyle = BorderStyle.FixedSingle
            };
            lblRed.Location = new Point(startXX+100, startYY); 
            this.Controls.Add(lblRed);

            // Yeşil 
            Label lblGreen = new Label
            {
                Text = "Yeşil: Boş",
                ForeColor = Color.White,
                BackColor = Color.Green,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(labelWidth, labelHeight),
                BorderStyle = BorderStyle.FixedSingle
            };
            lblGreen.Location = new Point((startXX+100) + labelWidth + labelMargin, startYY); 
            this.Controls.Add(lblGreen);

            
            //yapıyorum bu sporu
            #endregion


        }
    }
}