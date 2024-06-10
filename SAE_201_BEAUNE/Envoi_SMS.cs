using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Envoi_SMS
    {
        private int num_ami;
        private int num_inscription;
        private string portable_sms;

        public Envoi_SMS()
        {
        }

        public Envoi_SMS(int num_ami, int num_inscription, string portable_sms)
        {
            this.Num_ami = num_ami;
            this.Num_inscription = num_inscription;
            this.Portable_sms = portable_sms;
        }

        public int Num_ami
        {
            get
            {
                return this.num_ami;
            }

            set
            {
                this.num_ami = value;
            }
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

        public string Portable_sms
        {
            get
            {
                return this.portable_sms;
            }

            set
            {
             if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("Vous devez saisir un numéro de téléphone valide");
                if (value.Length != 10)
                    throw new ArgumentOutOfRangeException("Le numéro de téléphone saisi doit posséder 10 caractères");
                this.portable_sms = value;
            }
        }
    }
}
