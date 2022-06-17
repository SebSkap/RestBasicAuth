using System.Text;

namespace RestBasicAuth.Model
{
    public class EncodedAuth
    {
        public static bool EncodedAuthValidate(string encodedUserId, string encodedPassword)
        {
            try
            {
                byte[] userIdData = Convert.FromBase64String(encodedUserId);
                string decodedUserIdData = Encoding.UTF8.GetString(userIdData);

                byte[] passwordData = Convert.FromBase64String(encodedPassword);
                string decodedPasswordData = Encoding.UTF8.GetString(passwordData);

                if (!(decodedUserIdData == "TestUser1") || !(decodedPasswordData == "TestPassword1"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
