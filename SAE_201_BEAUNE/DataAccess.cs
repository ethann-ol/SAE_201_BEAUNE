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
        private static Agent agentConnecter;
        private static string strConnexion;
        private DataAccess()
        {
            //ConnexionBD();
        }
        public static Agent AgentConnecter
        { 
            get { return agentConnecter; }
            set { agentConnecter = value; }
        }

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
        public bool ConnexionBD()
        {
            strConnexion = "Server=srv-peda-new;port=5433;"
            + $"Database=Beaune;Search Path=Beaune;uid={AgentConnecter.Login_agent};password={AgentConnecter.Mdp_agent};";

            bool pbConnexion = false;
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = strConnexion;
                Connexion.Open();

                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
            }
            catch (Exception e)
            {

                MessageBox.Show("Votre mot de passe ou login est incorecte");
                pbConnexion = true;

                // juste pour le debug : à transformer en MsgBox 
            }
            if (!pbConnexion)
                return true;
            else 
                return false;
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

