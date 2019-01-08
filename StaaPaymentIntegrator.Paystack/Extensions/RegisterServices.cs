using System;
using Microsoft.Extensions.DependencyInjection;
using Staaworks.PaymentIntegrator.Configuration;
using Staaworks.PaymentIntegrator.Providers;

namespace Staaworks.PaymentIntegrator.Paystack.Extensions
{
    public static class RegisterServices
    {
        public static IServiceCollection AddPaystack (this IServiceCollection services, IPaystackConfiguration configuration)
        {
            services.AddPaystackConfiguration(configuration);
            services.AddPaystackEmpty();
            services.AddPaystackForMiscBankOps();
            services.AddPaystackForPayments();
            services.AddPaystackForTransfers();
            //services.AddPaystackForSubscriptions();
            return services;
        }


        public static IServiceCollection AddPaystackConfiguration (this IServiceCollection services, IPaystackConfiguration configuration) => services.AddSingleton<IPaymentProviderConfiguration>(s =>
        {
            return configuration;
        });


        public static IServiceCollection AddPaystackEmpty (this IServiceCollection services) => services.AddTransient<IProvider>(s =>
        {
            try
            {
                var optionsProvider = s.GetService<IPaystackConfiguration>();

                if (optionsProvider.ProviderName != null)
                {
                    return new Paystack(optionsProvider.SecretKey, optionsProvider.ProviderName);
                }
                else
                {
                    return new Paystack(optionsProvider.SecretKey);
                }
            }
            catch
            {
                throw new InvalidOperationException("You must call `AddPaystackConfiguration` before using the `AddPaystackEmpty` extension");
            }
        });


        public static IServiceCollection AddPaystackForMiscBankOps (this IServiceCollection services) => services.AddTransient<IBanksProvider>(s =>
        {
            try
            {
                var optionsProvider = s.GetService<IPaystackConfiguration>();
                var paystack = s.GetService<Paystack>();

                paystack.InitializeBanks(optionsProvider.BanksListUrl, optionsProvider.BankAccountNameQueryUrl);
                return paystack;
            }
            catch
            {
                throw new InvalidOperationException("You must call `AddPaystackConfiguration` and register an `IProvider` with `Paystack` before using the `AddPaystackForMiscBankOps` extension");
            }
        });


        public static IServiceCollection AddPaystackForPayments (this IServiceCollection services) => services.AddTransient<IPaymentProvider>(s =>
         {
             try
             {
                 var optionsProvider = s.GetService<IPaystackConfiguration>();
                 var paystack = s.GetService<Paystack>();

                 paystack.InitializePayments(
                     optionsProvider.PaymentVerificationUrl,
                     optionsProvider.PaymentInitializationUrl,
                     optionsProvider.PaymentChargeAuthorizationUrl,
                     optionsProvider.PaymentReauthorizationUrl,
                     optionsProvider.PaymentCheckAuthorizationUrl);

                 return paystack;
             }
             catch
             {
                 throw new InvalidOperationException("You must call `AddPaystackConfiguration` and register an `IProvider` with `Paystack` before using the `AddPaystackForPayments` extension");
             }
         });


        public static IServiceCollection AddPaystackForTransfers (this IServiceCollection services) => services.AddTransient<ITransferProvider>(s =>
         {
             try
             {
                 var optionsProvider = s.GetService<IPaystackConfiguration>();
                 var paystack = s.GetService<Paystack>();

                 paystack.InitializePayments(
                     optionsProvider.PaymentVerificationUrl,
                     optionsProvider.PaymentInitializationUrl,
                     optionsProvider.PaymentChargeAuthorizationUrl,
                     optionsProvider.PaymentReauthorizationUrl,
                     optionsProvider.PaymentCheckAuthorizationUrl);

                 return paystack;
             }
             catch
             {
                 throw new InvalidOperationException("You must call `AddPaystackConfiguration` and register an `IProvider` with `Paystack` before using the `AddPaystackForTransfers` extension");
             }
         });

        
        /*public static IServiceCollection AddPaystackForSubscriptions(this IServiceCollection services) => services.AddTransient<ISubscriptionProvider>(s =>
        {
            try
            {
                var optionsProvider = s.GetService<IPaystackInitializationOptionsProvider>();
                var paystack = s.GetService<Paystack>();

                paystack.InitializePayments(
                    optionsProvider.PaymentVerificationUrl,
                    optionsProvider.PaymentInitializationUrl,
                    optionsProvider.PaymentChargeAuthorizationUrl,
                    optionsProvider.PaymentReauthorizationUrl,
                    optionsProvider.PaymentCheckAuthorizationUrl);

                return paystack;
            }
            catch
            {
                throw new InvalidOperationException("You must call `AddPaystackConfiguration` and register an `IProvider` with `Paystack` before using the `AddPaystackForSubscriptions` extension");
            }
        });
        */
    }
}
