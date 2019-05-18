using ASCOM.Alpaca.Client.Devices;

namespace ASCOM.Alpaca.Client.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="EquatorialCoordinateType"/>
    /// </summary>
    public class EquatorialCoordinateTypeResponse : Response, IValueResponse<EquatorialCoordinateType>
    {
        /// <summary>
        /// Equatorial coordinate type returned by the device
        /// </summary>
        public EquatorialCoordinateType Value { get; set; }
    }
}