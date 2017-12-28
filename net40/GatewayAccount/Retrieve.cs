﻿// =====================================================================
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace Samples.Net40
{
    /// <summary>
    /// This sample is to demo how to retrieve a gateway account profile 
    /// </summary>
    public partial class GatewayAccount
    {
        /// <summary>
        /// Retrieve a gateway account profile. Gateway account guid is generated by PayFabric,
        /// And 3rd party application may not keep this unique identifier. Howver developers can 
        /// still retrieve these unique identifiers by get all gateway account profiles by customer.
        /// 
        /// <param name="gatewayAccountId">GUID of gateway account profile</param>
        /// </summary>
        public void Retrieve(Guid gatewayAccountId)
        {
            try
            {
                var url = "https://sandbox.payfabric.com/v1/rest/api/setupid" + "/" + gatewayAccountId.ToString();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers["authorization"] = new Token().Create();
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string result = streamReader.ReadToEnd();   // JSON result
                Console.WriteLine(result);
                streamReader.Close();
                responseStream.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();

                //
                // Sample response
                // ------------------------------------------------------
                // Response text is a gateway account object with json format
                // Go to https://github.com/PayFabric/APIs/wiki/API-Objects#gateway-account for more details about gateway account object.
                // ------------------------------------------------------

            }
            catch (WebException e)
            {
                //  Handling exception from PayFabric
            }
            catch (Exception e)
            {
                //  Handling exception
            }

        }
    }
}
