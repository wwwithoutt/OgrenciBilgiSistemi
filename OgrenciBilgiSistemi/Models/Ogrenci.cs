using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Net.WebSockets;
using System.Text;
using System.Windows;

namespace OgrenciBilgiSistemi.Models
{
    internal class Ogrenci
    {
        private string _ogr_ad;
        private string _ogr_soyad;
        private int _ogr_numara;
        private string _ogr_fakulte;
        private List<string> _alan_dersler = new List<string>();

        public string Ad
        {
            get { return _ogr_ad; }
            set
            {
                if (value == _ogr_ad) return;

                _ogr_ad = value;
            }
        }
        public string Soyad
        {
            get { return _ogr_soyad; }
            set
            {
                if (value == _ogr_soyad) return;

                _ogr_soyad = value;
            }
        }
        public List<string> AlanDersler
        {
            get
            {
                return _alan_dersler;
            }
        }
        public void AlanDersEkle(string DersName)
        {
            if (!_alan_dersler.Contains(DersName))
            {
                _alan_dersler.Add(DersName);

            }
            else
            {
                Console.WriteLine($"Error: This {DersName} have already contained");
            }

        }
        public int OgrenciNumara
        {
            get { return _ogr_numara; }
            set
            {
                if (value == _ogr_numara) return;

                _ogr_numara = value;
            }
        }

        public string OgrenciFakulte
        {
            get { return _ogr_fakulte; }
            set
            {
                if (value == _ogr_fakulte) return;

                _ogr_fakulte = value; 
            }
        }

        public List<string> AlanDers
        {
            get { return _alan_dersler; }
        }
        public void DersEkle(string newDers)
        {
            if (!_alan_dersler.Contains(newDers))
            {
                _alan_dersler.Add(newDers);

            }
            else
            {
                MessageBox.Show("Böyle bir konu zaten var!");
            }
            

        }
        public void DersiSil(string Ders)
        {
            if (_alan_dersler.Contains(Ders))
            {
                _alan_dersler.Remove(Ders);
            }
            else return; 
        }
       
    }

}
