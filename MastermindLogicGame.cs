using System;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Nacti(string[,] pole)
        {
            //Výpis pole----------------------
            Console.Clear();
            Console.WriteLine("Hra Mastermind\nAutor: Bojan Anevski");
            Console.WriteLine(" Hraci pole  | Pomocna pole");
            for (int i = 0; i < 12; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Console.Write(pole[i, x]);
                }
                Console.WriteLine("");
            }
        }

        static void Main()
        {
            //Menu-----------------------------
            string path = "skore.txt";
            Console.Clear();
            Console.WriteLine("Zadejte 1 pro novou hru, 2 pro napovědu a 3 pro lokální high score");
            char menu = Console.ReadKey().KeyChar;
            while (menu != '1' && menu != '2' && menu != '3')
            {
                Console.Clear();
                Console.WriteLine("Zadejte 1 pro novou hru, 2 pro napovědu a 3 pro lokální high score");
                menu = Console.ReadKey().KeyChar;
            }
            if (menu == '2')
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------NÁPOVĚDA-----------------------------------");
                Console.WriteLine("\n Hra funguje tak, že se jako hráč snažíte uhádnout skrytý kód. ");
                Console.WriteLine(" Kód obsahuje 4 znaky a abeceda kódu je 6 písmen označených jako Herní znaky.");
                Console.WriteLine(" V kódu se nemůže vyskytovat stejný znak a ve vy také nemůžete hádat stejný znak na stejném řádku.");
                Console.WriteLine(" Jako nápovědu dostanete pro každé písmeno kódu pomocný znak.");
                Console.WriteLine(" Až uhádnete všechny znaky kódu, hra zkončí a vypíše se vám skóre.");
                Console.WriteLine("\nHerní znaky:");
                Console.WriteLine(" R-červená");
                Console.WriteLine(" G-zelená");
                Console.WriteLine(" B-modrá");
                Console.WriteLine(" Y-žlutá");
                Console.WriteLine(" P-fialová");
                Console.WriteLine(" O-oranžová");
                Console.WriteLine("\nPomocné znaky:");
                Console.WriteLine(" T-správná barva i správná pozice");
                Console.WriteLine(" H-správná barva ale špatná pozice");
                Console.WriteLine(" *-špatná barva i špatná pozice");
                Console.ReadKey();
                Main();
            }
            else if (menu == '3')
            {
                //výčet skore ze souboru------------------
                string line;
                try
                {
                    Console.Clear();
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Zatím nebylo získáno žádné skóre");
                        Console.ReadKey();
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(path);
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine(line);
                            line = sr.ReadLine();
                        }
                        sr.Close();
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.ReadKey();
                }
                finally
                {
                    Main();
                }
            }
            //Výpočet a výpis defaultního pole--------------
            int k;
            int j = 0;

            Random r = new Random();
            int rInt1 = r.Next(0, 5);
            int rInt2;
            int rInt3;
            int rInt4;
            do {rInt2 = r.Next(0, 5); }
            while (rInt2 == rInt1);
            do {rInt3 = r.Next(0, 5); }
            while (rInt3 == rInt1 || rInt3 == rInt2);
            do {rInt4 = r.Next(0, 5); }
            while (rInt4 == rInt1 || rInt4 == rInt2 || rInt4 == rInt3);

            string[] slova = new string[]
                {" R "," G "," B "," Y "," P "," O "};

            string[] klic = new string[]
                {slova[rInt1],slova[rInt2],slova[rInt3],slova[rInt4]};

            string[,] pole = new string[12, 9] {
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " },
                { " * "," * "," * "," * "," | "," * "," * "," * "," * " }};
            Nacti(pole);
            //Vstupy od hráče----------------
            while (j < 12 && j >= 0)
            {
                for (k = 0; k < 4; k++)
                {
                    char pokus;
                    Console.WriteLine("Zadejte znak:");
                    pokus = Console.ReadKey().KeyChar;
                    Console.Write("\n");
                    while (pokus != 'R' && pokus != 'r' && pokus != 'G' && pokus != 'g' && pokus != 'B' && pokus != 'b' && pokus != 'Y' && pokus != 'y' && pokus != 'P' && pokus != 'p' && pokus != 'O' && pokus != 'o')
                    {
                        Console.WriteLine("Zadejte prosim R, G, B, Y, P nebo O:");
                        pokus = Console.ReadKey().KeyChar;
                        Console.Write("\n");
                    }                  
                    string zpracovany = " " + Convert.ToString(pokus).ToUpper() + " ";
                    while (zpracovany == pole[j,0] || zpracovany == pole[j, 1] || zpracovany == pole[j, 2])
                    {
                        Console.WriteLine("Zadejte prosim jiny znak nez predchozi:");
                        pokus = Console.ReadKey().KeyChar;
                        Console.Write("\n");
                        zpracovany = " " + Convert.ToString(pokus).ToUpper() + " ";
                    }
                    
                    pole[j, k] = zpracovany;
                    Nacti(pole);
                }

                //Porovnání správnosti pole-------------
                for (int i = 0; i < klic.Count(); i++)
                {
                    if (pole[j, i] == klic[0] || pole[j, i] == klic[1] || pole[j, i] == klic[2] || pole[j, i] == klic[3])
                    {
                        pole[j, i + 5] = " H ";
                    }
                    if (pole[j, i] == klic[i])
                    {
                        pole[j, i + 5] = " T ";
                    }
                    else if (pole[j, i] != klic[0] && pole[j, i] != klic[1] && pole[j, i] != klic[2] && pole[j, i] != klic[3] && pole[j, i] != klic[i])
                    {
                        pole[j, i + 5] = " * ";
                    }
                }
                //Výherný výpis a výpis skore do souboru-----------------
                Nacti(pole);
                char nova;
                int score = 12 - j;
                if (pole[j, 0] == klic[0] && pole[j, 1] == klic[1] && pole[j, 2] == klic[2] && pole[j, 3] == klic[3])
                {
                    Console.WriteLine("Vyhrál jsi a klíč byl " + klic[0] + " " + klic[1] + " " + klic[2] + " " + klic[3]);
                    Console.WriteLine("Tvoje skóre bylo " + score);
                    Console.WriteLine("Zadej nick pro uložení do tabulky skóre, nebo zadej N nebo n pro pokračování bez uložení: ");
                    string nick = Console.ReadLine();
                    Console.Clear();
                    //zápis skore do souboru-------------
                    if (nick != "N" && nick != "n")
                    {
                        try
                        {
                            if (!File.Exists(path))
                            {
                                using (StreamWriter sw = File.CreateText(path))
                                {
                                    sw.WriteLine("Skore hráče " + nick + " je " + score);
                                }
                            }

                            else
                            {
                                using (StreamWriter sw = File.AppendText(path))
                                {
                                    sw.WriteLine("Skore hráče " + nick + " je " + score);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                    }
                    do
                    {
                        Console.WriteLine("Jestli chceš ukončit hru zmackni 1, jestli chces přejít do menu zmáčkni 2");
                        nova = Console.ReadKey().KeyChar;
                    }
                    while (nova != '1' && nova != '2');

                    if (nova == '1')
                    {
                        Environment.Exit(0);
                    }
                    else if (nova == '2')
                    {
                        Main();
                    }
                }
                //Proherné menu a výpis-----------------
                else if (j == 11)
                {
                    Console.WriteLine("Prohrál jsi a klíč byl " + klic[0] + " " + klic[1] + " " + klic[2] + " " + klic[3]);
                    do
                    {
                        Console.WriteLine("Jestli chceš ukončit hru zmackni 1, jestli chces přejít do menu zmáčkni 2");
                        nova = Console.ReadKey().KeyChar;
                    }
                    while (nova != '1' && nova != '2');

                    if (nova == '1')
                    {
                        Environment.Exit(0);
                    }
                    else if (nova == '2')
                    {
                        Main();
                    }
                }
                j++;
            }
        }
    }
}

