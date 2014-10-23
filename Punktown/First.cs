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
        public static int[] temporalStat = new int[5] { 50, 35, -100, 0, 0 }; // HPmax, HPcurr, XP, LVL, Bullets
        public static string[] skillName = new string[11] { "Hit points", "Hacking (main)", "Ranged (main)", "Lockpick (main)", "Melee (main)", "Athletics (secondary)", "Knowledge (secondary)", "Notice (secondary)", "Speech (secondary)", "Stealth (secondary)", "Streetwise (secondary)" };
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
                Console.WriteLine("Input {2} for {0}. His value is {1}, tool quality is {3}", skillName[skillNumber], skill[skillNumber], skillNumber, inv[skillNumber]);
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
                    if (result > 8 && skillNumber < 5 && encounterStatus[3] == 1)
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
            if (encounterStatus[2] == 0 && (Math.Abs(mainSkill) == 2 || Math.Abs(mainSkill) == 4 || Math.Abs(secondarySkill) == 5 || Math.Abs(secondarySkill) == 8))
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
                Console.WriteLine("You have noticed that {1} have average protection against {0}", skillName[skillNumber], enemyName);
            }
            else
            {
                Console.WriteLine("You have noticed that {1} have strong protection versus {0}", skillName[skillNumber], enemyName);
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
            int option = preciseInput(Console.ReadLine(), new int[] { 1, 2});
            if (option == 1)
            {
                Console.WriteLine("{0} is now afraid of you and will surrender on low hp", enemyName);
                encounterStatus[4] = 1;
            }
            else
            {
                Console.WriteLine("{0} is distracted and his defences temporaly lowered for d6", enemyName);
                encounterStatus[5] = -1;
            }
        }

        static void actionInput()
        {
            Console.WriteLine("Choose main skill in action (It could main or secondary skill, '23' to remind options)");
            mainSkill = preciseInput(Console.ReadLine(), new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 23 });
            if (mainSkill == 23)
            {
                declareSkill();
                Console.WriteLine("Enter main action");
                mainSkill = preciseInput(Console.ReadLine(), new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            }
            Console.WriteLine("Choose secondary action (It is always secondary skill)");
            secondarySkill = preciseInput(Console.ReadLine(), new int[] { 5, 6, 7, 8, 9, 10 });
        }
        
        static int damageMultiplier()
        {
            int damageMultiplier = 1;
            if (mainSkill == 2 && encounterStatus[1] == 1)
            {
                Console.WriteLine("Fire from the cover! x2 damage!");
                damageMultiplier = 2;
            }
            if (mainSkill == 4 && secondarySkill == 5 && encounterStatus[1] == 1)
            {
                Console.WriteLine("Sinister charge! x4 damage!!!");
                damageMultiplier = 4;
            }
            else if (mainSkill == 4 && encounterStatus[1] == 1)
            {
                Console.WriteLine("Backstab! x3 damage!");
                damageMultiplier = 3;
            }
            else if (mainSkill == 4 && secondarySkill == 5)
            {
                Console.WriteLine("Charge! x2 damage!");
                damageMultiplier = 2;
            }
            return damageMultiplier;
        }
        
        static void secondaryEffects()
        {
            if (mainSkill == 5)
            {
                encounterStatus[0] = encounterStatus[0] + 2;
            }
            if (secondarySkill == 5)
            {
                encounterStatus[0] = encounterStatus[0] + 2;
            }
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
        }

        static void encounterBrute ()
        {
            enemyName = "Huge brute";
            Console.WriteLine("{0} with aggressive intentions is approaching", enemyName);
            armorInput(new int[11] { 50, 100, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            resetEncounterStatus();
            do
            {
                enemyTurn(5);
                declareStatus();
                actionInput();
                mainSkill = missOrHit(mainSkill);
                secondarySkill = missOrHit(secondarySkill);
                secondaryEffects();
                armor[0] = armor[0] - (mainSkillDamage() * damageMultiplier());
                statusUpdate();
                Console.WriteLine("Hit points left: {0}", armor[0]);
            } while (armor[0] - (encounterStatus[4] * 20) > 0);
            conclusion(105);
        }

        static void enemyTurn(int power)
        {
            int fullArmor = 10 + skill[5] + inv[4];
            Console.WriteLine("{0} if fightning you!", enemyName);
            int damage = D(20);
            if (damage + power > fullArmor)
            {
                damage = d(6) + d(6);
                temporalStat[1] = temporalStat[1] - damage;
                Console.WriteLine("BLow hits your for {0}, you have {1} HP left", damage, temporalStat[1]);
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
                Console.WriteLine("Brute surrendered!");
            }
            else
            {
                Console.WriteLine("Brute is defeated!");
            }
            temporalStat[2] = temporalStat[2] + reward;
            Console.WriteLine("You awarded with {0} XP!", reward);
            if (d(100) < reward)
            {
                int skillNumber = d(10);
                Console.WriteLine("You have found new tool for {0}!", skillName[skillNumber]);
                inv[skillNumber]++;
            }
        }

        static void levelUp ()
        {
            if (temporalStat[2] >= 0)
            {
                temporalStat[3]++;
                temporalStat[2] = temporalStat[2] - ((temporalStat[3] + 2) * (50));
                Console.WriteLine("You have reached {0} level! Choose skill to improve (23 to remind options)", temporalStat[3]);
                int skillToImprove = preciseInput(Console.ReadLine(), new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 23 });
                if (skillToImprove == 23)
                {
                    declareSkill();
                    Console.WriteLine("Choose skill to improve");
                    skillToImprove = preciseInput(Console.ReadLine(), new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
                }
                skill[skillToImprove]++;
            }
        }

        static void whereTo ()
        {
            levelUp();
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
                    Console.WriteLine("'Huckster' is correct way to exit from game for now");
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

        static void Main(string[] args)
        {
            firstChapter();
        }
    }
}
