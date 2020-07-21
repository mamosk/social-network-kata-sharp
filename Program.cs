using System;
using System.IO;
using System.Threading.Tasks;
using social_network_kata_sharp.io;

namespace social_network_kata_sharp
{
    class Program
    {
        async static Task<int> Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    kata();
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

        private static void kata()
        {
            Console.SetOut(new PrefixedTextWriter());
            string[] cmd;
            string user;
            while (true)
            {
                Console.Write("");
                cmd = Console.ReadLine().Split(" ");
                switch (cmd.Length)
                {
                    // No command
                    case 0: continue;
                    // Single word command
                    case 1:
                        switch (cmd[0])
                        {
                            // Exit
                            case "exit":
                                return;

                            // Help
                            case "help":
                                break;

                            // Read
                            default:
                                // TODO read user timeline
                                user = cmd[0];
                                continue;
                        }
                        break;

                    // Multiple word command
                    default:
                        user = cmd[0];
                        switch (cmd[1])
                        {
                            // Post
                            case "->":
                                // TODO post to user timeline
                                continue;

                            // Follow
                            case "follows":
                                // TODO user follows another user
                                continue;

                            // Wall
                            case "wall":
                                // TODO read user and zir followees timelines
                                continue;

                            default:
                                break;
                        }
                        break;
                }
                help();
            }
        }

        private const string HELP = @"
kata commands:
  <user name> -> <message>           -> post message to user timeline
  <user name>                        -> read messages from user timeline
  <user name> follows <another user> -> subscribe user to another user timeline
  <user name> wall                   -> read messages from user timeline and subscriptions

utility commands:
  exit -> exit the cli
  help -> read this help

kata readme: https://github.com/xpeppers/social_networking_kata
            ";
        private static void help()
        {
            using (StringReader reader = new StringReader(HELP))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

    }


}
