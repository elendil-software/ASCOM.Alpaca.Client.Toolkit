﻿using System.Collections.Generic;

namespace ASCOM.Alpaca.Responses.Numeric
{
    public class IntArrayResponse : Response, IValueResponse<List<int>>
    {
        public List<int> Value { get; set; }
    }
}