using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Linq;
using NivelStocareDate;
using LibrarieModele;

namespace AplicatieWPF
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            AdministrareMasiniFisierText fisier =
                new AdministrareMasiniFisierText("Masini.txt");

            var masini = fisier.GetMasini();

            DataContext = masini.FirstOrDefault();
        }
    }
}