﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Inscription
    {
		private int num_inscription;

		public int Num_inscription
		{
			get { return num_inscription; }
			set { num_inscription = value; }
		}
		private int num_course;

		public int Num_course
		{
			get { return num_course; }
			set { num_course = value; }
		}
		private DateTime date_insription;

		public DateTime Date_inscription
		{
			get { return date_insription; }
			set { date_insription = value; }
		}

        public Inscription(int num_inscription, int num_course, DateTime date_inscription)
        {
            this.Num_inscription = num_inscription;
            this.Num_course = num_course;
            this.Date_inscription = date_inscription;
        }
        public Inscription(int num_inscription, int num_course)
        {
            this.Num_inscription = num_inscription;
            this.Num_course = num_course;
        }
    }
}