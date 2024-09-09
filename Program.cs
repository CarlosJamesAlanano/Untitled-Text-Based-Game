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
            try
            {
                IntroScene();
                while (candleTime > 0)
                {
                    FirstInteraction();
                    if (candleTime <= 0) break;
                }
                EndScene();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void Divider()
        {
            Console.WriteLine("\n----------------------------------------\n");
        }

        static void IntroScene()
        {
            try
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
                Console.WriteLine("E. Exit");
                Console.Write("Enter your choice: ");
                string choiceInput = Console.ReadLine();

                if (int.TryParse(choiceInput, out int choice))
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("Karl nods knowingly. \"Time is fickle. But it may listen, just this once.\"");
                        StartTimeTravel();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine($"Karl chuckles softly. \"Regret is for those who refuse to learn from the past. Let's see if youâ€™re one of them.\"");
                        StartTimeTravel();
                    }
                    else
                    {
                        throw new Exception("Invalid numeric choice.");
                    }
                }
                else if (choiceInput.Equals("E", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\"Hesitation is a luxury you can't afford,\" Karl says, a stern edge to his voice. He hands you an old pocket watch. \"Let's begin.\"");
                    StartTimeTravel();
                }
                else
                {
                    throw new Exception("Invalid choice. Please enter a valid option.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in IntroScene: {ex.Message}");
                IntroScene();
            }
        }

        static void StartTimeTravel()
        {
            try
            {
                Divider();
                Console.WriteLine($"The room spins, and suddenly {MainCharacter} finds himself back in his apartment a week earlier, staring at {Companion}. She's humming a tune, unaware of the storm brewing in your mind.");
                Thread.Sleep(2000);
                Console.WriteLine("The past isn't just memories; it's a living thing, twisting and changing based on what you do now.");
                Divider();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in StartTimeTravel: {ex.Message}");
            }
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
            try
            {
                Divider();
                Console.WriteLine("You decide to open up about your regrets. The words come out heavy, but the relief is almost immediate.");
                Console.WriteLine("1. Talk about what went wrong");
                Console.WriteLine("2. Ask for forgiveness");
                Console.WriteLine("3. Admit that you still care");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    regretLevel -= 20;
                    candleTime -= 5;
                    trustLevel += 20;
                    Console.WriteLine($"{Companion} listens quietly. The weight in her eyes suggests sheâ€™s heard this before, but something is different this time.");
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in ExpressRegret: {ex.Message}");
            }
        }
        static void Observe()
        {
            try{
            Divider();
            Console.WriteLine($"You observe {Companion} quietly, hoping she'll make the first move. But all you feel is the growing distance.");
            Console.WriteLine("1. Break the silence and approach");
            Console.WriteLine("2. Write down what you want to say and leave it behind");
            Console.WriteLine("3. Walk away, overwhelmed");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in ExpressRegret: {ex.Message}");
            }
        }

        static void CasualConversation()
        {
            try{
            Divider();
            Console.WriteLine($"{Companion} responds with a faint smile, but the tension lingers. This conversation needs to go deeper.");
            Console.WriteLine("1. Ask about her feelings");
            Console.WriteLine("2. Reminisce about the good times");
            Console.WriteLine("3. Transition into an apology");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

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
                Console.WriteLine($"You share a light-hearted memory, and for a moment, the tension eases.");
                FinalInteraction();
            }
            else if (choice == 3)
            {
                regretLevel -= 10;
                candleTime -= 10;
                trustLevel += 15;
                Console.WriteLine("You decide to stop beating around the bush and directly address what's weighing on you.");
                FinalInteraction();
            }
            else
            {
                Console.WriteLine("Your uncertainty freezes the conversation in place.");
            }
            Divider();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in ExpressRegret: {ex.Message}");
            }
        }

        static void LeaveRoom()
        {
            try{
            Divider();
            Console.WriteLine("You walk out, but doubt lingers. Do you really want to let this moment slip away?");
            Console.WriteLine("1. Go back and try again");
            Console.WriteLine("2. Keep walking, even if it means regret");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                candleTime -= 5;
                trustLevel -= 10;
                Console.WriteLine("You turn back and enter the room again, determined to make things right.");
                FirstInteraction();
            }
            else if (choice == 2)
            {
                regretLevel += 30;
                Console.WriteLine("You continue walking away, the weight of regret heavy on your shoulders.");
            }
            else
            {
                Console.WriteLine("You stand frozen, unable to decide.");
            }
            Divider();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in ExpressRegret: {ex.Message}");
            }
        }

        static void SecondInteraction()
        {
            try{
            Divider();
            Console.WriteLine("The conversation deepens, but time is running out. How do you use the remaining moments?");
            Console.WriteLine("1. Make a final heartfelt apology");
            Console.WriteLine("2. Reflect on your actions and their impact");
            Console.WriteLine("3. Ask for a chance to make things right");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                regretLevel -= 20;
                candleTime -= 10;
                trustLevel += 20;
                Console.WriteLine($"You pour your heart out, hoping that your apology resonates.");
                FinalInteraction();
            }
            else if (choice == 2)
            {
                regretLevel -= 15;
                candleTime -= 5;
                trustLevel += 10;
                Console.WriteLine($"You reflect on your actions, hoping she understands your remorse.");
                FinalInteraction();
            }
            else if (choice == 3)
            {
                regretLevel -= 10;
                candleTime -= 5;
                trustLevel += 10;
                Console.WriteLine($"You ask for another chance, hoping she sees the sincerity in your eyes.");
                FinalInteraction();
            }
            else
            {
                Console.WriteLine("You struggle to find the right words, and the remaining time slips away.");
            }
            Divider();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in ExpressRegret: {ex.Message}");
            }
        }

        static void FinalInteraction()
        {
            try{
            Divider();
            Console.WriteLine("Time is running out. How do you end this encounter?");
            Console.WriteLine("1. Express your gratitude and leave");
            Console.WriteLine("2. Reaffirm your apology");
            Console.WriteLine("3. Say goodbye and return to the present");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("You express your gratitude and leave, hoping the message was clear.");
                EndScene();
            }
            else if (choice == 2)
            {
                Console.WriteLine($"You reaffirm your apology, hoping it will leave a lasting impression.");
                EndScene();
            }
            else if (choice == 3)
            {
                Console.WriteLine("You say your goodbyes and return to the present, awaiting the outcome of your actions.");
                EndScene();
            }
            else
            {
                Console.WriteLine("Your uncertainty leaves you at a loss for words, and time runs out.");
                EndScene();
            }
            Divider();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in ExpressRegret: {ex.Message}");
            }
        }

        static void EndScene()
        {
            try
            {
                Divider();
                Console.WriteLine("You return to the present, the effects of your choices shaping the world you find yourself in.");
                Console.WriteLine("Regret and growth now define your path, and the outcome depends on how you faced the past.");

                Divider();
                Console.WriteLine("Type 'exit' to close the game.");
                bool validExit = false;
                while (!validExit)
                {
                    string input = Console.ReadLine();
                    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        validExit = true;
                    }
                    else
                    {
                        throw new Exception("Invalid input. Please type 'exit' to quit.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in EndScene: {ex.Message}");
            }
        }
    }
}
