using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Course : ICloneable

    {
		private int num_course;

		public int Num_course
		{
			get { return this.num_course; }
			set { this.num_course = value; }
		}
		private double distance;

		public double Distance
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

		private double prix_inscription;

		public double Prix_inscription
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
	

		public Course(int num_course, double distance, string heure_depart, double prix_inscription, string nom_course, DateTime date_course) 
		{ 
			this.Num_course = num_course;
			this.Distance = distance;
			this.Heure_depart = heure_depart;
			this.Prix_inscription = prix_inscription;
			this.Nom_course = nom_course;
			this.Date_course = date_course;

		}

        public override string? ToString()
        {
            return Num_course + " " + Distance + " " + Heure_depart + " " + Prix_inscription + " " + Nom_course + " " + Date_course;
        }

        public object Clone()
        {
            return new Course(this.num_course, this.distance, this.heure_depart, this.prix_inscription, this.nom_course, this.date_course);
        }
    }
}
