﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Signer;
using DFOrder.Model;
using AmazonClient.InventoryModel;
using AmazonClient.Ack;
using System.Timers;
using System.Net;
using System.Collections.Specialized;
using Amazon.SellingPartnerAPIAA;

namespace AmazonClient
{
    class Program
    {
        #region Prop
        static private AuthHelper signatureHelper;
        static private RestClient restClient;
        static private RestRequest restRequest;
        private const string live_url_base = "https://sellingpartnerapi-na.amazon.com";
        private const string sandbox_url_base = "https://sandbox.sellingpartnerapi-na.amazon.com";//did not work
        static string content_form_urlencoded = "application/x-www-form-urlencoded";
        static string content_json = "application/json";
        static string purchase_order_resource = "/vendor/directFulfillment/orders/v1/purchaseOrders";
        static string ack_order_resource = "/vendor/directFulfillment/orders/v1/acknowledgements";
        static string restricted_token = "/tokens/2021-03-01/restrictedDataToken";
        #endregion
        static void Main(string[] args)
        {
            //Timer aTimer = new System.Timers.Timer(60 * 60 *1000);
            //aTimer.Elapsed += new ElapsedEventHandler(Routine);
            //aTimer.Start();
            //Console.ReadLine();

            signatureHelper = new AuthHelper(
                 AppCred.Default.ClientId, AppCred.Default.ClientSecret, AppCred.Default.RefreshToken, new Uri(AppCred.Default.Endpoint),
                 AppCred.Default.AccessKeyId, AppCred.Default.SecretKey, AppCred.Default.Region
            );

            //OrderImport();
            getRtoken();
            //UpdateInventory();

            //"03", "Canceled out of stock"
            //SubmitAck(BuildAck("00", "Shipping 100 percent of ordered product"));

        }

        static string getRtoken()
        {
            List<string> li = new List<string>();
            li.Add("buyerInfo");
            li.Add("shippingAddress");
            restClient = new RestClient(live_url_base);
            IRestRequest restRequest = new RestRequest(restricted_token, Method.POST);

            restRequest.AddHeader("x-amz-access-token", signatureHelper.GetToken());

            restRequest.AddQueryParameter("method", "GET");
            restRequest.AddQueryParameter("path", "/vendor/directFulfillment/orders/v1/purchaseOrders");
            restRequest.AddQueryParameter("dataElements", li.ToString());

            var request = signatureHelper.SignRequest(restRequest, restClient, "application/json");
            try
            {
                var result = restClient.Execute(request);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var payload = JsonConvert.DeserializeObject<Payload>(result.Content);
                    Console.WriteLine(payload);
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    Console.WriteLine(result.Content);
                    Console.ReadLine();
                    string new_token = signatureHelper.GetToken();
                }
            }
            catch (Exception e)
            {
                throw;
            }


            //RestrictedResource rt = new RestrictedResource("GET", "/vendor/directFulfillment/orders/v1/purchaseOrders", li);

            //var wb = new WebClient();
            //var data = new NameValueCollection();
            //string url = "https://sellingpartnerapi-na.amazon.com/tokens/2021-03-01/restrictedDataToken";
            //wb.Headers.Add("x-amz-access-token", signatureHelper.GetToken());
            //data["method"] = "GET";
            //data["path"] = "/vendor/directFulfillment/orders/v1/purchaseOrders";
            //data["dataElements"] = li.ToString();
            //try
            //{
            //    var response = wb.UploadValues(url, "POST", data);
            //    string s = wb.Encoding.GetString(response);
            //    var res = JsonConvert.DeserializeObject<restrictedresource>(s);
            //    Console.WriteLine(res);
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}

            return "a";
        }

        private static void Routine(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("one second");
        }

        //static void ShipmentImport()
        //{
        //    restClient = new RestClient(live_url_base);
        //    IRestRequest restRequest = new RestRequest(purchase_order_resource, Method.GET);

        //    restRequest.AddHeader("x-amz-access-token", "token_from_your_secure_db");

        //    restRequest.AddQueryParameter("createdAfter", DateTime.Now.AddHours(-1).ToString("o"));
        //    restRequest.AddQueryParameter("createdBefore", DateTime.Now.ToString("o"));

        //    var request = signatureHelper.SignRequest(restRequest, restClient, content_form_urlencoded);

        //    try
        //    {
        //        var result = restClient.Execute(request);
        //        if(result.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            var payload = JsonConvert.DeserializeObject<SLpayload>(result.Content);

        //            foreach (var shippinglabel in payload.ShippingLabel)
        //            {

        //            }
        //        }
        //    }
        //}


        static void OrderImport()
        {
            restClient = new RestClient(sandbox_url_base);
            IRestRequest restRequest = new RestRequest(purchase_order_resource, Method.GET);

            restRequest.AddHeader("x-amz-access-token", signatureHelper.GetToken());

            //restRequest.AddQueryParameter("createdAfter", DateTime.Now.AddHours(-7).ToString("o"));
            //restRequest.AddQueryParameter("createdBefore", DateTime.Now.ToString("o"));

            restRequest.AddQueryParameter("createdBefore", "2020-02-20T00:00:00-08:00");
            restRequest.AddQueryParameter("createdAfter", "2020-02-15T14:00:00-08:00");
            restRequest.AddQueryParameter("includeDetails", "true");
            restRequest.AddQueryParameter("limit", "2");
            restRequest.AddQueryParameter("sortOrder", "DESC");

            var request = signatureHelper.SignRequest(restRequest, restClient, content_form_urlencoded);

            try
            {
                var result = restClient.Execute(request);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //read your orders
                    var payload = JsonConvert.DeserializeObject<Payload>(result.Content);
                    Console.WriteLine(payload);
                    //foreach (var order in payload.Orders)
                    //{
                    //    string po = order.PurchaseOrderNumber;
                    //    DateTime orderDate = order.OrderDetails.OrderDate;


                    //    foreach (var item in order.OrderDetails.Items)
                    //    {
                    //        string vendorSku = item.VendorProductIdentifier;
                    //        string price = item.NetPrice.Amount;
                    //        int qty = item.OrderedQuantity.Amount;

                    //    }
                    //}

                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    Console.WriteLine(result.Content);
                    Console.ReadLine();
                    //bad token
                    string new_token = signatureHelper.GetToken();

                    //save new_token to your secure location/db and run OrderImport again
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        static void UpdateInventory()
        {
            string your_dc_id = "ABC";

            string inventory_url = "/vendor/directFulfillment/inventory/v1/warehouse/" + your_dc_id + "/items";

            restClient = new RestClient(live_url_base);
            IRestRequest restRequest = new RestRequest(inventory_url, Method.POST);


            restRequest.AddHeader("x-amz-access-token", signatureHelper.GetToken());

            string json = BuildInventoryUpdateFeed();

            restRequest.AddParameter(content_json, json, ParameterType.RequestBody);

            var request = signatureHelper.SignRequest(restRequest, restClient, content_json);

            try
            {
                var result = restClient.Execute(request);

            }
            catch (Exception e)
            {

                throw;
            }


        }

        static string BuildInventoryUpdateFeed()
        {
            var details = new InventoryDetails();
            details.sellingParty = new InventoryModel.SellingParty() { partyId = "your_vendor_id" };
            details.isFullUpdate = false;

            var update = new InventoryUpdate();
            update.inventory = details;

            var list = new List<InventoryItem>();
            var item = new InventoryItem();
            item.buyerProductIdentifier = "buyer_item";
            item.vendorProductIdentifier = "vendor_item";
            item.isObsolete = false;

            var available = new Available();
            available.amount = 345;
            available.unitOfMeasure = "Each";

            item.availableQuantity = available;

            list.Add(item);

            details.items = list;

            return JsonConvert.SerializeObject(update, Formatting.Indented);


        }

        static AckOrders BuildAck(string code, string description)
        {


            string amazon_po = "get_amazon_po_from_your_db";

            var ackRequest = new AckOrders();
            var ackList = new List<OrderAcknowledgement>();

            var ack = new OrderAcknowledgement();
            ack.AcknowledgementDate = DateTime.Now.ToString("o");

            var ackStatus = new AcknowledgementStatus();
            ackStatus.Code = code;
            ackStatus.Description = description;

            ack.AcknowledgementStatus = ackStatus;

            ack.PurchaseOrderNumber = amazon_po;

            ack.SellingParty = new Ack.SellingParty { PartyId = "your_selling_id" };//SellingParty and ShipFromParty are other models too
            ack.ShipFromParty = new Ack.ShipFromParty { PartyId = "your_ship_from_id" };

            ack.VendorOrderNumber = "your_system_order_number";

            var items = new List<ItemAcknowledgements>();

            var i = new ItemAcknowledgements();
            i.AcknowledgedQuantity = new AcknowledgedQuantity { Amount = 2, UnitOfMeasure = "Each" };

            i.BuyerProductIdentifier = "get_item_id_from_amazon_order";

            i.ItemSequenceNumber = "1";//amazon order should have this data

            i.VendorProductIdentifier = "your_seller_sku";

            items.Add(i);

            ack.Items = items;

            ackList.Add(ack);

            ackRequest.OrderAcknowledgements = ackList;

            return ackRequest;
        }

        static void SubmitAck(AckOrders order)
        {          
            RestClient restClient = new RestClient(live_url_base);
            IRestRequest restRequest = new RestRequest(ack_order_resource, Method.POST);

            //restRequest.AddHeader("Accept", content_json);
            //adding token on the client side
            restRequest.AddHeader("x-amz-access-token", signatureHelper.GetToken());

            //add the body
            string json = JsonConvert.SerializeObject(order, Formatting.Indented);

            restRequest.AddParameter("orderAcknowledgements", json, content_json, ParameterType.RequestBody);

            restRequest = signatureHelper.SignRequest(restRequest, restClient, content_json);

            try
            {
                var result = restClient.Execute(restRequest);

                System.IO.File.WriteAllText("C:\\Amazon1P\\ack\\" + Guid.NewGuid() + ".txt", result.Content);//keep the orignal message

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var payload = JsonConvert.DeserializeObject<POSTResponse>(result.Content);
                 
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    var payload = JsonConvert.DeserializeObject<POSTResponse>(result.Content);

                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    //token expired - get a new one
                    string new_toke = signatureHelper.GetToken();

                    //AppCred.Default.AccessToken = new_toke;
                    //AppCred.Default.Save();
                   
                        //saved new token
                        //run again
                        
                        SubmitAck(order);                    
                }
                else
                {
                    //problem
                    //Status: 400 - Request has missing or invalid parameters and cannot be parsed.
                    //Status: 403 - 403 can be caused for reasons like Access Denied, Unauthorized, Expired Token, Invalid Signature or Resource Not Found.
                    //Status: 404 - The resource specified does not exist.
                    //Status: 415 - The entity of the request is in a format not supported by the requested resource.
                    //Status: 429 - The frequency of requests was greater than allowed.
                    //Status: 500 - Encountered an unexpected condition which prevented the server from fulfilling the request.
                    //Status: 503 - Temporary overloading or maintenance of the server.


                }
            }
            catch (Exception e)
            {
                //save error 
            }



        }
    }
}
