using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace odev2
{
    class Program
    {
        private static int k = 0;
        private static int i = 0;
        private static int j = 0;

       private static  HashSet<BinaryTree> set = new HashSet<BinaryTree>();

        private static double max = 0.0;
        private static string maxDeger ="";
        private static int maxSutun = 0;
        private static int kararSayisi = 0;

        //elemanları sütün sutun seklinde atmak için listeler tanımladım.

        private static List<string> sayilar1 = new List<string>();
        private static List<int> sayilar2 = new List<int>();
        private static List<string> sayilar3 = new List<string>();
        private static List<string> sayilar4 = new List<string>();
        private static List<int> sayilar5 = new List<int>();
        private static List<string> sayilar6 = new List<string>();


       

        //Tekrarlıyan elemanları engelemek için hashsetler oluşturdum.
        private static HashSet<string> hash1 = new HashSet<string>();
        private static HashSet<int> hash2 = new HashSet<int>();
        private static HashSet<string> hash3 = new HashSet<string>();
        private static HashSet<string> hash4 = new HashSet<string>();
        private static HashSet<int> hash5 = new HashSet<int>();
        private static HashSet<string> hash6 = new HashSet<string>();


        //hashsetlerdeki elemanları tekrar listeye aldım.
        private static List<string> h1 = new List<string>();
        private static List<int> h2 = new List<int>();
        private static List<string> h3 = new List<string>();
        private static List<string> h4 = new List<string>();
        private static List<int> h5 = new List<int>();
        private static List<string> h6 = new List<string>();

        //testTrain verilerini aktarmak için listeler tanımladım.
        private static List<List<string>> test = new List<List<string>>();
       

        static void Main(string[] args)
        {

            //kok olusturma işlemini yaptım.
            dosyadanCek();

            BinaryTree kok = new BinaryTree();
            kok.s1 = sayilar1;
            kok.s2 = sayilar2;
            kok.s3 = sayilar3;
            kok.s4 = sayilar4;
            kok.s5 = sayilar5;
            kok.s6 = sayilar6;
            kok.h1 = h1;
            kok.h2 = h2;
            kok.h3 = h3;
            kok.h4 = h4;
            kok.h5 = h5;
            kok.h6 = h6;

            kok.isim = "kok";


            enbuyuktetayıbul( kok);
            

            sagsolparcala(kok);
            set.Add(kok);

            BinaryTree g;

          
            while (kararSayisi != 0)
            {
                
                g = kok;
                ara(g);

            }

            g = kok;
          
            // accuracy,tp oranı,tn oranı,tp adedi,tn adedi hesaplandı.
            int tp = 0, tn = 0, good=0,bad=0;
            for ( i = 0; i < test.Count; i++)
            {
                if (test[i][5]=="good")
                {
                    good++;
                }
                else
                {
                    bad++;
                }
                g = kok;
                string sonuc = incele(g,test[i]);
                if (sonuc==test[i][5]&& sonuc =="bad"&&  test[i][5]=="bad")
                {
                    tn++;
                }
                else if (sonuc == test[i][5] && sonuc == "good" && test[i][5] == "good")
                {
                    tp++;
                }
            }
            Console.WriteLine("Accuracy : " + (1.0 * (tp+tn))/(1.0 * test.Count));
            Console.WriteLine("TP adedi :"+ tp);
            Console.WriteLine("Tn adedi :" + tn);
            Console.WriteLine("Tn oranı :" + (1.0*tn)/(1.0*bad));
            Console.WriteLine("Tp oranı :" + (1.0 * tp)/(1.0*good));








        }// indise göre saga veya saol gitme işlemi yapıldı.
        public static string incele(BinaryTree g,List<string>test)
        {
            while (true)
            {

           
            if(g.indis== 2 || g.indis==5)
            {
                int temp = Convert.ToInt32(test[g.indis - 1]);
                if (temp <= Convert.ToInt32(g.veri)) 
                {
                    g = g.sol;
                }
            
            else
            {
                    g = g.sag;
            }
            }
            else if(g.indis==1 || g.indis==3 || g.indis==4)
            {
                if (test[g.indis-1]==g.veri)
                {
                    g = g.sol;
                }
                else
                {
                    g = g.sag;

                }

            }
            else
            {
                return g.isim;
            }
        }
    }
        
        



     
        public static void ara(BinaryTree kok)// agacı yerlestirdim.
        {

            
            if (  kok.isim == "karar" && kok.sol == null && kok.sag == null)
            {
                enbuyuktetayıbul(kok);

               
                sagsolparcala(kok);
               
                kararSayisi--;
              
                return;
            }
            else
            {
                if(kok.sol != null && kok.sag != null)
                {
                    ara(kok.sol);
                    ara(kok.sag);
                }
                
               
            }
           
           
        }
        //Agaca sag ve sol sekilde ekleme yapıldı.
         public static  void sagsolparcala(BinaryTree kok)
        {

            kok.sol = new BinaryTree();
            kok.sag = new BinaryTree();
            if (maxSutun == 1)
            {

                for (i = 0; i < kok.s1.Count; i++)
                {
                    if (maxDeger == kok.s1[i])
                    {
                        kok.sol.s1.Add(kok.s1[i]);
                        kok.sol.s2.Add(kok.s2[i]);
                        kok.sol.s3.Add(kok.s3[i]);
                        kok.sol.s4.Add(kok.s4[i]);
                        kok.sol.s5.Add(kok.s5[i]);
                        kok.sol.s6.Add(kok.s6[i]);

                    }
                    else
                    {
                        kok.sag.s1.Add(kok.s1[i]);
                        kok.sag.s2.Add(kok.s2[i]);
                        kok.sag.s3.Add(kok.s3[i]);
                        kok.sag.s4.Add(kok.s4[i]);
                        kok.sag.s5.Add(kok.s5[i]);
                        kok.sag.s6.Add(kok.s6[i]);
                    }
                }


            }
           else if (maxSutun == 3)
            {

                for (i = 0; i < kok.s3.Count; i++)
                {
                    if (maxDeger == kok.s3[i])
                    {
                        kok.sol.s1.Add(kok.s1[i]);
                        kok.sol.s2.Add(kok.s2[i]);
                        kok.sol.s3.Add(kok.s3[i]);
                        kok.sol.s4.Add(kok.s4[i]);
                        kok.sol.s5.Add(kok.s5[i]);
                        kok.sol.s6.Add(kok.s6[i]);

                    }
                    else
                    {
                        kok.sag.s1.Add(kok.s1[i]);
                        kok.sag.s2.Add(kok.s2[i]);
                        kok.sag.s3.Add(kok.s3[i]);
                        kok.sag.s4.Add(kok.s4[i]);
                        kok.sag.s5.Add(kok.s5[i]);
                        kok.sag.s6.Add(kok.s6[i]);
                    }
                }


            }
            else if (maxSutun == 4)
            {

                for (i = 0; i < kok.s4.Count; i++)
                {
                    if (maxDeger == kok.s4[i])
                    {
                        kok.sol.s1.Add(kok.s1[i]);
                        kok.sol.s2.Add(kok.s2[i]);
                        kok.sol.s3.Add(kok.s3[i]);
                        kok.sol.s4.Add(kok.s4[i]);
                        kok.sol.s5.Add(kok.s5[i]);
                        kok.sol.s6.Add(kok.s6[i]);

                    }
                    else
                    {
                        kok.sag.s1.Add(kok.s1[i]);
                        kok.sag.s2.Add(kok.s2[i]);
                        kok.sag.s3.Add(kok.s3[i]);
                        kok.sag.s4.Add(kok.s4[i]);
                        kok.sag.s5.Add(kok.s5[i]);
                        kok.sag.s6.Add(kok.s6[i]);
                    }
                }


            }
            else if (maxSutun == 2)
            {
                int temp = Convert.ToInt32(maxDeger);

                for (i = 0; i < kok.s2.Count; i++)
                {
                    if ( kok.s2[i] <= temp)
                    {
                        kok.sol.s1.Add(kok.s1[i]);
                        kok.sol.s2.Add(kok.s2[i]);
                        kok.sol.s3.Add(kok.s3[i]);
                        kok.sol.s4.Add(kok.s4[i]);
                        kok.sol.s5.Add(kok.s5[i]);
                        kok.sol.s6.Add(kok.s6[i]);

                    }
                    else
                    {
                        kok.sag.s1.Add(kok.s1[i]);
                        kok.sag.s2.Add(kok.s2[i]);
                        kok.sag.s3.Add(kok.s3[i]);
                        kok.sag.s4.Add(kok.s4[i]);
                        kok.sag.s5.Add(kok.s5[i]);
                        kok.sag.s6.Add(kok.s6[i]);
                    }
                }


            }
            else if (maxSutun == 5)
            {
                int temp = Convert.ToInt32(maxDeger);

                for (i = 0; i < kok.s5.Count; i++)
                {
                    if (kok.s5[i] <= temp)
                    {
                        kok.sol.s1.Add(kok.s1[i]);
                        kok.sol.s2.Add(kok.s2[i]);
                        kok.sol.s3.Add(kok.s3[i]);
                        kok.sol.s4.Add(kok.s4[i]);
                        kok.sol.s5.Add(kok.s5[i]);
                        kok.sol.s6.Add(kok.s6[i]);

                    }
                    else
                    {
                        kok.sag.s1.Add(kok.s1[i]);
                        kok.sag.s2.Add(kok.s2[i]);
                        kok.sag.s3.Add(kok.s3[i]);
                        kok.sag.s4.Add(kok.s4[i]);
                        kok.sag.s5.Add(kok.s5[i]);
                        kok.sag.s6.Add(kok.s6[i]);
                    }
                }


            }
          

            // benzersiz olan verilerini oluşturdum
            hash1 = new HashSet<string>();
            hash2 = new HashSet<int>();
            hash3 = new HashSet<string>();
            hash4 = new HashSet<string>();
            hash5 = new HashSet<int>();
            hash6 = new HashSet<string>();
            for (i = 0; i < kok.sol.s1.Count; i++)
            {
                hash1.Add(kok.sol.s1[i]);

            }
            for (i = 0; i < kok.sol.s2.Count; i++)
            {
                hash2.Add(kok.sol.s2[i]);

            }
            for (i = 0; i < kok.sol.s3.Count; i++)
            {
                hash3.Add(kok.sol.s3[i]);

            }
            for (i = 0; i < kok.sol.s4.Count; i++)
            {
                hash4.Add(kok.sol.s4[i]);

            }
            for (i = 0; i < kok.sol.s5.Count; i++)
            {
                hash5.Add(kok.sol.s5[i]);

            }
            for (i = 0; i < kok.sol.s6.Count; i++)
            {
                hash6.Add(kok.sol.s6[i]);

            }
            kok.sol.h1 = new List<string>(hash1.ToList());
            kok.sol.h2 = new List<int>(hash2.ToList());
            kok.sol.h3 = new List<string>(hash3.ToList());
            kok.sol.h4 = new List<string>(hash4.ToList());
            kok.sol.h5 = new List<int>(hash5.ToList());
            kok.sol.h6 = new List<string>(hash6.ToList());





            hash1 = new HashSet<string>();
            hash2 = new HashSet<int>();
            hash3 = new HashSet<string>();
            hash4 = new HashSet<string>();
            hash5 = new HashSet<int>();
            hash6 = new HashSet<string>();




            for (i = 0; i < kok.sag.s1.Count; i++)
            {
                hash1.Add(kok.sag.s1[i]);

            }
            for (i = 0; i < kok.sag.s2.Count; i++)
            {
                hash2.Add(kok.sag.s2[i]);

            }
            for (i = 0; i < kok.sag.s3.Count; i++)
            {
                hash3.Add(kok.sag.s3[i]);

            }
            for (i = 0; i < kok.sag.s4.Count; i++)
            {
                hash4.Add(kok.sag.s4[i]);

            }
            for (i = 0; i < kok.sag.s5.Count; i++)
            {
                hash5.Add(kok.sag.s5[i]);

            }
            for (i = 0; i < kok.sag.s6.Count; i++)
            {
                hash6.Add(kok.sag.s6[i]);

            }// 
            kok.sag.h1 = new List<string>(hash1.ToList());
            kok.sag.h2 = new List<int>(hash2.ToList());
            kok.sag.h3 = new List<string>(hash3.ToList());
            kok.sag.h4 = new List<string>(hash4.ToList());
            kok.sag.h5 = new List<int>(hash5.ToList());
            kok.sag.h6 = new List<string>(hash6.ToList());

           
            if (kok.sol.h6.Count==1)
            {
                kok.sol.isim = kok.sol.h6[0];
                kok.sol.veri = "yok";
                kok.sol.indis = -99;
            }
            else
            {
                kok.sol.isim = "karar";
                kararSayisi++;
              

            }
            if (kok.sag.h6.Count == 1)
            {
                kok.sag.isim = kok.sag.h6[0];
                kok.sag.veri = "yok";
                kok.sag.indis = -99;
            }
            else
            {
                kok.sag.isim = "karar";
                kararSayisi++;
               
            }

           


        }
        //nominal ve sayisal degerlerin tetaları arasında max tetayı buluyorum.
        public static void enbuyuktetayıbul(BinaryTree kok)
        {
          max = 0.0;
         maxDeger="";
         maxSutun = 0; 

          Tetadegerihesapla(kok.s1, kok.h1, kok.s6);
            Tetadegerihesapla(kok.s3, kok.h3, kok.s6);
            Tetadegerihesapla(kok.s4, kok.h4, kok.s6);

            List<int> h2sirali = kok.h2;
            h2sirali.Sort();
            SayisalTetadegerihesapla(kok.s2, h2sirali, kok.s6);

            List<int> h5sirali = kok.h5;
            h5sirali.Sort();
            SayisalTetadegerihesapla(kok.s5, h5sirali, kok.s6);
            kok.veri = maxDeger;

            for (i = 0; i < kok.h1.Count; i++)
            {
                if (maxDeger == kok.h1[i])
                {
                    maxSutun = 1;
                    break;
                }

            }

            for (i = 0; i < kok.h3.Count; i++)
            {
                if (maxDeger == kok.h3[i])
                {
                    maxSutun = 3;
                    break;
                }

            }

            for (i = 0; i < kok.h4.Count; i++)
            {
                if (maxDeger == kok.h4[i])
                {
                    maxSutun = 4;
                    break;
                }

            }

            for (i = 0; i < kok.h2.Count; i++)
            {
                if (maxDeger == kok.h2[i].ToString())
                {
                    maxSutun = 2;
                    break;
                }

            }

            for (i = 0; i < kok.h5.Count; i++)
            {
              
                if (maxDeger == kok.h5[i].ToString())
                {
                    maxSutun = 5;
                    break;
                }

            }

            kok.indis = maxSutun;

        }
        public static void dosyadanCek()
        {

           
            StreamReader str = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\trainSet.csv");//TrainSet dosyası okutuldu.
            StreamReader str2 = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\testSet.csv");//testSet dosyası okutuldu.

            string satır = str.ReadLine();
            satır = str.ReadLine();
            while (satır != null)//Split yaptıktan sonra sutun sutun seklinde  listelere  attım TrainSeteki verileri.
            {
                string[] satirlar = satır.Split(',');
                for (j = 0; j < 6; j++)
                {
                    if (j == 0)
                    {
                        sayilar1.Add(satirlar[0]);
                    }
                    else if (j == 1)
                    {
                        sayilar2.Add(Convert.ToInt32(satirlar[1]));
                    }
                    else if (j == 2)
                    {
                        sayilar3.Add(satirlar[2]);
                    }
                    else if (j == 3)
                    {
                        sayilar4.Add(satirlar[3]);
                    }
                    else if (j == 4)
                    {
                        sayilar5.Add(Convert.ToInt32(satirlar[4]));
                    }
                    else if (j == 5)
                    {
                        sayilar6.Add(satirlar[5]);
                    }


                }
                satır = str.ReadLine();

            }



            str.Close();
             satır = str2.ReadLine();
            satır = str2.ReadLine();
            while (satır != null)//  verileri listeye attıp satırlar seklinde splitledim  test setindeki dosyaları.
            {
                string[] satirlar = satır.Split(',');
                test.Add(new List<string>());
                for (j = 0; j < 6; j++)
                {
                    test[test.Count - 1].Add(satirlar[j]);


                }
                satır = str2.ReadLine();

            }
            str.Close();
            // Listeye atıgım elemanları HashSetlere atarak aynı eleman tekrarını engeledim.
            hash1 = new HashSet<string>();
            hash2 = new HashSet<int>();
            hash3 = new HashSet<string>();
            hash4 = new HashSet<string>();
            hash5 = new HashSet<int>();
            hash6 = new HashSet<string>();

            for (i = 0; i < sayilar1.Count; i++)
            {
                hash1.Add(sayilar1[i]);

            }
            for (i = 0; i < sayilar2.Count; i++)
            {
                hash2.Add(sayilar2[i]);

            }
            for (i = 0; i < sayilar3.Count; i++)
            {
                hash3.Add(sayilar3[i]);

            }
            for (i = 0; i < sayilar4.Count; i++)
            {
                hash4.Add(sayilar4[i]);

            }
            for (i = 0; i < sayilar5.Count; i++)
            {
                hash5.Add(sayilar5[i]);

            }
            for (i = 0; i < sayilar6.Count; i++)
            {
                hash6.Add(sayilar6[i]);

            }// Her elemandan tek sekilde olan hashsetleri listeye atarak sayısal değerleri kucukten buyuge sıralatım.
            h1 = new List<string>(hash1.ToList());
            h2 = new List<int>(hash2.ToList());
            h3 = new List<string>(hash3.ToList());
            h4 = new List<string>(hash4.ToList());
            h5 = new List<int>(hash5.ToList());
            h6 = new List<string>(hash6.ToList());
        }
        //Sayisal değerler dısındaki değerler için teta hesabı yaptım.
        public static void Tetadegerihesapla(List<string> hepsi, List<string> farklilar, List<string> sınıf)
        {

            double sag = 0, sol = 0, sol_bad = 0, sol_good = 0, sag_good = 0, sag_bad = 0;
            for (int i = 0; i < farklilar.Count; i++)
            {
                for (int j = 0; j < hepsi.Count; j++)
                {
                    if (farklilar[i] == hepsi[j])
                    {
                        sol++;
                        if (sınıf[j] == "good")
                        {
                            sol_good++;
                        }
                        else
                        {
                            sol_bad++;
                        }

                    }
                    else
                    {
                        sag++;
                        if (sınıf[j] == "good")
                        {
                            sag_good++;
                        }
                        else
                        {
                            sag_bad++;
                        }
                    }


                }

                double temp = 2 * (sol / 750) * (sag / 750) * (Math.Abs(sol_good / sol - sag_good / sag) + Math.Abs(sol_bad / sol - sag_bad / sag));

                if (max < temp)
                {
                    max = temp;
                    maxDeger = farklilar[i];
                }
                sag = 0;
                sol = 0;
                sol_bad = 0;
                sag_bad = 0;
                sol_good = 0;
                sag_good = 0;
            }


        }//Sayisal değerler için split atarak teta değeri hesaplatım.
        public static void SayisalTetadegerihesapla(List<int> hepsi, List<int> farklilar, List<string> sınıf)
        {

            double sag = 0, sol = 0, sol_bad = 0, sol_good = 0, sag_good = 0, sag_bad = 0;
            for (int i = 0; i < farklilar.Count - 1; i++)
            {
                for (int j = 0; j < hepsi.Count; j++)
                {
                    if (hepsi[j] <= farklilar[i])
                    {
                        sol++;
                        if (sınıf[j] == "good")
                        {
                            sol_good++;
                        }
                        else
                        {
                            sol_bad++;
                        }

                    }
                    else
                    {
                        sag++;
                        if (sınıf[j] == "good")
                        {
                            sag_good++;
                        }
                        else
                        {
                            sag_bad++;
                        }
                    }


                }

                double temp =2 * (sol / 750) * (sag / 750) * (Math.Abs(sol_good / sol - sag_good / sag) + Math.Abs(sol_bad / sol - sag_bad / sag));


                if (max < temp)
                {
                    max = temp;
                    maxDeger = farklilar[i].ToString();
                }
                sag = 0;
                sol = 0;
                sol_bad = 0;
                sag_bad = 0;
                sol_good = 0;
                sag_good = 0;
            }


        }





    }


}


