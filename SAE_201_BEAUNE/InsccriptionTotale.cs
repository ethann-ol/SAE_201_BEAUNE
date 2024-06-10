using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class InsccriptionTotale
    {
		private int num_inscription;
		private int num_course;
		private int num_coureur;
		private TimeSpan temps_prevu;
		private DateTime date_inscription;
		public int nb_incrit = 0;
		public static int id = 1;

		public DateTime Date_inscription
		{
			get { return date_inscription; }
			set { this.date_inscription = value; }
		}

		public TimeSpan Temps_prevu
		{
			get { return temps_prevu; }
			set { this.temps_prevu = value; }
		}

		public int Num_coureur
		{
			get { return num_coureur; }
			set { this.num_coureur = value; }
		}

		public int Num_course
		{
			get { return num_course; }
			set { this.num_course = value; }
		}

		public int Num_inscription
		{
			get { return num_inscription; }
			set { this.num_inscription = value; }
		}
        public InsccriptionTotale()
        {
        }

        public InsccriptionTotale(int num_inscription, int num_course, int num_coureur, TimeSpan temps_prevu, DateTime date_inscription)
        {
            this.Num_inscription = num_inscription;
            this.Num_course = num_course;
            this.Num_coureur = num_coureur;
            this.Temps_prevu = temps_prevu;
            this.Date_inscription = date_inscription;
			id = this.Num_inscription;
        }

        public InsccriptionTotale(int num_course, int num_coureur, TimeSpan temps_prevu)
        {
			this.Num_inscription = id;
            this.Num_course = num_course;
            this.Num_coureur = num_coureur;
            this.Temps_prevu = temps_prevu;
            this.Date_inscription = DateTime.Today.Date;
        }

        public override bool Equals(object? obj)
        {
            return obj is InsccriptionTotale inscri && inscri.num_course == this.num_course && inscri.num_coureur == this.num_coureur;
        }
    }
}
