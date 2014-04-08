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
      var companies = Company.All ();
      foreach (var company in companies) {
        Console.WriteLine (company.id.ToString () + ": " + company.name);
      }
      var new_company = new Company();
      new_company.description = "Acme Properties";
      new_company.name = "Acme Prop";
      new_company.email = "acme@engine.co.za";
      new_company = Company.Create(new_company);
      new_company.name = "Other Acme Prop";
      new_company = new_company.Update ();
      var branches = Branch.All ();
      foreach (var branch in branches) {
        Console.WriteLine (branch.id.ToString () + ": " + branch.name);
      }
      var new_branch = new Branch ();
      new_branch.name = "Acme Branch #1";
      new_branch.description = "The first ever Acme Branch";
      new_branch = Branch.Create (new_branch);
      new_branch.name = "Acme Branch #2 actually";
      new_branch = new_branch.Update ();
      var agents = Agent.All ();
      foreach (var agent in agents) {
        Console.WriteLine (agent.id.ToString () + ": " + agent.first_name + " " + agent.last_name);
      }
      var new_agent = new Agent ();
      new_agent.branch_id = new_branch.id;
      new_agent.first_name = "John";
      new_agent.last_name = "Smith";
      new_agent.email = "smithers@engine.co.za";
      new_agent = Agent.Create (new_agent);
      new_agent.first_name = "Jack";
      new_agent = new_agent.Update ();
      var listings = Listing.All ();
      foreach (var listing in listings) { 
        Console.WriteLine (listing.id.ToString () + ": " + listing.headline);
      }
      var new_listing = new Listing();
      new_listing.property_type = "residential";
      new_listing.listing_type = "sale";
      new_listing.status_sellable = "current";
      new_listing.headline = "A cool house";
      new_listing.description = "This is a pretty cool house";
      new_listing.features = new List<Feature> ();
      var bedrooms = new Feature ();
      bedrooms.name = "Bedrooms";
      bedrooms.count = "2";
      new_listing.features.Add (bedrooms);
      var image = new ListingImage ();
      image.caption = "Awesomesauce";
      image.url = "http://propertygenie.co.za/assets/index_background-84ec0c49973c354e38aea4b19d440e69.jpg";
      new_listing.images = new List<ListingImage> ();
      new_listing.images.Add (image);
      new_listing = Listing.Create (new_listing);
      new_listing.headline = "Definitely a cool house";
      new_listing.address = new Address ();
      new_listing.address.street = "Northumberland Ave";
      new_listing.address.street_number = "123";
      new_listing.address.suburb = "Wonderland";
      new_listing.address.town = "Townville";
      new_listing.buildings = new List<Building> ();
      var building = new Building ();
      building.area_unit = "sqm";
      building.area_value = 1000;
      new_listing.buildings.Add (building);
      new_listing.Update ();
      Console.WriteLine ("Done..");
      Console.ReadLine ();
    }
  }
}
