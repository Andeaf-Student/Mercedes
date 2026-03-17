List<Masina> masini = new List<Masina>();

masini.Add(new Masina("Mercedes C-Class", 2022, "benzina", 1999, 204, 15000, "automata", 35000, true));

Client client1 = new Client("Popescu", "Ion", "1960101223344");

Vanzare vanzare1 = new Vanzare(client1, masini[0]);

foreach (Masina m in masini)
{
    Console.WriteLine($"Model: {m.Model}");
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
    Console.WriteLine("6. Iesire");
    optiune = Console.ReadLine();

switch (optiune)
{
    case "1":
            int n;
            Console.WriteLine($"Ce masina vrei sa vezi: (numarul masinii)");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Model: {masini[n].Model}");
            Console.WriteLine($"An Fabricatie: {masini[n].AnFabricatie}");
            Console.WriteLine($"Tip Motorizare: {masini[n].TipMotorizare}");
            Console.WriteLine($"Capacitate Cilindrica: {masini[n].CapacitateCilindrica} cc");
            Console.WriteLine($"Cai Putere: {masini[n].CaiPutere} CP");
            Console.WriteLine($"Kilometri: {masini[n].Kilometri}");

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
            Console.WriteLine("La revedere!");
            break;
        default:
            Console.WriteLine("Optiune invalida. Incearca din nou.");
            break;
 }
} while (optiune != "6");