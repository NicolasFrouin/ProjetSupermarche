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
using System.Windows.Shapes;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour RayonSecteur.xaml
    /// </summary>
    public partial class RayonSecteur : Window
    {
        GestionnaireBdd gstBdd;
        public RayonSecteur(GestionnaireBdd unGst)
        {
            InitializeComponent();
            gstBdd = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboSecteurs.ItemsSource = gstBdd.GetAllSecteurs();
        }

        private void cboSecteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstRayon.ItemsSource = gstBdd.GetRayonParSecteur((cboSecteurs.SelectedItem as Secteur).NumS);
        }
    }
}
