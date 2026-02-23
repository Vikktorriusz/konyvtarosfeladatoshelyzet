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

               
        }
    }
}

