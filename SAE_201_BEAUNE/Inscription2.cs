using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Inscription2
    {
        private int num_inscription;
        private int num_coureur;
        private TimeSpan temps_prevu;

        public Inscription2()
        {
        }

        public Inscription2(int num_inscription, int num_coureur, TimeSpan temps_prevu)
        {
            this.Num_inscription = num_inscription;
            this.Num_coureur = num_coureur;
            this.Temps_prevu = temps_prevu;
        }

        public int Num_inscription
        {
            get
            {
                return this.num_inscription;
            }

            set
            {
                this.num_inscription = value;
            }
        }

        public int Num_coureur
        {
            get
            {
                return this.num_coureur;
            }

            set
            {
                this.num_coureur = value;
            }
        }

        public TimeSpan Temps_prevu
        {
            get
            {
                return this.temps_prevu;
            }

            set
            {
                this.temps_prevu = value;
            }
        }

    }
}
