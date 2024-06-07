

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
            private ObservableCollection<Inscription2> lesInscriptions2 = new ObservableCollection<Inscription2>();
            private ObservableCollection<Inscription> lesInscriptions = new ObservableCollection<Inscription>(); 
            private ObservableCollection<Federation> lesFederations = new ObservableCollection<Federation>();
            private ObservableCollection<Envoi_SMS> lesEnvois_SMS = new ObservableCollection<Envoi_SMS>();
            private ObservableCollection<Club> lesClubs = new ObservableCollection<Club>();
            private ObservableCollection<Amis> lesAmis = new ObservableCollection<Amis>();
            private ObservableCollection<Distance> lesDistances = new ObservableCollection<Distance>();
            private ObservableCollection<Course> lesCourses = new ObservableCollection<Course>();
            private ObservableCollection<Coureur> lesCoureurs = new ObservableCollection<Coureur>();
        private NpgsqlConnection connexion = null;   // futur lien à la BD


        public ObservableCollection<Course> LesCourses
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
        public ObservableCollection<Coureur> LesCoureurs
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
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }

        public ObservableCollection<Amis> LesAmis
        {
            get
            {
                return this.lesAmis;
            }

            set
            {
                this.lesAmis = value;
            }
        }

        public ObservableCollection<Distance> LesDistances
        {
            get
            {
                return this.lesDistances;
            }

            set
            {
                this.lesDistances = value;
            }
        }

        public ObservableCollection<Club> LesClubs
        {
            get
            {
                return this.lesClubs;
            }

            set
            {
                this.lesClubs = value;
            }
        }

        public ObservableCollection<Envoi_SMS> LesEnvois_SMS
        {
            get
            {
                return this.lesEnvois_SMS;
            }

            set
            {
                this.lesEnvois_SMS = value;
            }
        }

        public ObservableCollection<Federation> LesFederations
        {
            get
            {
                return this.lesFederations;
            }

            set
            {
                this.lesFederations = value;
            }
        }

        public ObservableCollection<Inscription> LesInscriptions
        {
            get
            {
                return this.lesInscriptions;
            }

            set
            {
                this.lesInscriptions = value;
            }
        }

        public ObservableCollection<Inscription2> LesInscriptions2
        {
            get
            {
                return this.lesInscriptions2;
            }

            set
            {
                this.lesInscriptions2 = value;
            }
        }
        private Agent agentConnecter;

        public Agent AgentConnecter
        {
            get { return agentConnecter; }
            set { agentConnecter = value; }
        }
        private Connexion connexionWin;

        public Connexion ConnexionWin
        {
            get { return connexionWin; }
            set { connexionWin = value; }
        }



        public ApplicationData()
        {
        }

        public bool TryConnexionBD(Agent agentConnecter)
        {
            DataAccess.AgentConnecter = agentConnecter;
            return DataAccess.Instance.ConnexionBD();
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
            String sql = "SELECT num_course, distance,heure_depart,prix_inscription FROM Course ";
            try
            {
                
                DataTable dataTable = DataAccess.Instance.GetData(sql);
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
            this.LesCoureurs = new ObservableCollection<Coureur>();
            String sql = "SELECT num_coureur, code_club, num_federation, nom_coureur, lien_photo, prenom_coureur, ville_coureur, potable, sexe, num_licence FROM coureur";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
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
        public int ReadDistance()
        {
            this.lesDistances = new ObservableCollection<Distance>();
            String sql = "SELECT num_course, num_borne, nb_km FROM Distance";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Distance nouveau = new Distance(int.Parse(res["num_course"].ToString()), int.Parse(res["num_borne"].ToString()), int.Parse(res["nb_km"].ToString()));
                    lesDistances.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadAmi()
        {
            this.lesAmis = new ObservableCollection<Amis>();
            String sql = "SELECT num_ami FROM amis";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Amis nouveau = new Amis(int.Parse(res["num_ami"].ToString()));
                    lesAmis.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadClub()
        {
            this.lesClubs = new ObservableCollection<Club>();
            String sql = "SELECT code_club, nom_club FROM club";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Club nouveau = new Club(res["code_club"].ToString(), res["nom_club"].ToString());
                    lesClubs.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

        public int ReadEnvoiSms()
        {
            this.lesEnvois_SMS = new ObservableCollection<Envoi_SMS>();
            String sql = "SELECT num_ami, num_inscription, portable_sms FROM envoi_sms";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Envoi_SMS nouveau = new Envoi_SMS(int.Parse(res["num_ami"].ToString()), int.Parse(res["num_inscription"].ToString()), res["portable_sms"].ToString());
                    lesEnvois_SMS.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        
        public int ReadFederation()
        {
            this.LesFederations = new ObservableCollection<Federation>();
            String sql = "SELECT num_federation, nom_federation FROM federation";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Federation nouveau = new Federation(int.Parse(res["num_federation"].ToString()), res["nom_federation"].ToString());
                    LesFederations.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadInscription()
        {
            this.LesInscriptions = new ObservableCollection<Inscription>();
            String sql = "SELECT num_inscription, num_course, date_inscription FROM inscription";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Inscription nouveau = new Inscription(int.Parse(res["num_inscription"].ToString()), int.Parse(res["num_coureur"].ToString()), DateTime.Parse(res["date_inscription"].ToString()));
                    LesInscriptions.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadInscription2()
        {
            this.LesInscriptions2 = new ObservableCollection<Inscription2>();
            String sql = "SELECT num_inscription, num_coureur, date_inscription FROM inscription2";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Inscription2 nouveau = new Inscription2(int.Parse(res["num_inscription"].ToString()), int.Parse(res["num_coureur"].ToString()), TimeSpan.Parse(res["temps_prevu"].ToString()));
                    LesInscriptions2.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }


    }
}
