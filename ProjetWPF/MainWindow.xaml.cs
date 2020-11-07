using SupermarcheMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GestionnaireBdd gstBdd;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gstBdd = new GestionnaireBdd();
        }

        private void btnRayonSecteur_Click(object sender, RoutedEventArgs e)
        {
            RayonSecteur frm = new RayonSecteur(gstBdd);
            frm.Show();
        }

        private void btnNewEmploye_Click(object sender, RoutedEventArgs e)
        {
            NewEmploye frm = new NewEmploye(gstBdd);
            frm.Show();
        }

        private void btnGestionHoraire_Click(object sender, RoutedEventArgs e)
        {
            GestionHoraire frm = new GestionHoraire(gstBdd);
            frm.Show();
        }
    }
}
