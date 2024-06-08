using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Inscription
    {
		public int NumCoureur;
		public TimeSpan TempsPrevu;
		private  int num_inscription;
		private static int id = 0;
		

		public int Num_inscription
		{
			get { return num_inscription; }
			set { this.num_inscription = value; }
		}
		private int num_course;

		public int Num_course
		{
			get { return this.num_course; }
			set { this.num_course = value; }
		}
		private DateTime date_insription;

		public DateTime Date_inscription
		{
			get { return this.date_insription; }
			set { 
				DateTime today =  DateTime.Today;
				if (value <= today)
					throw new ArgumentException("La date d'inscription n'est pas valide");
				this.date_insription = value;
			}
		}
        public Inscription()
        {
        }
        public Inscription(int num_course, DateTime date_inscription)
        {
			this.num_inscription = id++;
            this.Num_course = num_course;
            this.Date_inscription = date_inscription;
        }

        public Inscription(int num_inscription, int num_course, DateTime date_inscription)
        {
            Num_inscription = num_inscription;
            Num_course = num_course;
            Date_inscription = date_inscription;
        }
    }
}
