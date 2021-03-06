﻿using Microsoft.Extensions.DependencyInjection;
using MMTShop.Shared;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client
{
    public partial class Program
    {
        private static async Task Main()
        {
            //Set as null to use value in appSettings.json, specify a base url to ignore the value in appSettings.json
            Initialize(
                null);

            while (applicationState.IsRunning)
            {
                try
                {
                    Console.WriteLine("Welcome to MMT Shop.{0}",
                        FormatConstants.NewLine);

                    await CheckServerStatus();

                    DisplayOptions();

                    if (await ParseInput(
                        Console.ReadKey(true).KeyChar))
                    {
                        WaitForInput();
                    }
                }
                catch (
                    InvalidOperationException exception)
                {
                    Console
                        .WriteLine(
                            exception.Message);
                }
            }

            Console.WriteLine(
                "Good Bye!");
        }

        #region Methods

        private static Task<bool> CheckServerStatus()
        {
            return MenuCommandDispatcher
                .InvokeAsync<bool>(GeneralConstants
                                    .ServerCheckCommandCharacter,
                                   applicationState,
                                   CancellationToken.None);
        }

        private static void WaitForInput()
        {
            Console
                .WriteLine("Press any key to continue");

            Console.
                ReadKey(true);
        }

        private static void DisplayOptions()
        {
            Console
                .WriteLine(
                    "Please select an option{0}" +
                    "1. Display featured products{0}" +
                    "2. Display categories and get products for a specific category{0}" +
                    "q. Quit",
                    FormatConstants.NewLine);
        }

        private static async Task<bool> ParseInput(
            char input)
        {
            try
            {
                return await MenuCommandDispatcher
                    .InvokeAsync<bool>(
                        input,
                        applicationState,
                        CancellationToken.None);
            }
            catch (DispatcherNotFoundException ex)
            {
                throw new InvalidOperationException(
                    "Input must be a number between 1-2 or q to quit",
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new InvalidOperationException(
                    ex.Message,
                    ex);
            }
        }

        #endregion

        #region Properties
        private static ICommandDispatcher<char> MenuCommandDispatcher => services
            .GetRequiredService<ICommandDispatcher<char>>();
        #endregion

        #region Fields
        private static readonly ApplicationState applicationState = new ApplicationState { IsRunning = true };
        private static IServiceProvider services;
        #endregion
    }
}
