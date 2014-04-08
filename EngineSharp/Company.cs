using System;
using System.Collections.Generic;

namespace EngineSample
{
	public class Company : EngineResource
	{
    private const string path = "companies";

		public string name { get; set; }
		public string description { get; set; }
		public string source_reference { get; set; }
		public string email { get; set; }
		public string telephone { get; set; }
		public string fax { get; set; }
		public string url { get; set; }

    public Company Update() {
      return Company.Update (this);
    }

		public static List<Company> All() {
      return EngineResource.All<Company> (path);
		}

    public static Company Create(Company company) {
      return EngineResource.Create<Company> (company, path);
    }

    public static Company Update(Company company) {
      return EngineResource.Update<Company> (company, path);
    }

	}
}

