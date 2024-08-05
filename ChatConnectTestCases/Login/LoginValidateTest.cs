//using ChatConnectInterfaces.Login;
//using ChatConnectModels.Login;
//using ChatConnectServices.Login;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace ChatConnectTestCases.Login
//{
//    [TestClass]
//    public class LoginValidateTest
//    {
//        private readonly ILoginValidate _loginValidate;

//        public LoginValidateTest()
//        {
//            _loginValidate = new LoginValidate();
//        }

//        [TestMethod]
//        public void Given_I_Have_LoginModel_ThenLoginModel_Is_Invalid()
//        {
//            LoginModel loginModel = new LoginModel();

//            bool isValidate = _loginValidate.Validate(loginModel);

//            Assert.IsFalse(isValidate);
//        }
//    }
//}
