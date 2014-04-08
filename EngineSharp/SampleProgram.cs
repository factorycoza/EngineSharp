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
    public static void Main (string[] args)
    {
      // companies
      var companies = Company.All ();
      foreach (var company in companies) {
        Console.WriteLine (company.id.ToString () + ": " + company.Name);
      }
      var new_company = new Company() {
        Description   = "Acme Properties",
        Name          = "Acme Prop",
        Email         = "acme@engine.co.za"
      };
      new_company = Company.Create(new_company);
      new_company.Name = "Other Acme Prop";
      new_company = new_company.Update ();

      // branches
      var branches = Branch.All ();
      foreach (var branch in branches) {
        Console.WriteLine (branch.id.ToString () + ": " + branch.Name);
      }
      var new_branch = new Branch () { 
        Name        = "Acme Branch #1",
        Description = "The first ever Acme Branch"
      };
      new_branch = Branch.Create (new_branch);
      new_branch.Name = "Acme Branch #2 actually";
      new_branch = new_branch.Update ();

      // agents
      var agents = Agent.All ();
      foreach (var agent in agents) {
        Console.WriteLine (agent.id.ToString () + ": " + agent.FirstName + " " + agent.LastName);
      }
      var new_agent = new Agent () { 
        BranchId  = new_branch.id,
        FirstName = "John",
        LastName  = "Smith",
        Email      = "smithers@engine.co.za"
      };
      new_agent = Agent.Create (new_agent);
      new_agent.FirstName = "Jack";
      new_agent = new_agent.Update ();

      // listings
      var listings = Listing.All ();
      foreach (var listing in listings) { 
        Console.WriteLine (listing.id.ToString () + ": " + listing.Headline);
      }
      var new_listing = new Listing () { 
        PropertyType   = "residential",
        ListingType    = "sale",
        StatusSellable = "current",
        Headline        = "A cool house",
        Description     = "This is a pretty cool house",
        Features        = new List<Feature> (),
        Images          = new List<ListingImage> (),
        Buildings       = new List<Building> ()
      };
      var bedrooms = new Feature () {
        Name  = "Bedrooms",
        Count = "2"
      };
      new_listing.Features.Add (bedrooms);
      var image = new ListingImage () {
        Caption = "Awesomesauce",
        Url = "http://propertygenie.co.za/assets/index_background-84ec0c49973c354e38aea4b19d440e69.jpg"
      };
      new_listing.Images.Add (image);
      new_listing = Listing.Create (new_listing);
      new_listing.Headline = "Definitely a cool house";
      new_listing.Address = new Address () {
        Street        = "Northumberland Ave",
        StreetNumber = "123",
        Suburb        = "Wonderland",
        Town          = "Townville"
      };
      var building = new Building () { 
        AreaUnit  = "sqm",
        AreaValue = 1000
      };
      new_listing.Buildings.Add (building);
      new_listing.Update ();

      Console.WriteLine ("Done..");
      Console.ReadLine ();
    }
  }
}
