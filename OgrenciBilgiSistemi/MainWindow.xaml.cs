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


            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
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
