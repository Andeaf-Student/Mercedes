using System;


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
