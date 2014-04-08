using System;

namespace EngineSample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // ****************** Companies ******************
            Console.WriteLine("Getting Companies ...");
            var companies = Company.All();
            foreach (var company in companies)
            {
                Console.WriteLine(company.Id + ": " + company.Name);
            }

            Company thisCompany;
            if (companies.Count == 0)
            {
                Console.WriteLine("Creating a new company ...");
                thisCompany = new Company
                {
                    Description = "Acme Properties",
                    Name = "Acme Prop",
                    Email = "acme@engine.co.za"
                };
                thisCompany = Company.Create(thisCompany);
            }
            else
            {
                thisCompany = companies[0];
            }

            Console.WriteLine("Updating company ...");
            thisCompany.Name = "Other Acme Prop";
            thisCompany = thisCompany.Update();

            // ****************** Branches ******************
            Console.WriteLine("Getting Branches ...");
            var branches = Branch.All();
            foreach (var branch in branches)
            {
                Console.WriteLine(branch.Id + ": " + branch.Name);
            }

            Branch thisBranch;
            if (branches.Count == 0)
            {
                Console.WriteLine("Creating a new branch ...");
                thisBranch = new Branch
                {
                    Name = "Acme Branch #1",
                    Description = "The first ever Acme Branch"
                };
                thisBranch = Branch.Create(thisBranch);
            }
            else
            {
                thisBranch = branches[0];
            }

            Console.WriteLine("Updating branch ...");
            thisBranch.Name = "Acme Branch #2 actually";
            thisBranch = thisBranch.Update();

            // ****************** Agents ******************
            Console.WriteLine("Getting Agents ...");
            var agents = Agent.All();
            foreach (var agent in agents)
            {
                Console.WriteLine(agent.Id + ": " + agent.FirstName + " " + agent.LastName);
            }

            Agent thisAgent;
            if (agents.Count == 0)
            {
                Console.WriteLine("Creating a new agent ...");
                thisAgent = new Agent
                {
                    BranchId = branches[0].Id,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "smithers@engine.co.za"
                };
                thisAgent = Agent.Create(thisAgent);
            }
            else
            {
                thisAgent = agents[0];
            }

            Console.WriteLine("Updating agent ...");
            thisAgent.FirstName = "Jack";
            thisAgent = thisAgent.Update();

            // ****************** Listings ******************
            var listings = Listing.All();
            foreach (var listing in listings)
            {
                Console.WriteLine(listing.Id + ": " + listing.Headline);
            }

            Listing thisListing;
            if (listings.Count == 0)
            {
                thisListing = new Listing
                {
                    PropertyType = "residential",
                    ListingType = "sale",
                    StatusSellable = "current",
                    Headline = "A cool house",
                    Description = "This is a pretty cool house",
                    Address = new Address
                    {
                        Suburb = "Wonderland",
                        PostalCode = "1234"
                    },
                    Features =
                    {
                        new Feature
                        {
                            Name = "Bedrooms",
                            Count = "2"
                        }
                    },
                    Images =
                    {
                        new ListingImage
                        {
                            Caption = "Awesomesauce",
                            Url =
                                "http://propertygenie.co.za/assets/index_background-84ec0c49973c354e38aea4b19d440e69.jpg"
                        },
                        new ListingImage
                        {
                            Caption = "Awesomesauce",
                            Url =
                                "http://propertygenie.co.za/assets/index_background-84ec0c49973c354e38aea4b19d440e69.jpg"
                        }
                    },
                    Buildings =
                    {
                        new Building
                        {
                            AreaUnit = "sqm",
                            AreaValue = 1000
                        }
                    }
                };
                thisListing = Listing.Create(thisListing);
            }
            else
            {
                thisListing = listings[0];
            }
            thisListing.Headline = "Definitely a cool house";
            thisListing.Address = new Address()
            {
                Street = "Northumberland Ave",
                StreetNumber = "123",
                Suburb = "Wonderland",
                Town = "Townville",
                PostalCode = "1234"
            };
            thisListing.Update();

            Console.WriteLine("Done..");
            Console.ReadLine();
        }
    }
}
