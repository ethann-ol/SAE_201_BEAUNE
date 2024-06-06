using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Federation
    {
        private int num_federation;
        private string nom_federation;

        public Federation(int num_federation, string nom_federation)
        {
            this.Num_federation = num_federation;
            this.Nom_federation = nom_federation;
        }

        public int Num_federation
        {
            get
            {
                return this.num_federation;
            }

            set
            {
                this.num_federation = value;
            }
        }

        public string Nom_federation
        {
            get
            {
                return this.nom_federation;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Vous devez saisir un nom de fédération valide");
                if (value.Length < 10)
                    throw new ArgumentException("Le nom de fédération est trop long");
                this.nom_federation = value;
            }
        }
    }
}
