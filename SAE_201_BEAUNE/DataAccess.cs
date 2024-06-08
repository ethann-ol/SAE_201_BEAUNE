using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAE_201_BEAUNE
{
    public class DataAccess
    {
        private static DataAccess instance;
        private static string strConnexion;
        private static string password;
        private static string login;
        private bool isConnected;

        private DataAccess()
        {
            //ConnexionBD();
        }
        /*
        public static Agent AgentConnecter
        { 
            get { return agentConnecter; }
            set { agentConnecter = value; }
        }
        */
        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }
        public NpgsqlConnection? Connexion
        {
            get;
            set;
        }
        public static string Login { get => login; set => login = value; }
        public static string Password { get => password; set => password = value; }
        public bool IsConnected { get => isConnected; set => isConnected = value; }
        public bool ConnexionBD()
        {
            string strConnexion2 = "Server=srv-peda-new;port=5433;"
            + $"Database=sae201_marathon;Search Path=beaune;uid={Login};password={Password};";
            strConnexion = $"Host=localhost;Username={Login};Password={Password};Database=sae201_marathon";
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = strConnexion;
                Connexion.Open();
                return true;
                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
            }
            catch (Exception e)
            {
                Connexion = null;
                MessageBox.Show("Votre mot de passe ou login est incorecte");
                return false;   

                // juste pour le debug : à transformer en MsgBox 
            }
            /*
            if (!pbConnexion)
                return true;
            else 
                return false;
            */
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

        public DataTable GetData(string selectSQL)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + selectSQL + e.ToString());
                return null;
            }
        }
        public int SetData(string setSQL)
        {

            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + setSQL + e.ToString());
                return 0;
            }
        }
    }
}

