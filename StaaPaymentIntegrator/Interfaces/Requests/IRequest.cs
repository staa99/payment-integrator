using System;
using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Requests
{
    public interface IRequest
    {
        Task<string> Serialize ();

        /// <summary>
        /// A method that validates the current values of properties and gives out an exception to describe the situation when invalid. Note that this function doesn't actually throw any exceptions.
        /// </summary>
        /// <returns>A boolean value that is <see langword="true"/> when valid and <see langword="false"/> otherwise. When invalid, an exception that describes the situation is given out.</returns>
        bool Validate (out Exception ex);
    }
}
