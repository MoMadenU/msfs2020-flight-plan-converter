using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanConverter
{
    public class ICAOIdent
    {
        public string icaoTemplate;

        public ICAOIdent(string icaoIdent, bool isAirport)
        {
            icaoTemplate = isAirport
                ? $@"<ICAO>
                <ICAOIdent>{icaoIdent}</ICAOIdent>
            </ICAO>"
                : $@"<ICAO>
                <ICAORegion>K6</ICAORegion>
                <ICAOIdent>{icaoIdent}</ICAOIdent>
            </ICAO>";
        }
    }
}
