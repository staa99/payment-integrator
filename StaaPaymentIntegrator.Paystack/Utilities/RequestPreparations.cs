using System;
using System.Text.RegularExpressions;
using Staaworks.PaymentIntegrator.Interfaces.Requests;

namespace Staaworks.PaymentIntegrator.Paystack.Utilities
{
    internal static class RequestPreparations
    {
        private const string emailRegex = "^([a-zA-Z0-9_\\.\\-])+\\@(([a-zA-Z0-9\\-])+\\.)+([a-zA-Z0-9]{2,4})+$";
        internal static void AssertReady (Action assertParameters, IRequest request = null)
        {
            if (request != null && !request.Validate(out var ex))
            {
                throw new NotSupportedException("The request is not well formed", ex);
            }

            assertParameters();
        }

        internal static bool IsEmail (this string email) =>
            email != null && Regex.IsMatch(email, emailRegex);
    }
}