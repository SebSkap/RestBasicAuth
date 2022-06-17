using Microsoft.AspNetCore.Mvc;
using RestBasicAuth.Model;
using System.Text;

namespace RestBasicAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet(Name = "GetAuth")]
        public string Get()
        {
            var request = Request;

            RequestHeader requestHeader = new RequestHeader();
            requestHeader = RequestHeader.getCredentials(request);

            EncodedAuth encodedAuth = new EncodedAuth();
            bool restValidated = EncodedAuth.EncodedAuthValidate(requestHeader.EncodedUserId, requestHeader.EncodedPassword);

            if (!restValidated)
            {
                throw new Exception("Unauthorized.");
            }

            return "Authentication passed";
        }
    }
}