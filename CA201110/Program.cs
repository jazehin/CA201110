using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CA201110
{
    class Program
    {
        struct Diak
        {
            public string vnev, knev;
            public int h;
            public double m;
            public bool fiu;

            public Diak Hozzaad(string vnev, string knev, int h, double m, bool fiu)
            {
                this.vnev = vnev;
                this.knev = knev;
                this.h = h;
                this.m = m;
                this.fiu = fiu;
                return this;
            }

            public void Kiir()
            {
                Console.WriteLine($"Név: {this.vnev} {this.knev}\nMagassága: {this.h} cm\nSúlya: {this.m} kg");
            }
        }

        static void Main()
        {
            var sr = new StreamReader(@"..\..\Res\diakok.txt", Encoding.UTF8);
            List<Diak> diakok = new List<Diak>();
            int index = 0;
            while (!sr.EndOfStream)
            {

                string[] diakAdat = sr.ReadLine().Replace(',', '.').Split(' ');
                diakok.Add(new Diak().Hozzaad(diakAdat[0], diakAdat[1], Convert.ToInt32(diakAdat[2]), Convert.ToDouble(diakAdat[3]), diakAdat[4] == "fiú"));
                index++;
            }
            index = 0;
            for (int i = 0; i < diakok.Count; i++)
            {
                if (diakok[i].fiu == false && diakok[i].m > diakok[index].m) index = i;
            }
            Console.WriteLine("A legkövérebb lány:");
            diakok[index].Kiir();

            sr.Close();
            Console.ReadKey();
        }
    }
}
