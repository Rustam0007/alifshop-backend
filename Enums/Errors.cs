using System.ComponentModel;

namespace market_place.Enums;

public enum Errors
{
    [Description("Approved")]
    Approved = 1000,
    [Description("Accepted for further process")]
    Accepted = 900,
    [Description("Bad request")]
    BadRequest = 910,
    [Description("Bad gateway")]
    BadGateway = 911,
    [Description("Bad gateway")] 
    NotFound = 919,
    [Description("Internal server error")]
    InternalError = 924,
    [Description("Gateway timeout")] 
    GatewayTimeout = 925,
}