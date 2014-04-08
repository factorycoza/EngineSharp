using System;
using System.Collections.Generic;

namespace EngineSample
{
    public class Company : EngineResource
    {
        private const string Path = "companies";

        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceReference { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Url { get; set; }

        public Company Update()
        {
            return Update(this, Path);
        }

        public static List<Company> All()
        {
            return All<Company>(Path);
        }

        public static Company Create(Company company)
        {
            return Create(company, Path);
        }

    }
}

