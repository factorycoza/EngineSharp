using System;
using System.Collections.Generic;
using RestSharp;

namespace EngineSample
{
  public class Listing : EngineResource
  {
    private const string path = "listings";

    public Address address { get; set; }
    public List<Agent> agents { get; set; }
    public string authority { get; set; }
    public List<Building> buildings { get; set; }
    public string category { get; set; }
    public string currency_code { get; set; }
    public string currency_name { get; set; }
    public DateTime date_available { get; set; }
    public string description { get; set; }
    public List<Feature> features { get; set; }
    public DateTime first_listed_at { get; set; }
    public bool furnished { get; set; }
    public string headline { get; set; }
    public List<ListingImage> images { get; set; }
    public DateTime list_until { get; set; }
    public string property_type { get; set; }
    public string listing_type { get; set; }
    public bool negotiable { get; set; }
    public bool new_construction { get; set; }
    public string ownership_type { get; set; }
    public bool price_on_application { get; set; }
    public int rates_amount { get; set; }
    public int sale_price { get; set; }
    public string status_sellable { get; set; }
    public string tenancy { get; set; }
    public string terms { get; set; }
    public bool under_offer { get; set; }
    public string source_reference { get; set; }

    public Listing Update() {
      return Listing.Update (this);
    }

    public static List<Listing> All ()
    {
      IRestRequest request = CreateRequest (path, Method.GET);
      request.RootElement = "results"; // this is to do with the way index requests are paged
      IRestResponse<List<Listing>> listings = Client ().Execute<List<Listing>> (request);
      return listings.Data;
    }

    public static Listing Create(Listing listing) {
      return EngineResource.Create<Listing> (listing, path);
    }

    public static Listing Update(Listing listing) {
      return EngineResource.Update<Listing> (listing, path);
    }
 
  }
}

