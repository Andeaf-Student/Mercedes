Masina masina1 = new Masina("Mercedes C-Class", 2022, "benzina", 1999, 204, 15000, "automata", 35000, true);

Client client1 = new Client("Popescu", "Ion", "1960101223344");

Vanzare vanzare1 = new Vanzare(client1, masina1);

Console.WriteLine(masina1.Model);

string optiune;
do
{ 
    Console.WriteLine("Alege o optiune:");
    Console.WriteLine("1. Afiseaza detaliile masinii");
    Console.WriteLine("2. Afiseaza detaliile clientului");
    Console.WriteLine("3. Afiseaza data vanzarii");
    Console.WriteLine("4. Introdu o masina de la tastatura");
    Console.WriteLine("5. Iesire");
    optiune = Console.ReadLine();

switch (optiune)
{
    case "1":
            Console.WriteLine($"Model: {masina1.Model}");
            Console.WriteLine($"An Fabricatie: {masina1.AnFabricatie}");
            Console.WriteLine($"Tip Motorizare: {masina1.TipMotorizare}");
            Console.WriteLine($"Capacitate Cilindrica: {masina1.CapacitateCilindrica} cc");
            Console.WriteLine($"Cai Putere: {masina1.CaiPutere} CP");
            Console.WriteLine($"Kilometri: {masina1.Kilometri} km");
            Console.WriteLine($"Transmisie: {masina1.Transmisie}");
            Console.WriteLine($"Pret: {masina1.Pret} EUR");
            Console.WriteLine($"Disponibil: {(masina1.Disponibil ? "Da" : "Nu")}");
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


        case "5":
            Console.WriteLine("La revedere!");
            break;
        default:
            Console.WriteLine("Optiune invalida. Incearca din nou.");
            break;
 }
} while (optiune != "5");