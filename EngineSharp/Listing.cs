using System;
using System.Collections.Generic;
using RestSharp;

namespace EngineSample
{
    public class Listing : EngineResource
    {
        private const string path = "listings";

        public Address Address { get; set; }
        public List<Agent> Agents { get; set; }
        public string Authority { get; set; }
        public List<Building> Buildings { get; set; }
        public string Category { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public DateTime DateAvailable { get; set; }
        public string Description { get; set; }
        public List<Feature> Features { get; set; }
        public DateTime FirstListedAt { get; set; }
        public bool Furnished { get; set; }
        public string Headline { get; set; }
        public List<ListingImage> Images { get; set; }
        public DateTime ListUntil { get; set; }
        public string PropertyType { get; set; }
        public string ListingType { get; set; }
        public bool Negotiable { get; set; }
        public bool NewConstruction { get; set; }
        public string OwnershipType { get; set; }
        public bool PriceOnApplication { get; set; }
        public int RatesAmount { get; set; }
        public int SalePrice { get; set; }
        public string StatusSellable { get; set; }
        public string Tenancy { get; set; }
        public string Terms { get; set; }
        public bool UnderOffer { get; set; }
        public string SourceReference { get; set; }

        public Listing Update()
        {
            return Update(this, path);
        }

        public static List<Listing> All()
        {
            var request = CreateRequest(path, Method.GET);
            request.RootElement = "results"; // this is to do with the way index requests are paged
            var client = CreateClient();
            var listings = client.Execute<List<Listing>>(request);
            return listings.Data;
        }

        public static Listing Create(Listing listing)
        {
            return Create(listing, path);
        }
    }
}