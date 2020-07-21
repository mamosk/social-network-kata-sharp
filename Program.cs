using System;
using System.Threading.Tasks;

namespace social_network_kata_sharp
{
    class Program
    {
        async static Task<int> Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    // TODO kata
                    return 0;
                case 1:
                    switch (args[0])
                    {
                        case "demo":
                            // TODO demo
                            break;
                        default:
                            await Console.Error.WriteLineAsync($"Unrecognized argument: {args[0]}");
                            return 1;
                    }
                    return 0;
                default:
                    await Console.Error.WriteLineAsync($"Unrecognized arguments: {string.Join(" ", args)}");
                    return 1;
            }
        }
    }
}
