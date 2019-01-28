using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace ACIWEB_DESKTOP_REPORT
{
    class SapConnection : IDestinationConfiguration
    {

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {

            SAPParam sapParam = new SAPParam();
            sapParam.GetValueFromFile();

            RfcConfigParameters parms = new RfcConfigParameters();

            if (destinationName.Equals("SAPDest"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, sapParam.AppServerHost);
                parms.Add(RfcConfigParameters.SystemNumber, sapParam.SystemNumber);
                parms.Add(RfcConfigParameters.SystemID, sapParam.SystemID);
                parms.Add(RfcConfigParameters.User, sapParam.User);
                parms.Add(RfcConfigParameters.Password, sapParam.Password);
                parms.Add(RfcConfigParameters.Client, sapParam.Client);
                parms.Add(RfcConfigParameters.Language, sapParam.Language);
                parms.Add(RfcConfigParameters.PoolSize, sapParam.PoolSize);

                if (sapParam.SapRouter != null)
                {
                    parms.Add(RfcConfigParameters.SAPRouter, sapParam.SapRouter);
                }
               

            }
            return parms;

        }
    }
}
