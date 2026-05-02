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

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            StartContent.Visibility = Visibility.Collapsed;
            MenuContent.Visibility = Visibility.Visible;
        }

        private void BtnShowList_Click(object sender, RoutedEventArgs e)
        {
            MenuContent.Visibility = Visibility.Collapsed;
            ListContent.Visibility = Visibility.Visible;
        }

        private void BtnShowAdd_Click(object sender, RoutedEventArgs e)
        {
            MenuContent.Visibility = Visibility.Collapsed;
            AddContent.Visibility = Visibility.Visible;
        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            ListContent.Visibility = Visibility.Collapsed;
            AddContent.Visibility = Visibility.Collapsed;
            BuyContent.Visibility = Visibility.Collapsed;
            MenuContent.Visibility = Visibility.Visible;
            TxtMesajVanzare.Text = "";
        }

        private void BtnShowBuy_Click(object sender, RoutedEventArgs e)
        {
            MenuContent.Visibility = Visibility.Collapsed;
            BuyContent.Visibility = Visibility.Visible;
            IncarcaMasiniInStoc();
        }

        private void IncarcaMasiniInStoc()
        {
            AdministrareMasiniFisierText fisier = new AdministrareMasiniFisierText(caleFisier);
            masini = fisier.GetMasini();

            ListaMasiniStoc.Items.Clear();
            foreach (var m in masini)
            {
                if (m.Disponibil)
                {
                    ListaMasiniStoc.Items.Add(m.Model + " - " + m.Pret + " EUR");
                }
            }
            BtnConfirmaAchizitia.IsEnabled = false;
            TxtDetaliiCumparare.Text = "Selectează o mașină pentru a vedea detaliile...";
        }

        private void ListaMasiniStoc_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListaMasiniStoc.SelectedIndex != -1 && ListaMasiniStoc.SelectedItem != null)
            {
                string selectie = ListaMasiniStoc.SelectedItem.ToString();
                
                // Folosim LastIndexOf pentru a separa modelul de preț, 
                // astfel încât modelele cu cratimă (ex: A-Class) să fie identificate corect
                int lastDashIndex = selectie.LastIndexOf('-');
                if (lastDashIndex != -1)
                {
                    string modelStr = selectie.Substring(0, lastDashIndex).Trim();
                    
                    var masina = masini.Find(m => m.Model == modelStr && m.Disponibil);
                    if (masina != null)
                    {
                        TxtDetaliiCumparare.Text = masina.Info();
                        BtnConfirmaAchizitia.IsEnabled = true;
                    }
                }
            }
        }

        private void BtnConfirmaAchizitia_Click(object sender, RoutedEventArgs e)
        {
            if (ListaMasiniStoc.SelectedIndex != -1 && ListaMasiniStoc.SelectedItem != null)
            {
                string selectie = ListaMasiniStoc.SelectedItem.ToString();
                int lastDashIndex = selectie.LastIndexOf('-');
                if (lastDashIndex != -1)
                {
                    string modelStr = selectie.Substring(0, lastDashIndex).Trim();

                    var masina = masini.Find(m => m.Model == modelStr && m.Disponibil);
                    if (masina != null)
                    {
                        masina.Disponibil = false; // Marcam ca vanduta

                        AdministrareMasiniFisierText fisier = new AdministrareMasiniFisierText(caleFisier);
                        fisier.SalveazaMasini(masini);

                        TxtMesajVanzare.Text = $"Felicitări! Ați cumpărat modelul {masina.Model}.";
                        IncarcaMasiniInStoc(); // Refresh lista
                    }
                }
            }
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