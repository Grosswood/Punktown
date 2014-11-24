using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
        public static int[] temporalStat = new int[5] { 100, 85, -100, 0, 0 }; // HPmax, HPcurr, XP, LVL, bullets
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
            Console.WriteLine("You are in 'help' section. Input '1' for skills description, '2' for bullets, '3' to exit help");
            int help = preciseInput(new int[] {1, 2, 3});
            if (help == 1)
            {
                Console.WriteLine("Hacking (main) is used against any kinds of turrets, cybernetic life-forms or when comfronting computer controlled systems. It is the main source of damage in such battles");
                Console.WriteLine("Ranged (main) is way to inflict physical damage while maintaining distance. In most cases it lets you avoid damage from melee opponent, but in close range Melee (main) can be more effective. You need bullets to fire, but beware, bullets also used as money here.");
                Console.WriteLine("Lockpick (main) is required to open both mechanical and electronics locks");
                Console.WriteLine("Melee (main) - ability to deal damage at close distance");
                Console.WriteLine("Athletics (secondary) required to get away from someone or conversely approach. Also passively increasing armor");
                Console.WriteLine("Knowledge (secondary) can help character to remember vital spots of his target to unlock critical strikes");
                Console.WriteLine("Notice (secondary) can be used to determine level of defence against random skill");
                Console.WriteLine("Speech (secondary) have several ways to use. You can intimidate target and force it surrender on low HP, or you can distract to make you next move more successful");
                Console.WriteLine("Stealth (secondary) can be used to avoid battles. Also damage when breaking stealth is immensely increased");
                Console.WriteLine("Streetwise (secondary) lets you avoid the battle both at the beginning, before opponent noticing you, or after beginning when you have reached certain distance");
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
            int location = d(9);
            int level = d(3);
            if (temporalStat[3] > 7)
            {
                level = level + 5;
            }
            switch (location)
            {
                case (1):
                    encounterBrute(level);
                    break;
                case (2):
                    encounterMadScientist(level);
                    break;
                case (3):
                    encounterTurret(level);
                    break;
                case (4):
                    encounterChest(level);
                    break;
                case (5):
                    encounterCyborg(level);
                    break;
                case (6):
                    encounterJunky(level);
                    break;
                case (7):
                    encounterSpider(level);
                    break;
                case (8):
                    encounterAdaptoid(level);
                    break;
                case (9):
                    encounterLittleBoy(level);
                    break;
                case (10):

                    break;
                default:
                    Console.WriteLine("Hey, I've been here! Probably made a circle or something.");
                    break;
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
            encounterStatus[0] = 2;
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
            int skillNumber = d(4);
            if (armor[skillNumber] == 100)
            {
                Console.WriteLine("You have noticed that {0} is useless here", skillName[skillNumber]);
            }
            else
            {
                Console.WriteLine("{0} has armor {1} against {2}", enemyName, armor[skillNumber], skillName[skillNumber]);
            }
            skillNumber = d(6) + 4;
            if (armor[skillNumber] == 100)
            {
                Console.WriteLine("You have noticed that {0} is useless here", skillName[skillNumber]);
            }
            else
            {
                Console.WriteLine("{0} has armor {1} against {2}", enemyName, armor[skillNumber], skillName[skillNumber]);
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
            if (mainSkill == 2)
            {
                if (temporalStat[4] == 0)
                {
                    Console.WriteLine("You don't have bullets to fire. Choose another action");
                    mainSkill = preciseInput(new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10 });
                    if ((mainSkill == 1 || mainSkill == 3 || mainSkill == 4) && encounterStatus[0] > 3)
                    {
                        Console.WriteLine("You need to be in close range (3 or less) to use Hacking, Lockpick or Melee. Please choose different skill");
                        mainSkill = preciseInput(new int[] { 5, 6, 7, 8, 9, 10 });
                    }
                }
                else
                {
                    temporalStat[4]--;
                }
            }
            if ((mainSkill == 1 || mainSkill == 3 || mainSkill == 4) && encounterStatus[0] > 3)
            {
                Console.WriteLine("You need to be in close range (3 or less) to use Hacking, Lockpick or Melee. Please choose different skill");
                mainSkill = preciseInput(new int[] { 2, 5, 6, 7, 8, 9, 10 });
                if (mainSkill == 2)
                {
                    if (temporalStat[4] == 0)
                    {
                        Console.WriteLine("You don't have bullets to fire. Choose another action");
                        mainSkill = preciseInput(new int[] { 5, 6, 7, 8, 9, 10 });
                    }
                    else
                    {
                        temporalStat[4]--;
                    }
                }

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
            int result = skill[7] + inv[7] + D(20);
            if (result < armor[7])
            {
                Console.WriteLine("You noticed him too late! You have to fight!");
                encounterStatus[2] = 1;
                return 0;
            }
            encounterStatus[0] = result - armor[7] + 2;
            Console.WriteLine("{0} is {1} meters away, he haven't noticed you yet", enemyName, encounterStatus[0]);
            Console.WriteLine("Do you want to fight (1) or to retreat tactically? (2)");
            int decision = preciseInput(new int[] { 1, 2 });
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

        static void encounterBrute (int level)
        {
            enemyName = "Huge brute";
            Console.WriteLine("{0} (lvl {1}) is approaching with aggressive intentions", enemyName, level);
            armorInput(new int[11] { 50, 100, (6 + level), 100, (8 + level), (6 + level), (6 + level), (6 - level), (8 + level), (6 + level), (6 + level) });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    enemyTurn(3 + level);
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
                conclusion(((3 + level) / 4) * 76);
            }
        }

        static void encounterLittleBoy(int level)
        {
            enemyName = "Boy";
            Console.WriteLine("Little boy with long dark hair and pale skin is motionlessly standing in your way", enemyName, level);
            armorInput(new int[11] { 50, 100, (10 + level), 100, (8 + level), (10 + level), (12 + level), (8 - level), (12 + level), (10 + level), (10 + level) });
            resetEncounterStatus();
            encounterStatus[2] = 1;
            if (runOrFight() == 1)
            {
                Console.WriteLine("You found him just around the corner. Or is it his twin brother?");
            }
            Console.WriteLine("'Give me candy, please?' He asked. (1) - give, (2) - not to.");
            int answer = preciseInput(new int[] { 1, 2 });
            if ((answer == 1) && (inv[0] == 1))
            {
                Console.WriteLine("You gave him candy :) He left some loot for you and happily leaving");
                conclusion(80);
                return;
            }
            else if ((answer == 1) && (inv[0] == 0))
            {
                Console.WriteLine("You don't have candy :(");
            }
            Console.WriteLine("Then I need your life instead!");
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    int HPWas = temporalStat[1];
                    enemyTurn(1 + level);
                    if (HPWas > temporalStat[1])
                    {
                        HPWas = HPWas - temporalStat[1];
                        Console.WriteLine("He drain your life and heal himself for {0} HP and now has {1} HP", HPWas, armor[0]);
                        armor[0] = armor[0] + HPWas;
                    }
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
                conclusion(((3 + level) / 4) * 88);
            }
        }

        static void encounterAdaptoid(int level)
        {
            enemyName = "Adaptoid";
            Console.WriteLine("{0} (lvl {1}) is approaching with aggressive intentions", enemyName, level);
            armorInput(new int[11] { 50, (6 + level), (6 + level), (6 + level), (6 + level), (6 + level), (6 + level), (6 - level), (6 + level), (6 + level), (6 + level) });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    enemyTurn(2 + level);
                }
                declareStatus();
                actionInput();
                mainSkill = missOrHit(mainSkill);
                secondarySkill = missOrHit(secondarySkill);
                secondaryEffects();
                if (mainSkill == 6 || secondarySkill == 6)
                {
                    Console.WriteLine("You do know, that adaptoid have increased defences against skill that you just used for several turns");
                }
                armor[0] = armor[0] - (mainSkillDamage() * damageMultiplier());
                int skillNumber = 0;
                for (skillNumber = 1; skillNumber < 11; skillNumber++)
                {
                    if (armor[skillNumber] > (6 + level))
                    {
                        armor[skillNumber]--;
                    }
                }
                armor[Math.Abs(mainSkill)] = 10 + level;
                armor[Math.Abs(secondarySkill)] = 10 + level;
                statusUpdate();
                Console.WriteLine("{1} has {0} hit points left", armor[0], enemyName);
            } while ((armor[0] - (encounterStatus[4] * 20) > 0) && (encounterStatus[0] < 90));
            if (encounterStatus[0] < 90)
            {
                conclusion(((3 + level) / 4) * 88);
            }
        }

        static void encounterSpider(int level)
        {
            enemyName = "Spider";
            Console.WriteLine("Oversized {0} (lvl {1}) is approaching with aggressive intentions", enemyName, level);
            armorInput(new int[11] { 50, 100, (8 + level), 100, (10 + level), (8 + level), (8 + level), (12 - level), 100, (8 + level), (10 + level) });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    enemyTurn(2 + level);
                }
                declareStatus();
                actionInput();
                if (mainSkill != 7 && secondarySkill != 7 && (d(20) > inv[7]+skill[7]))
                {
                    Console.WriteLine("You haven't noticed spider net and stepped in it! You can't run this turn");
                    armor[5] = 100;
                }
                mainSkill = missOrHit(mainSkill);
                secondarySkill = missOrHit(secondarySkill);
                secondaryEffects();
                armor[0] = armor[0] - (mainSkillDamage() * damageMultiplier());
                statusUpdate();
                armor[5] = 8 + level;
                Console.WriteLine("{1} has {0} hit points left", armor[0], enemyName);
            } while ((armor[0] - (encounterStatus[4] * 20) > 0) && (encounterStatus[0] < 90));
            if (encounterStatus[0] < 90)
            {
                conclusion(((3 + level) / 4) * 84);
            }
        }

        static void encounterJunky(int level)
        {
            enemyName = "Weak junky";
            Console.WriteLine("{0} (lvl {1}) is approaching with aggressive intentions", enemyName, level);
            armorInput(new int[11] { 50, 100, (6 + level), 100, (6 + level), (6 + level), (6 + level), (6 - level), (6 + level), (6 + level), (6 + level) });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    enemyTurn(1 + level);
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
                conclusion(((3 + level) / 4) * 40);
            }
        }

        static void encounterCyborg(int level)
        {
            enemyName = "Cyborg";
            Console.WriteLine("{0} (lvl {1}) is approaching with aggressive intentions", enemyName, level);
            armorInput(new int[11] { 50, (6 + level), (10 + level), 100, (10 + level), (8 + level), (10 + level), (8 - level), 100, (6 + level), (6 + level) });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    enemyTurn(3 + level);
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
                conclusion(((3 + level) / 4) * 80);
            }
        }

        static void encounterMadScientist(int level)
        {
            enemyName = "Mad scientist";
            Console.WriteLine("{0} (lvl {1}) is approaching with aggressive intentions", enemyName, level);
            armorInput(new int[11] { 50, 100, (6 + level), 100, (6 + level), (8 + level), (10 + level), (8 - level), (10 + level), (8 + level), (8 + level) });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    enemyTurn(2 + level);
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
                conclusion(((3 + level) / 4) * 60);
            }
        }

        static void encounterTurret(int level)
        {
            enemyName = "Sentinel turret";
            Console.WriteLine("{0} (lvl {1}) is standing in your way", enemyName, level);
            armorInput(new int[11] { 50, (8 + level), (10 + level), (12 + level), (10 + level), 0, (8 + level), 0, 100, (10+level), 100 });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                if (encounterStatus[0] < 11 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    Console.WriteLine("{0} has ranged attack!", enemyName);
                    enemyTurn(2 + level);
                }
                declareStatus();
                actionInput();
                mainSkill = missOrHit(mainSkill);
                secondarySkill = missOrHit(secondarySkill);
                secondaryEffects();
                armor[0] = armor[0] - (mainSkillDamage() * damageMultiplier());
                int becauseTurretWontMove = encounterStatus[0];
                statusUpdate();
                encounterStatus[0] = becauseTurretWontMove;
                Console.WriteLine("{1} has {0} hit points left", armor[0], enemyName);
            } while ((armor[0] - (encounterStatus[4] * 20) > 0) && (encounterStatus[0] < 90));
            if (encounterStatus[0] < 90)
            {
                conclusion(((3 + level) / 4) * 80);
            }
        }

        static void encounterChest(int level)
        {
            enemyName = "Locked chest";
            Console.WriteLine("You see {0}", enemyName, level);
            armorInput(new int[11] { 60, (6+level), 100, 100, 100, 0, (6+level), (6-level), 100, 100, 0 });
            resetEncounterStatus();
            encounterStatus[2] = 1;
            if (runOrFight() == 1)
            {
                return;
            }
            do
            {
                declareStatus();
                actionInput();
                mainSkill = missOrHit(mainSkill);
                secondarySkill = missOrHit(secondarySkill);
                if (mainSkill == 6 || mainSkill == 7 || secondarySkill == 6 || secondarySkill == 7)
                {
                    Console.WriteLine("In order to open the chest you need first to damage security system (hacking), then to open mechanical lock (lockpicking) and then to force it open (melee or ranged)");
                }
                if (-5 < mainSkill && mainSkill < 0 && encounterStatus[0] < 4)
                {
                    Console.WriteLine("You wasn't careful! Security system strike you with electricity for {0} damage!", (4 * level));
                    Console.WriteLine("You have {0} HP left", temporalStat[0]);
                    temporalStat[0] = temporalStat[0] - (4 * level);
                    if (temporalStat[1] <= 0)
                    {
                        Console.WriteLine("You have died!");
                        Environment.Exit(0);
                    }
                }
                secondaryEffects();
                int variableMainSkillDamage = mainSkillDamage();
                int variableDamageMultiplier = damageMultiplier();
                if ((armor[0] > 40) &&  (armor[0] - (variableMainSkillDamage * variableDamageMultiplier) <= 40))
                {
                    Console.WriteLine("You've severly damaged security system, now you must use lockpicking");
                    armor[1] = 100;
                    armor[3] = 8 + level;
                }
                if ((armor[0] > 20) && (armor[0] - (variableMainSkillDamage * variableDamageMultiplier) <= 20))
                {
                    Console.WriteLine("You've cracked the lock, but it is stuck. You need to use brute force now");
                    armor[3] = 100;
                    armor[2] = 6 + level;
                    armor[4] = 6 + level;
                }
                armor[0] = armor[0] - (variableMainSkillDamage * variableDamageMultiplier);
                int becauseChestWontMove = encounterStatus[0];
                statusUpdate();
                encounterStatus[0] = becauseChestWontMove;
                Console.WriteLine("{1} has {0} hit points left", armor[0], enemyName);
            } while ((armor[0] - (encounterStatus[4] * 20) > 0) && (encounterStatus[0] < 90));
            if (encounterStatus[0] < 90)
            {
                conclusion(((3 + level) / 4) * 72);
            }
        }

        static void encounterBossStageOne()
        {
            Console.WriteLine("OH MY GOD! It's a final boss!");
            enemyName = "Main bad guy";
            Console.WriteLine("{0} is approaching with aggressive intentions", enemyName);
            armorInput(new int[11] { 50, 100, 12, 100, 10, 10, 8, 8, 12, 6, 100 });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                Console.WriteLine("Sorry, but no running away this time");
            }
            do
            {
                if (encounterStatus[0] < 4 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    enemyTurn(5);
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
            Console.WriteLine("'You think this is the end?! I SHALL RETURN!!!'");
            if (encounterStatus[0] < 90)
            {
                conclusion(Math.Abs(temporalStat[2]));
            }
        }

        static void encounterBossStageTwo()
        {
            enemyName = "Main bad guy";
            Console.WriteLine("{0} is approaching with aggressive intentions. Now he have power armor and laser gun!", enemyName);
            armorInput(new int[11] { 100, 8, 14, 100, 12, 6, 12, 10, 16, 6, 100 });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                Console.WriteLine("Sorry, but no running away this time");
            }
            do
            {
                if (encounterStatus[0] < 15 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    Console.WriteLine("{0} has ranged attack!", enemyName);
                    enemyTurn(4);
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
            Console.WriteLine("'That shit is useless' - he yells - 'I just need a bigger gun!'");
            if (encounterStatus[0] < 90)
            {
                conclusion(Math.Abs(temporalStat[2]));
            }
        }

        static void encounterBossFinal()
        {
            enemyName = "Main bad guy";
            Console.WriteLine("{0} is approaching with aggressive intentions Now he have TANK!", enemyName);
            armorInput(new int[11] { 200, 6, 16, 8, 14, 10, 10, 10, 100, 8, 100 });
            resetEncounterStatus();
            if (runOrFight() == 1)
            {
                Console.WriteLine("Sorry, but no running away this time");
            }
            do
            {
                if (encounterStatus[0] < 15 && encounterStatus[2] == 1 && encounterStatus[1] == 0)
                {
                    Console.WriteLine("{0} has ranged attack!", enemyName);
                    enemyTurn(6);
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
            Console.WriteLine("'NOOOOO!!!! By the rules of the genre I only have three incarnation! I hate this part! Screw you all!'");
            if (encounterStatus[0] < 90)
            {
                conclusion(Math.Abs(temporalStat[2]));
            }
        }

        static void isItTimeForBoss()
        {
            if (temporalStat[3] == 5)
            {
                encounterBossStageOne();
                levelUp();
                autoSave();
            }
            if (temporalStat[3] == 6)
            {
                encounterBossStageTwo();
                levelUp();
                autoSave();
            }
            if (temporalStat[3] == 7)
            {
                encounterBossFinal();
                levelUp();
                autoSave();
                endOfAlpha();
            }
        }

        static void enemyTurn(int power)
        {
            int fullArmor = 10 + skill[5] + inv[4];
            Console.WriteLine("{0} is fightning you!", enemyName);
            //one variable instead of two
            int iterationNumber = d(20);
            if (iterationNumber + (power * 2) > fullArmor)
            {
                Console.WriteLine("He hits!");
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
            int money = d(20);
            if (money == 20 && inv[0] == 0)      
            {
                inv[0] = 1;
                Console.WriteLine("You found candy! :)");
            }
            if (armor[0] == 50)
            {
                // that case is for little boy encounter if you have candy
            }
            else if (armor[0] > 0)
            {
                Console.WriteLine("{0} surrendered!", enemyName);
            }
            else
            {
                Console.WriteLine("{0} is defeated!", enemyName);
            }
            int skillNumber = 0;
            money = 0;
            for (skillNumber = 0; skillNumber < reward; skillNumber++)
            {
                money = money + d(3) - 1;
            }
            temporalStat[4] = temporalStat[4] + money;
            temporalStat[2] = temporalStat[2] + reward;
            Console.WriteLine("You have found {0} bullets", money);
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
                temporalStat[0] = temporalStat[0] + 10;
                temporalStat[1] = temporalStat[1] + 10;
                temporalStat[2] = temporalStat[2] - ((temporalStat[3] + 2) * (50));
                Console.WriteLine("You have reached {0} level! You gain 10 additional HP", temporalStat[3]);
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
            autoSave();
            Console.WriteLine("What will you do now? (type 'help' for available options)");
            switch (Console.ReadLine())
            {
                case ("help"):
                    Console.WriteLine("Type '1' to find random battle");
                    Console.WriteLine("Type '2' to visit huckster");
                    Console.WriteLine("Type '3' to exit");
                    break;
                case ("1"):
                    Console.WriteLine("Ha! Adventure!");
                    isItTimeForBoss();
                    wonder();
                    break;
                case ("2"):
                    Console.WriteLine("Black market has everything you need!");
                    huckster();
                    break;
                case ("3"):
                    Console.WriteLine("Good bye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Is it in Africa? Sorry, I have no idea how to get there");
                    break;
            }
            whereTo();
        }

        static void autoSave()
        {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PunktownAutoSave.txt");
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (int number in skill)
                {
                    writer.WriteLine(number);
                }
                foreach (int number in inv)
                {
                    writer.WriteLine(number);
                }
                foreach (int number in temporalStat)
                {
                    writer.WriteLine(number);
                }
            }
            Console.WriteLine("Your progress saved!");
        }

        static void huckster()
        {
            Console.WriteLine("You have {0} bullets", temporalStat[4]);
            Console.WriteLine("Input '1' to buy first aid kit (20 HP/ 10 bullets), '2' to upgrade your gear, '3' to exit");
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
                    Console.WriteLine("You don't have enough bullets!");
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
                    Console.WriteLine("'{0}' to upgrade {1}({2}) to {3} for {4} bullets", whatToBuy, toolName[whatToBuy], skillName[whatToBuy], (inv[whatToBuy] + 1), ((inv[whatToBuy] + 1) * 10));
                }
                whatToBuy = preciseInput(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
                if (temporalStat[4] < ((inv[whatToBuy] + 1) * 10) )
                {
                    Console.WriteLine("You don't have enough bullets!");
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

        static void charCreation()
        {
            Console.WriteLine("Hello! This is alpha-version of Punktown, text-based RPG");
            Console.WriteLine("Do you want to load last auto-save (1) or create new charecter (2)?");
            int answer = preciseInput(new int[] { 1, 2 });
            if (answer == 1)
            {
                //here we need file not found exception
                var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PunktownAutoSave.txt");
                string[] save = File.ReadAllLines(fileName);
                foreach (string line in save)
                {
                    int number = Int32.Parse(line);
                    if (answer < 12)
                    {
                        //Console.WriteLine(answer - 1);
                        //Console.WriteLine(number);
                        skill[answer - 1] = number;
                    }
                    else if (answer < 23)
                    {
                        inv[answer - 12] = number;
                    }
                    else
                    {
                        temporalStat[answer - 23] = number;
                    }
                    
                    answer++;
                }
            }
            else
            {
                Console.WriteLine("This is character creation section, you will need to pick few skills, that will be more reliable than others");
                Console.WriteLine("Skill can be main or secondary. Main skills do the most damage to opponent, while secondary skills plays supporting roles");
                Console.WriteLine("In one turn of the battle you could use main and secondary skill or two secondary skills");
                Console.WriteLine("You may pick skills now, type 'help' to summon help section where you can find detailed skills description");
                Console.WriteLine("Right now all you skill is '1' you will have 4 points to increase main skills and 6 for secondary");
                Console.WriteLine("Please choose main skills to improve");
                int improve = 0;
                for (improve = 0; improve < 4; improve++)
                {
                    int skillToImprove = preciseInput(new int[] { 1, 2, 3, 4 });
                    skill[skillToImprove]++;
                    Console.WriteLine("Your {0} now is {1}, you have {2} points left to spent", skillName[skillToImprove], skill[skillToImprove], (3 - improve));
                }
                Console.WriteLine("Please choose secondary skills to improve");
                for (improve = 0; improve < 6; improve++)
                {
                    int skillToImprove = preciseInput(new int[] { 5, 6, 7, 8, 9, 10 });
                    skill[skillToImprove]++;
                    Console.WriteLine("Your {0} now is {1}, you have {2} points left to spent", skillName[skillToImprove], skill[skillToImprove], (5 - improve));
                }
                Console.WriteLine("Your character is now created!");
            }
            Console.WriteLine("This game supports auto-save feature");
        }

        static void endOfAlpha()
        {
            Console.WriteLine("You have succesfully defeated Main Bad Guy. That is the end of alpha-version");
            Console.WriteLine("I hope you liked the game. Your feedback would be highly appriciated");
            Console.WriteLine("Please contact me via email 'mozge4ok@gmail.com'");
            Console.WriteLine("Stay tuned for coming beta-version! :)");
            Console.WriteLine("If you want one-more-fight just run game again, all your progress is saved :)");
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            charCreation();
            firstChapter();
        }
    }
}
