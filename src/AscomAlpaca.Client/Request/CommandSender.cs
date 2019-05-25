﻿using System;
using System.Net;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Exceptions;
using ES.AscomAlpaca.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace ES.AscomAlpaca.Client.Request
{
    internal class CommandSender : ICommandSender
    {
        private readonly ILogger _logger;
        private readonly IRestClientFactory _restClientFactory;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new NewtonsoftJsonPrivateResolver()
        };

        public CommandSender()
        {
            _restClientFactory = new RestClientFactory();
        }

        public CommandSender(IRestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory ?? throw new ArgumentNullException(nameof(restClientFactory));
        }

        public CommandSender(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _restClientFactory = new RestClientFactory();
        }

        public IRestResponse ExecuteRequest(string baseUrl, IRestRequest request)
        {
            IRestResponse response = _restClientFactory.Create(baseUrl).Execute(request);
            ThrowExceptionOnError(response);
            _logger?.LogDebug("Response : {Response}", response.Content);
            return response;
        }

        public TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse
        {
            IRestResponse response = _restClientFactory.Create(baseUrl).Execute(request);
            ThrowExceptionOnError(response);
            var data = JsonConvert.DeserializeObject<TASCOMRemoteResponse>(response.Content, _jsonSerializerSettings);
            _logger?.LogDebug("Response : {Response}", data);
            return data;
        }
        
        public async Task<IRestResponse> ExecuteRequestAsync(string baseUrl, IRestRequest request)
        {
            IRestResponse response = await _restClientFactory.Create(baseUrl).ExecuteTaskAsync(request);
            ThrowExceptionOnError(response);
            _logger?.LogDebug("Response : {Response}", response.Content);
            return response;
        }
        
        public async Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse
        {
            IRestResponse response = await _restClientFactory.Create(baseUrl).ExecuteTaskAsync(request);
            ThrowExceptionOnError(response);
            var data = JsonConvert.DeserializeObject<TASCOMRemoteResponse>(response.Content, _jsonSerializerSettings);
            _logger?.LogDebug("Response : {@Response}", data);
            return data;
        }

        private void ThrowExceptionOnError(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed && response.StatusCode == 0)
            {
                _logger?.LogError("Request not completed, response status : {ResponseStatus}, error message : {ErrorMessage}", response.ResponseStatus, response.ErrorMessage);
                throw new AlpacaClientException(response.ErrorMessage, response.ErrorException);
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger?.LogError("{ErrorName} ({ErrorCode}), error message : {ErrorMessage}", response.StatusCode, (int)response.StatusCode, response.Content);
                throw new AlpacaServerException(response.Content);
            }
        }
    }
}