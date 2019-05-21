using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AscomAlpacaClient.Exceptions;
using AscomAlpacaClient.Logging;
using AscomAlpacaClient.Request;
using AscomAlpacaClient.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace AscomAlpacaClient.Devices
{
    public sealed class Camera : DeviceBase, ICamera
    {
        public Camera(DeviceConfiguration configuration) : base(configuration)
        {
        }

        public Camera(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        public Camera(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        public Camera(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal Camera(DeviceConfiguration configuration, ICommandSender commandSender) : 
            base(configuration, commandSender)
        {
        }

        internal Camera(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Camera;

        public int GetBayerOffsetX() => ExecuteRequest<int, IntResponse>(BuildGetBayerOffsetXRequest);
        public async Task<int> GetBayerOffsetXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBayerOffsetXRequest);
        private IRestRequest BuildGetBayerOffsetXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BayerOffsetX, Method.GET, GetClientTransactionId());

        public int GetBayerOffsetY() => ExecuteRequest<int, IntResponse>(BuildGetBayerOffsetYRequest);
        public async Task<int> GetBayerOffsetYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBayerOffsetYRequest);
        private IRestRequest BuildGetBayerOffsetYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BayerOffsetY, Method.GET, GetClientTransactionId());

        public int GetBinX() => ExecuteRequest<int, IntResponse>(BuildGetBinXRequest);
        public async Task<int> GetBinXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBinXRequest);
        private IRestRequest BuildGetBinXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BinX, Method.GET, GetClientTransactionId());

        public void SetBinX(int binX) => ExecuteRequest(BuildSetBinXRequest, binX);
        public async Task SetBinXAsync(int binX) => await ExecuteRequestAsync(BuildSetBinXRequest, binX);
        private IRestRequest BuildSetBinXRequest(int binX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.BinX, binX.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.BinX, Method.PUT, parameters, GetClientTransactionId());
        }

        public int GetBinY() => ExecuteRequest<int, IntResponse>(BuildGetBinYRequest);
        public async Task<int> GetBinYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBinYRequest);
        private IRestRequest BuildGetBinYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BinY, Method.GET, GetClientTransactionId());

        public void SetBinY(int binY) => ExecuteRequest(BuildSetBinYRequest, binY);
        public async Task SetBinYAsync(int binY) => await ExecuteRequestAsync(BuildSetBinYRequest, binY);
        private IRestRequest BuildSetBinYRequest(int binY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.BinY, binY.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.BinY, Method.PUT, parameters, GetClientTransactionId());
        }

        public CameraState GetCameraState() => ExecuteRequest<CameraState, CameraStateResponse>(BuildGetCameraStateRequest);
        public async Task<CameraState> GetCameraStateAsync() => await ExecuteRequestAsync<CameraState, CameraStateResponse>(BuildGetCameraStateRequest);
        private IRestRequest BuildGetCameraStateRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CameraState, Method.GET, GetClientTransactionId());

        public int GetCameraXSize() => ExecuteRequest<int, IntResponse>(BuildGetCameraXSizeRequest);
        public async Task<int> GetCameraXSizeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetCameraXSizeRequest);
        private IRestRequest BuildGetCameraXSizeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CameraXSize, Method.GET, GetClientTransactionId());

        public int GetCameraYSize() => ExecuteRequest<int, IntResponse>(BuildGetCameraYSizeRequest);
        public async Task<int> GetCameraYSizeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetCameraYSizeRequest);
        private IRestRequest BuildGetCameraYSizeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CameraYSize, Method.GET, GetClientTransactionId());

        public bool CanAbortExposure() => ExecuteRequest<bool, BoolResponse>(BuildCanAbortExposureRequest);
        public async Task<bool> CanAbortExposureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAbortExposureRequest);
        private IRestRequest BuildCanAbortExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanAbortExposure, Method.GET, GetClientTransactionId());

        public bool CanAsymmetricBin() => ExecuteRequest<bool, BoolResponse>(BuildCanAsymmetricBinRequest);
        public async Task<bool> CanAsymmetricBinAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAsymmetricBinRequest);
        private IRestRequest BuildCanAsymmetricBinRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanAsymmetricBin, Method.GET, GetClientTransactionId());
        
        public bool CanFastReadout() => ExecuteRequest<bool, BoolResponse>(BuildCanFastReadoutRequest);
        public async Task<bool> CanFastReadoutAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFastReadoutRequest);
        private IRestRequest BuildCanFastReadoutRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanFastReadout, Method.GET, GetClientTransactionId());

        public bool CanGetCoolerPower() => ExecuteRequest<bool, BoolResponse>(BuildCanGetCoolerPowerRequest);
        public async Task<bool> CanGetCoolerPowerAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanGetCoolerPowerRequest);
        private IRestRequest BuildCanGetCoolerPowerRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanGetCoolerPower, Method.GET, GetClientTransactionId());

        public bool CanPulseGuide() => ExecuteRequest<bool, BoolResponse>(BuildCanPulseGuideRequest);
        public async Task<bool> CanPulseGuideAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanPulseGuideRequest);
        private IRestRequest BuildCanPulseGuideRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanPulseGuide, Method.GET, GetClientTransactionId());

        public bool CanSetCCDTemperature() => ExecuteRequest<bool, BoolResponse>(BuildCanSetCCDTemperatureRequest);
        public async Task<bool> CanSetCCDTemperatureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetCCDTemperatureRequest);
        private IRestRequest BuildCanSetCCDTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanSetCCDTemperature, Method.GET, GetClientTransactionId());

        public bool CanStopExposure() => ExecuteRequest<bool, BoolResponse>(BuildCanStopExposureRequest);
        public async Task<bool> CanStopExposureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanStopExposureRequest);
        private IRestRequest BuildCanStopExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanStopExposure, Method.GET, GetClientTransactionId());

        public double GetCCDTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetCCDTemperatureRequest);
        public async Task<double> GetCCDTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCCDTemperatureRequest);
        private IRestRequest BuildGetCCDTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CCDTemperature, Method.GET, GetClientTransactionId());

        public bool IsCoolerOn() => ExecuteRequest<bool, BoolResponse>(BuildIsCoolerOnRequest);
        public async Task<bool> IsCoolerOnAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsCoolerOnRequest);
        private IRestRequest BuildIsCoolerOnRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CoolerOn, Method.GET, GetClientTransactionId());

        public void SetCoolerOn(bool coolerOn) => ExecuteRequest(BuildSetCoolerOnRequest, coolerOn);
        public async Task SetCoolerOnAsync(bool coolerOn) => await ExecuteRequestAsync(BuildSetCoolerOnRequest, coolerOn);
        private IRestRequest BuildSetCoolerOnRequest(bool coolerOn)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.CoolerOn, coolerOn.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.CoolerOn, Method.PUT, parameters, GetClientTransactionId());
        }

        public double GetCoolerPower() => ExecuteRequest<double, DoubleResponse>(BuildGetCoolerPowerRequest);
        public async Task<double> GetCoolerPowerAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCoolerPowerRequest);
        private IRestRequest BuildGetCoolerPowerRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CoolerPower, Method.GET, GetClientTransactionId());

        public double GetElectronPerADU() => ExecuteRequest<double, DoubleResponse>(BuildGetElectronPerADURequest);
        public async Task<double> GetElectronPerADUAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetElectronPerADURequest);
        private IRestRequest BuildGetElectronPerADURequest() => RequestBuilder.BuildRestRequest(CameraMethod.ElectronsPerADU, Method.GET, GetClientTransactionId());

        public double GetExposureMax() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureMaxRequest);
        public async Task<double> GetExposureMaxAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureMaxRequest);
        private IRestRequest BuildGetExposureMaxRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ExposureMax, Method.GET, GetClientTransactionId());

        public double GetExposureMin() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureMinRequest);
        public async Task<double> GetExposureMinAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureMinRequest);
        private IRestRequest BuildGetExposureMinRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ExposureMin, Method.GET, GetClientTransactionId());

        public double GetExposureResolution() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureResolutionRequest);
        public async Task<double> GetExposureResolutionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureResolutionRequest);
        private IRestRequest BuildGetExposureResolutionRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ExposureResolution, Method.GET, GetClientTransactionId());

        public bool IsFastReadout() => ExecuteRequest<bool, BoolResponse>(BuildIsFastReadoutRequest);
        public async Task<bool> IsFastReadoutAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsFastReadoutRequest);
        private IRestRequest BuildIsFastReadoutRequest() => RequestBuilder.BuildRestRequest(CameraMethod.FastReadout, Method.GET, GetClientTransactionId());

        public void SetFastReadout(bool fastReadout) => ExecuteRequest(BuildSetFastReadoutRequest, fastReadout);
        public async Task SetFastReadoutAsync(bool fastReadout) => await ExecuteRequestAsync(BuildSetFastReadoutRequest, fastReadout);
        private IRestRequest BuildSetFastReadoutRequest(bool fastReadout)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.FastReadout, fastReadout.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.FastReadout, Method.PUT, parameters, GetClientTransactionId());
        }

        public double GetFullWellCapacity() => ExecuteRequest<double, DoubleResponse>(BuildGetFullWellCapacityRequest);
        public async Task<double> GetFullWellCapacityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetFullWellCapacityRequest);
        private IRestRequest BuildGetFullWellCapacityRequest() => RequestBuilder.BuildRestRequest(CameraMethod.FullWellCapacity, Method.GET, GetClientTransactionId());

        public int GetGain() => ExecuteRequest<int, IntResponse>(BuildGetGainRequest);
        public async Task<int> GetGainAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainRequest);
        private IRestRequest BuildGetGainRequest() => RequestBuilder.BuildRestRequest(CameraMethod.Gain, Method.GET, GetClientTransactionId());

        public void SetGain(int gain) => ExecuteRequest(BuildSetGainRequest, gain);
        public async Task SetGainAsync(int gain) => await ExecuteRequestAsync(BuildSetGainRequest, gain);
        private IRestRequest BuildSetGainRequest(int gain)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.Gain, gain.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.Gain, Method.PUT, parameters, GetClientTransactionId());
        }

        public int GetGainMax() => ExecuteRequest<int, IntResponse>(BuildGetGainMaxRequest);
        public async Task<int> GetGainMaxAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainMaxRequest);
        private IRestRequest BuildGetGainMaxRequest() => RequestBuilder.BuildRestRequest(CameraMethod.GainMax, Method.GET, GetClientTransactionId());

        public int GetGainMin() => ExecuteRequest<int, IntResponse>(BuildGetGainMinRequest);
        public async Task<int> GetGainMinAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainMinRequest);
        private IRestRequest BuildGetGainMinRequest() => RequestBuilder.BuildRestRequest(CameraMethod.GainMin, Method.GET, GetClientTransactionId());

        public IList<string> GetGains() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetGainsRequest);
        public async Task<IList<string>> GetGainsAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetGainsRequest);
        private IRestRequest BuildGetGainsRequest() => RequestBuilder.BuildRestRequest(CameraMethod.Gains, Method.GET, GetClientTransactionId());

        public bool HasShutter() => ExecuteRequest<bool, BoolResponse>(BuildHasShutterRequest);
        public async Task<bool> HasShutterAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildHasShutterRequest);
        private IRestRequest BuildHasShutterRequest() => RequestBuilder.BuildRestRequest(CameraMethod.HasShutter, Method.GET, GetClientTransactionId());

        public double GetHeatSinkTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetHeatSinkTemperatureRequest);
        public async Task<double> GetHeatSinkTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetHeatSinkTemperatureRequest);
        private IRestRequest BuildGetHeatSinkTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.HeatSinkTemperature, Method.GET, GetClientTransactionId());

        
        
        public Array GetImageArray()
        {
            IRestRequest request = BuildGetImageArrayRequest();
            IRestResponse response = CommandSender.ExecuteRequest(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        public async Task<Array> GetImageArrayAsync()
        {
            IRestRequest request = BuildGetImageArrayRequest();
            IRestResponse response = await CommandSender.ExecuteRequestAsync(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        private IRestRequest BuildGetImageArrayRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ImageArray, Method.GET, GetClientTransactionId());

        public Array GetImageArrayVariant()
        {
            IRestRequest request = BuildGetImageArrayVariantRequest();
            IRestResponse response = CommandSender.ExecuteRequest(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        public async Task<Array> GetImageArrayVariantAsync()
        {
            IRestRequest request = BuildGetImageArrayVariantRequest();
            IRestResponse response = await CommandSender.ExecuteRequestAsync(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        private IRestRequest BuildGetImageArrayVariantRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ImageArrayVariant, Method.GET, GetClientTransactionId());

        
        private Array ParseImageResponse(IRestResponse response)
        {
            (ImageArrayType type, int rank) = ParseTypeAndRank(response.Content);

            if (rank == 2)
            {
                return Parse2DImageResponse(response, type);
            }

            if (rank == 3)
            {
                return Parse3DImageResponse(response, type);
            }

            throw new AlpacaInvalidValueException($"Image rank {rank} is not supported");
        }
        private (ImageArrayType type, int rank) ParseTypeAndRank(string jsonString)
        {
            string responseString = jsonString.Substring(0, 50);
            MatchCollection matches = Regex.Matches(responseString, "^{\\s*\"Type\":\\s*(\\d),\"Rank\":\\s*(\\d*)", RegexOptions.IgnoreCase);
            ImageArrayType type = (ImageArrayType)int.Parse(matches[0].Groups[1].Value);
            int rank = int.Parse(matches[0].Groups[2].Value);

            return (type, rank);
        }

        private static Array Parse3DImageResponse(IRestResponse response, ImageArrayType type)
        {
            switch (type)
            {
                case ImageArrayType.Int:
                    var imageArrayInt3DResponse = JsonConvert.DeserializeObject<ImageArrayInt3DResponse>(response.Content);
                    return imageArrayInt3DResponse.HandleResponse<int[,,], ImageArrayInt3DResponse>();

                case ImageArrayType.Short:
                    var imageArrayShort3DResponse = JsonConvert.DeserializeObject<ImageArrayShort3DResponse>(response.Content);
                    return imageArrayShort3DResponse.HandleResponse<short[,,], ImageArrayShort3DResponse>();

                case ImageArrayType.Double:
                    var imageArrayDouble3DResponse = JsonConvert.DeserializeObject<ImageArrayDouble3DResponse>(response.Content);
                    return imageArrayDouble3DResponse.HandleResponse<double[,,], ImageArrayDouble3DResponse>();

                default:
                    throw new AlpacaInvalidValueException($"'ImageArrayType '{type} ({(int)type})' is not a valid value");
            }
        }

        private static Array Parse2DImageResponse(IRestResponse response, ImageArrayType type)
        {
            switch (type)
            {
                case ImageArrayType.Int:
                    var imageArrayInt2DResponse = JsonConvert.DeserializeObject<ImageArrayInt2DResponse>(response.Content);
                    return imageArrayInt2DResponse.HandleResponse<int[,], ImageArrayInt2DResponse>();

                case ImageArrayType.Short:
                    var imageArrayShort2DResponse = JsonConvert.DeserializeObject<ImageArrayShort2DResponse>(response.Content);
                    return imageArrayShort2DResponse.HandleResponse<short[,], ImageArrayShort2DResponse>();

                case ImageArrayType.Double:
                    var imageArrayDouble2DResponse = JsonConvert.DeserializeObject<ImageArrayDouble2DResponse>(response.Content);
                    return imageArrayDouble2DResponse.HandleResponse<double[,], ImageArrayDouble2DResponse>();

                default:
                    throw new AlpacaInvalidValueException($"'ImageArrayType '{type} ({(int)type})' is not a valid value");
            }
        }

        public bool IsImageReady() => ExecuteRequest<bool, BoolResponse>(BuildIsImageReadyRequest);
        public async Task<bool> IsImageReadyAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsImageReadyRequest);
        private IRestRequest BuildIsImageReadyRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ImageReady, Method.GET, GetClientTransactionId());

        public bool IsPulseGuiding() => ExecuteRequest<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        public async Task<bool> IsPulseGuidingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        private IRestRequest BuildIsPulseGuidingRequest() => RequestBuilder.BuildRestRequest(CameraMethod.IsPulseGuiding, Method.GET, GetClientTransactionId());

        public double GetLastExposureDuration() => ExecuteRequest<double, DoubleResponse>(BuildGetLastExposureDurationRequest);
        public async Task<double> GetLastExposureDurationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetLastExposureDurationRequest);
        private IRestRequest BuildGetLastExposureDurationRequest() => RequestBuilder.BuildRestRequest(CameraMethod.LastExposureDuration, Method.GET, GetClientTransactionId());

        public DateTime GetLastExposureStartTime()
        {
            string dateTimeString = ExecuteRequest<string, StringResponse>(BuildGetLastExposureStartTimeRequest);
            return DateTime.Parse(dateTimeString);
        }
        public async Task<DateTime> GetLastExposureStartTimeAsync()
        {
            string dateTimeString = await ExecuteRequestAsync<string, StringResponse>(BuildGetLastExposureStartTimeRequest);
            return DateTime.Parse(dateTimeString);
        }
        private IRestRequest BuildGetLastExposureStartTimeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.LastExposureStartTime, Method.GET, GetClientTransactionId());

        public int GetMaxADU() => ExecuteRequest<int, IntResponse>(BuildGetMaxADURequest);
        public async Task<int> GetMaxADUAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxADURequest);
        private IRestRequest BuildGetMaxADURequest() => RequestBuilder.BuildRestRequest(CameraMethod.MaxADU, Method.GET, GetClientTransactionId());

        public int GetMaxBinX() => ExecuteRequest<int, IntResponse>(BuildGetMaxBinXRequest);
        public async Task<int> GetMaxBinXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxBinXRequest);
        private IRestRequest BuildGetMaxBinXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.MaxBinX, Method.GET, GetClientTransactionId());

        public int GetMaxBinY() => ExecuteRequest<int, IntResponse>(BuildGetMaxBinYRequest);
        public async Task<int> GetMaxBinYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxBinYRequest);
        private IRestRequest BuildGetMaxBinYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.MaxBinY, Method.GET, GetClientTransactionId());

        public int GetNumX() => ExecuteRequest<int, IntResponse>(BuildGetNumXRequest);
        public async Task<int> GetNumXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetNumXRequest);
        private IRestRequest BuildGetNumXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.NumX, Method.GET, GetClientTransactionId());

        public void SetNumX(int numX) => ExecuteRequest(BuildSetNumXRequest, numX);
        public async Task SetNumXAsync(int numX) => await ExecuteRequestAsync(BuildSetNumXRequest, numX);
        private IRestRequest BuildSetNumXRequest(int numX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.NumX, numX.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.NumX, Method.PUT, parameters, GetClientTransactionId());
        }

        public int GetNumY() => ExecuteRequest<int, IntResponse>(BuildGetNumYRequest);
        public async Task<int> GetNumYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetNumYRequest);
        private IRestRequest BuildGetNumYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.NumY, Method.GET, GetClientTransactionId());

        public void SetNumY(int numY) => ExecuteRequest(BuildSetNumYRequest, numY);
        public async Task SetNumYAsync(int numY) => await ExecuteRequestAsync(BuildSetNumYRequest, numY);
        private IRestRequest BuildSetNumYRequest(int numY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.NumY, numY.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.NumY, Method.PUT, parameters, GetClientTransactionId());
        }

        public int GetPercentCompleted() => ExecuteRequest<int, IntResponse>(BuildGetPercentCompletedRequest);
        public async Task<int> GetPercentCompletedAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPercentCompletedRequest);
        private IRestRequest BuildGetPercentCompletedRequest() => RequestBuilder.BuildRestRequest(CameraMethod.PercentCompleted, Method.GET, GetClientTransactionId());

        public double GetPixelSizeX() => ExecuteRequest<double, DoubleResponse>(BuildGetPixelSizeXRequest);
        public async Task<double> GetPixelSizeXAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPixelSizeXRequest);
        private IRestRequest BuildGetPixelSizeXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.PixelSizeX, Method.GET, GetClientTransactionId());

        public double GetPixelSizeY() => ExecuteRequest<double, DoubleResponse>(BuildGetPixelSizeYRequest);
        public async Task<double> GetPixelSizeYAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPixelSizeYRequest);
        private IRestRequest BuildGetPixelSizeYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.PixelSizeY, Method.GET, GetClientTransactionId());

        public int GetReadoutMode() => ExecuteRequest<int, IntResponse>(BuildGetReadoutModeRequest);
        public async Task<int> GetReadoutModeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetReadoutModeRequest);
        private IRestRequest BuildGetReadoutModeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ReadoutMode, Method.GET, GetClientTransactionId());

        public void SetReadoutMode(int readoutMode) => ExecuteRequest(BuildSetReadoutModeRequest, readoutMode);
        public async Task SetReadoutModeAsync(int readoutMode) => await ExecuteRequestAsync(BuildSetReadoutModeRequest, readoutMode);
        private IRestRequest BuildSetReadoutModeRequest(int readoutMode)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.ReadoutMode, readoutMode.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.ReadoutMode, Method.PUT, parameters, GetClientTransactionId());
        }
        
        public IList<string> GetReadoutModes() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetReadoutModesRequest);
        public async Task<IList<string>> GetReadoutModesAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetReadoutModesRequest);
        private IRestRequest BuildGetReadoutModesRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ReadoutModes, Method.GET, GetClientTransactionId());

        public string GetSensorName() => ExecuteRequest<string, StringResponse>(BuildGetSensorNameRequest);
        public async Task<string> GetSensorNameAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetSensorNameRequest);
        private IRestRequest BuildGetSensorNameRequest() => RequestBuilder.BuildRestRequest(CameraMethod.SensorName, Method.GET, GetClientTransactionId());

        public SensorType GetSensorType() => ExecuteRequest<SensorType, SensorTypeResponse>(BuildGetSensorTypeRequest);
        public async Task<SensorType> GetSensorTypeAsync() => await ExecuteRequestAsync<SensorType, SensorTypeResponse>(BuildGetSensorTypeRequest);
        private IRestRequest BuildGetSensorTypeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.SensorType, Method.GET, GetClientTransactionId());

        public double GetCCDTemperatureSetPoint() => ExecuteRequest<double, DoubleResponse>(BuildGetCCDTemperatureSetPointRequest);
        public async Task<double> GetCCDTemperatureSetPointAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCCDTemperatureSetPointRequest);
        private IRestRequest BuildGetCCDTemperatureSetPointRequest() => RequestBuilder.BuildRestRequest(CameraMethod.SetCCDTemperature, Method.GET, GetClientTransactionId());

        public void SetCCDTemperatureSetPoint(double temperature) => ExecuteRequest(BuildSetCCDTemperatureSetPointRequest, temperature);
        public async Task SetCCDTemperatureSetPointAsync(double temperature) => await ExecuteRequestAsync(BuildSetCCDTemperatureSetPointRequest, temperature);
        private IRestRequest BuildSetCCDTemperatureSetPointRequest(double temperature)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.SetCCDTemperature , temperature.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.SetCCDTemperature , Method.PUT, parameters, GetClientTransactionId());
        }

        public int GetStartX() => ExecuteRequest<int, IntResponse>(BuildGetStartXRequest);
        public async Task<int> GetStartXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetStartXRequest);
        private IRestRequest BuildGetStartXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.StartX, Method.GET, GetClientTransactionId());

        public void SetStartX(int startX) => ExecuteRequest(BuildSetStartXRequest, startX);
        public async Task SetStartXAsync(int startX) => await ExecuteRequestAsync(BuildSetStartXRequest, startX);
        private IRestRequest BuildSetStartXRequest(int startX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.StartX , startX.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.StartX, Method.PUT, parameters, GetClientTransactionId());
        }

        public int GetStartY() => ExecuteRequest<int, IntResponse>(BuildGetStartYRequest);
        public async Task<int> GetStartYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetStartYRequest);
        private IRestRequest BuildGetStartYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.StartY, Method.GET, GetClientTransactionId());

        public void SetStartY(int startY) => ExecuteRequest(BuildSetStartYRequest, startY);
        public async Task SetStartYAsync(int startY) => await ExecuteRequestAsync(BuildSetStartYRequest, startY);
        private IRestRequest BuildSetStartYRequest(int startY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.StartY , startY.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.StartY, Method.PUT, parameters, GetClientTransactionId());
        }

        public void AbortExposure() => ExecuteRequest(BuildAbortExposureRequest);
        public async Task AbortExposureAsync() => await ExecuteRequestAsync(BuildAbortExposureRequest);
        private IRestRequest BuildAbortExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.AbortExposure, Method.PUT, GetClientTransactionId());

        public void PulseGuide(GuideDirection direction, int duration) => ExecuteRequest(BuildPulseGuideRequest, direction, duration);
        public async Task PulseGuideAsync(GuideDirection direction, int duration) => await ExecuteRequestAsync(BuildPulseGuideRequest, direction, duration);
        private IRestRequest BuildPulseGuideRequest(GuideDirection direction, int duration)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.Direction, direction.ToString()},
                {CameraRequestParameters.Duration , duration.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.PulseGuide, Method.PUT, parameters, GetClientTransactionId());
        }
        
        public void StartExposure(double duration, bool isLight) => ExecuteRequest(BuildStartExposureRequest, duration, isLight);
        public async Task StartExposureAsync(double duration, bool isLight) => await ExecuteRequestAsync(BuildStartExposureRequest, duration, isLight);
        private IRestRequest BuildStartExposureRequest(double duration, bool isLight)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.Duration, duration.ToString(CultureInfo.InvariantCulture)},
                {CameraRequestParameters.Light , isLight.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.StartExposure, Method.PUT, parameters, GetClientTransactionId());
        }

        public void StopExposure() => ExecuteRequest(BuildStopExposureRequest);
        public async Task StopExposureAsync() => await ExecuteRequestAsync(BuildStopExposureRequest);
        private IRestRequest BuildStopExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.StopExposure, Method.PUT, GetClientTransactionId());
    }
}