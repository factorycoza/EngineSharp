using System;
using System.Collections.Generic;

namespace EngineSample
{
  public class Agent : EngineResource
	{
    private const string path = "agents";

    public int branch_id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public string telephone { get; set; }
		public string mobile { get; set; }
		public string fax { get; set; }
		public string url { get; set; }
		public string twitter_url { get; set; }
		public string facebook_url { get; set; }
		public string linkedin_url { get; set; }
		public string secondary_phone_number { get; set; }
		public string source_reference { get; set; }

    public Agent Update() {
      return Agent.Update (this);
    }

    public static List<Agent> All() {
      return EngineResource.All<Agent> (path);
    }

    public static Agent Create(Agent Agent) {
      return EngineResource.Create<Agent> (Agent, path);
    }

    public static Agent Update(Agent Agent) {
      return EngineResource.Update<Agent> (Agent, path);
    }

	}
}

