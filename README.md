[![Build Status](https://travis-ci.com/staa99/payment-integrator.svg?branch=master)](https://travis-ci.com/staa99/payment-integrator)

# Payment Integrator

This repository is intended for use by developers and organizations to solve their payment integration needs. The base is an abstraction library that can be implemented to provide support for different payment providers.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What you need to begin integrating the right way ;-)

* The `StaaPaymentIntegrator` nuget package.
* The particular implementation of your payment provider. Usually something like, `StaaPaymentIntegrator.***`.

### Installing

You can add the base payment integrator (this project) by using any of the following options.
    * The recommended way is to use NuGet.
    * You can also clone this repository and build it manually.

You can usually find particular implementations of this library that are supported by the developer on NuGet.

For example, to integrate with Paystack, you can use the `StaaPaymentIntegrator.Paystack` package.

To add all supported Paystack features, simply call
`services.AddPaystack(configuration);`
on your IServiceCollection.
Read the docs to see how to manually configure the library for your use.

(aside)
Hey, what's all this fuss about Paystack? Well, I personally use Paystack in projects, so why not write first for Paystack?

## Built With

* [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) - .NET Standard is used so the project is useful across all modern .NET platforms.

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Authors

* **Ahmad Alfawwaz** - *Initial work* - [Staa99](https://github.com/staa99)

See also the list of [contributors](https://github.com/staa99/payment-integrator/contributors) who participated in this project.

## License

This project is licensed under the GNU Public License - see the [LICENSE](LICENSE) file for details

## Short Background

I have always used Paystack in my projects. But I wanted to try other providers like FlutterWave so I thought of how to build something that will not depend explicitly on any particular provider.

## Acknowledgments

* A big thanks to [PurpleBooth](https://github.com/PurpleBooth) for the awesome template used to develop this README.
