using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punktown
{
    class First
    {
        private static readonly Random random = new Random();

        private static readonly object syncLock = new object();

        public static int d(int dice)
        {
            lock (syncLock)
            {
                return random.Next(1, dice);
            }
        }

        static int D(int dice)
        {
            int diceValue = d(dice);
            Console.WriteLine("d" + dice + " rolls for " + diceValue);
            return (diceValue);
        }

        public static int input(string input)
        {
            int number = 0;
            int.TryParse(input, out number);
            while (number == 0)
            {
                Console.WriteLine("You've entered invalid data, please enter valid one");
                int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static int preciseInput(string input, int [] desiredValues)
        {
            int number = 0;
            int.TryParse(input, out number);
            int place = Array.IndexOf(desiredValues, number);
            while (place == -1)
            {
                Console.WriteLine("You've entered invalid data, please enter valid one");
                int.TryParse(Console.ReadLine(), out number);
                place = Array.IndexOf(desiredValues, number);
            }
            return number;
        }

        static void declareSkill()
        {
            int skillNumber = 0;
            for (skillNumber = 1; skillNumber < skillName.Length; skillNumber++)
            {
                Console.WriteLine("Input {2} to use {0}. His value is {1}, tool quality is {3}", skillName[skillNumber], skill[skillNumber], skillNumber, inv[skillNumber]);
            }
        }

        static void declareStatus(int[] encounterStatus)
        {
            Console.WriteLine("Distance is {0} meters", encounterStatus[0]);
            if (encounterStatus[1] == 1)
            {
                Console.WriteLine("You are hidden");
            }
            if (encounterStatus[2] == 1)
            {
                Console.WriteLine("You have cover");
            }
            if (encounterStatus[3] == 0)
            {
                Console.WriteLine("He is not aware of you");
            }
            if (encounterStatus[4] == 1)
            {
                Console.WriteLine("This message is not supposed to appear");
            }
        }

        static void struckLimb()
        {
            string[] limbs = new string[] { "left leg", "right leg", "left arm", "right arm", "torso", "head" };
            Console.WriteLine("You hit {0}.", limbs[d(6)]);
        }
        
        static void awake()
        {
            Console.WriteLine("You are sleeping...");
            Console.ReadLine();
            Console.WriteLine("The cold and darkness inside your head became The Universe. Your Universe");
            Console.ReadLine();
            Console.WriteLine("ZZAPP!");
            Console.WriteLine("The cold is melting while darkness becomes more... 'physical'. Hurtfully physical. Like acute pain in your chest");
            Console.ReadLine();
            Console.WriteLine("ZZZZZAPP!");
            Console.WriteLine("The Uiverse is falling apart like stattered mirror");
            Console.WriteLine("Something is pushing you forward and you falling right into shadows");
            //struckLimb();
            Console.WriteLine("You are awake...");
            Console.WriteLine("...");
            Console.WriteLine("You find yourself in big container with a lot of wires and lights. Left side of your chest is in pain. Lights is so bright and if you look it's hard to fight feeling that your eyes is burning out.");
            Console.WriteLine("Pain in your ears complete the painting of your suffering after machine voice declares 'Power level is low, initializing emergency protocol'.");
            Console.WriteLine("Few seconds later hellishly bright light replaced with nice dim red lights.");
            Console.WriteLine("It makes you a bit worry, like somethig is wrong, but at least now you can see with your eyes");
            Console.WriteLine("'Outer shell is damaged, power leaking is detected. Evacuation is highly recomended'");
            Console.WriteLine("You see something like console with some keys. You do remember that it have something to do with geting out of here, but details elude you");
        }

        static void charCreationStory()
        {
            Console.WriteLine("[Now charecter creation will start. During this event all your action is conditionally sucessful. Some desicion leads to more satisfying consecvenses. It's required to build up your style of game. Don't worry, later you will be able to completely reassign your skills if you wish]");
            Console.WriteLine("Choose action to perform:");
            Console.WriteLine("1 - Let's try polite way: press some buttons and try to remember how this thing works");
            Console.WriteLine("2 - Puny buttons is for weaklings! Try to kick your way out. This thing has to have her durability limited");
            int action = preciseInput(Console.ReadLine(), new int[] { 1, 2 });
            if (action == 1)
            {
                Console.WriteLine("[Your hacking skill increased!]");
                Console.WriteLine("'Hey, wait! I do remember how it is works, but... why? What is this thing anyway? Ok, I think it's better to find an answer outside of this high-tech coffin.");
                Console.WriteLine("You have pressed some buttons and locks on door started to unlock. Most of them but one moved away. It seems jammed");
                Console.WriteLine("Should you put some strength in it (1) or look for something to pick lock (2)?");
                action = preciseInput(Console.ReadLine(), new int[] { 1, 2 });
                if (action == 1)
                {
                    Console.WriteLine("[Your melee skill increased!]");
                    Console.WriteLine("Your kicked your way out!");
                }
                else
                {
                    Console.WriteLine("[Your lockpick skill increased!]");
                    Console.WriteLine("Your found your way out!");
                }
            }
            else
            {
                Console.WriteLine("[Your melee skill increased!]"); 
                Console.WriteLine("'AAAhhhh tiny useless buttons! Who need them anyway?!'");
                Console.WriteLine("Lock won't succumb");
                Console.WriteLine("Should you put more fore it (1) or try to find a weak spot in door (2)?");
                action = preciseInput(Console.ReadLine(), new int[] { 1, 2 });
                if (action == 1)
                {
                    Console.WriteLine("[Your melee skill increased!]");
                    Console.WriteLine("You put in your kick all you have in your current condition, but it seems your bones was not ready for this. You hurt your left leg. But on the bright side - you crushed last lock and the door is wide open!");
                }
                else
                {
                    Console.WriteLine("[Your notice skill increased!]");
                    Console.WriteLine("You found weak spot!");
                }
            }
        }

        static void wonder ()
        {
            Random random = new Random();
            int location = random.Next(0, 1000);
            location = 5;
            if (location < 10)
            {
                encounterBrute();
            }
            else
            {
                Console.WriteLine("Hey, I've been here! Probably gave a circle or something.");
            }
        }

        static int missOrHit(int skillNumber, int[] armor)
        {
            if (armor[skillNumber] == 100)
            {
                Console.WriteLine("{0} is useless here!", skillName[skillNumber]);
                skillNumber = 0;
            }
            else if (skill[skillNumber] + inv[skillNumber] + D(20) < armor[skillNumber])
            {
                Console.WriteLine("{0} misses!", skillName[skillNumber]);
                skillNumber = 0;
            }
            else
            {
                Console.WriteLine("{0} hits!", skillName[skillNumber]);
            }
            return skillNumber;
        }

        static void stealthAction(int mainSkill, int secondarySkill, int[] armor, float[] encounterStatus, int damage)
        {
            if (mainSkill == 1 || mainSkill == 5 || mainSkill == 7 || mainSkill == 8 || secondarySkill == 1 || secondarySkill == 5 || secondarySkill == 7 || secondarySkill == 8)
            {
                Console.WriteLine("You broke your stealth with your another action");
                encounterStatus[1] = 0;
            }
            else if (encounterStatus[1] == 0)
            {
                Console.WriteLine("Stealth action! You now hidden");
                encounterStatus[1] = 1;
            }
            damage = 0;
        }

        static int withoutCombo(int mainSkill, int secondarySkill, int[] armor, int[] encounterStatus)
        {
            int damage = 0;
            if (mainSkill > 0)
            {
                damage = D(6);
            }
            return damage;
        }

        static void encounterBrute ()
        {
            int[] armor = new int[11] { 200, 10, 100, 10, 10, 10, 10, 10, 10, 10, 10 };
            int[] encounterStatus = new int[5] { 5, 0, 0, 0, 0 }; //"Range", "Hiddenness", "Cover", "Awareness", "AnotherStatus"
            Console.WriteLine("Huge brute with aggressive intentions is approaching");
            do
            {
                declareStatus(encounterStatus);
                Console.WriteLine("Choose main skill in action('23' to remind options)");
                int mainSkill = preciseInput(Console.ReadLine(), new int[] { 1, 2, 3, 4, 5, 23 });
                if (mainSkill == 23)
                {
                    declareSkill();
                    Console.WriteLine("Enter main action");
                    mainSkill = preciseInput(Console.ReadLine(), new int[] { 1, 2, 3, 4, 5 });
                }
                Console.WriteLine("Choose secondary action");
                int secondarySkill = preciseInput(Console.ReadLine(), new int[] { 1, 6, 7, 8, 9, 10 });

                mainSkill = missOrHit(mainSkill, armor);
                secondarySkill = missOrHit(secondarySkill, armor);

                int damage = withoutCombo(mainSkill, secondarySkill, armor, encounterStatus);
                armor[0] = armor[0] - damage;

                if (encounterStatus[0] > 0)
                {encounterStatus[0]--;}

                Console.WriteLine("Hit points left {0}", armor[0]);
            } while (armor[0] > 0);
            Console.WriteLine("Brute is defeated!");
        }

        static void whereTo ()
        {
            Console.WriteLine("What will you do now? (type 'help' for available options)");
            switch (Console.ReadLine())
            {
                case ("help"):
                    Console.WriteLine("Type '1' to venture to new random location");
                    Console.WriteLine("Type '2' to visit huckster");
                    whereTo();
                    break;
                case ("1"):
                    Console.WriteLine("Ha! Adventure!");
                    wonder();
                    whereTo();
                    break;
                case ("2"):
                    Console.WriteLine("'Huckster' is temporal exit from game for now");
                    break;
                default:
                    Console.WriteLine("Is it in Africa? Sorry, I have no idea how to get there");
                    whereTo();
                    break;
            }
        }

        static void firstChapter()
        {
            //awake();
            //charCreationStory(skill, inv, skillName);
            whereTo();
        }

        public static int[] skill = new int[11] { 100, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        public static int[] inv = new int[11] { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static string[] skillName = new string[11] { "Hit points", "Athletics (main or secondary)", "Hacking (main)", "Ranged (main)", "Lockpick (main)", "Melee (main)", "Knowledge (secondary)", "Notice (secondary)", "Speech (secondary)", "Stealth (secondary)", "Streetwise (secondary)" };

        static void Main(string[] args)
        {
            firstChapter();
        }
    }
}
