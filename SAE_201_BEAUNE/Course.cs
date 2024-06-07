using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Course

    {
		private int num_course;

		public int Num_course
		{
			get { return this.num_course; }
			set { this.num_course = value; }
		}
		private int distance;

		public int Distance
		{
			get { return this.distance; }
			set { this.distance = value; }
		}
		private string heure_depart;

		public string Heure_depart
		{
			get { return this.heure_depart; }
			set {
				if (String.IsNullOrEmpty(value))
					throw new ArgumentNullException("Vous devez saisir une heure de départ valide");
				
				
				this.heure_depart = value; }
		}

		private int prix_inscription;

		public int Prix_inscription
		{
			get { return this.prix_inscription; }
			set { this.prix_inscription = value; }
		}
		private string nom_course;
		public string Nom_course
        {
            get { return this.nom_course; }
            set {
				if (String.IsNullOrEmpty(value))
					throw new ArgumentNullException("Le nom de course saisi n'est pas valide");

				if (value.Length > 50)
					throw new ArgumentOutOfRangeException("Le nom de course saisi dépasse le nombre de caractères autorisé");
				
				this.nom_course = value; }
        }

		private DateTime date_course;

		public DateTime Date_course
		{
			get { return this.date_course; }
			set {
                DateTime today = DateTime.Today;
                if (value < today)
                    throw new ArgumentException("La date de course saisie n'est pas valide");


                this.date_course = value; }
		}
	

		public Course(int num_course, int distance, string heure_depart, int prix_inscription, string nom_course, DateTime date_course) 
		{ 
			this.Num_course = num_course;
			this.Distance = distance;
			this.Heure_depart = heure_depart;
			this.Prix_inscription = prix_inscription;
			this.Nom_course = nom_course;
			this.Date_course = date_course;

		}




	}
}
