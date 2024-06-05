using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_201_BEAUNE
{
    public class Agent
    {
		private int num_agent;

		public int Num_agent
		{
			get { return num_agent; }
			set { num_agent = value; }
		}
		private string login_agent;

		public string Login_agent
		{
			get { return login_agent; }
			set {
				if (value.Length > 8)
					throw new Exception("Le login n'est pas correct");
				login_agent = value; }
		}
		private string mdp_agent;

		public string Mdp_agent
		{
			get { return mdp_agent; }
			set {
				if (value.Length > 20)
					throw new Exception("Le mdp est trop long");
				mdp_agent = value; }
		}

        public Agent(string login_agent, string mdp_agent)
        {
            this.Login_agent = login_agent;
            this.Mdp_agent = mdp_agent;
        }

        public Agent()
        {
        }

        public override string? ToString()
        {
            return $"ID: {this.Login_agent}" +
				$"MDP: {this.Mdp_agent}";
        }
    }
}
