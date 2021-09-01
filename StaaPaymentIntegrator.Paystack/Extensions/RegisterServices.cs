using System;
using System.Linq;
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
            services.AddPaystackEmpty(configuration.ProviderName);
            services.AddPaystackForMiscBankOps(configuration.ProviderName);
            services.AddPaystackForPayments(configuration.ProviderName);
            services.AddPaystackForTransfers(configuration.ProviderName);
            //services.AddPaystackForSubscriptions();
            return services;
        }


        public static IServiceCollection AddPaystackConfiguration (this IServiceCollection services, IPaystackConfiguration configuration) => services.AddSingleton<IPaymentProviderConfiguration>(s =>
        {
            return configuration;
        });


        public static IServiceCollection AddPaystackEmpty (this IServiceCollection services, string key) => services.AddSingleton<IProvider>(s =>
        {
            try
            {
                var optionsProvider = s.GetServices<IPaymentProviderConfiguration>().First(c => c.ProviderName == key) as IPaystackConfiguration;
                
                return new Paystack(optionsProvider.SecretKey, optionsProvider.ProviderName);
            }
            catch
            {
                throw new InvalidOperationException("You must call `AddPaystackConfiguration` before using the `AddPaystackEmpty` extension");
            }
        });


        public static IServiceCollection AddPaystackForMiscBankOps (this IServiceCollection services, string key) => services.AddSingleton<IBanksProvider>(s =>
        {
            try
            {
                var optionsProvider = s.GetServices<IPaymentProviderConfiguration>().First(c => c.ProviderName == key) as IPaystackConfiguration;
                var paystack = s.GetService<IProvider>() as Paystack;

                paystack.InitializeBanks(optionsProvider.BanksListUrl, optionsProvider.BankAccountNameQueryUrl);
                return paystack;
            }
            catch
            {
                throw new InvalidOperationException("You must call `AddPaystackConfiguration` and register an `IProvider` with `Paystack` before using the `AddPaystackForMiscBankOps` extension");
            }
        });


        public static IServiceCollection AddPaystackForPayments (this IServiceCollection services, string key) => services.AddSingleton<IPaymentProvider>(s =>
         {
             try
             {
                 var optionsProvider = s.GetServices<IPaymentProviderConfiguration>().First(c => c.ProviderName == key) as IPaystackConfiguration;
                 var paystack = s.GetService<IProvider>() as Paystack;

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


        public static IServiceCollection AddPaystackForTransfers (this IServiceCollection services, string key) => services.AddSingleton<ITransferProvider>(s =>
         {
             try
             {
                 var optionsProvider = s.GetServices<IPaymentProviderConfiguration>().First(c => c.ProviderName == key) as IPaystackConfiguration;
                 var paystack = s.GetService<IProvider>() as Paystack;

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


        /*public static IServiceCollection AddPaystackForSubscriptions(this IServiceCollection services, string key) => services.AddTransient<ISubscriptionProvider>(s =>
        {
            try
            {
                var optionsProvider = s.GetServices<IPaystackInitializationOptionsProvider>();
                var paystack = s.GetServices<IProvider>() as Paystack;

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
