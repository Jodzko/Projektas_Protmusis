using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace Metodai
{
    public static class Methods
    {
        public static Dictionary<string, int> Greeting(Dictionary<string, int> users, out string currentUser)
        {

            Console.WriteLine("Sveiki prisijungę į protmūšį!");
            bool success = true;
            bool success1 = true;
            currentUser = "";
            string firstName = "";
            string lastName = "";
            Console.WriteLine("Kad prisijungti veskite savo vardą ir pavardę: ");
            while (success)
            {
                
                Console.WriteLine("Vardas: ");
                string input = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Bandykite dar kartą");
                    continue;
                }
                else
                {
                    firstName = input;
                    success = false;
                }
            }
            
            while(success1)
            {
                Console.WriteLine("Pavardė: ");
                string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Bandykite dar kartą");
                continue;
            }
            else
            {
                lastName = input;
                success1 = false;
            }
                currentUser = firstName + " " + lastName;
            }
            if (users.ContainsKey(currentUser))
            {
                Console.WriteLine("Prisijungėte su esamu vartotoju.");
                Console.WriteLine("Sveiki sugrįžę!");
                Console.ReadLine();
                var updatedUsers = new Dictionary<string, int>();
                foreach (var item in users)
                {
                    updatedUsers.Add(item.Key, item.Value);
                    users = updatedUsers;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sveiki prisijungę į protmūšį " + currentUser + "!");
                Console.ReadLine();
                users.Add(currentUser, 0);
            }
            Console.Clear();
            Meniu(users, currentUser);
            return users;
        }
        public static void Meniu(Dictionary<string, int> users, string currentUser)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t Dabartinis vartotojas  " + currentUser);
            Console.WriteLine("\t\t\t\t\t Meniu: ");
            Console.WriteLine("1. Atsijungimas ");
            Console.WriteLine();
            Console.WriteLine("2. Žaidimo taisyklių atvaizdavimas");
            Console.WriteLine();
            Console.WriteLine("3. Žaidimo rezultatų ir dalyvių peržiūra");
            Console.WriteLine();
            Console.WriteLine("4. Dalyvavimas (Start Game)");
            Console.WriteLine();
            Console.WriteLine("5. Išėjimas iš žaidimo");
            Console.WriteLine();
            bool something = true;
            int finalChoice = 0;
            while (something)
            {
                Console.WriteLine("Įveskite savo pasirinkimą:        (1 - 5) ");
                string input = Console.ReadLine().Trim();
                int choice;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Bandykite dar kartą");
                    continue;
                }
                if (int.TryParse(input, out choice))
                {
                    if (choice > 0 && choice < 6)
                    {
                        something = false;
                        finalChoice = choice;
                    }
                    else
                    {
                        Console.WriteLine("Bandykite dar kartą");
                    }
                }
                else
                {
                    Console.WriteLine("Bandykite dar kartą");
                }
            }
            switch (finalChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Sekmingai atsijungta.");
                    Greeting(users, out currentUser);
                    break;
                case 2:
                    RulesDisplay(users, currentUser);
                    break;
                case 3:
                    Console.Clear();
                    UsersDisplay(users, currentUser);
                    break;
                case 4:
                    StartGame(users, currentUser);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Iki kito karto!");                    
                    break;
                default:
                    Console.WriteLine("Neteisinga įvestis.");
                    Meniu(users, currentUser);
                    break;

            }


        }
        public static void UsersDisplay(Dictionary<string, int> users, string currentUser)
        {
            Console.WriteLine("\t\t\t\t\t Dabartinis vartotojas  " + currentUser);
            Console.WriteLine("Pasirinkite ką norite pamatyti: ");
            Console.WriteLine("1. Visus esamus dalyvius");
            Console.WriteLine("2. Dalyvių rezultatus");
            bool success = true;
            int finalChoice = 0;
            while (success)
            {
                Console.WriteLine("Įveskite savo pasirinkimą:         ");
                string input = Console.ReadLine().Trim();
                int choice;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Bandykite dar kartą");
                    continue;
                }
                if (int.TryParse(input, out choice))
                {
                    if (choice > 0 && choice < 3)
                    {
                        success = false;
                        finalChoice = choice;
                    }
                    else
                    {
                        Console.WriteLine("Bandykite dar kartą");
                    }
                }
                else
                {
                    Console.WriteLine("Bandykite dar kartą");
                }
            }
            switch (finalChoice)
            {
                case 1:
                    Console.WriteLine("\t\t\t\t\t Visi dalyviai: ");
                    foreach (var item in users)
                    {
                        Console.WriteLine(item.Key);
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t Visų žaidėjų lentelė: ");
                    Console.WriteLine();
                    var ordered = users.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    for (int i = 1; i <= 10; i++)
                    {
                        foreach (var item in ordered)
                        {           
                            Console.Write(i + " Vieta: " + item);
                            i++;
                            if (i - 1 <= 3)
                            {
                                Console.Write(new string ('*', i - 1 ));
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                            if(i == ordered.Count + 1)
                            {
                                i = 11;
                                break;
                            }
                        }
                        
                    }
                    
                    break;
                default:
                    Console.WriteLine("Neteisinga įvestis.");
                    UsersDisplay(users, currentUser);
                    break;
            }
            while (!success)
            {
                Console.WriteLine("Įveskite q, kad grįžti į meniu.");
                string input = Console.ReadLine().Trim();
                if (input == "q")
                {
                    success = true;
                    Meniu(users, currentUser);
                }
            }

        }

        public static void RulesDisplay(Dictionary<string, int> users, string currentUser)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t Dabartinis vartotojas  " + currentUser);
            Console.WriteLine("Sveikiname prisijungus prie protmūšio!");
            Console.WriteLine();
            Console.WriteLine("Šis protmūšis turi X kategorijų. Kiekvienoje kategorijoje jums bus užduoti 5 klausimai.");
            Console.WriteLine();
            Console.WriteLine("Pasirinkus kategoriją pradėsite žaidimą ir turėsite pasirinkti teisingą atsakymą iš 4 galimų variantų");
            Console.WriteLine();
            Console.WriteLine("Kiekvienas teisingas atsakymas jums pridės vieną tašką prie bendros taškų sumos.");
            Console.WriteLine();
            Console.WriteLine("Spauskite q raidę, norėdami grįžti į Meniu...");
            Console.WriteLine();
            string input1 = Console.ReadLine().Trim();
            if (input1 == "q")
            {
                Meniu(users, currentUser);
            }
            if (input1 != "q")
            {
                RulesDisplay(users, currentUser);
            }
        }
        public static Dictionary<string, int> StartGame(Dictionary<string, int> users, string currentUser)
        {
            Console.WriteLine("\t\t\t\t\t Dabartinis vartotojas  " + currentUser);
            var questions = new List<string>
            {
                "Kokia šalis vadinama \"Rytų saulės šalimi\" ",//1
                "Kokia yra ilgiausias upė pasaulyje?",//2
                "Kokia dykuma yra didžiausia pasaulyje pagal plotą?",//3
                "Everesto kalnas randasi tarp kurių dviejų šalių sienų?",//4
                "Kokia šalis yra mažiausia pasaulyje pagal plotą?",//5
                "Didysis barjerinis rifas yra prie kurios šalies krantų?",//6
                "Australijos sostinė yra...",//7 ats Canberra
                "Kokia upė teka per Kairo miestą?",// 8 ats Nilo upė
                "Serbijos sostinė yra...",//9 ats Belgradas
                "Istanbulo miestas yra išsidėstęs dviejuose kontinentuose, kokie tai kontinentai?"//10 Europa ir Azija
            };
            var choices = new List<string>
            {
                "1.Kinija \n2.Pietų Korėja \n3.Japonija \n4.Tailandas \n",
                "1.Misisipės upė \n2.Nilo upė \n3.Amazonės upė \n4.Jangdzė upė \n",
                "1.Kalahario dykuma \n2.Saharos dykuma \n3.Gobio dykuma \n4.Atakamos dykuma \n",
                "1.Nepalas ir Kinija \n2.Indija ir Nepalas \n3.Kinija ir Indija \n4.Butanas ir Kinija \n",
                "1.Monakas \n2.Nauru \n3.Vatikano miestas \n4.San Marinas \n",
                "1.Indonezija \n2.Fidžis\n3.Australija \n4.Naujoji Zelandija \n",
                "1.Sidnėjus \n2.Melburnas\n3.Brisbanas \n4.Kanbera \n",
                "1.Amazonė \n2.Jangdzė \n3.Nilas \n4.Ganga \n",
                "1.Atėnai \n2.Belgradas \n3.Kraljevo \n4.Zrenjanin \n",
                "1.Europa ir Afrika \n2.Europa ir Azija \n3.Šiaurės ir Pietų Amerikos \n4.Azijos ir Pietų amerikos \n"
            };
            var answerNumber = new Dictionary<int, int>
            {
                {0, 3},
                {1, 2},
                {2, 2},
                {3, 1},
                {4, 3},
                {5, 3},
                {6, 4},
                {7, 3},
                {8, 2},
                {9, 2}
            };
            var answers = new Dictionary<int, string>
            {
                {0, "3. Japonija, " },
                {1, "2. Nilo upė, " },
                {2, "2. Saharos dykuma" },
                {3, "1. Nepalas ir Kinija" },
                {4, "3. Vatikano miestas" },
                {5, "3. Australija" },
                {6, "4. Kanbera" },
                {7, "3. Nilas"},
                {8, "2. Belgradas"},
                {9, "2. Europa ir Azija" }
            };
            var askedQuestions = new List<int>();
            var correctAnswers = new Dictionary<string, string>();
            var incorrectAnswers = new Dictionary<string, string>();
            int correct = 0;

            for (int i = 0; askedQuestions.Count < 5; i++)
            {
                bool parsing = true;
                var finalChoice = 0;
                while (parsing)
                {
                    var random = new Random();
                    int question = random.Next(0, 10);
                    Console.Clear();
                    Console.Write("Turimas taškų skaičius: ");
                    foreach (var item in users)
                    {
                        if(item.Key == currentUser)
                        {
                            Console.WriteLine(item.Value + correct);
                        }
                    }
                    Console.WriteLine(askedQuestions.Count + "  /  5");

                    if (askedQuestions.Contains(question))
                    {
                        
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(questions[question]);
                        Console.Write(choices[question]);
                        string input2 = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(input2))
                        {
                            Console.WriteLine("Bandykit dar kartą");
                            Console.ReadLine();
                            continue;
                        }
                        if (int.TryParse(input2, out int choice))
                        {
                            if (choice > 0 && choice < 5)
                            {
                                finalChoice = choice;
                                askedQuestions.Add(question);
                                parsing = false;
                            }
                            else
                            {
                                Console.WriteLine("Bandykit dar kartą");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bandykit dar kartą");
                            Console.ReadLine();
                        }
                        if (!parsing)
                        {
                            Console.WriteLine("Teisingas atsakymas buvo: " + answers[question]);
                            Console.WriteLine("Spauskite be kurį klaviša, kad gauti kitą klausimą...");
                            Console.ReadLine();
                            if (finalChoice == answerNumber[question])
                            {
                                correct++;
                                correctAnswers.Add(questions[question], answers[question]);
                            }
                            else
                            {
                                incorrectAnswers.Add(questions[question], answers[question]);
                            }
                        }

                    }


                }

            }

            if (users.ContainsKey(currentUser))
            {
                var updatedUsers = new Dictionary<string, int>();
                foreach (var item in users)
                {
                    if (item.Key == currentUser)
                    {
                        int x = item.Value;
                        updatedUsers.Add(item.Key, x + correct);
                        continue;
                    }
                    updatedUsers.Add(item.Key, item.Value);

                }
                users = updatedUsers;


            }
            bool changed = false;
            while (!changed)
            {
                Console.Clear();
                Console.WriteLine("Šios sesijos metu surinkote: " + correct);
                foreach (var item in users)
                {
                    if (item.Key == currentUser)
                    {
                        Console.WriteLine("Bendra turimų taškų suma yra: " + item.Value);
                        Console.WriteLine();

                    }
                }
                var ordered = users.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                Console.WriteLine("Dabartinė lentelė pagal surinktus taškus: ");
                foreach (var item in ordered)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
                Console.WriteLine("Teisingai atsakėte i šiuos klausimus: ");
                foreach (var item in correctAnswers)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
                if (incorrectAnswers.Count == 0)
                {
                    while (!changed)
                    {
                        Console.WriteLine("Įveskite q, kad grįžti į meniu.");
                        string exit5 = Console.ReadLine().Trim();

                        if (exit5 == "q")
                        {

                            Meniu(users, currentUser);
                            changed = true;
                        }

                    }
                }
                else 
                { 
                Console.WriteLine("Neteisingai atsakėte į šiuos klausimus: ");
                foreach (var item in incorrectAnswers)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                        changed = true;
                        bool menu = true;
                        while (menu)
                        {
                            Console.WriteLine("Įveskite q, kad grįžti į meniu.");
                            string exit = Console.ReadLine().Trim();

                            if (exit == "q")
                            {

                                Meniu(users, currentUser);
                                menu = false;
                            }

                        }
                        return users;
                    }
                    
                    
                }
                
            }
            return users;
            
        }       
        }
    
    }

            
        
   


