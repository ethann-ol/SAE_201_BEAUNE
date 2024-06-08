using Npgsql;
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

namespace SAE_201_BEAUNE
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public static bool closedByConnexion = false;

        public Connexion()
        {
            InitializeComponent();
        }

        private void butConnexion_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationData.TryConnexionBD())
            {
                Connexion.closedByConnexion = true;
                this.Close();
            }


        }
        /*
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!closedByConnexion)
            {
                Application.Current.Shutdown();
            }
        }
        */
    }
}
