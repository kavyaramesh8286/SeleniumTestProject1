using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBTTestProject.Configurations
{
    public static class ConfigParameters
    {
        /// <summary>
        /// Gets the URL of the application.
        /// </summary>
        public static Uri ApplicationURL
        {
            get
            {
                return new Uri(TestContext.Parameters.Get("LoginUrl")!);
            }
        }

        /// <summary>
        /// Gets the user name.
        /// </summary>
        public static string UserName
        {
            get
            {
                return TestContext.Parameters.Get("userName")!;
            }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public static string Password
        {
            get
            {
                return TestContext.Parameters.Get("password")!;
            }
        }

    }
}
