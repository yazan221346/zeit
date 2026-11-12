
using System;
using System.Globalization;

class Program
{
    class zeit
    {
        private int stunden;
        private int mint;
        private int sce;

        public zeit()
        {
            stunden = 0;
            mint = 0;
            sce = 0;
        }

        public zeit(int secunden)
        {
            if (secunden < 0 || secunden >= 86400)
            {
                Console.WriteLine(" ungultege ein gaben ");
            }

            stunden = secunden / 3600;
            mint = (secunden % 3600) / 60;
            sce = secunden % 60;
        }

        public zeit(int stunden, int mint, int sce)
        {
            Rzeit(stunden, mint, sce);

            this.stunden = stunden;
            this.mint = mint;
            this.sce = sce;
        }

        public zeit(string zeit)
        {
            if (zeit == null || zeit.Length != 8 ||
                zeit[2] != ':' || zeit[5] != ':')
            {
                Console.WriteLine("Falsches Format! Beispiel: 12:34:54");
             
            }
            if (!int.TryParse(zeit.Substring(0, 2), out stunden) ||
                !int.TryParse(zeit.Substring(3, 2), out mint) ||
                !int.TryParse(zeit.Substring(6, 2), out sce))
            {
                Console.WriteLine(" ungultege ein gaben ");
            }
    
            Rzeit(stunden, mint, sce);
        }

        public void zeig()
        {
            Console.WriteLine($"{stunden:D2}:{mint:D2}:{sce:D2}");
        }

        private void Rzeit(int stunden, int mint, int sce)
        {
            if (stunden < 0 || stunden > 23 ||
                mint < 0 || mint > 59 ||
                sce < 0 || sce > 59)
            {
                Console.WriteLine(" ungultege ein gaben ");
            }
        }

        public void stopuhr()
        {
            
            
                int mint = 0;
                int sce = 0;
                int stunden = 0;

                bool ende = false;
                bool laeuft = false; 

                while (!ende)
                {
                    Console.Clear();
                    Console.WriteLine("S = Starten | P = Pause | R = Reset | E = Ende");
                    Console.WriteLine($"{stunden:D2}:{mint:D2}:{sce:D2}");

                    
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo wahl = Console.ReadKey(true);

                        if (wahl.Key == ConsoleKey.S)
                        {
                            laeuft = true;
                        }
                        else if (wahl.Key == ConsoleKey.P)
                        {
                            laeuft = false;
                        }
                        else if (wahl.Key == ConsoleKey.R)
                        {
                            laeuft = false;
                            stunden = 0;
                            mint = 0;
                            sce = 0;
                        }
                        else if (wahl.Key == ConsoleKey.E)
                        {
                            ende = true;
                        }
                    }

        
                    if (laeuft)
                    {
                        Thread.Sleep(1000);
                        sce++;
                        if (sce > 59)
                        {
                            sce = 0;
                            mint++;
                            if (mint > 59)
                            {
                                mint = 0;
                                stunden++;
                            }
                        }
                    }
                    else
                    {
                       
                        Thread.Sleep(50);
                    }
                }
            

        }
    }

    static void Main(string[] args)
    {
        zeit zeit = new zeit(23, 20, 30);
        zeit.zeig();

        zeit zeit1 = new zeit(86000);
        zeit1.zeig();

        zeit zeit2 = new zeit("12:55:40");
        zeit2.zeig();

        zeit zeit3 = new zeit();
        zeit3.zeig();
        
        zeit zeit4 = new zeit();
        zeit4.stopuhr();
    }
}
