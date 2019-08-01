using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DonationSample.Models;
using Staaworks.PaymentIntegrator.Providers;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Banks;

namespace DonationSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }

        public IActionResult About ()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact ()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error ()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("/one-time-payment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Donate([FromServices] IPaymentProvider provider, int donation, string email)
        {
            var request = new PaymentInitializationRequest();
            request.Initialize(new Dictionary<string, string>
            {
                [PAYSTACK_AMOUNT_KEY] = (donation * 100).ToString(),
                [PAYSTACK_INITIALIZATION_REFERENCE_KEY] = Guid.NewGuid().ToString(),
                [PAYSTACK_EMAIL_KEY] = email,
                [PAYSTACK_CALLBACK_URL_KEY] = Url.Action("confirm")
            });

            var response = await provider.MakePayment(request);

            return Json(response);
        }


        [HttpGet("/query-account-name")]
        public async Task<IActionResult> QueryAccountName ([FromServices] IBanksProvider provider, string bankCode, string accountNumber)
        {
            var request = new BankAccountNameQueryRequest();

            request.Initialize(new Dictionary<string, string>
            {
                [PAYSTACK_BANK_ACCOUNT_NUMBER_KEY] = accountNumber,
                [PAYSTACK_BANK_REFERENCE_KEY] = bankCode
            });

            var response = await provider.QueryAccountName(request);

            return Json(response);
        }


        [HttpGet("/banks-list")]
        public async Task<IActionResult> GetBanks ([FromServices] IBanksProvider provider)
        {
            var response = await provider.GetBanks();

            return Json(response);
        }


        [HttpGet("/callback")]
        public async Task<IActionResult> Confirm ([FromServices] IPaymentProvider provider, string reference)
        {
            var request = new PaymentVerificationRequest();
            request.Initialize(new Dictionary<string, string>
            {
                [PAYSTACK_VERIFICATION_REFERENCE_KEY] = reference
            });

            var response = await provider.VerifyPayment(request);
            if (response.Successful)
            {
                ViewBag.amountPaid = (response.Amount/100f).ToString();
            }

            return View("Index");
        }
    }
}
