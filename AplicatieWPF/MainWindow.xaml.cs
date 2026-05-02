using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using LibrarieModele;
using NivelStocareDate;

namespace AplicatieWPF
{
    public partial class MainWindow : Window
    {
        private List<Masina> masini = new List<Masina>();
        private string caleFisier;

        public MainWindow()
        {
            InitializeComponent();

            // Fișierul stă lângă executabil
            caleFisier = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Masini.txt");

            IncarcaComboBoxuri();
        }

        // Populează ComboBox-ul de culori și ListBox-ul de opțiuni la pornire
        private void IncarcaComboBoxuri()
        {
            // Culori
            foreach (Masina.Culoare c in Enum.GetValues(typeof(Masina.Culoare)))
            {
                CmbCuloare.Items.Add(c);
            }
            CmbCuloare.SelectedIndex = 0;

            // Opțiuni extra
            foreach (Masina.Obtiuni o in Enum.GetValues(typeof(Masina.Obtiuni)))
            {
                LstOptiuni.Items.Add(o);
            }
        }

        private void BtnListaMasini_Click(object sender, RoutedEventArgs e)
        {
            AdministrareMasiniFisierText fisier =
                new AdministrareMasiniFisierText(caleFisier);
            masini = fisier.GetMasini();

            ListaMasini.Items.Clear();
            for (int i = 0; i < masini.Count; i++)
            {
                ListaMasini.Items.Add($"{i + 1}. {masini[i].Model}");
            }
        }

        private void BtnDetalii_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TxtIndex.Text, out int index))
            {
                index--;
                if (index >= 0 && index < masini.Count)
                {
                    TxtDetalii.Text = masini[index].Info();
                }
                else
                {
                    TxtDetalii.Text = "Index invalid!";
                }
            }
            else
            {
                TxtDetalii.Text = "Introdu un număr valid!";
            }
        }

        private void BtnSalveaza_Click(object sender, RoutedEventArgs e)
        {
            // Validare câmpuri obligatorii
            if (string.IsNullOrWhiteSpace(TxtModel.Text) ||
                string.IsNullOrWhiteSpace(TxtAnFabricatie.Text) ||
                string.IsNullOrWhiteSpace(TxtTipMotorizare.Text) ||
                string.IsNullOrWhiteSpace(TxtCapacitate.Text) ||
                string.IsNullOrWhiteSpace(TxtCaiPutere.Text) ||
                string.IsNullOrWhiteSpace(TxtKilometri.Text) ||
                string.IsNullOrWhiteSpace(TxtTransmisie.Text) ||
                string.IsNullOrWhiteSpace(TxtPret.Text))
            {
                TxtMesaj.Foreground = System.Windows.Media.Brushes.Red;
                TxtMesaj.Text = "Completează toate câmpurile obligatorii!";
                return;
            }

            // Parsare valori numerice
            if (!int.TryParse(TxtAnFabricatie.Text, out int an) ||
                !int.TryParse(TxtCapacitate.Text, out int capacitate) ||
                !int.TryParse(TxtCaiPutere.Text, out int caiPutere) ||
                !int.TryParse(TxtKilometri.Text, out int km) ||
                !double.TryParse(TxtPret.Text, out double pret))
            {
                TxtMesaj.Foreground = System.Windows.Media.Brushes.Red;
                TxtMesaj.Text = "An, Capacitate, CP, Kilometri și Preț trebuie să fie numere valide!";
                return;
            }

            // Construiește obiectul Masina
            Masina masinaNoua = new Masina
            {
                Model = TxtModel.Text.Trim(),
                AnFabricatie = an,
                TipMotorizare = TxtTipMotorizare.Text.Trim(),
                CapacitateCilindrica = capacitate,
                CaiPutere = caiPutere,
                Kilometri = km,
                Transmisie = TxtTransmisie.Text.Trim(),
                Pret = pret,
                Disponibil = true,
                CuloareMasina = (Masina.Culoare)CmbCuloare.SelectedItem
            };

            // Adaugă opțiunile selectate din ListBox
            foreach (Masina.Obtiuni optiune in LstOptiuni.SelectedItems)
            {
                masinaNoua.Optiuni.Add(optiune);
            }

            // Salvează în fișier
            try
            {
                AdministrareMasiniFisierText fisier =
                    new AdministrareMasiniFisierText(caleFisier);
                fisier.AddMasina(masinaNoua);
                masini.Add(masinaNoua);

                TxtMesaj.Foreground = System.Windows.Media.Brushes.Green;
                TxtMesaj.Text = $"Mașina \"{masinaNoua.Model}\" a fost salvată cu succes!";

                CurataFormular();
            }
            catch (Exception ex)
            {
                TxtMesaj.Foreground = System.Windows.Media.Brushes.Red;
                TxtMesaj.Text = $"Eroare la salvare: {ex.Message}";
            }
        }

        // Resetează câmpurile după salvare
        private void CurataFormular()
        {
            TxtModel.Text = "";
            TxtAnFabricatie.Text = "";
            TxtTipMotorizare.Text = "";
            TxtCapacitate.Text = "";
            TxtCaiPutere.Text = "";
            TxtKilometri.Text = "";
            TxtTransmisie.Text = "";
            TxtPret.Text = "";
            CmbCuloare.SelectedIndex = 0;
            LstOptiuni.SelectedItems.Clear();
        }
    }
}