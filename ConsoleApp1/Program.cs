﻿using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Client;
using ASCOM.Alpaca.Client.Device;
using ASCOM.Alpaca.Client.Methods;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;
using RequestBuilder = ASCOM.Alpaca.Client.Device.RequestBuilder;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new AscomRemoteParametersBase();
            var commandSender = new CommandSender(parameters.GetBaseUrl());
            var requestBuilder = new RequestBuilder(DeviceType.telescope, 1);
            
            var isConnectedMethod = requestBuilder.BuildRestRequest(CommonMethod.Connected, Method.GET);
            var isConnectedResponse = commandSender.ExecuteRequest<BoolResponse>(isConnectedMethod);
            Console.WriteLine($"isConnectedResponse : {isConnectedResponse.Value}");
            
            var connectMethod = requestBuilder.BuildRestRequest(CommonMethod.Connected, Method.PUT, new Dictionary<string, object> {{"Connected", true}});
            var connectResponse = commandSender.ExecuteRequest<MethodResponse>(connectMethod);
            Console.WriteLine($"connectResponse : {connectResponse.ErrorNumber}");

            var parkMethod = requestBuilder.BuildRestRequest(TelescopeMethod.Park, Method.PUT);
            var parkResponse = commandSender.ExecuteRequest<MethodResponse>(parkMethod);
            Console.WriteLine($"parkResponse : {parkResponse.ErrorNumber}");
            
            Console.ReadKey();
        }
    }
}