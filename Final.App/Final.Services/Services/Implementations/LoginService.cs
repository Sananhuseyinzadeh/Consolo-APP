

using System;
using System.Threading.Tasks;

namespace Final.Services.Services.Implementations
{
    public class LoginService
    {
        public async Task StartApp()
        {
            ConsoloAppServices consoleAppService = new ConsoloAppServices();

            Console.WriteLine("1.As Admin");
            Console.WriteLine("2. As User");

            string Request = Console.ReadLine();

            if (Request == "1")
            {
                bool result = await consoleAppService.Login();

                while (!result)
                {
                    result = await consoleAppService.Login();
                    if (!result)
                    {

                        Console.WriteLine("2.Return  As User");
                        Request = Console.ReadLine();
                        if (Request == "2")
                        {
                            result = true;
                        }
                    }
                }
            }

            if (consoleAppService.IsAdmin)
            {
                consoleAppService.ShowAdmin();
            }
            else
            {
                consoleAppService.ShowUser();
            }

        }
    }
}
