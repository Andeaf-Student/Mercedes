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
    { GPS,
      ScauneIncalzite, 
      Trapa,
      SenzoriParcare,
      CameraMarsarier }

    public enum Culoare
    {
        Negru,
        Alb,
        Rosu,
        Albastru,
        Gri,
        Argintiu
    }

    public Masina(string model, int anFabricatie, string tipMotorizare,
                  int capacitateCilindrica, int caiPutere, int kilometri,
                  string transmisie, double pret, bool disponibil, Culoare culoare)
    {
        Model = model;
        AnFabricatie = anFabricatie;
        TipMotorizare = tipMotorizare;
        CapacitateCilindrica = capacitateCilindrica;
        CaiPutere = caiPutere;
        Kilometri = kilometri;
        Transmisie = transmisie;
        Pret = pret;
        Disponibil = disponibil;
        CuloareMasina = culoare;
    }
    public Masina()
    {

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
        Console.Write("Alege o culoare: ");
        Console.WriteLine("1. Negru\n"+
            "2. Alb\n"+
            "3. Rosu\n"+
            "4. Albastru\n"+
            "5. Gri\n"+
            "6. Argintiu");
        int optiune = int.Parse(Console.ReadLine());

        if (optiune >= 1 && optiune <= 6)
        {
            CuloareMasina = (Culoare)(optiune - 1);
        }
        else
        {
            Console.WriteLine("Optiune invalida!");
        }
        Console.WriteLine("Cate obtiuni extra are?");
        int numarOptiuni = int.Parse(Console.ReadLine());
        for (int i = 0; i < numarOptiuni; i++)
        {
            Console.WriteLine("Alege o obtiune extra: ");
            Console.WriteLine("1. GPS\n" +
                "2. Scaune Incalzite\n" +
                "3. Trapa\n" +
                "4. Senzori Parcare\n" +
                "5. Camera Marsarier");
            int optiuneExtra = int.Parse(Console.ReadLine());
            if (optiuneExtra >= 1 && optiuneExtra <= 5)
            {
                Optiuni.Add((Obtiuni)(optiuneExtra - 1));
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
            }
        }


    }

    public string Info()
    {
        string optiuniText = "";

        if (Optiuni.Count == 0)
        {
            optiuniText = "Fara optiuni extra";
        }
        else
        {
            optiuniText = string.Join(", ", Optiuni);
        }

        return $"Model: {Model}\n" +
               $"An Fabricatie: {AnFabricatie}\n" +
               $"Tip Motorizare: {TipMotorizare}\n" +
               $"Capacitate Cilindrica: {CapacitateCilindrica} cc\n" +
               $"Cai Putere: {CaiPutere} CP\n" +
               $"Kilometri: {Kilometri}\n" +
               $"Transmisie: {Transmisie}\n" +
               $"Pret: {Pret} EUR\n" +
               $"Culoare: {CuloareMasina}\n"+
               $"Optiuni: {optiuniText}\n";
    }


}
