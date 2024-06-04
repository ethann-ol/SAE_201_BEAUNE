

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
       
            private ObservableCollection<Coureur> lesClients = new ObservableCollection<Coureur>();
            private NpgsqlConnection connexion = null;   // futur lien à la BD


        public ObservableCollection<Coureur> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
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
       
	   public ApplicationData()
        {
           
            this.ConnexionBD();
            this.Read();
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
        public int Read()
            {
             this.LesClients = new ObservableCollection<Coureur>();
                String sql = "SELECT id, nom,prenom,email,genre,telephone, dateNaissance FROM Client";
                try
                {
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    foreach (DataRow res in dataTable.Rows)
                    {
                        Coureur nouveau = new Coureur(int.Parse(res["id"].ToString()),
                        res["nom"].ToString(), res["prenom"].ToString(),
                        res["email"].ToString(), DateTime.Parse(res["dateNaissance"].ToString()),
                        res["telephone"].ToString(),
                        LesClients.Add(nouveau);
                    }
                    return dataTable.Rows.Count;
                }
                catch (NpgSqlException e)
                { Console.WriteLine("pb de requete : " + e); return 0; }

            }
        public int Create(Coureur c)
        {
            int nb;
            String sql = $"insert into client (nom,prenom,email,genre,telephone, dateNaissance)"
            + $" values ('{c.Nom}','{c.Prenom}','{c.Email}'"
            + $",'{(char)c.Genre}','{c.Telephone}', "
            + $"'{c.DateNaissance.Year}-{c.DateNaissance.Month}-{c.DateNaissance.Day}'); ";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }
        public int Update(Coureur c)
        {
            int nb;
            String sql = $"Update client SET nom = '{c.Nom}'," +
                $"prenom = '{c.Prenom}'," +
                $"email = '{c.Email}'," +
                $"genre = '{(char)c.Genre}'," +
                $"telephone = '{c.Telephone}', " +
                $"dateNaissance = '{c.DateNaissance.Year}-{c.DateNaissance.Month}-{c.DateNaissance.Day}' " +
                $"WHERE id = '{c.Id}'; ";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
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

        public int Delete(Coureur c)
        {
            int nb;
            String sql = $"DELETE FROM Client WHERE Id = '{c.Id}'";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }
    }
    
}
