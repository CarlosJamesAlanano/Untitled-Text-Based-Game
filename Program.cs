using System;
using System.Threading;

namespace app
{
    class Program
    {
        // Character names
        private const string MainCharacter = "Zed";
        private const string Companion = "Shane";

        // Story variables
        private static int regretLevel = 50;
        private static int trustLevel = 50;
        private static int candleTime = 30; // in seconds

        // Maximum levels
        private static int MaxRegretLevel = 100;

        static void Main(string[] args)
        {
            IntroScene();
            while (candleTime > 0)
            {
                FirstInteraction();
                if (candleTime <= 0) break;
            }
            EndScene();
        }

        /// Check for "exit" input
        static void CheckForExit(string input)
        {
            if (input.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting the game. Thank you for playing!");
                Environment.Exit(0);
            }
        }

        static void Divider()
        {
            Console.WriteLine("\n----------------------------------------\n");
        }

        static void IntroScene()
        {
            Divider();
            Console.WriteLine($"{MainCharacter} sits alone, weighed down by memories of {Companion}. The regret feels like a physical presence in the room.");
            Thread.Sleep(1500);
            Console.WriteLine($"In a desperate attempt to find peace, {MainCharacter} seeks out an obscure antique shop rumored to hold objects with a mysterious connection to the past.");
            Thread.Sleep(2000);
            Console.WriteLine($"As {MainCharacter} steps into the shadowy shop, a grizzled old man 'Karl' emerges from behind the counter.");
            Console.WriteLine($"\"You look like a man burdened by the weight of 'what-ifs',\" Karl says, his voice gravelly yet strangely soothing.");
            Divider();
            Console.WriteLine("1. \"I need a second chance.\"");
            Console.WriteLine("2. \"I don't know if I deserve another shot...\"");
            Console.WriteLine("Exit");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            CheckForExit(input); // Check if the user wants to exit
            int choice = int.Parse(input);

            if (choice == 1)
            {
                Console.WriteLine("Karl nods knowingly. \"Time is fickle. But it may listen, just this once.\"");
                StartTimeTravel();
            }
            else if (choice == 2)
            {
                Console.WriteLine($"Karl chuckles softly. \"Regret is for those who refuse to learn from the past. Let's see if you’re one of them.\"");
                StartTimeTravel();
            }
            else
            {
                Console.WriteLine($"\"Hesitation is a luxury you can't afford,\" Karl says, a stern edge to his voice. He hands you an old pocket watch. \"Let's begin.\"");
                StartTimeTravel();
            }
        }

        static void StartTimeTravel()
        {
            Divider();
            Console.WriteLine($"The room spins, and suddenly {MainCharacter} finds himself back in his apartment a week earlier, staring at {Companion}. She's humming a tune, unaware of the storm brewing in your mind.");
            Thread.Sleep(2000);
            Console.WriteLine("The past isn't just memories; it's a living thing, twisting and changing based on what you do now.");
            Divider();
        }

        static void FirstInteraction()
        {
            try
            {
                Divider();
                Console.WriteLine("What do you do?");
                Console.WriteLine("1. Apologize straight away");
                Console.WriteLine("2. Stay silent and observe");
                Console.WriteLine("3. Start with light conversation");
                Console.WriteLine("4. Walk away, conflicted");

                bool validInput = false;
                while (!validInput)
                {
                    Console.Write("Enter your choice: ");
                    string input = Console.ReadLine();
                    CheckForExit(input); // Check if the user wants to exit

                    try
                    {
                        int choice = int.Parse(input);

                        if (choice >= 1 && choice <= 4)
                        {
                            validInput = true;

                            switch (choice)
                            {
                                case 1:
                                    regretLevel -= 15;
                                    candleTime -= 5;
                                    trustLevel += 10;
                                    Console.WriteLine($"You blurt out an apology. {Companion} stops mid-song, surprised by the urgency in your voice.");
                                    ExpressRegret();
                                    break;
                                case 2:
                                    regretLevel += 10;
                                    candleTime -= 10;
                                    trustLevel -= 5;
                                    Console.WriteLine($"You remain silent, letting the tension grow. {Companion} senses something is off but says nothing.");
                                    Observe();
                                    break;
                                case 3:
                                    candleTime -= 5;
                                    trustLevel += 5;
                                    Console.WriteLine($"You break the ice with a casual comment, hoping to ease into the conversation. {Companion} smiles faintly, but you know time is running out.");
                                    CasualConversation();
                                    break;
                                case 4:
                                    regretLevel += 20;
                                    candleTime -= 5;
                                    trustLevel -= 10;
                                    Console.WriteLine("You can't handle it. You walk out, the echoes of her song haunting you as you close the door.");
                                    LeaveRoom();
                                    break;
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid choice. Please select one of the provided options.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
                Divider();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in FirstInteraction: {ex.Message}");
            }
        }

        static void ExpressRegret()
        {
            Divider();
            Console.WriteLine("You decide to open up about your regrets. The words come out heavy, but the relief is almost immediate.");
            Console.WriteLine("1. Talk about what went wrong");
            Console.WriteLine("2. Ask for forgiveness");
            Console.WriteLine("3. Admit that you still care");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            CheckForExit(input); // Check if the user wants to exit
            int choice = int.Parse(input);

            if (choice == 1)
            {
                regretLevel -= 20;
                candleTime -= 5;
                trustLevel += 20;
                Console.WriteLine($"{Companion} listens quietly. The weight in her eyes suggests she’s heard this before, but something is different this time.");
                SecondInteraction();
            }
            else if (choice == 2)
            {
                regretLevel -= 10;
                candleTime -= 10;
                trustLevel += 15;
                Console.WriteLine($"\"I don't expect you to forgive me, but I have to ask.\" You see her resolve wavering.");
                SecondInteraction();
            }
            else if (choice == 3)
            {
                candleTime -= 5;
                trustLevel += 10;
                Console.WriteLine($"\"Despite everything, I still care,\" you say, and the sincerity seems to catch her off-guard.");
                SecondInteraction();
            }
            else
            {
                Console.WriteLine("You choke on the words, unable to express what you really feel. The moment passes.");
            }
            Divider();
        }

        static void Observe()
        {
            Divider();
            Console.WriteLine($"You observe {Companion} quietly, hoping she'll make the first move. But all you feel is the growing distance.");
            Console.WriteLine("1. Break the silence and approach");
            Console.WriteLine("2. Write down what you want to say and leave it behind");
            Console.WriteLine("3. Walk away, overwhelmed");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            CheckForExit(input); // Check if the user wants to exit
            int choice = int.Parse(input);

            if (choice == 1)
            {
                candleTime -= 5;
                trustLevel += 10;
                Console.WriteLine($"You take a step forward, unsure of what to say but determined to try.");
                SecondInteraction();
            }
            else if (choice == 2)
            {
                regretLevel -= 10;
                candleTime -= 10;
                trustLevel += 5;
                Console.WriteLine($"You scribble a heartfelt message on a note, hoping she reads it when you're gone.");
                FinalInteraction();
            }
            else if (choice == 3)
            {
                regretLevel += 20;
                candleTime -= 5;
                trustLevel -= 10;
                Console.WriteLine("You walk away, the regret already gnawing at you.");
                FinalInteraction();
            }
            else
            {
                Console.WriteLine("Your hesitation costs you the moment.");
            }
            Divider();
        }

        static void CasualConversation()
        {
            Divider();
            Console.WriteLine($"{Companion} responds with a faint smile, but the tension lingers. This conversation needs to go deeper.");
            Console.WriteLine("1. Ask about her feelings");
            Console.WriteLine("2. Reminisce about the good times");
            Console.WriteLine("3. Transition into an apology");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            CheckForExit(input); // Check if the user wants to exit
            int choice = int.Parse(input);

            if (choice == 1)
            {
                regretLevel -= 10;
                candleTime -= 5;
                trustLevel += 15;
                Console.WriteLine($"You gently prod her feelings, hoping to understand where she stands now.");
                SecondInteraction();
            }
            else if (choice == 2)
            {
                candleTime -= 5;
                trustLevel += 10;
                Console.WriteLine("You talk about the better times, hoping to remind her of how things once were.");
                SecondInteraction();
            }
            else if (choice == 3)
            {
                regretLevel -= 15;
                candleTime -= 5;
                trustLevel += 20;
                Console.WriteLine($"You transition the conversation into an apology, hoping to set things right.");
                SecondInteraction();
            }
            else
            {
                Console.WriteLine("The moment slips through your fingers, and you lose the opportunity.");
            }
            Divider();
        }

        static void LeaveRoom()
        {
            Divider();
            Console.WriteLine($"The room fades as {MainCharacter} walks away, the regrets piling up even before the door fully closes.");
            EndScene();
        }

        static void SecondInteraction()
        {
            Divider();
            Console.WriteLine($"The air between {MainCharacter} and {Companion} feels heavy, but progress has been made.");
            Thread.Sleep(1000);
        }

        static void FinalInteraction()
        {
            Divider();
            Console.WriteLine("Time is running out. Make your final choice before the candle burns out completely.");
            Thread.Sleep(1000);
            EndScene();
        }

        static void EndScene()
        {
            Console.WriteLine($"The candle flickers its last, and {MainCharacter} is pulled back to the present.");
            Thread.Sleep(1000);

            if (regretLevel <= MaxRegretLevel / 2 && trustLevel >= 50)
            {
                Console.WriteLine("You return to a changed world. The past wasn't perfect, but the future looks brighter now.");
            }
            else
            {
                Console.WriteLine("You return, but something feels off. The regrets still linger, and the past remains unresolved.");
            }

            Console.WriteLine("Thank you for playing. Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
