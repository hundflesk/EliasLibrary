using System;
using System.Collections.Generic;
using System.Linq;

namespace EliasLibrary
{
    /// <summary>
    /// <para>En klass av användare för spel.</para>
    /// </summary>
    public class User
    {
        public string name;
        public int score;

        public User(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public static List<User> CreateUser(List<User> userList)
        {
            User[] userArray = userList.ToArray();

            Console.Clear();
            while (true)
            {
                Console.Write("Vad heter du?\nSvar: ");
                string name = Console.ReadLine();
                Console.Clear();

                if (name.Any(chr => !Char.IsLetter(chr)) || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Ditt namn är oacceptabelt.\n");
                    Console.WriteLine("1. Använd inga mellanslag.");
                    Console.WriteLine("2. Använd inga siffror.");
                    Console.WriteLine("3. Använd inga specialtecken.");
                    Console.WriteLine("4. Lämna inte fältet tomt.");
                }
                else if (name.Length < 3)
                    Console.WriteLine("Ditt namn är för kort.\nAnvänd minst tre bokstäver.");
                else
                {
                    name = name.ToLower();

                    bool userExisting = false;
                    for (int i = 0; i < userArray.Length; i++)
                    {
                        if (name == userArray[i].name.ToLower())
                        {
                            userExisting = true;
                            break;
                        }
                    }
                    if (userExisting == true)
                        Console.WriteLine("Det användarnamnet är taget... Välj ett annat!");

                    else
                    {
                        if (char.IsLower(name[0]))
                            name = char.ToUpper(name[0]) + name.Substring(1);

                        Console.WriteLine("Namnet går att använda!\n");

                        ConsoleKey ans = Task.AreYouSure("använda detta namn");
                        if (ans == ConsoleKey.Enter)
                        {
                            userList.Add(new User(name, 0));
                            return userList;
                        }
                        else if (ans == ConsoleKey.Spacebar)
                            Console.WriteLine("Registreringen avbröts.");
                    }
                }
                Task.PressEnter("välja ett annat namn");
            }
        }
    }

    public class Task
    {
        ///<summary>
        ///<para>Tryck 'ENTER' för att ____... (meningen som skrivs)</para>
        ///<para>Byt ut "____" mot något/några ord som förklarar vad användaren ska göra.</para>
        ///<para>En radavbrytning görs innan meningen skrivs ut. Konsollen rensas i slutet.</para>
        ///</summary>
        public static void PressEnter(string word)
        {
            Console.WriteLine($"\nTryck 'ENTER' för att {word}...");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    break;
            }
            Console.Clear();
        }

        /// <summary>
        /// <para>Är du säker på att du vill ____? (meningen som skrivs)</para>
        /// <para>Byt ut "____" mot några ord som förklarar vad användaren ska bekräfta eller neka.</para>
        /// <para>Konsollen rensas i slutet.</para>
        /// </summary>
        public static ConsoleKey AreYouSure(string word)
        {
            Console.WriteLine($"Är du säker på att du vill {word}?");
            Console.WriteLine("[ENTER] = JA | [SPACE] = NEJ\n");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    return key;
                }
            }
        }
    }
}