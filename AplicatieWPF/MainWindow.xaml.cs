using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LibrarieModele;
using NivelStocareDate;

namespace AplicatieWPF
{
    public partial class MainWindow : Window
    {
        private List<Masina> masini = new List<Masina>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnListaMasini_Click(object sender, RoutedEventArgs e)
        {
            AdministrareMasiniFisierText fisier =
                new AdministrareMasiniFisierText("Masini.txt");

            masini = fisier.GetMasini();

            ListaMasini.Items.Clear();

            for (int i = 0; i < masini.Count; i++)
            {
                ListaMasini.Items.Add($"{i+1}. {masini[i].Model}");
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
                TxtDetalii.Text = "Introdu un numar valid!";
            }
        }
    }
}