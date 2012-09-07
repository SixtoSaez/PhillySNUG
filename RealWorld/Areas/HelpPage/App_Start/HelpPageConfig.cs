using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using RealWorld.Areas.Rest.Models;
using RealWorld.Models;

namespace RealWorld.Areas.HelpPage
{
    /// <summary>
    /// Use this class to customize the Help Page.
    /// For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
    /// or you can provide the samples for the requests/responses.
    /// </summary>
    public static class HelpPageConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Set to use the documentation from XML documentation file.
            config.SetDocumentationProvider(
                new XmlDocumentationProvider(
                    HttpContext.Current.Server.MapPath("~/App_Data/RealWorld.xml")));

            var controller = "LoginWithLinks";
            var action = "Get";
            SetupSampleForControllerAction(
                config,
                (sample, mediaType) => config.SetSampleResponse(sample, mediaType, controller, action),
                GetResponseLinkedCredentials());

            action = "Post";
            SetupSampleForControllerAction(
                config,
                (sample, mediaType) => config.SetSampleRequest(sample, mediaType, controller, action),
                PostRequestLinkedCredentials());

            SetupSampleForControllerAction(
                config,
                (sample, mediaType) => config.SetSampleResponse(sample, mediaType, controller, action),
                PostResponseLinkedCredentials());

            controller = "Login";
            action = "Post";
            SetupSampleForControllerAction(
                config,
                (sample, mediaType) => config.SetSampleRequest(sample, mediaType, controller, action),
                PostRequestCredentials());

            SetupSampleForControllerAction(
                config,
                (sample, mediaType) => config.SetSampleResponse(sample, mediaType, controller, action),
                PostResponseCredentials());

            controller = "SomeProcess";
            action = "Get";
            SetupSampleForControllerAction(
                config,
                (sample, mediaType) => config.SetSampleResponse(sample, mediaType, controller, action),
                GetResponseBizProcessStatus());

            controller = "SomeProcessWithLinks";
            action = "Get";
            SetupSampleForControllerAction(
                config,
                (sample, mediaType) => config.SetSampleResponse(sample, mediaType, controller, action),
                GetResponseLinkedBizProcessStatus());
        }

        private static void SetupSampleForControllerAction<T>(
            HttpConfiguration config,
            Action<object, MediaTypeHeaderValue> configAction,
            T sample)
        {
            // JSON
            var mediaTypeHeaderValue = new MediaTypeHeaderValue("text/json");
            var jsonResponse = config.GetHelpPageSampleGenerator().WriteSampleObjectUsingFormatter(
                new JsonMediaTypeFormatter(),
                sample,
                typeof(T),
                mediaTypeHeaderValue);

            configAction(jsonResponse, mediaTypeHeaderValue);
            configAction(jsonResponse, new MediaTypeHeaderValue("application/json"));

            // XML
            mediaTypeHeaderValue = new MediaTypeHeaderValue("text/xml");
            var xmlResponse = config.GetHelpPageSampleGenerator().WriteSampleObjectUsingFormatter(
                new XmlMediaTypeFormatter(),
                sample,
                typeof(T),
                mediaTypeHeaderValue);

            configAction(xmlResponse, mediaTypeHeaderValue);
            configAction(xmlResponse, new MediaTypeHeaderValue("application/xml"));
        }

        private static LinkedCredentials PostResponseLinkedCredentials()
        {
            return new LinkedCredentials
                       {
                           UserName = "John",
                           Password = "validatedToken",
                           Links = new[]
                                       {
                                           new AppLink
                                               {
                                                   Rel =
                                                       "http://appDomain/schema/getOrders",
                                                   Href = "http://appDomain/api/orders/john",
                                                   Method = "GET",
                                                   Description = "Get orders for this user"
                                               },
                                           new AppLink
                                               {
                                                   Rel =
                                                       "http://appDomain/schema/getOrderHistory",
                                                   Href = "http://appDomain/api/orderhistory/john/{cutoffDate}",
                                                   Method = "GET",
                                                   Description = "Get order history through this cutoff date"
                                               },
                                           new AppLink
                                               {
                                                   Rel = "payment",
                                                   Href = "https://appDomain/api/payments/john",
                                                   Method = "GET",
                                                   Description = "Start the payment process"
                                               }

                                       }
                       };
        }

        private static LinkedCredentials GetResponseLinkedCredentials()
        {
            return new LinkedCredentials
            {
                UserName = "",
                Password = "",
                Links = new AppLink[0]
            };
        }

        private static LinkedCredentials PostRequestLinkedCredentials()
        {
            return new LinkedCredentials
            {
                UserName = "John",
                Password = "aPassword",
                Links = new AppLink[0]
            };
        }

        private static Credentials PostRequestCredentials()
        {
            return new Credentials
            {
                UserName = "John",
                Password = "aPassword"
            };
        }

        private static Credentials PostResponseCredentials()
        {
            return new Credentials
            {
                UserName = "John",
                Password = "validatedToken"
            };
        }

        private static BizProcessStatus GetResponseBizProcessStatus()
        {
            return new BizProcessStatus
                       {
                           Status = "All is good",
                           ProcessingDetails = new[]
                                                   {
                                                       "One detail",
                                                       "Two detail"
                                                   }
                       };
        }

        private static LinkedBizProcessStatus GetResponseLinkedBizProcessStatus()
        {
            return new LinkedBizProcessStatus
                       {
                           Status = "All is good",
                           ProcessingDetails = new[]
                                                   {
                                                       new AppLink
                                                           {
                                                               Rel = "http://appDomain/schema/otherProcess",
                                                               Href = "http://appDomain/api/orderProcess/john",
                                                               Method = "GET",
                                                               Description = "Get some other process info"
                                                           },

                                                   }
                       };
        }
    }
}
