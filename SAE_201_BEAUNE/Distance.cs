using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Distance
    {
        private int num_course;
        private int num_borne;
        private int nb_km;

        public Distance(int num_course, int num_borne, int nb_km)
        {
            this.Num_course = num_course;
            this.Num_borne = num_borne;
            this.Nb_km = nb_km;
        }

        public int Num_course
        {
            get
            {
                return this.num_course;
            }

            set
            {
                this.num_course = value;
            }
        }

        public int Num_borne
        {
            get
            {
                return this.num_borne;
            }

            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException("Le num borne doit être compris entre 1 et 5");
            

                this.num_borne = value;
            }
        }

        public int Nb_km
        {
            get
            {
                return this.nb_km;
            }

            set
            {
                this.nb_km = value;
            }
        }
    }
}
