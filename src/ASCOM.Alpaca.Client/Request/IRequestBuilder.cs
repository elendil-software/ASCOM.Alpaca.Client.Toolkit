using System;
using System.Collections.Generic;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public interface IRequestBuilder
    {
        IRestRequest BuildRestRequest(Enum command, Method httpMethod, int clientTransactionId);
        IRestRequest BuildRestRequest(Enum command, Method httpMethod, Dictionary<string, object> parameters, int clientTransactionId);
    }
}