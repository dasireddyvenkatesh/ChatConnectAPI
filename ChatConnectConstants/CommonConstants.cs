namespace ChatConnectConstants
{
    public class CommonConstants
    {
        public static readonly string EmailRegex = "@\"\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z";

        public static readonly string PasswordIgnore = "[<>\"'%&+\\\\']";

        public static readonly string LoginFailed = "Invalid credentials. Please try again.";

        public static readonly string LoginSuccess = "Login successful!";
    }
}
