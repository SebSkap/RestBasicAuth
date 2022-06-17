using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using RestBasicAuth.Model;

namespace RestBasicAuthTest
{
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetCredentialsTest()
        {
            RequestHeader requestHeader = new RequestHeader();

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["user-id"] = "VGVzdFVzZXIx";
            httpContext.Request.Headers["password"] = "VGVzdFBhc3N3b3JkMQ==";

            var httpRequest = new DefaultHttpContext().Request;
            httpRequest.Headers.Add("user-id", "VGVzdFVzZXIx");
            httpRequest.Headers.Add("password", "VGVzdFBhc3N3b3JkMQ==");

            requestHeader = RequestHeader.getCredentials(httpRequest);

            if ((requestHeader.EncodedUserId == "VGVzdFVzZXIx") && (requestHeader.EncodedPassword == "VGVzdFBhc3N3b3JkMQ=="))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void EncodedAuthValidateTest()
        {
            string encodedUserId = "VGVzdFVzZXIx";
            string encodedPassword = "VGVzdFBhc3N3b3JkMQ==";

            bool isAuthenticated = EncodedAuth.EncodedAuthValidate(encodedUserId, encodedPassword);

            Assert.IsTrue(isAuthenticated);
        }
    }
}