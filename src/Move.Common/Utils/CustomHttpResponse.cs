using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Move.Common.Utils;

public static class CustomHttpResponse
{
    public static ObjectResult Error(StatusCodeError httpStatusCode, string code, string messageToDeveloper, string messageToUserTh, string messageToUserEn)
    {
        var error = new ErrorPayload
        {
            errorId = Guid.NewGuid().ToString(),
            code = code,
            messageToDeveloper = messageToDeveloper,
            messageToUser = new MessageToUserDetail
            {
                langTh = messageToUserTh,
                langEn = messageToUserEn
            },
            created = DateTimes.GetCurrentUtcDateTimeInThaiTimeZone(DateTimes.DateTimeFormat.YearMonthDayByDashTHourMinuteSecondByColonZ, DateTimes.LanguageCultureName.ENGLISH_UNITED_STATES, DateTimes.DateTimeUtcOffset.HHMM)
        };

        var objResult = new ObjectResult(new { error });
        objResult.StatusCode = (int)httpStatusCode;

        return objResult;
    }

    // public static ObjectResult Error(HttpStatusCode httpStatusCode, string code, string messageToDeveloper, string messageToUserTh, string messageToUserEn)
    // {
    //     var error = new ErrorPayload
    //     {
    //         errorId = Guid.NewGuid().ToString(),
    //         code = code,
    //         messageToDeveloper = messageToDeveloper,
    //         messageToUser = new MessageToUserDetail
    //         {
    //             langTh = messageToUserTh,
    //             langEn = messageToUserEn
    //         },
    //         created = DateTimes.GetCurrentUtcDateTimeInThaiTimeZone(DateTimes.DateTimeFormat.YearMonthDayByDashTHourMinuteSecondByColonZ, DateTimes.LanguageCultureName.ENGLISH_UNITED_STATES, DateTimes.DateTimeUtcOffset.HHMM)
    //     };

    //     var objResult = new ObjectResult(new { error });
    //     objResult.StatusCode = (int)httpStatusCode;

    //     return objResult;
    // }

    public static ObjectResult Success(StatusCodeSuccess httpStatusCode, Object data)
    {
        var objResult = new ObjectResult(new { data });
        objResult.StatusCode = (int)httpStatusCode;

        return objResult;
    }

    // public static ObjectResult Success(HttpStatusCode httpStatusCode, Object data)
    // {
    //     var objResult = new ObjectResult(new { data });
    //     objResult.StatusCode = (int)httpStatusCode;

    //     return objResult;
    // }

    public static ObjectResult Success(StatusCodeSuccess httpStatusCode, Object data, Object pagination)
    {
        var objResult = new ObjectResult(new { data, pagination });
        objResult.StatusCode = (int)httpStatusCode;

        return objResult;
    }

    // public static ObjectResult Success(HttpStatusCode httpStatusCode, Object data, Object pagination)
    // {
    //     var objResult = new ObjectResult(new { data, pagination });
    //     objResult.StatusCode = (int)httpStatusCode;

    //     return objResult;
    // }
}

public enum StatusCodeSuccess
{
    OK = HttpStatusCode.OK,
    Created = HttpStatusCode.Created
}

public enum StatusCodeError
{
    BadRequest = HttpStatusCode.BadRequest,
    Unauthorized = HttpStatusCode.Unauthorized,
    NotFound = HttpStatusCode.NotFound,
    InternalServerError = HttpStatusCode.InternalServerError,
    ServiceUnavailable = HttpStatusCode.ServiceUnavailable
}

public class ErrorPayload
{
    public string? errorId { get; set; }
    public string? code { get; set; }
    public string? messageToDeveloper { get; set; }
    public MessageToUserDetail? messageToUser { get; set; }
    public string? created { get; set; }
}

public class MessageToUserDetail
{
    public string? langTh { get; set; }
    public string? langEn { get; set; }
}
