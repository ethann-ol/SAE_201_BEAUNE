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
			get { return num_course; }
			set { this.num_course = value; }
		}
		private int distance;

		public int Distance
		{
			get { return distance; }
			set { this.distance = value; }
		}
		private string heure_depart;

		public string Heure_depart
		{
			get { return heure_depart; }
			set { 
				if (String.IsNullOrEmpty(value))
					throw new ArgumentNullException("Vous devez saisir une heure de départ");
				
				
				this.heure_depart = value; }
		}

		private int prix_inscription;

		public int Prix_inscription
		{
			get { return prix_inscription; }
			set { this.prix_inscription = value; }
		}
		public Course(int num_course, int distance, string heure_depart, int prix_inscription) 
		{ 
			this.num_course = num_course;
			this.distance = distance;
			this.heure_depart = heure_depart;
			this.prix_inscription = prix_inscription;

		}




	}
}
