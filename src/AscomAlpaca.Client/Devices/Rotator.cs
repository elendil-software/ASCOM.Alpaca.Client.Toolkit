using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Client.Responses;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    public sealed class Rotator : DeviceBase, IRotator
    {
        public Rotator(DeviceConfiguration configuration) : base(configuration)
        {
        }

        public Rotator(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        public Rotator(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        public Rotator(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        public Rotator(DeviceConfiguration configuration, ICommandSender commandSender) : base(configuration, commandSender)
        {
        }

        public Rotator(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Rotator;

        public bool CanReverse() => ExecuteRequest<bool, BoolResponse>(BuildCanReverseRequest);
        public async Task<bool> CanReverseAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanReverseRequest);
        private IRestRequest BuildCanReverseRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.CanReverse, Method.GET, GetClientTransactionId());

        public bool IsMoving() => ExecuteRequest<bool, BoolResponse>(BuildIsMovingRequest);
        public async Task<bool> IsMovingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsMovingRequest);
        private IRestRequest BuildIsMovingRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.IsMoving, Method.GET, GetClientTransactionId());

        public double GetPosition() => ExecuteRequest<double, DoubleResponse>(BuildGetPositionRequest);
        public async Task<double> GetPositionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.Position, Method.GET, GetClientTransactionId());

        public bool IsReversed() => ExecuteRequest<bool, BoolResponse>(BuildIsReversedRequest);
        public async Task<bool> IsReversedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsReversedRequest);
        private IRestRequest BuildIsReversedRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.Reverse, Method.GET, GetClientTransactionId());

        public void SetReversed(bool reversed) => ExecuteRequest(BuildSetReversedRequest, reversed);
        public async Task SetReversedAsync(bool reversed) => await ExecuteRequestAsync(BuildSetReversedRequest, reversed);
        private IRestRequest BuildSetReversedRequest(bool reversed)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorCommandParameters.Reverse , reversed.ToString()}
            };
            return RequestBuilder.BuildRestRequest(RotatorCommand.Reverse, Method.PUT, parameters, GetClientTransactionId());
        }

        public double GetStepSize() => ExecuteRequest<double, DoubleResponse>(BuildGetStepSizeRequest);
        public async Task<double> GetStepSizeAsync() =>  await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStepSizeRequest);
        private IRestRequest BuildGetStepSizeRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.StepSize, Method.GET, GetClientTransactionId());

        public double GetTargetPosition() => ExecuteRequest<double, DoubleResponse>(BuildGetTargetPositionRequest);
        public async Task<double> GetTargetPositionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTargetPositionRequest);
        private IRestRequest BuildGetTargetPositionRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.TargetPosition, Method.GET, GetClientTransactionId());

        public void Halt() => ExecuteRequest(BuildHaltRequest);
        public async Task HaltAsync() => await ExecuteRequestAsync(BuildHaltRequest);
        private IRestRequest BuildHaltRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.Halt, Method.PUT, GetClientTransactionId());

        public void Move(double position) => ExecuteRequest(BuildMoveRequest, position);
        public async Task MoveAsync(double position) => await ExecuteRequestAsync(BuildMoveRequest, position);
        private IRestRequest BuildMoveRequest(double position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorCommandParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(RotatorCommand.Move, Method.PUT, parameters, GetClientTransactionId());
        }

        public void MoveAbsolute(double position) => ExecuteRequest(BuildMoveAbsoluteRequest, position);
        public async Task MoveAbsoluteAsync(double position) => await ExecuteRequestAsync(BuildMoveAbsoluteRequest, position);
        private IRestRequest BuildMoveAbsoluteRequest(double position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorCommandParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(RotatorCommand.MoveAbsolute, Method.PUT, parameters, GetClientTransactionId());
        }
    }
}