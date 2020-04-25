using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FuelDashApp.Helper
{
    public class EmailParser
    {
        public static void ParseEmail(string email,
            out string referenceNumber,
            out DateTime dateEntered,
            out string priority,
            out DateTime estimatedArrival,
            out string site,
            out string address,
            out string problemDescription)
        {
            referenceNumber = Between(email, "The referenced work order number is", "Here").Replace("\r\n", "");
            Debug.WriteLine("ReferenceNo.:" + referenceNumber);

            dateEntered =Convert.ToDateTime(Between(email, "Date Entered:", "Priority").Replace("\r\n", ""));
            Debug.WriteLine("Date Entered:" + dateEntered);

            priority = Between(email, "Priority:", "Estimated").Replace("\r\n", "");
            Debug.WriteLine("Priority:" + priority);

            estimatedArrival = Convert.ToDateTime(Between(email, "Target:", "Region:").Replace("\r\n", ""));
            Debug.WriteLine("EstimatedArrival:" + estimatedArrival);

            //region = Between(email, "Region:", "Division:").Replace("\r\n", "");
            //Debug.WriteLine("Region:" + region);

            //division = Between(email, "Division:", "District:").Replace("\r\n", "");
            //Debug.WriteLine("Division:" + division);

            //district = Between(email, "District:", "Site:").Replace("\r\n", "");
            //Debug.WriteLine("District:" + district);

            site = email.Substring(email.IndexOf("Site:") + 5, 8);
            Debug.WriteLine("Site:" + site);

            var siteIndex = email.IndexOf(site);
            var actualIndex = siteIndex + site.Length;
            var location = email.IndexOf("Location");
            var diff = location - siteIndex - site.Length;
            address = email.Substring(actualIndex, diff).Replace("\r\n", "");
            Debug.WriteLine("Address.:" + address);


            //locationWithinSite = Between(email, "Location within Site:", "Caller").Replace("\r\n", "");
            //Debug.WriteLine("Location within Site:" + locationWithinSite);

            //callerName = Between(email, "Caller name:", "Caller phone").Replace("\r\n", "");
            //Debug.WriteLine("Caller name:" + callerName);

            //callerPhone = Between(email, "Caller phone:", "Problem").Replace("\r\n", "");
            //Debug.WriteLine("Caller phone::" + callerPhone);

            problemDescription = Between(email, "Problem Description:", "Assignment").Replace("\r\n", "");
            Debug.WriteLine("Problem Description:" + problemDescription);

            //assignment = Between(email, "Assignment:", "Order Status:").Replace("\r\n", "");
            //Debug.WriteLine("Assignment:" + assignment);

            //orderStatus = Between(email, "Order Status:", "Warranty").Replace("\r\n", "");
            //Debug.WriteLine("Order Status:" + orderStatus);

            //warranty = Between(email, "Warranty:", "\r", true).Replace("\r\n", "");
            //Debug.WriteLine("Warranty:" + warranty);

        }

        private static string Between(string value, string a, string b, bool isLastIndex = false)
        {
            int posA = value.IndexOf(a);
            int posB = 0;
            if (isLastIndex)
            {
                posB = value.LastIndexOf(b);
            }
            else
            {
                posB = value.IndexOf(b);
            }

            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
}
