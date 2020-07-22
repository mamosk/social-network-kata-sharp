using System;
using System.Collections.Generic;
using System.IO;
using SocialNetwork.IO;
using SocialNetwork.Kata;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {

        private static Lazy<IKata> lazykata = new Lazy<IKata>(() => new Kata.Kata());


        private static Lazy<IList<(short? Base, string Word)>> timeUnits = new Lazy<IList<(short?, string)>>(() => new List<(short?, string)>() {
            (60, "second"),
            (60, "minute"),
            (24, "hour"),
            (null, "day")
        });

        private static IKata Kata { get => lazykata.Value; }

        private static IList<(short? Base, string Word)> TimeUnits { get => timeUnits.Value; }

        #region methods

        #region main methods
        static int Main(string[] args)
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
                            Console.Error.WriteLine($"Unrecognized argument: {args[0]}");
                            return 1;
                    }
                    return 0;
                default:
                    Console.Error.WriteLine($"Unrecognized arguments: {string.Join(" ", args)}");
                    return 1;
            }
        }

        // Loop reading user commands, checking with switch-case statements:
        // break = incorrect command: display help for user;
        // continue = correct command: command executed, read input again;
        // return = exit command: stop kata execution.
        private static void kata()
        {
            Console.SetOut(new PrefixedTextWriter());
            string[] cmd;
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
                                WriteLines(Kata.Read(cmd[0]));
                                continue;
                        }
                        break;

                    // Multiple word command
                    default:

                        // Switch second word of command
                        switch (cmd[1])
                        {

                            // Post
                            case "->":
                                if (cmd.Length == 3)
                                {
                                    Kata.Post(cmd[0], cmd[2]);
                                    continue;
                                }
                                break;

                            // Follow
                            case "follows":
                                if (cmd.Length == 3)
                                {
                                    Kata.Follow(cmd[0], cmd[2]);
                                    continue;
                                }
                                break;

                            // Wall
                            case "wall":
                                if (cmd.Length == 2)
                                {
                                    WriteLines(Kata.Wall(cmd[0]));
                                    continue;
                                }
                                break;

                            default:
                                break;

                        }
                        break;

                }

                // Help
                help();

            }

        }

        #endregion main

        #region render

        private static void WriteLines(IList<(string User, string Text, uint Instant)> posts) => posts?.OrderByDescending(post => post.Instant).ToList().ForEach(post => WriteLine(post.User, post.Text, post.Instant));

        private static void WriteLine(string user, string text, uint instant) => Console.WriteLine($"{user} - {text} ({ago(instant)})");

        private static string ago(uint instant)
        {
            uint seconds = (uint)Math.Round((DateTime.UtcNow.Ticks) * 1.0 / TimeSpan.TicksPerSecond, 0) - instant;
            string word = null;
            foreach (var timeUnit in TimeUnits)
            {
                word = timeUnit.Word;
                if (timeUnit.Base.HasValue && seconds > timeUnit.Base.Value)
                {
                    seconds = (uint)Math.Round((seconds) * 1.0 / timeUnit.Base.Value, 0);
                }
                else
                {
                    break;
                }
            }
            return $"{seconds} {word ?? "second"}{(seconds > 1 ? "s" : "")} ago";
        }

        #endregion render

        #region help methods

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

        #endregion help

        #endregion methods

    }


}
