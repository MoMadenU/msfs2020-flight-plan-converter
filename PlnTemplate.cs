using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanConverter
{

    public class PlnTemplate
    {
        public string departureName;
        public string destinationName;
        public string departureICAO;
        public string destinationICAO;
        public string crusingAlt = "2000.00";
        public string fpType = "VFR";
        public string departureLLA;
        public string destinationLLA;
        public string appVersionMaj = "11";
        public string appVersionBuild = "282174";
        public string waypoints;

        public string getTemplate()
        {
            string plnTemplate = $@"<?xml version=""1.0"" encoding=""UTF-8""?>

<SimBase.Document Type=""AceXML"" version=""1,0"">
    <Descr>AceXML Document</Descr>
    <FlightPlan.FlightPlan>
        <Title>{departureName} to {destinationName}</Title>
        <FPType>{fpType}</FPType>
        <CruisingAlt>{crusingAlt}.000</CruisingAlt>
        <DepartureID>{departureICAO}</DepartureID>
        <DepartureLLA>{departureLLA}</DepartureLLA>
        <DestinationID>{destinationICAO}</DestinationID>
        <DestinationLLA>{destinationLLA}</DestinationLLA>
        <Descr>{departureName} to {destinationName}</Descr>
        <DepartureName>{departureName}</DepartureName>
        <DestinationName>{destinationName}</DestinationName>
        <AppVersion>
            <AppVersionMajor>{appVersionMaj}</AppVersionMajor>
            <AppVersionBuild>{appVersionBuild}</AppVersionBuild>
        </AppVersion>
    {waypoints}    </FlightPlan.FlightPlan>
</SimBase.Document>
";
            return plnTemplate;
        }
    }
}
