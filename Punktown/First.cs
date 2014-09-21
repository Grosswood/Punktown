using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punktown
{
    class First
    {
        static int d(int dice)
        {
//Private random            
            Random random = new Random();
            return (random.Next(1, dice));
        }

        static int D(int dice)
        {
//Public random
            Random random = new Random();
            int diceValue = random.Next(1, dice);
            Console.WriteLine("d" + dice + " rolls for " + diceValue);
            return (diceValue);
        }

        static void declareSkill(int skillNumber, string[] skillName, float[] skillValue)
        {
            Console.WriteLine("Your {0} is {1}", skillName[skillNumber], skillValue[skillNumber]);
        }

        static void struckLimb()
        {
            string[] limbs = new string[] { "left leg", "right leg", "left arm", "right arm", "torso", "head" };
            Console.WriteLine("You hit {0}", limbs[d(6)]);
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
            struckLimb();
            Console.WriteLine("You are awake...");
        }

        static void firstChapter(float[] skill, float[] inv, string[] skillName)
        {
            awake();

        }

        static void Main(string[] args)
        {
            float[] skill = new float[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            float[] inv = new float[10] { 1, 0, 1, 0, 0.5f, 1, 0, 1, 1, 1 };
            string[] skillName = new string[10] { "Acrobatics", "Hacking", "Knowledge", "Lockpick", "Melee", "Notice", "Ranged", "Speech", "Stealth", "Streetwise" };
            /*for (int skillNumber = 0; skillNumber < 10; skillNumber++)
            {
                declareSkill(skillNumber, skillName, skill);
            }*/
            firstChapter(skill, inv, skillName);
            
        }
    }
}
