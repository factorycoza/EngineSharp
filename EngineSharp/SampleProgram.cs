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
        Console.WriteLine (company.id.ToString () + ": " + company.name);
      }
      var new_company = new Company() {
        description   = "Acme Properties",
        name          = "Acme Prop",
        email         = "acme@engine.co.za"
      };
      new_company = Company.Create(new_company);
      new_company.name = "Other Acme Prop";
      new_company = new_company.Update ();

      // branches
      var branches = Branch.All ();
      foreach (var branch in branches) {
        Console.WriteLine (branch.id.ToString () + ": " + branch.name);
      }
      var new_branch = new Branch () { 
        name        = "Acme Branch #1",
        description = "The first ever Acme Branch"
      };
      new_branch = Branch.Create (new_branch);
      new_branch.name = "Acme Branch #2 actually";
      new_branch = new_branch.Update ();

      // agents
      var agents = Agent.All ();
      foreach (var agent in agents) {
        Console.WriteLine (agent.id.ToString () + ": " + agent.first_name + " " + agent.last_name);
      }
      var new_agent = new Agent () { 
        branch_id  = new_branch.id,
        first_name = "John",
        last_name  = "Smith",
        email      = "smithers@engine.co.za"
      };
      new_agent = Agent.Create (new_agent);
      new_agent.first_name = "Jack";
      new_agent = new_agent.Update ();

      // listings
      var listings = Listing.All ();
      foreach (var listing in listings) { 
        Console.WriteLine (listing.id.ToString () + ": " + listing.headline);
      }
      var new_listing = new Listing () { 
        property_type   = "residential",
        listing_type    = "sale",
        status_sellable = "current",
        headline        = "A cool house",
        description     = "This is a pretty cool house",
        features        = new List<Feature> (),
        images          = new List<ListingImage> (),
        buildings       = new List<Building> ()
      };
      var bedrooms = new Feature () {
        name  = "Bedrooms",
        count = "2"
      };
      new_listing.features.Add (bedrooms);
      var image = new ListingImage () {
        caption = "Awesomesauce",
        url = "http://propertygenie.co.za/assets/index_background-84ec0c49973c354e38aea4b19d440e69.jpg"
      };
      new_listing.images.Add (image);
      new_listing = Listing.Create (new_listing);
      new_listing.headline = "Definitely a cool house";
      new_listing.address = new Address () {
        street        = "Northumberland Ave",
        street_number = "123",
        suburb        = "Wonderland",
        town          = "Townville"
      };
      var building = new Building () { 
        area_unit  = "sqm",
        area_value = 1000
      };
      new_listing.buildings.Add (building);
      new_listing.Update ();

      Console.WriteLine ("Done..");
      Console.ReadLine ();
    }
  }
}
