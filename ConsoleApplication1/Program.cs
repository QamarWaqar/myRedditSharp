using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using RedditSharp.Things;

namespace TestingReddit
{
    class Program
    {
        static void Main(string[] args)
        {
            // FOR ALL OF THIS TO WORK THE APPLICATION SHOULD NOT BE CLOSED // 
            // EVERY THING WILL WORK 1 HOUR for BOTH PERMANENT ACCESS AND TEMPORARY //
            // BUT FOR PERMANENT ACCESS YOU NEED TO REFRESH YOUR TOKEN AFTER EACH 1 HOUR //
            // THE END OF STORY //

            // START OF PERSONAL USE SCRIPT APP //
            //gettingTemporaryAccessTokenAndUsername();
            //testingTemporaryAccessToken();
            // END OF PERSONAL USE SCRIPT APP //

            //installedAppTest();
            installedAppTempAccessTokenTest();
        }

        public static void gettingTemporaryAccessTokenAndUsername()
        {
            // Calling AuthProvider.cs //
            AuthProvider aP = new AuthProvider("2Fa0HpO8fT42Og", "-xJE3-lqQ-mBjSjd_Rzy94Nk6N8", "http://www.rockyb.somee.com/");
            // Creating Authorization URL //
            string URL = aP.GetAuthUrl("yellowYellowDirtyFellow", AuthProvider.Scope.identity, false);
            // use that URL in your Tor Browser and it will goto Reddit and ask for App to Allow for 1 hour [default] 
            // and will redirect to your redirectURi with the query parameters which contans code query parameter //
            Console.WriteLine(URL);
            // Now using the Code that I received in query string //
            // GetOAuthToken will only work 1 time, if u call it again you will get an Exception //
            // It will not go for 1 hour thus it means temporary access does not work for 1 hour, but only 1 time access //
            string myFirstTokenEver = aP.GetOAuthToken("ksPR45q7EUTFVUgT8SYkZkshq2I", false);
            // Remember remember this token is only valid for 1 time access //
            // After that you can only 'refresh' your token if u had made call to GetAuthUrl with 'true' at end, seeking permanent //
            // Because permanent or temporary; all expire in 1 hour, temporary cannot be refreshed but permanent can only be refreshed //
            // after 1 hour //
            // To Refresh put 'true' instead of 'false' in the GetOAuthToken //
            Console.WriteLine("MY TOKEN IS: " + myFirstTokenEver);
            Reddit r = new Reddit(myFirstTokenEver);
            r.InitOrUpdateUser();
            Console.WriteLine(r.User.Id);
            Console.WriteLine("Username: " + r.User.FullName);
        }

        public static void testingTemporaryAccessToken()
        {
            // Using 1 hour Temporary Token //
            Reddit r = new Reddit("3DSuFA7HRtqnxyUcttDioE3Z6XE");
            Console.WriteLine(r.User.Created.ToString());
            Console.WriteLine(r.User.FullName);
            //Console.WriteLine(r.GetUser("qwrmqr").FullName);
            //AuthenticatedUser aU = r.LogIn("qwrmqr", "h3llm4nq", true);
            //Console.WriteLine(aU.FullName);
        }

        public static void installedAppTest()
        {
            AuthProvider aP = new AuthProvider("17_E0gqG6nDzDg", "V9AJyc6DIv50IdzybK6uGMOjv1A", "http://www.rockyb.somee.com/");
            string URL = aP.GetAuthUrl("blueBlueInTheHue", AuthProvider.Scope.identity, false);
            Console.WriteLine(URL);
            string tempToken = aP.GetOAuthToken("DeMD8BqugDZCDIG-mzRM_RWz_kM", false);
            Console.WriteLine("Temp. Token is: " + tempToken);
            //Reddit r = new Reddit("qwrmqr", "h3llm4nq", true);
            //r.InitOrUpdateUser();
            //Console.WriteLine(r.User.FullName);
        }

        public static void installedAppTempAccessTokenTest()
        {
            Reddit r = new Reddit("kGqpqGhju-rZ2FBUf-PBqFFWKtI");
            AuthenticatedUser aU = r.User;
            Console.WriteLine("Account was created at: " + aU.Created.ToString());
            Console.WriteLine("FullName: " + aU.FullName);
            Console.WriteLine("Has Gold: " + aU.HasGold.ToString());
            Console.WriteLine("Has Mail: " + aU.HasMail.ToString());
            Console.WriteLine("Has Mod Mail: " + aU.HasModMail.ToString());
            Console.WriteLine("IsModerator: " + aU.IsModerator.ToString());
            Console.WriteLine("Link Karma: " + aU.LinkKarma.ToString());
            Console.WriteLine("Name: " + aU.Name);
        }
    }
}
