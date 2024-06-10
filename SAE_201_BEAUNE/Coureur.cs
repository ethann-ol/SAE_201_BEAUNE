using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAE_201_BEAUNE
{
    public enum SexeCoureur { Homme = 'H', Femme = 'F'};

    public class Coureur
    {
		private int num_coureur;

		public int Num_coureur
		{
			get { return this.num_coureur; }
			set { this.num_coureur = value; }
		}

		private string code_club;

		public string Code_club
		{
			get { return this.code_club; }
			set {
				if (value.Length > 2)
					throw new ArgumentOutOfRangeException("Le code club est trop long");
				this.code_club = value;
			}
		}
		private string num_federation;

		public string Num_federation
		{
			get { return this.num_federation; }
			set {
                this.num_federation = value; }
		}
		private string nom_coureur;

		public string Nom_coureur
		{
			get { return this.nom_coureur; }
			set {
                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Le nom coureur est trop long");
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Le nom coureur ne peut pas etre vide");
                this.nom_coureur = value;
			}
		}
		private string lien_photo;

		public string Lien_photo
		{
			get { return this.lien_photo; }
			set {
                if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("Le lien est trop long");
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Le lien ne peut pas etre vide");
                this.lien_photo = value;

            }
		}
		private string prenom_coureur;

		public string Prenom_coureur
		{
			get { return this.prenom_coureur; }
			set {
                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Le prenom est trop long");
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Le prenom ne peut pas etre vide");
                this.prenom_coureur = value;
            }
		}
		private string ville_coureur;

		public string Ville_coureur
		{
			get { return this.ville_coureur; }
			set {
                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("La ville est trop longue");
                this.prenom_coureur = value;
            }
		}
		private string portable;

		public string Portable
		{
			get { return this.portable; }
			set {
				if (value.Length != 10)
					throw new ArgumentException("Le numero de telephone n'est pas correct");
				this.portable = value; }
		}
		private SexeCoureur sexe;

		public SexeCoureur Sexe
		{
			get { return this.sexe; }
			set { this.sexe = value; }
		}
		private string num_licence;

		public string Num_licence
		{
			get { return this.num_licence; }
			set {
				if (value.Length != 10)
					throw new ArgumentOutOfRangeException("Le numero de licence est incorrect");
				this.num_licence = value; }
		}
        public Coureur(int num_coureur, string code_club, string num_federation, string nom_coureur, string lien_photo, string prenom_coureur, string ville_coureur, string portable, SexeCoureur sexe, string num_licence)
        {
            this.Num_coureur = num_coureur;
            this.Code_club = code_club;
            this.Num_federation = num_federation;
            this.Nom_coureur = nom_coureur;
            this.Lien_photo = lien_photo;
            this.Prenom_coureur = prenom_coureur;
            this.Ville_coureur = ville_coureur;
            this.Portable = portable;
            this.Sexe = sexe;
            this.Num_licence = num_licence;
        }
        public Coureur(int num_coureur, string code_club, string num_federation, string nom_coureur, string prenom_coureur, string portable)
        {
            this.Num_coureur = num_coureur;
            this.Code_club = code_club;
            this.Num_federation = num_federation;
            this.Nom_coureur = nom_coureur;
            this.Prenom_coureur = prenom_coureur;
            this.Portable = portable;
        }

        public Coureur(int num_coureur, string code_club, string num_federation, string nom_coureur, string lien_photo, string prenom_coureur, string ville_coureur, string portable, string num_licence) : this(num_coureur, code_club, num_federation, nom_coureur, lien_photo, prenom_coureur)
        {
            Ville_coureur = ville_coureur;
            Portable = portable;
            Num_licence = num_licence;
        }
    }
}
