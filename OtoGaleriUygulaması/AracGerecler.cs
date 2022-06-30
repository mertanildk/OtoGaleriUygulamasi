using System;
using System.Collections.Generic;

using System.Text;

namespace OtoGaleriUygulaması
{
    class AracGerecler
    {
       
        static public bool PlakaMi(string veri)
        {
            
            if (veri.Length > 6 && veri.Length < 10
                && SayiMi(veri.Substring(0, 2))
                && HarfMi(veri.Substring(2, 1)))
            {
                
                if (veri.Length == 7 && SayiMi(veri.Substring(3)))
                {
                    return true;
                }
              
                else if (veri.Length < 9 && HarfMi(veri.Substring(3, 1)) && SayiMi(veri.Substring(4)))
                {
                    return true;
                }
                
                else if (HarfMi(veri.Substring(3, 2)) && SayiMi(veri.Substring(5)))
                {
                    return true;
                }
            }
            return false;   
        }



        static public bool HarfMi(string veri)
        {
            veri = veri.ToUpper();

            for (int i = 0; i < veri.Length; i++)
            {
                int kod = (int)veri[i];
                if ((kod >= 65 && kod <= 90) != true)
                {
                    return false;
                }
            }

            return true;
        }

       

        static public bool SayiMi(string giris)
        {
            foreach (char item in giris)
            {
                if (!Char.IsNumber(item))
                {
                    return false;
                }
            }
            return true;
        }

        static public string YaziAl(string yazi)
        {
            int sayi;

           

            do
            {
                try
                {
                    Console.Write(yazi);
                    string giris = Console.ReadLine().ToUpper();

                    if (int.TryParse(giris, out sayi))
                    {
                        throw new Exception("Giriş tanımlanamadı. Tekrar deneyin.");
                    }

                    else
                    {
                        return giris;
                    }

                }catch(Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            } while (true);

        }

        static public int SayiAl(string mesaj)
        {
            int sayi;

         

            do
            {
                try
                {
                    Console.Write(mesaj);
                    string giris = Console.ReadLine();

                    if (int.TryParse(giris, out sayi))
                    {
                        return sayi;
                    }
                    else
                    {
                        throw new Exception("Giriş tanımlanamadı. Tekrar deneyin.");
                    }

                }catch(Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            } while (true);

        }


    
        static public string PlakaAl(string mesaj)
        {

            string plaka;
            do
            {
                try
                {
                    Console.Write(mesaj);
                    plaka = Console.ReadLine().ToUpper();

                    if (!PlakaMi(plaka))
                    {
                        throw new Exception("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                        
                    }

                    return plaka;


                }catch(Exception e)
                {

                    Console.WriteLine(e.Message);
                }
               

            } while (true);

           

        }

       
            

        static public ARAC_TIPI AracTipiAl()
        {
            Console.WriteLine("Araç tipi: ");
            Console.WriteLine("SUV için 1");
            Console.WriteLine("Hatchback için 2");
            Console.WriteLine("Sedan için 3");

            while (true)
            {
                try
                {

                    Console.Write("Seçiminiz: ");
                    string secim = Console.ReadLine();

                    switch (secim)
                    {
                        case "1":
                            return ARAC_TIPI.SUV;

                        case "2":
                            return ARAC_TIPI.Hatchback;

                        case "3":
                            return ARAC_TIPI.Sedan;

                        default:
                            throw new Exception("Giriş tanımlanamadı. Tekrar deneyin.");
                            
                    }

                }catch(Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }




      
        
        
        
        
        }
    } 


    }




