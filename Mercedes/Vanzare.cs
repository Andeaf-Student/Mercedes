using System;
using LibrarieModele;
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