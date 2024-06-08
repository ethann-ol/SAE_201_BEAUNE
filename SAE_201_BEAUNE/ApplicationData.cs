

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
        private static ObservableCollection<Inscription2> lesInscriptions2 = new ObservableCollection<Inscription2>();
        private static ObservableCollection<Inscription> lesInscriptions = new ObservableCollection<Inscription>(); 
        private static ObservableCollection<Federation> lesFederations = new ObservableCollection<Federation>();
        private static ObservableCollection<Envoi_SMS> lesEnvois_SMS = new ObservableCollection<Envoi_SMS>();
        private static ObservableCollection<Club> lesClubs = new ObservableCollection<Club>();
        private static ObservableCollection<Amis> lesAmis = new ObservableCollection<Amis>();
        private static ObservableCollection<Distance> lesDistances = new ObservableCollection<Distance>();
        private static ObservableCollection<Course> lesCourses = new ObservableCollection<Course>();
        private static ObservableCollection<Coureur> lesCoureurs = new ObservableCollection<Coureur>();
        private static string login;
        private static string password;
        public static string Login
        {
            get => login;
            set
            {
                if (value.Length > 8)
                {
                    throw new ArgumentException("Login trop long");
                }
                login = value;
            }
        }
        public static string Password { get => password; set => password = value; }


        public static ObservableCollection<Course> LesCourses { get => lesCourses; set => lesCourses = value; }

        public static ObservableCollection<Coureur> LesCoureurs { get => lesCoureurs; set => lesCoureurs = value; }
        public static ObservableCollection<Distance> LesDistances { get => lesDistances; set => lesDistances = value; }
        public static ObservableCollection<Amis> LesAmis { get => lesAmis; set => lesAmis = value; }
        public static ObservableCollection<Club> LesClubs { get => lesClubs; set => lesClubs = value; }
        public static ObservableCollection<Envoi_SMS> LesEnvois_SMS { get => lesEnvois_SMS; set => lesEnvois_SMS = value; }
        public static ObservableCollection<Federation> LesFederations { get => lesFederations; set => lesFederations = value; }
        public static ObservableCollection<Inscription> LesInscriptions { get => lesInscriptions; set => lesInscriptions = value; }
        public static ObservableCollection<Inscription2> LesInscriptions2 { get => lesInscriptions2; set => lesInscriptions2 = value; }

  
        public ApplicationData()
        {
        }

        public static bool TryConnexionBD()
        {
            DataAccess.Login = Login;
            DataAccess.Password = Password;
            return DataAccess.Instance.ConnexionBD();
        }


        public static void ReadCourse()
        {
            LesCourses.Clear();
            LesCoureurs.Clear();
            LesDistances.Clear();
            LesAmis.Clear();
            LesClubs.Clear();
            LesEnvois_SMS.Clear();
            LesFederations.Clear();
            LesInscriptions.Clear();
            LesInscriptions2.Clear();
            string sql = "SELECT num_course, distance, heure_depart, prix_inscription, nom_course, date_course FROM course";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Course nouveau = new Course(int.Parse(res["num_course"].ToString()), double.Parse(res["distance"].ToString()), res["heure_depart"].ToString(),
                        double.Parse(res["prix_inscription"].ToString()), res["nom_course"].ToString(), DateTime.Parse(res["date_course"].ToString()));
                LesCourses.Add(nouveau);
            }
            sql = "SELECT num_coureur, code_club, num_federation, nom_coureur, lien_photo, prenom_coureur, ville_coureur, potable, sexe, num_licence FROM coureur";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Coureur nouveau = new Coureur(int.Parse(res["num_coureur"].ToString()), (res["code_club"].ToString()), res["num_federation"].ToString(),
                        res["nom_coureur"].ToString(), res["prenom_coureur"].ToString(), res["potable"].ToString());
                LesCoureurs.Add(nouveau);
            }
            sql = "SELECT num_course, num_borne, nb_km FROM Distance";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Distance nouveau = new Distance(int.Parse(res["num_course"].ToString()), int.Parse(res["num_borne"].ToString()), int.Parse(res["nb_km"].ToString()));
                lesDistances.Add(nouveau);
            }
            sql = "SELECT num_ami FROM amis";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Amis nouveau = new Amis(int.Parse(res["num_ami"].ToString()));
                lesAmis.Add(nouveau);
            }
            sql = "SELECT code_club, nom_club FROM club";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Club nouveau = new Club(res["code_club"].ToString(), res["nom_club"].ToString());
                lesClubs.Add(nouveau);
            }
            sql = "SELECT num_ami, num_inscription, portable_sms FROM envoi_sms";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Envoi_SMS nouveau = new Envoi_SMS(int.Parse(res["num_ami"].ToString()), int.Parse(res["num_inscription"].ToString()), res["portable_sms"].ToString());
                lesEnvois_SMS.Add(nouveau);
            }
            sql = "SELECT num_federation, nom_federation FROM federation";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Federation nouveau = new Federation(res["num_federation"].ToString(), res["nom_federation"].ToString());
                LesFederations.Add(nouveau);
            }
            sql = "SELECT num_inscription, num_course, date_inscription FROM inscription";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Inscription nouveau = new Inscription(int.Parse(res["num_inscription"].ToString()), int.Parse(res["num_coureur"].ToString()), DateTime.Parse(res["date_inscription"].ToString()));
                LesInscriptions.Add(nouveau);
            }
            sql = "SELECT num_inscription, num_coureur, temps_prevu FROM inscription2";
            foreach (DataRow res in DataAccess.Instance.GetData(sql).Rows)
            {
                Inscription2 nouveau = new Inscription2(int.Parse(res["num_inscription"].ToString()), int.Parse(res["num_coureur"].ToString()), TimeSpan.Parse(res["temps_prevu"].ToString()));
                LesInscriptions2.Add(nouveau);
            }
        }  
    }
}
