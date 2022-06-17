namespace RestBasicAuth.Model
{
    public class RequestHeader
    {
        public string EncodedUserId { get; set; }
        public string EncodedPassword { get; set; }

        public static RequestHeader getCredentials(HttpRequest request)
        {
            try
            {
                RequestHeader requestHeader = new RequestHeader();

                var headers = request.Headers;

                var headerValues = new Dictionary<string, string>();

                foreach (var value in headers)
                {
                    headerValues.Add(value.Key, value.Value);
                }

                var username = headerValues["user-id"];
                var password = headerValues["password"];

                requestHeader.EncodedUserId = username;
                requestHeader.EncodedPassword = password;

                return requestHeader;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}