using System;

namespace AutomationTest
{
    public class GlobalsWords
    {

        public static string URLPage = "http://www.cnnnewsource.com/";
        public static string EmailTest = string.Empty;

        #region HomePage

        public static string TitlePageHome = "CNN Newsource";


        public static string MenuXPathLink1 = ".//*[@id='menu-item-181402']/a";
        public static string MenuTextLink1 = "HOME";

        public static string MenuXPathLink2 = ".//*[@id='menu-item-181401']/a";
        public static string MenuTextLink2 = "NEWSOURCE";

        public static string MenuXPathLink3 = ".//*[@id='menu-item-181403']/a";
        public static string MenuTextLink3 = "DIGITAL SERVICES";

        public static string MenuXPathLink4 = ".//*[@id='menu-item-177228']/a";
        public static string MenuTextLink4 = "CNN COLLECTION";

        public static string MenuXPathLink5 = ".//*[@id='menu-item-177246']/a";
        public static string MenuTextLink5 = "LATEST INSIGHTS";

        public static string MenuXPathLink6 = ".//*[@id='menu-item-197436']/a";
        public static string MenuTextLink6 = "IN THE CLASSROOM";

        public static string MenuXPathLink7 = ".//*[@id='menu-item-176259']/a";
        public static string MenuTextLink7 = "CONTACT";

        #endregion HomePage

        #region RegisterPage

        public static string TitlePageRegister = "Register - My ASP.NET Application";


        #endregion RegisterPage

        #region LoginPage

        public static string TitlePageLogin = "Log in - My ASP.NET Application";

        #endregion LoginPage

        #region Shared Pages

        public static string VarText = "kevin1";
        public static string VarPassBad = "kevin2";
        public static string VarPassBadFormat = "kevin#";

        public static string emailRequired = "The Email field is required.";
        public static string passwordRequired = "The Password field is required.";

        public static string emailNotValid = "The Email field is not a valid e-mail address.";
        public static string passwordNotMatch = "The password and confirmation password do not match.";

        public static string passwordNotContainsUpperLetterOrCharacter = "Passwords must have at least one non letter or digit character. Passwords must have at least one uppercase ('A'-'Z').";
        public static string passwordNotContainsNumbers = "Passwords must have at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z').";

        public static string loginInvalid = "Invalid login attempt.";

        #endregion Shared Pages

    }
}
