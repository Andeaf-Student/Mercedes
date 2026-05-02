using System;
using System.Collections.Generic;

namespace LibrarieModele
{
    public class Masina
    {
        public string Model { get; set; }
        public int AnFabricatie { get; set; }
        public string TipMotorizare { get; set; }
        public int CapacitateCilindrica { get; set; }
        public int CaiPutere { get; set; }
        public int Kilometri { get; set; }
        public string Transmisie { get; set; }
        public double Pret { get; set; }
        public bool Disponibil { get; set; }
        public Culoare CuloareMasina { get; set; }
        public List<Obtiuni> Optiuni { get; set; } = new List<Obtiuni>();

        public enum Obtiuni
        {
            GPS,
            ScauneIncalzite,
            Trapa,
            SenzoriParcare,
            CameraMarsarier
        }

        public enum Culoare
        {
            Negru,
            Alb,
            Rosu,
            Albastru,
            Gri,
            Argintiu
        }

        public Masina() { }

        // Constructor pentru citirea din fisier
        public Masina(string linieFisier)
        {
            string[] date = linieFisier.Split(';');

            Model = date[0];
            AnFabricatie = int.Parse(date[1]);
            TipMotorizare = date[2];
            CapacitateCilindrica = int.Parse(date[3]);
            CaiPutere = int.Parse(date[4]);
            Kilometri = int.Parse(date[5]);
            Transmisie = date[6];
            Pret = double.Parse(date[7]);
            Disponibil = bool.Parse(date[8]);
            CuloareMasina = Enum.Parse<Culoare>(date[9]);

            Optiuni = new List<Obtiuni>();
            if (date.Length > 10 && date[10] != "NicioOptiune")
            {
                string[] optiuniArray = date[10].Split(',');
                foreach (var opt in optiuniArray)
                {
                    if (Enum.TryParse<Obtiuni>(opt, out Obtiuni o))
                        Optiuni.Add(o);
                }
            }
        }

        public void Citire()
        {
            Console.WriteLine("Introdu detaliile masinii:");
            Console.Write("Model: ");
            Model = Console.ReadLine();
            Console.Write("An Fabricatie: ");
            AnFabricatie = int.Parse(Console.ReadLine());
            Console.Write("Tip Motorizare: ");
            TipMotorizare = Console.ReadLine();
            Console.Write("Capacitate Cilindrica (cc): ");
            CapacitateCilindrica = int.Parse(Console.ReadLine());
            Console.Write("Cai Putere (CP): ");
            CaiPutere = int.Parse(Console.ReadLine());
            Console.Write("Kilometri: ");
            Kilometri = int.Parse(Console.ReadLine());
            Console.Write("Transmisie: ");
            Transmisie = Console.ReadLine();
            Console.Write("Pret (EUR): ");
            Pret = double.Parse(Console.ReadLine());

            Console.WriteLine("Alege o culoare:");
            int i = 1;
            foreach (var culoare in Enum.GetValues(typeof(Culoare)))
            {
                Console.WriteLine($"{i}. {culoare}");
                i++;
            }
            int optiuneCuloare = int.Parse(Console.ReadLine());
            CuloareMasina = (Culoare)(optiuneCuloare - 1);

            Console.WriteLine("Cate optiuni extra are masina?");
            int nrOptiuni = int.Parse(Console.ReadLine());
            for (int j = 0; j < nrOptiuni; j++)
            {
                Console.WriteLine("Alege o optiune extra:");
                int k = 1;
                foreach (var opt in Enum.GetValues(typeof(Obtiuni)))
                {
                    Console.WriteLine($"{k}. {opt}");
                    k++;
                }
                int optExtra = int.Parse(Console.ReadLine());
                Optiuni.Add((Obtiuni)(optExtra - 1));
            }
        }

        public string Info()
        {
            string optiuniText = Optiuni.Count > 0 ? string.Join(", ", Optiuni) : "Fara optiuni extra";
            return $"Model: {Model}\n" +
                   $"An Fabricatie: {AnFabricatie}\n" +
                   $"Tip Motorizare: {TipMotorizare}\n" +
                   $"Capacitate Cilindrica: {CapacitateCilindrica} cc\n" +
                   $"Cai Putere: {CaiPutere} CP\n" +
                   $"Kilometri: {Kilometri}\n" +
                   $"Transmisie: {Transmisie}\n" +
                   $"Pret: {Pret} EUR\n" +
                   $"Culoare: {CuloareMasina}\n" +
                   $"Optiuni: {optiuniText}\n";
        }

        public string ConversieLaSirPentruFisier()
        {
            string optiuniText = Optiuni.Count > 0 ? string.Join(",", Optiuni) : "NicioOptiune";
            return $"{Model};{AnFabricatie};{TipMotorizare};{CapacitateCilindrica};{CaiPutere};{Kilometri};{Transmisie};{Pret};{Disponibil};{CuloareMasina};{optiuniText}";
        }
    }
}