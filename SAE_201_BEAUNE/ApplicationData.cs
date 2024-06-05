

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SAE_201_BEAUNE
{

        public class ApplicationData
        {
       
            private ObservableCollection<Coureur> LesCourses = new ObservableCollection<Coureur>();
            private NpgsqlConnection connexion = null;   // futur lien à la BD


        /*public ObservableCollection<Coureur> lesCoureurs
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
        */
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
       
	   public ApplicationData()
        {
           
            this.ConnexionBD();
        }
        public void ConnexionBD()
            {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = "Server=srv-peda-new;" +
                                             "port=5433;" +
                                             "Database=Beaune;" +
                                             "Search Path = Beaune;" +
                                             "uid=stapleta;" +
                                             "password=cx2EQm;";
                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
                Connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
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
            String sql = "SELECT id, nom,prenom,email,genre,telephone, dateNaissance FROM Client";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Course nouveau = new Course();
                    //LesCourses.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

    }
    
}
