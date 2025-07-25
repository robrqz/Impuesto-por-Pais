using System;
using System.Threading.Tasks;
using Cálculo_de_impuestos_por_usuario.Tax.TaxConfigurationService;
using Cálculo_de_impuestos_por_usuario.Tax.TaxProcessor;
using Cálculo_de_impuestos_por_usuario.UniversalHelpers.MenuHelper;
using Cálculo_de_impuestos_por_usuario.UniversalHelpers.ValidationHelpers.ValidationHelpers;

using Cálculo_de_impuestos_por_usuario.User.UserHelper;
using Cálculo_de_impuestos_por_usuario.User.UserService;
using Microsoft.Extensions.DependencyInjection;
using Cálculo_de_impuestos_por_usuario.User.InterfaceUserService;
using Cálculo_de_impuestos_por_usuario.Tax.ITax;

public class Program
{
    static void Main()
    {
        var serverProvider = new ServiceCollection();
        
        serverProvider.AddSingleton<ITaxConfigurationService, TaxConfigurationService>(); 
        serverProvider.AddScoped<IUserService, UserService>();
        serverProvider.AddSingleton<TaxProcessor>();

        var Provider = serverProvider.BuildServiceProvider();

        var userService = Provider.GetRequiredService<IUserService>(); 
        var TaxProcessor = Provider.GetRequiredService<TaxProcessor>();
        var TaxConfigurationService = Provider.GetRequiredService<ITaxConfigurationService>();


        int MenuOption;
        do
        {
            var MenuSwitch = HelperMenu.MenuHelper(out MenuOption);

            if (!MenuSwitch.esValido)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(MenuSwitch.ErrorMessage);
                Console.ResetColor();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            switch (MenuOption)
            {
                case 1:
                    string UserName;
                    (bool isValidUsername, string ShowErrorMesaje) UserResult;
                    //User
                    do
                    {
                        Console.WriteLine("--Cree su nombre de usuario--");
                        UserName = Console.ReadLine();

                        UserResult = ValidationHelpers.ValidateTextWithoutNumbers(UserName);

                        //validation
                        if (!UserResult.isValidUsername)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error. ");
                            Console.ResetColor();
                            Console.WriteLine(UserResult.ShowErrorMesaje);
                            Console.WriteLine("Presione una tecla para volver al menú...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    } while (!UserResult.isValidUsername);

                    string CountryResult = null;
                    bool validCountry = false;
                    //Country
                    do
                    {
                        Console.WriteLine("--Seleccione su país--");
                        Console.WriteLine("1) Argentina");
                        Console.WriteLine("2) Brasil");
                        Console.WriteLine("3) USA");
                        Console.WriteLine("4) Otro");
                        string inputCountry = Console.ReadLine();

                        try
                        {
                            CountryResult = userService.GetUserCountry(inputCountry);
                            validCountry = true;
                        }
                        catch (ArgumentException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error. " + ex.Message);
                            Console.ResetColor();
                            Console.WriteLine("Presione una tecla para volver a intentarlo...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    } while (!validCountry);

                    decimal AmountInput;
                    bool validAmount = false;
                    //Amount
                    do
                    {
                        Console.WriteLine("--Ingrese el monto para calcular impuestos--");
                        string input = Console.ReadLine();

                        if (decimal.TryParse(input, out AmountInput))
                        {
                            validAmount = true; 
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error: Monto inválido.");
                            Console.ResetColor();
                            Console.WriteLine("Por favor, ingrese solo números válidos");
                        }

                    } while (!validAmount);


                    int NewID = userService.GetIDByUser(UserName);
                    var NewUser = userService.NewUser(UserName, CountryResult, NewID, AmountInput);

                    var processor = Provider.GetRequiredService<TaxProcessor>();
                    processor.Run(NewUser, AmountInput);
                    Console.Clear();

                    break;
                case 2:

                    var allUsers = userService.GetUserList();
                    if (!allUsers.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No hay usuarios registrados.");
                        Console.ResetColor();
                        break;
                    }

                    foreach (var user in allUsers)
                    {
                        TaxConfigurationService.ShowUserInfo(user);
                    }

                    Console.WriteLine("Ingrese cualquier tecla para volver al menu");
                    Console.ReadKey();
                    Console.Clear();

                    break;
            }
        } while (MenuOption != 3);
    }
}