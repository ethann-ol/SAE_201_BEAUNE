using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Amis
    {
		private int num_ami;

		public int Num_ami
		{
			get { return num_ami; }
			set { num_ami = value; }
		}

        public Amis(int num_ami)
        {
            Num_ami = num_ami;
        }
    }
}
