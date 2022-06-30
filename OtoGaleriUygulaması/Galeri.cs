using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulaması
{
    class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();
        public Galeri()
        {
            SahteVeriGir();
        }
        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count; 
            }
        }
        public int GaleridekiAracSayisi
        {
            get
            {
                return this.Arabalar.Where(a => a.Durum == DURUM.Galeride).ToList().Count;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                return this.Arabalar.Where(t => t.Durum == DURUM.Kirada).ToList().Count;
            }
        }


        public int ToplamAracKiralamaSuresi
        {
            get
            {
                return this.Arabalar.Sum(a => a.KiralamaSureleri.Sum());

            }
        } 



        public int ToplamAracKirlamaAdedi
        {
            get
            {
                return this.Arabalar.Sum(a => a.KiralamaSayisi);
            }
        }



        public float Ciro
        {
            get
            {
                return this.Arabalar.Sum(a => a.ToplamKiralamaSuresi * a.KiralamaBedeli);
            }
        }



        public void ArabaKirala(string plaka, int sure)
        {
            

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();
            if (a != null && a.Durum == DURUM.Galeride)
            {

                a.Durum = DURUM.Kirada;
                a.KiralamaSureleri.Add(sure);
            }


        }
        public void KiralamaIptal(string plaka)
        {
            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null)
            {
                a.Durum = DURUM.Galeride;
                a.KiralamaSureleri.RemoveAt(a.KiralamaSureleri.Count - 1);
            }

        }

        public DURUM DurumGetir(string plaka)
        {
            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();
            if (a != null)
            {
                return a.Durum;
            }
            return DURUM.Empty;
        }


        public void ArabaTeslimAl(string plaka)
        {

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper() && a.Durum == DURUM.Kirada).FirstOrDefault();

            if (a != null)
            {
                a.Durum = DURUM.Galeride;
            }
        }


        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
           

            Araba a = new Araba(plaka, marka, kiralamaBedeli, aracTipi);

            this.Arabalar.Add(a);
        }

        public List<Araba> ArabaListesiGetir(DURUM durum)
        {
           

            List<Araba> liste = this.Arabalar;
            if (durum == DURUM.Kirada)
            {
                liste = this.Arabalar.Where(a => a.Durum == durum).ToList();
            }
            else if (durum == DURUM.Galeride)
            {
                liste = this.Arabalar.Where(a => a.Durum == durum).ToList();
            }

            return liste;

        }



        public void ArabaSil(string plaka)
        {
            

            Araba a = this.Arabalar.Where(x => x.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null && a.Durum == DURUM.Galeride)
            {
                this.Arabalar.Remove(a);
            }

        }


        public void SahteVeriGir()
        {
            // Oluşturduğumuz Arabaekle metodu ile manuel bilgi girerek sahteveri oluştururuz.

            ArabaEkle("34arb3434", "FIAT", 70, ARAC_TIPI.Sedan);
            ArabaEkle("35arb3535", "KIA", 60, ARAC_TIPI.SUV);
            ArabaEkle("34us2342", "OPEL", 50, ARAC_TIPI.Hatchback);

        }




    }
}
