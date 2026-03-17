Masina masina1 = new Masina("Mercedes C-Class", 2022, "benzina", 1999, 204, 15000, "automata", 35000, true);

Client client1 = new Client("Popescu", "Ion", "1960101223344");

Vanzare vanzare1 = new Vanzare(client1, masina1);

Console.WriteLine(masina1.Model);