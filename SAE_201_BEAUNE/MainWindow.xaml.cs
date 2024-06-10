using System;
using System.Collections.Generic;
using System.Data;
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
            Connexion connexionWindow = new Connexion();
            connexionWindow.ShowDialog();
            if (!Connexion.closedByConnexion)
            {
                Environment.Exit(0);
            }
            InitializeComponent();
            ApplicationData.Read();




        }
        /*
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
                data.ReadCourse();
                data.ReadCoureur();
            }
        }
        */
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            InscriptionCourse inscriptionApp = new InscriptionCourse();
            inscriptionApp.ShowDialog();
        }


        private void dataInscription_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Inscription clientSelectionne = (Inscription)dataInscription.SelectedItem;
            string sql = $"select * from inscription2 where num_inscription = {clientSelectionne.Num_inscription} ;";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Inscription2 nouveau = new Inscription2(int.Parse(res["num_inscription"].ToString()), int.Parse(res["num_coureur"].ToString()), TimeSpan.Parse(res["temps_prevu"].ToString()));
                ApplicationData.LesInscriptions2.Add(nouveau);
                Console.WriteLine(nouveau);
                
            }
            
            Console.WriteLine(clientSelectionne);
        }

        private void butAjoutAmis_Click(object sender, RoutedEventArgs e)
        {
            AjouterUnAmi app = new AjouterUnAmi();
            app.ShowDialog();
        }

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dataInscription.SelectedItem != null)
            {
                InsccriptionTotale InscriptionSelect = (InsccriptionTotale)dataInscription.SelectedItem;
                MessageBoxResult res = MessageBox.Show(this, "Etes vous sur de vouloir supprimer "
                    + InscriptionSelect.Num_inscription + " " + InscriptionSelect.Num_coureur + " ?", "Confirmation",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                    ApplicationData.LesInscrits.Remove(InscriptionSelect);
                    string sql = $"delete from amis where num_inscription ={InscriptionSelect.Num_inscription};";
                    DataAccess.Instance.SetData(sql);
                    sql = $"delete from inscription2 where num_inscription ={InscriptionSelect.Num_inscription};";
                    DataAccess.Instance.SetData(sql);
                    sql = $"delete from inscription where num_inscription ={InscriptionSelect.Num_inscription};";
                    DataAccess.Instance.SetData(sql);
                    



            }
            else
                MessageBox.Show(this, "Veuillez selectionner un client");
        }

      
    }
}
