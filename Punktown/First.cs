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
        public static int mainSkill = 0;
        public static int secondarySkill = 0;
        public static string enemyName = "void";
        public static int[] skill = new int[11] { 100, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        public static int[] inv = new int[11] { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static int[] temporalStat = new int[5] { 50, 35, -100, 0, 0 }; // HPmax, HPcurr, XP, LVL, Credits
        public static string[] skillName = new string[11] { "Hit points", "Hacking (main)", "Ranged (main)", "Lockpick (main)", "Melee (main)", "Athletics (secondary)", "Knowledge (secondary)", "Notice (secondary)", "Speech (secondary)", "Stealth (secondary)", "Streetwise (secondary)" };
        public static string[] toolName = new string[11] { "Armor", "version for hacking worm", "laser gun", "lockpick set", "sledgehammer", "sneakers", "electronic notepad", "magnifying lens", "voice amplifier", "camouflage cloak", "compass" };
        public static int[] armor = new int[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static int[] encounterStatus = new int[6] { 10, 0, 0, 0, 0, 0 }; //"Range", "Hiddenness", "Awareness", "Familiarity", "Horrified", "Distracted"

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

        public static void help()
        {
            Console.WriteLine("You are in 'help' section. Input '1' for skills description, '2' for credits, '3' to exit");
            int help = preciseInput(new int[] {1, 2});
            if (help == 1)
            {
                Console.WriteLine("Hacking (main) is used against any kinds of turrets, cybernetic life-forms or when comfronting computer controlled systems. It is main source of damage in such battles");
                Console.WriteLine("Ranged (main) is way to inflict physical damage while maintaining distance. In most cases it lets you avoid damage from melee opponent, but in close range Melee (main) can be more effective");
                Console.WriteLine("Lockpick (main) is required to open both mechanical and electronics locks");
                Console.WriteLine("Melee (main) - ability to deal damage at close distance");
                Console.WriteLine("Athletics (secondary) required to get away from someone or conversevly approach. Also passively increasing armor");
                Console.WriteLine("Knowledge (secondary) can help charecter to remember vital spots of his tasrget to unlock critical strikes");
                Console.WriteLine("Notice (secondary) can be used to determine level of defence against random skill");
                Console.WriteLine("Speech (secondary) have several ways to use. You can intimidate target and force it surrender on low HP, or you can distract to make you next move more successful");
                Console.WriteLine("Stealth (secondary) can be used to avoid battles. Also damage when breaking stealth is immensely increased");
                Console.WriteLine("Streetwise (secondary) lets you avoid the battle both at the beginning, before opponent haven't noticed you, or after beginning when you reached certain distance");
            }
            if (help == 2)
            {
                Console.WriteLine("Thank you for participation in testing! Please contact me for more information, my email is 'mozge4ok@gmail.com'");
            }

        }

        public static int preciseInput(int [] desiredValues)
        {
            string input = Console.ReadLine();
            if (input == "help")
            {
                help();
            }
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
                Console.WriteLine("Input {2} for {0}. Its value is {1}, tool quality is {3}", skillName[skillNumber], skill[skillNumber], skillNumber, inv[skillNumber]);
            }
            Console.WriteLine("Your level is {4}. You have {0} hit points, out of {1}. XP to next level - {2}, armor is {3}", temporalStat[1], temporalStat[0], Math.Abs(temporalStat[2]), (10 + skill[5] + inv[4]), temporalStat[3] );
        }

        static void declareStatus()
        {
            Console.WriteLine("Distance is {0} meters", encounterStatus[0]);
            if (encounterStatus[1] == 1)
            {
                Console.WriteLine("You are hidden");
            }
            if (encounterStatus[2] == 0)
            {
                Console.WriteLine("{0} is not aware of your presence", enemyName);
            }
            if (encounterStatus[3] == 1)
            {
                Console.WriteLine("You know weak points of {0}", enemyName);
            }
            if (encounterStatus[4] == 1)
            {
                Console.WriteLine("{0} is afraid of you", enemyName);
            }
            if (encounterStatus[5] == 1)
            {
                Console.WriteLine("{0} is distracted", enemyName);
            }
        }

        static void wonder ()
        {
            int location = d(10);
            if (location == 1)
            {
                encounterBrute();
            }
            else if (location == 2)
            {
                encounterJunky();
            }
            else
            {
                Console.WriteLine("Hey, I've been here! Probably made a circle or something.");
            }
        }

        static int missOrHit(int skillNumber)
        {
            if (armor[skillNumber] == 100)
            {
                Console.WriteLine("{0} is useless here!", skillName[skillNumber]);
                skillNumber = -skillNumber;
            }
            else
            {
                int result = D(20);
                if (skill[skillNumber] + inv[skillNumber] + result + (d(6) * encounterStatus[5]) < armor[skillNumber])
                {
                    Console.WriteLine("{0} misses!", skillName[skillNumber]);
                    skillNumber = -skillNumber;
                }
                else
                {
                    Console.WriteLine("{0} hits!", skillName[skillNumber]);
                    if (result > 18 && skillNumber < 5 && encounterStatus[3] == 1)
                    {
                        encounterStatus[3] = 2;
                    }
                }
            }
            return skillNumber;
        }

        static void armorInput (int [] valuesToInput)
        {
            int position = 0;
            for (position = 0; position < armor.Length; position++)
            {
                armor[position] = valuesToInput[position];
            }
        }

        static void resetEncounterStatus()
        {
            //Is it wise not to create new local variable?
            for (encounterStatus[0] = 1; encounterStatus[0] < encounterStatus.Length; encounterStatus[0]++)
            {
                encounterStatus[encounterStatus[0]] = 0;
            }
            encounterStatus[0] = 10;
        }

        static int stealthBreakCheck()
        {
            int stealthStatus = 1;
            if (Math.Abs(mainSkill) == 2 || Math.Abs(mainSkill) == 4)
            {
                Console.WriteLine("You broke your stealth with {0}", skillName[Math.Abs(mainSkill)]);
                stealthStatus = 0;
            }
            else if (Math.Abs(secondarySkill) == 5 || Math.Abs(secondarySkill) == 8)
            {
                Console.WriteLine("You broke your stealth with {0}", skillName[Math.Abs(secondarySkill)]);
                stealthStatus = 0;
            }
            return stealthStatus;
        }

        static int mainSkillDamage()
        {
            int damage = 0;
            int weaponQuality = 0;
            if (mainSkill > 0 && mainSkill < 5)
            {
                for (weaponQuality = 0; weaponQuality < inv[mainSkill]; weaponQuality++)
                {
                    damage = damage + D(6);
                }
                if (encounterStatus[3] == 2)
                {
                    Console.WriteLine("Critical strike! x2 damage!");
                    damage = damage * 2;
                    encounterStatus[3] = 1;
                }
                Console.WriteLine("Damage done: {0}", damage);
            }
            else
            {
                Console.WriteLine("No damage done in this turn");
            }
            return damage;
        }

        static void statusUpdate ()
        {
            if (encounterStatus[1] == 1)
            {
                encounterStatus[1] = stealthBreakCheck();
            }
            if (encounterStatus[2] == 0 && (Math.Abs(mainSkill) == 2 || Math.Abs(mainSkill) == 4 || Math.Abs(secondarySkill) == 5 || Math.Abs(secondarySkill) == 8 || Math.Abs(mainSkill) == 5 || Math.Abs(mainSkill) == 8))
            {
                encounterStatus[2] = 1;
                Console.WriteLine("He is now aware of you!");
            }
            if (encounterStatus[0] > 0)
            {
                encounterStatus[0]--;
                if ((encounterStatus[2] == 1) && (encounterStatus[0] > 0))
                {
                    encounterStatus[0]--;
                }
            }
            if (encounterStatus[5] == -1)
            {
                encounterStatus[5] = 1;
            }
            else
            {
                encounterStatus[5] = 0;
            }
        }

        static void noticeSkill ()
        {
            int skillNumber = d(10);
            if (armor[skillNumber] == 100)
            {
                Console.WriteLine("You have noticed that {0} is useless here", skillName[skillNumber]);
            }
            if (armor[skillNumber] < 8)
            {
                Console.WriteLine("You have noticed that {1} is weak against {0}", skillName[skillNumber], enemyName);
            }
            else if (armor[skillNumber] < 13)
            {
                Console.WriteLine("You have noticed that {1} has average protection against {0}", skillName[skillNumber], enemyName);
            }
            else
            {
                Console.WriteLine("You have noticed that {1} has strong protection versus {0}", skillName[skillNumber], enemyName);
            }
        }

        static void knowledgeSkill ()
        {
            if (encounterStatus[3] == 1)
            {
                Console.WriteLine("There's no point in using knowledge more than once");
            }
            else
            {
                encounterStatus[3] = 1;
                Console.WriteLine("You know weak points of {0}. Critical strike unlocked!", enemyName);
            }
        }

        static void speachSkill()
        {
            Console.WriteLine("Please decide what you're going to tell to {0} ('1' to intimidate, '2' to distract)", enemyName);
            int option = preciseInput(new int[] { 1, 2});
            if (option == 1)
            {
                Console.WriteLine("{0} is now afraid of you and will surrender on low HP", enemyName);
                encounterStatus[4] = 1;
            }
            else
            {
                Console.WriteLine("{0} is distracted and his defences are temporaly lowered for d6", enemyName);
                encounterStatus[5] = -1;
            }
        }

        static void athleticsSkill(int multiplier)
        {
            Console.WriteLine("Are you running away (1) or closing in (2)?");
            int moreOrLess = preciseInput(new int[] { 1, 2 });
            if (moreOrLess == 1)
            {
                encounterStatus[0] = encounterStatus[0] + (1 * multiplier);
                if (multiplier == 2)
                {
                    if (mainSkill == 5)
                    {
                        encounterStatus[0]++;
                    }
                    if (secondarySkill == 5)
                    {
                        encounterStatus[0]++;
                    }
                }
                else if ((mainSkill == 5) || (secondarySkill == 5))
                {
                    encounterStatus[0] = encounterStatus[0] + (1 * multiplier);
                }
            }
            if (moreOrLess == 2 && encounterStatus[0] >= (2 * multiplier))
            {
                encounterStatus[0] = encounterStatus[0] - (1 * multiplier);
                if (multiplier == 2)
                {
                    if (mainSkill == 5)
                    {
                        encounterStatus[0]--;
                    }
                    if (secondarySkill == 5)
                    {
                        encounterStatus[0]--;
                    }
                }
                else if ((mainSkill == 5) || (secondarySkill == 5))
                {
                    encounterStatus[0] = encounterStatus[0] - (1 * multiplier);
                }
            }
        }

        static void actionInput()
        {
            Console.WriteLine("Choose main skill in action (It could be main or secondary skill, '23' to remind options)");
            mainSkill = preciseInput(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 23 });
            if (mainSkill == 23)
            {
                declareSkill();
                Console.WriteLine("Enter main action");
                mainSkill = preciseInput(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            }
            if ((mainSkill == 1 || mainSkill == 3 || mainSkill == 4) && encounterStatus[0] > 3)
            {
                Console.WriteLine("You need to be in close range (3 or less) to use Hacking, Lockpick or Melee. Please choose different skill");
                mainSkill = preciseInput(new int[] { 2, 5, 6, 7, 8, 9, 10 });
            }
            Console.WriteLine("Choose secondary action (It is always secondary skill)");
            secondarySkill = preciseInput(new int[] { 5, 6, 7, 8, 9, 10 });
        }
        
        static int damageMultiplier()
        {
            int damageMultiplier = 1;
            if (mainSkill == 2 && encounterStatus[1] == 1)
            {
                Console.WriteLine("Fire from the cover! x2 damage!");
                damageMultiplier = 2;
            }
            if (mainSkill == 4 && secondarySkill == 5 && encounterStatus[1] == 1 && encounterStatus[0] > 3 && encounterStatus[0] < 7)
            {
                Console.WriteLine("Sinister charge! x4 damage!!!");
                damageMultiplier = 4;
            }
            else if (mainSkill == 4 && encounterStatus[1] == 1)
            {
                Console.WriteLine("Backstab! x3 damage!");
                damageMultiplier = 3;
            }
            else if (mainSkill == 4 && secondarySkill == 5 && encounterStatus[0] > 3 && encounterStatus[0] < 7)
            {
                Console.WriteLine("Charge! x2 damage!");
                damageMultiplier = 2;
            }
            return damageMultiplier;
        }
        
        static void secondaryEffects()
        {
            if (mainSkill == 6)
            {
                knowledgeSkill();
            } 
            if (secondarySkill == 6)
            {
                knowledgeSkill();
            }
            if (mainSkill == 7)
            {
                noticeSkill();
            }
            if (secondarySkill == 7)
            {
                noticeSkill();
            }
            if (mainSkill == 8)
            {
                speachSkill();
            }
            if (secondarySkill == 8)
            {
                speachSkill();
            }
            if (mainSkill == 9)
            {
                encounterStatus[1] = 1;
            }
            if (secondarySkill == 9)
            {
                encounterStatus[1] = 1;
            }
            if (mainSkill == 10)
            {
                streetWiseSkill();
            }
            if (secondarySkill == 10)
            {
                streetWiseSkill();
            }
            if ((Math.Abs(mainSkill) == 5) && (Math.Abs(secondarySkill) == 5))
            {
                athleticsSkill(2);
            }
            else
            {
                if (Math.Abs(mainSkill) == 5)
                {
                    athleticsSkill(1);
                }
                if (Math.Abs(secondarySkill) == 5)
                {
                    athleticsSkill(1);
                }
            }
        }

        static void streetWiseSkill()
        {
            if (encounterStatus[0] < 19)
            {
                Console.WriteLine("You not far enough to get away from {0}", enemyName);
            }
            else
            {
                Console.WriteLine("Your tactical retreat is succesful");
                encounterStatus[0] = 100;
            }
        }

        static int runOrFight()
        {
            Console.WriteLine("Do you want to fight (1) or to retreat tactically? (0)");
            int decision = preciseInput(new int[] { 0, 1 });
            if (decision == 1)
            {
                Console.WriteLine("Good luck!");
                return 0;
            }
            else
            {
                decision = missOrHit(10);
                if (decision > 0)
                {
                    Console.WriteLine("Your retreat is succesful");
                    return 1;
                }
                else
                {
                    Console.WriteLine("You're not fast enough this time, you have to fight");
                    return 0;
                }
            }

        }

        static void encounterBrute ()
        {
            enemyName = "Huge brute";
            Console.WriteLine("{0} is approaching with aggressive intentions", enemyName);
            armorInput(new int[11] { 50, 100, 8, 100, 9, 7, 8, 9, 6, 8, 7 });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1)
                {
                    enemyTurn(3);
                }
                declareStatus();
                actionInput();
                mainSkill = missOrHit(mainSkill);
                secondarySkill = missOrHit(secondarySkill);
                secondaryEffects();
                armor[0] = armor[0] - (mainSkillDamage() * damageMultiplier());
                statusUpdate();
                Console.WriteLine("{1} has {0} hit points left", armor[0], enemyName);
            } while ((armor[0] - (encounterStatus[4] * 20) > 0) && (encounterStatus[0] < 90));
            if (encounterStatus[0] < 90)
            {
                conclusion(20);
            }
        }

        static void encounterJunky()
        {
            enemyName = "Weak junky";
            Console.WriteLine("{0} is approaching with aggressive intentions", enemyName);
            armorInput(new int[11] { 30, 100, 6, 100, 8, 6, 7, 9, 5, 6, 7 });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1)
                {
                    enemyTurn(1);
                }
                declareStatus();
                actionInput();
                mainSkill = missOrHit(mainSkill);
                secondarySkill = missOrHit(secondarySkill);
                secondaryEffects();
                armor[0] = armor[0] - (mainSkillDamage() * damageMultiplier());
                statusUpdate();
                Console.WriteLine("{1} has {0} hit points left", armor[0], enemyName);
            } while ((armor[0] - (encounterStatus[4] * 15) > 0) && (encounterStatus[0] < 90));
            if (encounterStatus[0] < 90)
            {
                conclusion(8);
            }
        }

        static void enemyTurn(int power)
        {
            int fullArmor = 10 + skill[5] + inv[4];
            Console.WriteLine("{0} is fightning you!", enemyName);
            int iterationNumber = D(20);
            if (iterationNumber + (power * 2) > fullArmor)
            {
                int damage = 0;
                for (iterationNumber = 0; iterationNumber < power; iterationNumber++)
                {
                    damage = damage + d(6);
                }
                temporalStat[1] = temporalStat[1] - damage;
                Console.WriteLine("Strike hits your for {0}, you have {1} HP left", damage, temporalStat[1]);
                if (temporalStat[1] <= 0)
                {
                    Console.WriteLine("You have died!");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Miss!");
            }
        }

        static void conclusion(int reward)
        {
            if (armor[0] > 0)
            {
                Console.WriteLine("{0} surrendered!", enemyName);
            }
            else
            {
                Console.WriteLine("{0} is defeated!", enemyName);
            }
            int skillNumber = 0;
            int money = 0;
            for (skillNumber = 0; skillNumber < reward; skillNumber++)
            {
                money = money + d(3) - 1;
            }
            temporalStat[4] = temporalStat[4] + money;
            temporalStat[2] = temporalStat[2] + reward;
            Console.WriteLine("You have found {0} credits", money);
            Console.WriteLine("You are awarded with {0} XP!", reward);
            if (d(100) < reward)
            {
                skillNumber = d(10);
                Console.WriteLine("You have found new {0}!", toolName[skillNumber]);
                inv[skillNumber]++;
            }
        }

        static void levelUp ()
        {
            if (temporalStat[2] >= 0)
            {
                temporalStat[3]++;
                temporalStat[0] = temporalStat[0] + 5;
                temporalStat[1] = temporalStat[1] + 5;
                temporalStat[2] = temporalStat[2] - ((temporalStat[3] + 2) * (50));
                Console.WriteLine("You have reached {0} level! You gain 5 additional HP");
                Console.WriteLine("Choose main skill to improve (23 to remind options)", temporalStat[3]);
                int skillToImprove = preciseInput(new int[] { 1, 2, 3, 4, 23 });
                if (skillToImprove == 23)
                {
                    declareSkill();
                    Console.WriteLine("Choose skill to improve");
                    skillToImprove = preciseInput(new int[] { 1, 2, 3, 4 });
                }
                skill[skillToImprove]++;
                Console.WriteLine("Your {0} now is {1}", skillName[skillToImprove], skill[skillToImprove]);
                Console.WriteLine("Choose secondary skill to improve (23 to remind options)", temporalStat[3]);
                skillToImprove = preciseInput(new int[] { 5, 6, 7, 8, 9, 10, 23 });
                if (skillToImprove == 23)
                {
                    declareSkill();
                    Console.WriteLine("Choose skill to improve");
                    skillToImprove = preciseInput(new int[] { 5, 6, 7, 8, 9, 10 });
                }
                skill[skillToImprove]++;
                Console.WriteLine("Your {0} now is {1}", skillName[skillToImprove], skill[skillToImprove]);
            }
        }

        static void whereTo ()
        {
            levelUp();
            Console.WriteLine("What will you do now? (type 'help' for available options)");
            switch (Console.ReadLine())
            {
                case ("help"):
                    Console.WriteLine("Type '1' to find random battle");
                    Console.WriteLine("Type '2' to visit huckster");
                    Console.WriteLine("Type '3' to exit");
                    whereTo();
                    break;
                case ("1"):
                    Console.WriteLine("Ha! Adventure!");
                    wonder();
                    whereTo();
                    break;
                case ("2"):
                    Console.WriteLine("Black market have everything you need!");
                    huckster();
                    whereTo();
                    break;
                case ("3"):
                    Console.WriteLine("Good bye!");
                    break;
                default:
                    Console.WriteLine("Is it in Africa? Sorry, I have no idea how to get there");
                    whereTo();
                    break;
            }
        }

        static void huckster()
        {
            Console.WriteLine("You have {0} credits", temporalStat[4]);
            Console.WriteLine("Input '1' to buy first aid kit (20 HP/ 10 credits), '2' to upgrade your gear, '3' to exit");
            int whatToBuy = preciseInput(new int[] {1, 2, 3 });
            if (whatToBuy == 1)
            {
                if (temporalStat[1] == temporalStat[0])
                {
                    Console.WriteLine("You are completely healthy, no need for first aid kits");
                    huckster();
                }
                else if (temporalStat[4] < 10)
                {
                    Console.WriteLine("You don't have enough money!");
                    huckster();
                }
                else
                {
                    temporalStat[4] = temporalStat[4] - 10;
                    temporalStat[1] = temporalStat[1] + 20;
                    if (temporalStat[1] > temporalStat[0])
                    {
                        temporalStat[1] = temporalStat[0];
                    }
                    Console.WriteLine("You now have {0} HP", temporalStat[1]);
                    huckster();
                }
            }
            if (whatToBuy == 2)
            {
                for (whatToBuy = 1; whatToBuy < 11; whatToBuy++)
                {
                    Console.WriteLine("'{0}' to upgrade {1}({2}) to {3} for {4} credits", whatToBuy, toolName[whatToBuy], skillName[whatToBuy], (inv[whatToBuy]+1), ((inv[whatToBuy]+1)*10) );
                }
                whatToBuy = preciseInput(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
                if (temporalStat[4] < ((inv[whatToBuy] + 1) * 10) )
                {
                    Console.WriteLine("You don't have enough money!");
                }
                else
                {
                    temporalStat[4] = temporalStat[4] - ((inv[whatToBuy] + 1) * 10);
                    inv[whatToBuy] = inv[whatToBuy] + 1;
                    Console.WriteLine("Your {0} quality now is {1}", toolName[whatToBuy], inv[whatToBuy]);
                }
                huckster();
            }
            if (whatToBuy == 3)
            {
                Console.WriteLine("See you soon!");
            }

        }

        static void firstChapter()
        {
            whereTo();
        }

        static void Main(string[] args)
        {
            firstChapter();
        }
    }
}
