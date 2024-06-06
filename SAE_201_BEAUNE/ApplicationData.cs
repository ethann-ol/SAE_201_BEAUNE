

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;

namespace SAE_201_BEAUNE
{

        public class ApplicationData
        {
       
            private ObservableCollection<Course> LesCourses = new ObservableCollection<Course>();
            private ObservableCollection<Coureur> LesCoureurs = new ObservableCollection<Coureur>();
        private NpgsqlConnection connexion = null;   // futur lien à la BD


        public ObservableCollection<Course> lesCourses
        {
            get
            {
                return this.lesCourses;
            }

            set
            {
                this.lesCourses = value;
            }
        }
        public ObservableCollection<Coureur> lesCoureurs
        {
            get
            {
                return this.lesCoureurs;
            }

            set
            {
                this.lesCoureurs = value;
            }
        }


        public NpgsqlConnection Connexion 
        {
            get
            {
                return this.connexion ;
            }

            set
            {
                this.connexion  = value;
            }
        }
       
	   public ApplicationData(Agent nouveauAgent, Connexion connexionWin)
        {
           
            this.ConnexionBD(nouveauAgent, connexionWin);
        }
        public void ConnexionBD(Agent nouveauAgent, Connexion connexionWin)
            {

            bool pbconnexion = false;
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = "Server=srv-peda-new;" +
                                             "port=5433;" +
                                             "Database=Beaune;" +
                                             "Search Path = Beaune;" +
                                             $"uid={nouveauAgent.Login_agent};" +
                                             $"password={nouveauAgent.Mdp_agent};";
                Connexion.Open();
                   
                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
            }
            catch (Exception e)
            {

                pbconnexion = true;
                MessageBox.Show("Votre mot de passe ou login est incorecte");

                // juste pour le debug : à transformer en MsgBox 
            }
            if (!pbconnexion)
            {
                connexionWin.MainWin.FenetreConnexion(false, connexionWin);
            }
        }
        
        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion : " + e); }
        }
        public int ReadCourse()
        {
            this.LesCourses = new ObservableCollection<Course>();
            String sql = "SELECT num_course, distance,heure_depart,prix_inscription FROM Course";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Course nouveau = new Course(int.Parse(res["num_course"].ToString()), int.Parse(res["distance"].ToString()), res["heure_depart"].ToString(),
                        int.Parse(res["prix_inscription"].ToString()));
                    LesCourses.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadCoureur()
        {
            String sql = "SELECT num_coureur, code_club, num_federation, nom_coureur, lien_photo, prenom_coureur, ville_coureur, potable, sexe, num_licence FROM coureur";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Coureur nouveau = new Coureur(int.Parse(res["num_coureur"].ToString()), (res["code_club"].ToString()), int.Parse(res["num_federation"].ToString()),
                        res["nom_coureur"].ToString(), res["prenom_coureur"].ToString(), res["potable"].ToString());
                    LesCoureurs.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

    }
    
}
