using System.Collections.Generic;

namespace EngineSample
{
    public class Agent : EngineResource
    {
        private const string Path = "agents";

        public int BranchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Url { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string SourceReference { get; set; }

        public Agent Update()
        {
            return Update(this, Path);
        }

        public static List<Agent> All()
        {
            return All<Agent>(Path);
        }

        public static Agent Create(Agent agent)
        {
            return Create(agent, Path);
        }

    }
}

