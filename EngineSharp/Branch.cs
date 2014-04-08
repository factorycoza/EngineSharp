using System.Collections.Generic;

namespace EngineSample
{
    public class Branch : EngineResource
    {
        private const string Path = "branches";

        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceReference { get; set; }

        public Branch Update()
        {
            return Update(this, Path);
        }

        public static List<Branch> All()
        {
            return All<Branch>(Path);
        }

        public static Branch Create(Branch branch)
        {
            return Create(branch, Path);
        }

    }
}

