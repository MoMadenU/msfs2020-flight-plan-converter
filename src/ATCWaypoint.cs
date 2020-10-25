using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanConverter
{
    public class ATCWaypoint
    {
        public string waypointID;
        public string waypointType;
        public string waypointLLA;
        public string icaoTemplate;

        public string getTemplate()
        {
            string waypointTemplate = $@"        <ATCWaypoint id=""{waypointID}"">
            <ATCWaypointType>{waypointType}</ATCWaypointType>
            <WorldPosition>{waypointLLA}</WorldPosition>
            <SpeedMaxFP>-1</SpeedMaxFP>
            {icaoTemplate}
        </ATCWaypoint>
";

            return waypointTemplate;
        }
    }
}