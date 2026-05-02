using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string caleFisier = Path.Combine(Environment.CurrentDirectory, "Masini.txt");
        AdministrareMasiniFisierText fisier = new AdministrareMasiniFisierText(caleFisier);
        List<Masina> masini = fisier.GetMasini();

        Client client1 = new Client("Popescu", "Ion", "1960101223344");

        Vanzare vanzare1 = new Vanzare(client1, masini.Count > 0 ? masini[0] : null);

        int index = 1;

        foreach (Masina m in masini)
        {
            Console.WriteLine($"{index}. Model: {m.Model}");
            index++;
        }

        // Funcție de căutare
        Masina Cautare(List<Masina> lista, string model)
        {
            foreach (Masina m in lista)
            {
                if (m.Model.Equals(model, StringComparison.OrdinalIgnoreCase))
                {
                    return m;
                }
            }
            return null;
        }

        string optiune;
        do
        {
            Console.WriteLine("\nAlege o optiune:");
            Console.WriteLine("1. Afiseaza detaliile masinii");
            Console.WriteLine("2. Afiseaza detaliile clientului");
            Console.WriteLine("3. Afiseaza data vanzarii");
            Console.WriteLine("4. Introdu o masina de la tastatura");
            Console.WriteLine("5. Cauta masina dupa model");
            Console.WriteLine("6. Cauta masina mai scumpa de...");
            Console.WriteLine("7. Iesire");
            optiune = Console.ReadLine()?.Trim();

            switch (optiune)
            {
                case "1":
                    Console.WriteLine("Ce masina vrei sa vezi: (numarul masinii)");
                    if (int.TryParse(Console.ReadLine(), out int n) && n >= 1 && n <= masini.Count)
                    {
                        Console.WriteLine(masini[n - 1].Info());
                    }
                    else
                    {
                        Console.WriteLine("Numar invalid.");
                    }
                    break;

                case "2":
                    Console.WriteLine($"Nume: {client1.Nume}");
                    Console.WriteLine($"Prenume: {client1.Prenume}");
                    Console.WriteLine($"CNP: {client1.CNP}");
                    break;

                case "3":
                    Console.WriteLine($"Data Vanzarii: {vanzare1.DataVanzarii}");
                    break;

                case "4":
                    Masina masinaNoua = new Masina();
                    masinaNoua.Citire();
                    masini.Add(masinaNoua);

                    fisier.AddMasina(masinaNoua);
                    index++;
                    Console.WriteLine("Masina salvata!");
                    break;

                case "5":
                    Console.WriteLine("Introdu modelul masinii pe care vrei sa o cauti:");
                    string modelCautat = Console.ReadLine()?.Trim();
                    Masina rezultat = Cautare(masini, modelCautat);

                    if (rezultat != null)
                    {
                        Console.WriteLine($"Model: {rezultat.Model} exista in reprezentanta.");
                    }
                    else
                    {
                        Console.WriteLine("Masina nu a fost gasita.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Introdu pretul minim:");
                    if (double.TryParse(Console.ReadLine(), out double pretMinim))
                    {
                        var rezultate = masini.Where(m => m.Pret > pretMinim).ToList();

                        if (rezultate.Count == 0)
                        {
                            Console.WriteLine("Nu exista masini mai scumpe decat " + pretMinim);
                        }
                        else
                        {
                            foreach (var m in rezultate)
                            {
                                Console.WriteLine(m.Info());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valoare invalida.");
                    }
                    break;

                case "7":
                    Console.WriteLine("La revedere!");
                    break;

                default:
                    Console.WriteLine("Optiune invalida. Incearca din nou.");
                    break;
            }
        } while (optiune != "7");
    }
}