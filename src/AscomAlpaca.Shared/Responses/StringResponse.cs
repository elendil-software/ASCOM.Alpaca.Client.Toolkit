﻿namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a string
    /// </summary>
    public class StringResponse : CommandResponse, IValueResponse<string>
    {
        /// <summary>
        /// String value returned by the device
        /// </summary>
        public string Value { get; set; }
    }
}