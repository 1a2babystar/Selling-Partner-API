using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DFOrder.Model
{
    abstract class temp
    {
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }
    }

    class POpayload : temp
    {
        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Order> Orders { get; set; }
    }

    class SLpayload : temp
    {
        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ShippingLabel> ShippingLabel { get; set; }
    }

    

    class ShippingLabel
    {
        [JsonProperty("purchaseOrderNumber")]
        public string PurchaseOrderNumber { get; set; }
        public PartyIdentification sellingParty { get; set; }
        public PartyIdentification shipFromParty { get; set; }
        public int labelFormat { get; set; }
        public IList<LabelData> labelData { get; set; }
    }

    class PartyIdentification
    {
        [JsonProperty("partyId")]
        public string partyId { get; set; }
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Address address { get; set; }
        [JsonProperty("taxRegistrationDetails", NullValueHandling = NullValueHandling.Ignore)]
        public IList<TaxRegistrationDetails> taxRegistrationDetails { get; set; }
    }

    class LabelData
    {
        [JsonProperty("packageIdentifier", NullValueHandling = NullValueHandling.Ignore)]
        public string packageIdentifier { get; set; }
        [JsonProperty("trackingNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string trackingNumber { get; set; }
        [JsonProperty("shipMethod", NullValueHandling = NullValueHandling.Ignore)]
        public string shipMethod { get; set; }
        [JsonProperty("shipMethodName", NullValueHandling = NullValueHandling.Ignore)]
        public string shipMethodName { get; set; }
        [JsonProperty("content")]
        public string content { get; set; }
    }

    class Address
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("addressLine1")]
        public string addressLine1 { get; set; }
        [JsonProperty("addressLine2", NullValueHandling = NullValueHandling.Ignore)]
        public string addressLine2 { get; set; }
        [JsonProperty("addressLine3", NullValueHandling = NullValueHandling.Ignore)]
        public string addressLine3 { get; set; }
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string city { get; set; }
        [JsonProperty("county", NullValueHandling = NullValueHandling.Ignore)]
        public string county { get; set; }
        [JsonProperty("district", NullValueHandling = NullValueHandling.Ignore)]
        public string district { get; set; }
        [JsonProperty("stateOrRegion", NullValueHandling = NullValueHandling.Ignore)]
        public string stateOrRegion { get; set; }
        [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
        public string postalCode { get; set; }
        [JsonProperty("countryCode")]
        public string countryCode { get; set; }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string phone { get; set; }
    }

    class TaxRegistrationDetails
    {
        [JsonProperty("taxRegistrationType", NullValueHandling = NullValueHandling.Ignore)]
        public int taxRegistrationType { get; set; }
        [JsonProperty("taxRegistrationNumber")]
        public string taxRegistrationNumber { get; set; }
        [JsonProperty("taxRegistrationAddress", NullValueHandling = NullValueHandling.Ignore)]
        public Address taxRegistrationAddress { get; set; }
        [JsonProperty("taxRegistrationMessages", NullValueHandling = NullValueHandling.Ignore)]
        public string taxRegistrationMessages { get; set; }
    }

    class RestrictedResource
    {
        public string method { get; set; }
        public string path { get; set; }
        public List<string> dataElements { get; set; }

        public RestrictedResource(string method, string path, List<string> dataElements)
        {
            this.method = method;
            this.path = path;
            this.dataElements = dataElements;
        }
    }

    class restrictedresource
    {
        public string restrictedDataToken { get; set; }
        public int expiresIn { get; set; }
    }

    class accesstokenresponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
