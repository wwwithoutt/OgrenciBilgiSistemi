using OgrenciBilgiSistemi.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OgrenciBilgiSistemi.Models;
using System.IO;            //
using System.Text.Json; // оба нужны что бы сохранить все на наш сд 

namespace OgrenciBilgiSistemi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ogrenci activeOgrenci = new Ogrenci();


        public MainWindow()
        {
            InitializeComponent();


            // Пытаемся загрузить данные, если файл существует
            if (File.Exists("ogrenci.json"))
            {
                try
                {
                    // 1. Читаем текст из файла
                    string jsonVeri = File.ReadAllText("ogrenci.json");

                    // 2. Превращаем текст обратно в объект Ogrenci
                    activeOgrenci = JsonSerializer.Deserialize<Ogrenci>(jsonVeri);

                    // 3. РУКАМИ расставляем данные по полочкам (в TextBox-ы)
                    TxtAd.Text = activeOgrenci.Ad;
                    TxtSoyad.Text = activeOgrenci.Soyad;
                    TxtNumara.Text = activeOgrenci.OgrenciNumara.ToString();

                    // 4. Обновляем список предметов
                    DersListi.ItemsSource = activeOgrenci.AlanDersler;

                    // 5. Обновляем счетчик
                    ToplamDers.Text = activeOgrenci.AlanDersler.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные: " + ex.Message);
                }
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                activeOgrenci.Ad = TxtAd.Text;
                activeOgrenci.Soyad = TxtSoyad.Text;
                activeOgrenci.OgrenciFakulte = TxtBolum.Text;
                
                if(int.TryParse(TxtNumara.Text , out int numara))
                {
                    activeOgrenci.OgrenciNumara = numara; 
                }else
                {
                    MessageBox.Show("Numarada Sadece Sayilar olmalu");
                    
                }

                var options = new JsonSerializerOptions { WriteIndented = true }; //текст в файле 
                string jsonVeri = JsonSerializer.Serialize(activeOgrenci, options);

                File.WriteAllText("ogrenci.json", jsonVeri);
                MessageBox.Show("Veriler Eklendi");


            }
            catch (Exception ex)
            { 
                MessageBox.Show($"Error : {ex.Message}");
            } 
            



        }
        //привязка нашей кнопки с текстом ввода 
        private void BtnAddDers_Click(object sender, RoutedEventArgs e)
        {
            string newDers = TxtNewDers.Text;
            if (! string.IsNullOrWhiteSpace(newDers))
            {
        
                activeOgrenci.DersEkle(newDers);

                
                DersListi.ItemsSource = null; 
                DersListi.ItemsSource = activeOgrenci.AlanDersler; 

             
                ToplamDers.Text = activeOgrenci.AlanDersler.Count.ToString();

                TxtNewDers.Clear();
            }
        }






        private void DersListi_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    if (DersListi.SelectedItem is string SecenDers)
                    {
                        activeOgrenci.DersiSil(SecenDers);

                        DersListi.ItemsSource = null;
                        DersListi.ItemsSource = activeOgrenci.AlanDersler;


                        ToplamDers.Text = activeOgrenci.AlanDersler.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // ошибкa вместо того, чтобы закрыть прогу
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }


    }
}
