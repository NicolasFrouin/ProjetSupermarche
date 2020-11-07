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

using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour GestionHoraire.xaml
    /// </summary>
    public partial class GestionHoraire : Window
    {
        GestionnaireBdd gstBdd;
        Employe lEmploye;
        Rayon leRayon;

        public GestionHoraire(GestionnaireBdd unGst)
        {
            InitializeComponent();
            gstBdd = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboEmployes.ItemsSource = gstBdd.GetAllEmploye();
            cboRayons.ItemsSource = gstBdd.GetAllRayons();
            //new MySqlDateTime(DateTime.Now).ToString();
            //new SqlDateTime(DateTime.Now).ToSqlString().ToString();
        }

        private void cboEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lEmploye = new Employe((cboEmployes.SelectedItem as Employe).NumE, (cboEmployes.SelectedItem as Employe).PrenomE);
            lstTravailler.ItemsSource = gstBdd.GetAllTravaillerParEmploye(lEmploye.NumE);
        }

        private void cboRayons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            leRayon = new Rayon((cboRayons.SelectedItem as Rayon).NumR, (cboRayons.SelectedItem as Rayon).NomR);
        }

        private void sldTemps_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtSlider.Text = Convert.ToInt16(sldTemps.Value).ToString();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (cboEmployes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un employé");
            }
            else if (cboRayons.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un rayon");
            }
            else
            {
                Travailler leTravail = new Travailler(lEmploye.NumE, leRayon.NumR, leRayon.NomR, DateTime.Now.ToString("s").Substring(0, 10), Convert.ToInt16(txtSlider.Text));
                try
                {
                    gstBdd.InsererTravaillerPourEmploye(leTravail);
                    lstTravailler.ItemsSource = gstBdd.GetAllTravaillerParEmploye(lEmploye.NumE);
                }
                catch (Exception)
                {
                    MessageBox.Show("L'employé a déjà travaillé dans ce rayon aujourd'hui");
                }
            }
        }
    }
}
