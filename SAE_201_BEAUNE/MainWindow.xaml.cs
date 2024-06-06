using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Connexion appConnexion;

        public Connexion AppConnexion
        {
            get { return appConnexion; }
            set { appConnexion = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            this.AppConnexion = new Connexion(this);
            FenetreConnexion(true, AppConnexion);




        }
        public void FenetreConnexion(bool ouvrir, Connexion appConnexion)
        {
            if (ouvrir)
            {
                appConnexion.Show();
                this.Hide();
            }
            else if (!ouvrir)
            {
                appConnexion.Hide();
                this.Show();
            }
        }
    }
}
