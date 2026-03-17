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

    public Masina(string model, int anFabricatie, string tipMotorizare,
                  int capacitateCilindrica, int caiPutere, int kilometri,
                  string transmisie, double pret, bool disponibil)
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
    }
    public Masina() 
    {
    
    }
}
