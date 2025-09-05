using CSharpBasics.Tund1;
using System;

namespace CSharpBasics
{
    internal class Assign
    {
        public static void Start()
        {
            while (true)
            {
                int choice = 0;
                try
                {
                    Console.Write("Sisestage valik number => ");
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Viga! {ex.Message}");
                }

                switch (choice)
                {
                    case 1:
                        Assign1();
                        break;
                    case 2:
                        Assign2();
                        break;
                    case 3:
                        Assign3();
                        break;
                    case 4:
                        Assign4();
                        break;
                    case 5:
                        Assign5();
                        break;
                    case 6:
                        Assign6();
                        break;
                    case 7:
                        Assign7();
                        break;
                    case 8:
                        Assign8();
                        break;
                }
            }
        }

        public static void Assign1()
        {
            Console.Write("Sisesta eesnimi => ");
            string name = Console.ReadLine();

            if (name.ToLower() == "juku")
            {
                Console.WriteLine("Lähme Jukuga kinno!");

                try
                {
                    Console.Write("Kui vana on Juku? => ");
                    int age = int.Parse(Console.ReadLine());

                    if (age < 0 || age > 100)
                        Console.WriteLine("Viga andmetega!");
                    else if (age < 6)
                        Console.WriteLine("Juku saab tasuta pileti.");
                    else if (age <= 14)
                        Console.WriteLine("Jukule on lastepilet.");
                    else if (age <= 65)
                        Console.WriteLine("Jukule on täispilet.");
                    else
                        Console.WriteLine("Jukule on sooduspilet.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Viga! {ex.Message}");
                }
            }

            Console.WriteLine();
        }

        public static void Assign2()
        {
            Console.Write("Sisesta esimese inimese nimi => ");
            string name1 = Console.ReadLine().ToLower();
            Console.Write("Sisesta teise inimese nimi => ");
            string name2 = Console.ReadLine().ToLower();

            if ((name1 == "hussein" && name2 == "maksim")
                || (name1 == "maksim" && name2 == "hussein"))
            {
                Console.WriteLine($"{name1} ja {name2} on täna pinginaabrid.");
            }
            else if ((name1 == "maksim" && name2 == "nikita")
                || (name1 == "nikita" && name2 == "maksim"))
            {
                Console.WriteLine($"{name1} ja {name2} on täna pinginaabrid.");
            }
            else
                Console.WriteLine($"{name1} ja {name2} ei ole täna pinginaabrid.");

            Console.WriteLine();
        }

        public static void Assign3()
        {
            try
            {
                Console.Write("Sisesta toa pikkus meetrites => ");
                float length = float.Parse(Console.ReadLine());

                Console.Write("Sisesta toa laius meetrites => ");
                float width = float.Parse(Console.ReadLine());

                float area = length * width;
                Console.WriteLine($"Toa põranda pindala on {area} m2.");

                Console.Write("Kas soovid teha remonti? (jah/ei) => ");
                string input = Console.ReadLine();
                if (input.ToLower() == "jah")
                {
                    Console.Write("Kui palju maksab ruutmeeter? => ");
                    float price = float.Parse(Console.ReadLine());
                    float summa = price * area;
                    Console.WriteLine($"Põranda vahetamise hind on {summa} eurot.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga! {ex.Message}");
            }

            Console.WriteLine();
        }

        public static void Assign4()
        {
            try
            {
                Console.Write("Sisesta hind peale 30% allahindlust => ");
                float price = float.Parse(Console.ReadLine());
                float origPrice = price / 0.7f;
                Console.WriteLine($"Alghind oli ligikaudu {origPrice} eurot.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga! {ex.Message}");
            }

            Console.WriteLine();
        }

        public static void Assign5()
        {
            Console.Write("Sisesta temperatuur => ");
            float temp = float.Parse(Console.ReadLine());
            if (temp > 18)
                Console.WriteLine("Temperatuur on üle 18 kraadi.");
            else
                Console.WriteLine("Temperatuur on alla või võrdne 18 kraadi.");

            Console.WriteLine();
        }

        public static void Assign6()
        {
            try
            {
                Console.Write("Sisesta oma pikkus sentimeetrites => ");
                int length = int.Parse(Console.ReadLine());
                if (length < 160)
                    Console.WriteLine("Oled lühike.");
                else if (length <= 185)
                    Console.WriteLine("Oled keskmist kasvu.");
                else
                    Console.WriteLine("Oled pikk.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga! {ex.Message}");
            }

            Console.WriteLine();
        }

        public static void Assign7()
        {
            try
            {
                Console.Write("Sisesta sugu (mees/naine) => ");
                string gender = Console.ReadLine().ToLower();

                Console.Write("Sisesta pikkus cm => ");
                int length = int.Parse(Console.ReadLine());

                if (gender == "mees")
                {
                    if (length < 165)
                        Console.WriteLine("Mees on lühike.");
                    else if (length <= 185)
                        Console.WriteLine("Mees on keskmine.");
                    else
                        Console.WriteLine("Mees on pikk.");
                }
                else if (gender == "naine")
                {
                    if (length < 155)
                        Console.WriteLine("Naine on lühike.");
                    else if (length <= 175)
                        Console.WriteLine("Naine on keskmine.");
                    else
                        Console.WriteLine("Naine on pikk.");
                }
                else
                    Console.WriteLine("Sugu ei tuvastatud.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga! {ex.Message}");
            }

            Console.WriteLine();
        }

        public static void Assign8()
        {
            float summa2 = 0;

            Console.Write("Kas soovid osta piima? (jah/ei) => ");
            if (Console.ReadLine().ToLower() == "jah")
                summa2 += 1.2f;

            Console.Write("Kas soovid osta saia? (jah/ei) => ");
            if (Console.ReadLine().ToLower() == "jah")
                summa2 += 0.8f;

            Console.Write("Kas soovid osta leiba? (jah/ei) => ");
            if (Console.ReadLine().ToLower() == "jah")
                summa2 += 1.5f;

            Console.WriteLine($"Kokku maksab ostetud kraam {summa2} eurot.");
        }
    }
}
