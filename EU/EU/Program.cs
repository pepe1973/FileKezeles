using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EU
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> tagallamok = new List<string[]>();

            using (StreamReader sr = new StreamReader("EUcsatlakozas.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] tomb = sor.Split(';');
                    tagallamok.Add(tomb);
                }
            }

            Console.WriteLine($"3. Feladat: EU tagállamainak száma: {tagallamok.Count} db");

            int darab = 0;

            for (int i = 0; i < tagallamok.Count; i++)
            {
                if (tagallamok[i][1].Substring(0, 4) == "2007")
                {
                    darab++;
                }
            }

            Console.WriteLine($"4. Feladat: 2007-ben {darab} ország csatlakozott.");

            for (int i = 0; i < tagallamok.Count; i++)
            {
                if (tagallamok[i][0] == "Magyarország")
                {
                    Console.WriteLine($"5. Feladat: Magyarország csatlakozásának dátuma: {tagallamok[i][1]}.");
                }
            }

            foreach (var item in tagallamok)
            {
                if (item[1].Contains(".05."))
                {
                    Console.WriteLine("6. Feladat: Májusban volt csatlakozás.");
                    break;
                }
            }

            DateTime alap = new DateTime(1900, 01, 01);
            string utolsoBelepo = "";

            for (int i = 0; i < tagallamok.Count; i++)
            {
                int ev = Int32.Parse(tagallamok[i][1].Substring(0, 4));
                int honap = Int32.Parse(tagallamok[i][1].Substring(5, 2));
                int nap = Int32.Parse(tagallamok[i][1].Substring(8));
                DateTime aktualis = new DateTime(ev, honap, nap);

                if (alap < aktualis)
                {
                    alap = aktualis;
                    utolsoBelepo = tagallamok[i][0];
                }
            }

            Console.WriteLine($"7. Feladat: Legutoljára csatlakozott ország: {utolsoBelepo}.");

            /*List<int[][]> evenkentiBelopokSzama = new List<int[][]>();

            for (int i = 0; i < tagallamok.Count; i++)
            {
                for (int j = 0; j < evenkentiBelopokSzama.Length; j++)
                {
                    if (tagallamok[i][1].Substring(0, 4) == evenkentiBelopokSzama[][])
                    {

                    }
                }
            }*/

            Dictionary<int, int> evenkentiBelepokSzama = new Dictionary<int, int>();

            for (int i = 0; i < tagallamok.Count; i++)
            {
                int ev = Int32.Parse(tagallamok[i][1].Substring(0, 4));
                int db = 0;

                foreach (KeyValuePair<int, int> item in evenkentiBelepokSzama)
                {
                    if (item.Key == ev)
                    {
                        db = item.Value;
                        evenkentiBelepokSzama.Remove(ev);
                        break; 
                    }
                }
                evenkentiBelepokSzama.Add(ev, ++db);
            }

            using (StreamWriter sw = new StreamWriter("kiiras.txt", false, Encoding.UTF8))
            {
                Console.WriteLine("8. feladat: Statisztika: ");
                sw.WriteLine("8. feladat: Statisztika: ");

                foreach (KeyValuePair<int, int> item in evenkentiBelepokSzama)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value} ország");
                    sw.WriteLine($"\t{item.Key} - {item.Value} ország");
                }
            }
           
            Console.ReadKey(true);
        }
    }
}
