using System;
using System.IO;

namespace Uctenka
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] cenaProduktu15 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; ;
            double[] cenaProduktu21 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; ;//cenaProduktu bude obsahovat cenu daneho produktu 
            string[] nazevProduktu15 = { "", "", "", "", "", "", "", "", "", "" }; //nazevProduktu bude obsahovat nazev produktu
            string[] nazevProduktu21 = { "", "", "", "", "", "", "", "", "", "" };
            char menu1, menu2;
            int pocetZbozi;
            double cena = 0;
            double cenadph = 0;
            double dph = 0;
            string[] rozdelovac; //Rozdeluje data z jidlo/elektronika.txt
            int pocitani = 0;
            int pomocne;
            string pathKosik = "kosik.txt";
            string kolikrat;
            DateTime dnes = DateTime.Now;

            //----------------------------------------------------------------------------
            StreamWriter vymazKosik = new StreamWriter("kosik.txt");
            vymazKosik.Write("");
            vymazKosik.Close();
            StreamWriter vymazUctenku = new StreamWriter("uctenkaok.txt");
            vymazUctenku.Write("");
            vymazUctenku.Close();

            string[] jidlo = File.ReadAllLines("jidlo.txt");
            foreach (string line in jidlo)
            {
                rozdelovac = line.Split('/');
                Console.WriteLine(rozdelovac[0] + ")" + rozdelovac[1] + " " + "-" + " " + rozdelovac[2] + rozdelovac[3]);
                cenaProduktu15[pocitani] = Double.Parse(rozdelovac[2]);
                nazevProduktu15[pocitani] = rozdelovac[1];
                pocitani++;
            }
            pocitani = 0;
            string[] elektronika = File.ReadAllLines("elektronika.txt");
            foreach (string line in elektronika)
            {
                rozdelovac = line.Split('/');
                Console.WriteLine(rozdelovac[0] + ")" + rozdelovac[1] + " " + "-" + " " + rozdelovac[2] + rozdelovac[3]);
                cenaProduktu21[pocitani] = Double.Parse(rozdelovac[2]);
                nazevProduktu21[pocitani] = rozdelovac[1];
                pocitani++;
            }
        //-------------------------------------------------------------------------------
        PrvniMenu:
            do
            {
                Console.Clear();
                Console.WriteLine("Vyberte si DPH kategorii\n");
                Console.WriteLine("1-Jidlo");
                Console.WriteLine("2-Elektronika");
                Console.WriteLine("k-pro vycet z kosiku");
                Console.WriteLine("d-pro dokonceni nakupu a vytisknuti uctenky");
                menu1 = Console.ReadKey().KeyChar;
            } while (menu1 != '1' && menu1 != '2' && menu1 != 'k' && menu1 != 'd' && menu1 != 'K' && menu1 != 'D');
            if (menu1 == '1')
            {
            DruheMenu:
                do
                {
                    Console.Clear();
                    Console.WriteLine("Vyberte si produkt\n");
                    Console.WriteLine("0-" + nazevProduktu15[0] + " " + cenaProduktu15[0] + " Kč");
                    Console.WriteLine("1-" + nazevProduktu15[1] + " " + cenaProduktu15[1] + " Kč");
                    Console.WriteLine("2-" + nazevProduktu15[2] + " " + cenaProduktu15[2] + " Kč");
                    Console.WriteLine("3-" + nazevProduktu15[3] + " " + cenaProduktu15[3] + " Kč");
                    Console.WriteLine("4-" + nazevProduktu15[4] + " " + cenaProduktu15[4] + " Kč");
                    Console.WriteLine("5-" + nazevProduktu15[5] + " " + cenaProduktu15[5] + " Kč");
                    Console.WriteLine("6-" + nazevProduktu15[6] + " " + cenaProduktu15[6] + " Kč");
                    Console.WriteLine("7-" + nazevProduktu15[7] + " " + cenaProduktu15[7] + " Kč");
                    Console.WriteLine("8-" + nazevProduktu15[8] + " " + cenaProduktu15[8] + " Kč");
                    Console.WriteLine("9-" + nazevProduktu15[9] + " " + cenaProduktu15[9] + " Kč");
                    Console.WriteLine("m-pro navrat do hlavniho menu");
                    menu2 = Console.ReadKey().KeyChar;
                } while (menu2 != '0' && menu2 != '1' && menu2 != '2' && menu2 != '3' && menu2 != '4' && menu2 != '5' && menu2 != '6' && menu2 != '7' && menu2 != '8' && menu2 != '9' && menu2 != 'm' && menu2 != 'M');
                if (menu2 == '0')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '1')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '2')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '3')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '4')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '5')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '6')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '7')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '8')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == '9')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu15[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu15[pomocne];
                                cenadph += cenaProduktu15[pomocne] * 0.85;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu15[pomocne] + " " + cenaProduktu15[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu15[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto DruheMenu;
                }
                else if (menu2 == 'm' || menu2 == 'M')
                {
                    goto PrvniMenu;
                }

            }
            else if (menu1 == '2')
            {
            TretiMenu:
                do
                {
                    Console.Clear();
                    Console.WriteLine("Vyberte si produkt\n");
                    Console.WriteLine("0-" + nazevProduktu21[0] + " " + cenaProduktu21[0] + " Kč");
                    Console.WriteLine("1-" + nazevProduktu21[1] + " " + cenaProduktu21[1] + " Kč");
                    Console.WriteLine("2-" + nazevProduktu21[2] + " " + cenaProduktu21[2] + " Kč");
                    Console.WriteLine("3-" + nazevProduktu21[3] + " " + cenaProduktu21[3] + " Kč");
                    Console.WriteLine("4-" + nazevProduktu21[4] + " " + cenaProduktu21[4] + " Kč");
                    Console.WriteLine("5-" + nazevProduktu21[5] + " " + cenaProduktu21[5] + " Kč");
                    Console.WriteLine("6-" + nazevProduktu21[6] + " " + cenaProduktu21[6] + " Kč");
                    Console.WriteLine("7-" + nazevProduktu21[7] + " " + cenaProduktu21[7] + " Kč");
                    Console.WriteLine("8-" + nazevProduktu21[8] + " " + cenaProduktu21[8] + " Kč");
                    Console.WriteLine("9-" + nazevProduktu21[9] + " " + cenaProduktu21[9] + " Kč");
                    Console.WriteLine("m-pro navrat do hlavniho menu");
                    menu2 = Console.ReadKey().KeyChar;
                } while (menu2 != '0' && menu2 != '1' && menu2 != '2' && menu2 != '3' && menu2 != '4' && menu2 != '5' && menu2 != '6' && menu2 != '7' && menu2 != '8' && menu2 != '9' && menu2 != 'm' && menu2 != 'M');
                if (menu2 == '0')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '1')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 1 && pocetZbozi <= 49)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '2')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '3')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '4')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '5')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '6')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '7')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '8')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == '9')
                {
                    pomocne = (int)Char.GetNumericValue(menu2);
                    Console.WriteLine("Zadejte kolikrat si chcete koupit produkt " + nazevProduktu21[pomocne]);
                    kolikrat = Console.ReadLine();
                    if (Int32.TryParse(kolikrat, out pocetZbozi))
                    {
                        if (pocetZbozi >= 0 && pocetZbozi <= 50)
                        {
                            for (int i = 0; i < pocetZbozi; i++)
                            {

                                cena += cenaProduktu21[pomocne];
                                cenadph += cenaProduktu21[pomocne] * 0.79;
                            }
                            using (StreamWriter pisKosik = File.AppendText(pathKosik))
                            {
                                pisKosik.WriteLine(nazevProduktu21[pomocne] + " " + cenaProduktu21[pomocne] + " Kč" + " * " + pocetZbozi);
                            }
                            Console.WriteLine(nazevProduktu21[pomocne] + " * " + pocetZbozi + " byl pridan do kosiku");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zadejte prosim kladne cislo mensi nez 50");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zadejte prosim cislo");
                        Console.ReadKey();
                    }
                    goto TretiMenu;
                }
                else if (menu2 == 'm' || menu2 == 'M')
                {
                    goto PrvniMenu;
                }
            }
            else if (menu1 == 'k' || menu1 == 'K')
            {
                Console.Clear();
                StreamReader sr = new StreamReader(pathKosik);
                string line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadKey();
                goto PrvniMenu;
            }
            else if (menu1 == 'd' || menu1 == 'D')
            {
                dph = Math.Round(cena - cenadph, 2);
                cena = Math.Round(cena, 2);
                cenadph = Math.Round(cenadph, 2);
                using (StreamWriter uctenka = File.AppendText("uctenkaok.txt"))
                {
                    uctenka.WriteLine("              MATYHO ELEKTROSPOTREBICE A JINE POTRAVINY");
                    uctenka.WriteLine("                  Dlouha jizda 15, 892 00 Bojanovice");
                    uctenka.WriteLine("Telefon:   777-777-777");
                    uctenka.WriteLine("IC:        46395105                                  DIC: CZ46395105");
                    uctenka.WriteLine("");
                    uctenka.WriteLine("--------------------------------------------------------------------");
                    uctenka.WriteLine("");
                    uctenka.WriteLine("Provozovna:      5                                      Pokladna:001");
                    uctenka.WriteLine("Datum a cas:     " + dnes + " ");
                    uctenka.WriteLine("Cislo Uctenky:   0001337");
                    uctenka.WriteLine("");
                    uctenka.WriteLine("--------------------------------------------------------------------\n");
                    StreamReader sr = new StreamReader(pathKosik);
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        uctenka.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                    uctenka.WriteLine("\n--------------------------------------------------------------------");
                    uctenka.WriteLine("\nCelkem cena: " + cena);
                    uctenka.WriteLine("Cena bez DPH: " + cenadph);
                    uctenka.WriteLine("DPH: " + dph);
                    uctenka.WriteLine("\n--------------------------------------------------------------------");
                    uctenka.WriteLine("\n                               FIK");
                    uctenka.WriteLine("             b3a09b52-7c87-4014-a496-4c7a53cf9125-03");
                    uctenka.WriteLine("                               BKP");
                    uctenka.WriteLine("          21F333BB-E48B257A-761B7B13-6FB9DEC9-92766734");
                }
            }
        }

    }
}
