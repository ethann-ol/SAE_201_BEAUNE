using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Club
    {
        private string code_club;
        private string nom_club;

        public string Code_club
        {
            get { return code_club; }
            set
            {
                if (value.Length > 2)
                    throw new ArgumentException("Le code club est trop long");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Vous devez saisir un code club valide");


                this.code_club = value;
            }
        }
        private int distance;

        public string Nom_club
        {
            get { return nom_club; }
            set
            {
                if (value.Length > 25)
                    throw new ArgumentException("Le nom club est trop long");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Vous devez saisir un nom de club valide");



                this.nom_club = value;
            }
        }

        public Club(string code_club, string nom_club)
        {
            this.Code_club = code_club;
            this.Nom_club = nom_club;
        }
    }
}
