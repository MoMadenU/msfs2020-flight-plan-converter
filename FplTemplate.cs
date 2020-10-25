using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CoordinateSharp;

namespace FlightPlanConverter
{

    public class FplTemplate
    {
        public string xmlPln;

        public static Dictionary<string, string> fpltopln = new Dictionary<string, string>()
        {
            {"AIRPORT", "Airport"},
            {"INT", "Intersection"},
            {"USER WAYPOINT", "User"},
            {"VOR", "Vor"}
        };

        public string FPLToPLN(string fpFilename, string crusingAlt)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(fpFilename);
            DateTime createdDate;
            XmlNode createdNode = doc.GetElementsByTagName("created")[0];

            if (createdNode != null)
            {
                createdDate = DateTime.Parse(createdNode.InnerText);
            }

            string routeName = doc.GetElementsByTagName("route-name")[0].InnerText;
            string[] srcdest = routeName.Split(" ".ToCharArray());
                

            XmlNodeList waypointNodeList = doc.GetElementsByTagName("waypoint");
            StringBuilder sbWaypoints = new StringBuilder();
            string departureLLA = null;
            string destinationLLA = null;
            
            foreach (XmlNode fplWaypoint in waypointNodeList)
            {
                string wType = fplWaypoint["type"].InnerText;
                // Can't deal with Custom properly
                if (wType.Equals("USER WAYPOINT"))
                    continue;

                ATCWaypoint plnWaypoint = new ATCWaypoint();
                plnWaypoint.waypointID = fplWaypoint["identifier"].InnerText;

                
                if (fpltopln.ContainsKey(wType))
                    plnWaypoint.waypointType = fpltopln[wType];

                string lat = fplWaypoint["lat"].InnerText;
                string lon = fplWaypoint["lon"].InnerText;

                Coordinate coord = new Coordinate(double.Parse(lat), double.Parse(lon));
                plnWaypoint.waypointLLA = $"{coord.Latitude},{coord.Longitude}"
                        .Replace("N ","N")
                        .Replace("S ","S")
                        .Replace("E ","W")
                        .Replace("W ", "W");

                if (plnWaypoint.waypointID.Equals(srcdest[0]))
                    departureLLA = plnWaypoint.waypointLLA;
                else if(plnWaypoint.waypointID.Equals(srcdest[1]))
                    destinationLLA =  plnWaypoint.waypointLLA;

                if (!plnWaypoint.waypointType.Equals("User"))
                {
                    ICAOIdent icao = new ICAOIdent(plnWaypoint.waypointID, 
                        plnWaypoint.waypointType.Equals("Airport"));
                    plnWaypoint.icaoTemplate = icao.icaoTemplate;
                }

                sbWaypoints.Append(plnWaypoint.getTemplate());
            }

            PlnTemplate plnTemplate = new PlnTemplate();

            plnTemplate.departureName = srcdest[0];
            plnTemplate.destinationName = srcdest[1];
            plnTemplate.fpType = "IFR";
            plnTemplate.crusingAlt = crusingAlt;
            plnTemplate.departureICAO = srcdest[0];
            plnTemplate.departureLLA = departureLLA;
            plnTemplate.destinationICAO = srcdest[1];
            plnTemplate.destinationLLA = destinationLLA;

            plnTemplate.waypoints = sbWaypoints.ToString();

            return plnTemplate.getTemplate();
        }
    }
}
