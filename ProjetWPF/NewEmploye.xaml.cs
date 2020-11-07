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
    /// Logique d'interaction pour NewEmploye.xaml
    /// </summary>
    public partial class NewEmploye : Window
    {
        GestionnaireBdd gstBdd;
        public NewEmploye(GestionnaireBdd unGst)
        {
            InitializeComponent();
            gstBdd = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNumEmploye.Text = gstBdd.GetLastNumEmploye().ToString();
            lstEmploye.ItemsSource = gstBdd.GetAllEmploye();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomEmploye.Text == "")
            {
                MessageBox.Show("Veuillez saisir le nom de l'employé");
            }
            else
            {
                gstBdd.InsererEmploye(Convert.ToInt16(txtNumEmploye.Text), txtNomEmploye.Text);
                txtNumEmploye.Text = gstBdd.GetLastNumEmploye().ToString();
                txtNomEmploye.Text = "";
                lstEmploye.ItemsSource = gstBdd.GetAllEmploye();
            }
        }
    }
}
