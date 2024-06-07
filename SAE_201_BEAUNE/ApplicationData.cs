

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
            private ObservableCollection<Inscription2> LesInscriptions2 = new ObservableCollection<Inscription2>();
            private ObservableCollection<Inscription> LesInscriptions = new ObservableCollection<Inscription>(); 
            private ObservableCollection<Federation> LesFederations = new ObservableCollection<Federation>();
            private ObservableCollection<Envoi_SMS> LesEnvois_SMS = new ObservableCollection<Envoi_SMS>();
            private ObservableCollection<Club> LesClubs = new ObservableCollection<Club>();
            private ObservableCollection<Amis> LesAmis = new ObservableCollection<Amis>();
            private ObservableCollection<Distance> LesDistances = new ObservableCollection<Distance>();
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
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }

        public ObservableCollection<Amis> lesAmis
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

        public ObservableCollection<Distance> lesDistances
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

        public ObservableCollection<Club> lesClubs
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

        public ObservableCollection<Envoi_SMS> lesEnvois_SMS
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

        public ObservableCollection<Federation> lesFederations
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

        public ObservableCollection<Inscription> lesInscriptions
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

        public ObservableCollection<Inscription2> lesInscriptions2
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
            String sql = "SELECT num_course, distance,heure_depart,prix_inscription FROM Course";
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
            this.LesDistances = new ObservableCollection<Distance>();
            String sql = "SELECT num_course, num_borne, nb_km FROM Distance";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Distance nouveau = new Distance(int.Parse(res["num_course"].ToString()), int.Parse(res["num_borne"].ToString()), int.Parse(res["nb_km"].ToString()));
                    LesDistances.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadAmi()
        {
            this.LesAmis = new ObservableCollection<Amis>();
            String sql = "SELECT num_ami FROM amis";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Amis nouveau = new Amis(int.Parse(res["num_ami"].ToString()));
                    LesAmis.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadClub()
        {
            this.LesClubs = new ObservableCollection<Club>();
            String sql = "SELECT code_club, nom_club FROM club";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Club nouveau = new Club(res["code_club"].ToString(), res["nom_club"].ToString());
                    LesClubs.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

        public int ReadEnvoiSms()
        {
            this.LesEnvois_SMS = new ObservableCollection<Envoi_SMS>();
            String sql = "SELECT num_ami, num_inscription, portable_sms FROM envoi_sms";
            try
            {
                DataTable dataTable = DataAccess.Instance.GetData(sql);
                foreach (DataRow res in dataTable.Rows)
                {
                    Envoi_SMS nouveau = new Envoi_SMS(int.Parse(res["num_ami"].ToString()), int.Parse(res["num_inscription"].ToString()), res["portable_sms"].ToString());
                    LesEnvois_SMS.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }


    }
}
