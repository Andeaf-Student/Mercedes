using System;
using System.Collections.Generic;
using static Masina.Culoare;
class Program
{
    static void Main()
    {
        List<Masina> masini = new List<Masina>();

        masini.Add(new Masina("Mercedes C-Class", 2022, "benzina", 1999, 204, 15000, "automata", 35000, true, Negru));
        masini.Add(new Masina("Mercedes E-Class", 2021, "diesel", 1991, 194, 30000, "automata", 40000, true, Alb));
        masini.Add(new Masina("Mercedes A-Class", 2020, "benzina", 1598, 136, 25000, "manuala", 27000, true, Rosu));
        masini.Add(new Masina("Mercedes GLA", 2021, "benzina", 1991, 163, 20000, "automata", 33000, true, Albastru));
        masini.Add(new Masina("Mercedes GLC", 2022, "diesel", 1950, 194, 12000, "automata", 47000, true, Gri));
        masini.Add(new Masina("Mercedes S-Class", 2022, "benzina", 2996, 333, 10000, "automata", 95000, true, Argintiu));
        masini.Add(new Masina("Mercedes CLA", 2020, "benzina", 1332, 136, 35000, "manuala", 28000, true, Negru));
        masini.Add(new Masina("Mercedes B-Class", 2021, "diesel", 1595, 116, 22000, "automata", 25000, true, Alb));
        masini.Add(new Masina("Mercedes GLE", 2022, "diesel", 2925, 330, 15000, "automata", 85000, true, Rosu));
        masini.Add(new Masina("Mercedes EQC", 2022, "electric", 0, 408, 5000, "automata", 70000, true, Albastru));

        Client client1 = new Client("Popescu", "Ion", "1960101223344");

        Vanzare vanzare1 = new Vanzare(client1, masini[0]);

        int index = 1;

        foreach (Masina m in masini)
        {
            Console.WriteLine($"{index}. Model: {m.Model}");
            index++;
        }

        Masina Cautare(List<Masina> masini, string model)
        {
            foreach (Masina m in masini)
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
            Console.WriteLine("Alege o optiune:");
            Console.WriteLine("1. Afiseaza detaliile masinii");
            Console.WriteLine("2. Afiseaza detaliile clientului");
            Console.WriteLine("3. Afiseaza data vanzarii");
            Console.WriteLine("4. Introdu o masina de la tastatura");
            Console.WriteLine("5. Cauta masina dupa model");
            Console.WriteLine("6. Cauta masina mai ieftina de...");
            Console.WriteLine("7. Iesire");
            optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    int n;
                    Console.WriteLine($"Ce masina vrei sa vezi: (numarul masinii)");
                    n = int.Parse(Console.ReadLine());
                    Console.WriteLine(masini[n].Info());

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
                    index++;
                    break;

                case "5":
                    Console.WriteLine("Introdu modelul masinii pe care vrei sa o cauti:");
                    string modelCautat = Console.ReadLine();
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
                    double pretMinim = double.Parse(Console.ReadLine());

                    // Folosim LINQ direct pe lista masini
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