using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace konyvtar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = File.ReadAllText("konyvek.json",System.Text.Encoding.Latin1);
                Konyvtar kt = JsonSerializer.Deserialize<Konyvtar>(file);

                List<Konyv> ifjusagi = new List<Konyv>();
                foreach (var k in kt.konyvtar)
                {
                    if (k.kategoriak.Contains("Ifjúsági"))
                    {
                        ifjusagi.Add(k);
                    }
                }

                for (int i = 0; i < ifjusagi.Count - 1; i++)
                {
                    for (int j = i + 1; j < ifjusagi.Count; j++)
                    {
                        if (ifjusagi[i].ar > ifjusagi[j].ar)
                        {
                            Konyv tmp = ifjusagi[i];
                            ifjusagi[i] = ifjusagi[j];
                            ifjusagi[j] = tmp;
                        }
                    }
                }

                Console.WriteLine("ifjusiagi regények ár sorrendben ilyen csökkenő:");
                Console.WriteLine();
                foreach (var konyv in ifjusagi)
                {
                    Console.WriteLine(konyv.cim + " (" + konyv.szerzok[0] + ") " + konyv.ar + " Ft");
                }

                List<Konyv> kevesebb100 = new List<Konyv>();
                List<Konyv> kevesebb300 = new List<Konyv>();
                List<Konyv> kevesebb400 = new List<Konyv>();

                foreach (var k in ifjusagi)
                {
                    if (k.oldalszam <= 99)
                        kevesebb100.Add(k);
                    else if (k.oldalszam <= 299)
                        kevesebb300.Add(k);
                    else if (k.oldalszam <= 399)
                        kevesebb400.Add(k);
                }

                Console.WriteLine();
                Console.WriteLine("Oldalszamok:");
                Console.WriteLine();


                Console.WriteLine("0-99 oldal között:");
                Console.WriteLine();
                int sorszam = 1;
                foreach (var k in kevesebb100)
                {
                    Console.WriteLine($"{sorszam++}. {k.cim}");
                }

                Console.WriteLine("200-299 oldal között:");
                Console.WriteLine();
                sorszam = 1;
                foreach (var k in kevesebb300)
                {
                    Console.WriteLine($"{sorszam++}. {k.cim}");
                }

                Console.WriteLine("300-399 oldal között:");
                Console.WriteLine();
                sorszam = 1;
                foreach (var k in kevesebb400)
                {
                    Console.WriteLine($"{sorszam++}. {k.cim}");
                }

            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON fájl feldolgozási hiba: " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Fájl nem található: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba: " + ex.Message);
            }
        }
    }
}

