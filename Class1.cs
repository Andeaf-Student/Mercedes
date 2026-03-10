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

public class Client
{
    public string Nume { get; set; }
    public string Prenume { get; set; }
    public string CNP { get; set; }

    public Client(string nume, string prenume, string cnp)
    {
        Nume = nume;
        Prenume = prenume;
        CNP = cnp;
    }
}

public class Vanzare
{
    public Client Client { get; set; }
    public Masina Masina { get; set; }
    public DateTime DataVanzarii { get; set; }

    public Vanzare(Client client, Masina masina)
    {
        Client = client;
        Masina = masina;
        DataVanzarii = DateTime.Now;
    }
}