namespace PassIn.Communication.Responses;
public class ResponseErrorJson
{
    public string Message { get; set; }

    public ResponseErrorJson(string message)
    {
        Message = message;
    }
}
