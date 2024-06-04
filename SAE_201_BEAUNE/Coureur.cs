using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAE_201_BEAUNE
{
    internal class Coureur
    {
		private int num_courreur;

		public int Num_courreur
		{
			get { return num_courreur; }
			set { num_courreur = value; }
		}

		private string code_club;

		public string Code_club
		{
			get { return code_club; }
			set {
				if (value.Length > 2)
					throw new ArgumentException("Le code club est trop long");
				if (String.IsNullOrEmpty(value))
					throw new ArgumentException("");
				
				
				code_club = value; }
		}
		private int num_federation;

		public int Num_federation
		{
			get { return num_federation; }
			set { num_federation = value; }
		}
		private string nom_coureur;

		public string Nom_coureur
		{
			get { return nom_coureur; }
			set { nom_coureur = value; }
		}
		private string lien_photo;

		public string Lien_photo
		{
			get { return lien_photo; }
			set { lien_photo = value; }
		}
		private string prenom_coureur;

		public string Prenom_coureur
		{
			get { return prenom_coureur; }
			set { prenom_coureur = value; }
		}
		private string ville_coureur;

		public string Ville_coureur
		{
			get { return ville_coureur; }
			set { ville_coureur = value; }
		}
		private string portable;

		public string Portable
		{
			get { return portable; }
			set { portable = value; }
		}
		private string sexe;

		public string Sexe
		{
			get { return sexe; }
			set { sexe = value; }
		}
		private string num_licence;

		public string Num_licence
		{
			get { return num_licence; }
			set { num_licence = value; }
		}



	}
}
