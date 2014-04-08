using System;
using System.Collections;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serializers;

namespace EngineSample
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            // companies
            var companies = Company.All();
            foreach (var company in companies)
            {
                Console.WriteLine(company.Id + ": " + company.Name);
            }

            return;

            var newCompany = new Company()
            {
                Description = "Acme Properties",
                Name = "Acme Prop",
                Email = "acme@engine.co.za"
            };
            newCompany = Company.Create(newCompany);
            newCompany.Name = "Other Acme Prop";
            newCompany = newCompany.Update();

            // branches
            var branches = Branch.All();
            foreach (var branch in branches)
            {
                Console.WriteLine(branch.Id + ": " + branch.Name);
            }
            var newBranch = new Branch()
            {
                Name = "Acme Branch #1",
                Description = "The first ever Acme Branch"
            };
            newBranch = Branch.Create(newBranch);
            newBranch.Name = "Acme Branch #2 actually";
            newBranch = newBranch.Update();

            // agents
            var agents = Agent.All();
            foreach (var agent in agents)
            {
                Console.WriteLine(agent.Id + ": " + agent.FirstName + " " + agent.LastName);
            }
            var newAgent = new Agent()
            {
                BranchId = newBranch.Id,
                FirstName = "John",
                LastName = "Smith",
                Email = "smithers@engine.co.za"
            };
            newAgent = Agent.Create(newAgent);
            newAgent.FirstName = "Jack";
            newAgent = newAgent.Update();

            // listings
            var listings = Listing.All();
            foreach (var listing in listings)
            {
                Console.WriteLine(listing.Id.ToString() + ": " + listing.Headline);
            }
            var new_listing = new Listing()
            {
                PropertyType = "residential",
                ListingType = "sale",
                StatusSellable = "current",
                Headline = "A cool house",
                Description = "This is a pretty cool house",
                Features = new List<Feature>(),
                Images = new List<ListingImage>(),
                Buildings = new List<Building>()
            };
            var bedrooms = new Feature()
            {
                Name = "Bedrooms",
                Count = "2"
            };
            new_listing.Features.Add(bedrooms);
            var image = new ListingImage()
            {
                Caption = "Awesomesauce",
                Url = "http://propertygenie.co.za/assets/index_background-84ec0c49973c354e38aea4b19d440e69.jpg"
            };
            new_listing.Images.Add(image);
            new_listing = Listing.Create(new_listing);
            new_listing.Headline = "Definitely a cool house";
            new_listing.Address = new Address()
            {
                Street = "Northumberland Ave",
                StreetNumber = "123",
                Suburb = "Wonderland",
                Town = "Townville"
            };
            var building = new Building()
            {
                AreaUnit = "sqm",
                AreaValue = 1000
            };
            new_listing.Buildings.Add(building);
            new_listing.Update();

            Console.WriteLine("Done..");
            Console.ReadLine();
        }
    }
}
