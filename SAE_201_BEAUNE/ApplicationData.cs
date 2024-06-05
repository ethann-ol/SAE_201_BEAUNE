

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
       
	   public ApplicationData(Agent nouveauAgent)
        {
           
            this.ConnexionBD(nouveauAgent);
        }
        public void ConnexionBD(Agent nouveauAgent)
            {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = "Server=srv-peda-new;" +
                                             "port=5433;" +
                                             "Database=Beaune;" +
                                             "Search Path = Beaune;" +
                                             $"uid={nouveauAgent.Login_agent};" +
                                             $"password={nouveauAgent.Mdp_agent};";
                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
                Connexion.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("pb de connexion : " + e);
                // juste pour le debug : à transformer en MsgBox 
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
        public int Read()
        {
            String sql = "SELECT num_course, distance,heure_depart,prix_inscription FROM Course";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Course nouveau = new Course((int.Parse(res["num_course"].ToString())), (int.Parse(res["distance"].ToString())), res["heure_depart"].ToString(),
                        (int.Parse(res["prix_inscription"].ToString())));
                    LesCourses.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

    }
    
}
