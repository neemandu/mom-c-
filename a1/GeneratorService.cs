using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a1
{
    public static class GeneratorService
    {
        private static int passLength = 16;
        private static int numberOfNonAlphanumericCharacters = 5; 
        public static string GetId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GetPassword()
        {
            return System.Web.Security.Membership.GeneratePassword(passLength, numberOfNonAlphanumericCharacters);
        }
    }
}