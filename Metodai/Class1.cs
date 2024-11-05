using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace Metodai
{
    public static class Methods
    {
        public static Dictionary<string, int> Greeting(Dictionary <string, int> users,out string currentUser)
        {
            
            Console.WriteLine("Sveiki prisijungę į protmūšį!");
            Console.WriteLine("Kad prisijungti veskite savo vardą ir pavardę: ");
            currentUser = Console.ReadLine().Trim();
            users.Add(currentUser, 0);            
            Meniu(users, currentUser);
            return users;            
        }
        public static void Meniu(Dictionary<string, int> users, string currentUser)
        {
            
            Console.WriteLine("\t\t\t\t\t Dabartinis vartotojas  " + currentUser);
            Console.WriteLine("\t\t\t\t\t Meniu: ");
            Console.WriteLine("1. Atsijungimas ");
            Console.WriteLine("2. Žaidimo taisyklių atvaizdavimas");
            Console.WriteLine("3. Žaidimo rezultatų ir dalyvių peržiūra");
            Console.WriteLine("4. Dalyvavimas (Start Game)");
            Console.WriteLine("5. Išėjimas iš žaidimo");
            bool success = true;
            int finalChoice = 0;
            while (success)
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
                    Console.Clear();
                    Console.WriteLine("Sekmingai atsijungta.");
                    Greeting(users, out currentUser);
                    break;
                case 2:
                    RulesDisplay(users, currentUser);
                    break;
                case 3:
                    Console.WriteLine("rezultatai");
                    UsersDisplay(users, currentUser);
                    break;
                case 4:
                    Console.WriteLine("start game");
                    StartGame(users, currentUser);                    
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Išjungiame programą.");
                    Console.WriteLine("Iki kito karto!!");
                    break;
                default:
                    Console.WriteLine("Neteisinga įvestis.");
                    Meniu(users, currentUser);
                    break;

            }


        }
        public static void UsersDisplay(Dictionary<string, int> users, string currentUser)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t Dabartinis vartotojas  " + currentUser);
            Console.WriteLine("Visi esami vartotojai: ");
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
            bool success = false;
            while (!success)
            {
                Console.WriteLine("Įveskite q, kad grįžti į meniu.");
                string input = Console.ReadLine().Trim();
                if (input == "q")
                {
                 Meniu(users, currentUser);
                }
            }
            
        }
    
    public static void RulesDisplay(Dictionary<string, int> users, string currentUser)
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t Dabartinis vartotojas  " + currentUser);
        Console.WriteLine("Sveikiname prisijungus prie protmūšio!");
        Console.WriteLine("Šis protmūšis turi X kategorijų. Kiekvienoje kategorijoje jums bus užduoti 5 klausimai.");
        Console.WriteLine("Pasirinkus kategoriją pradėsite žaidimą ir turėsite pasirinkti teisingą atsakymą iš 4 galimų variantų");
        Console.WriteLine("Jeigu jungiatės prie jau esamo vartotojo - to vartotojo taškai nėra sumuojami, pradedama skaičiuoti iš naujo.");
        Console.WriteLine("Kiekvienas teisingas atsakymas jums pridės vieną tašką prie bendros taškų sumos.");
        Console.WriteLine("Spauskite q raidę, norėdami grįžti į Meniu...");
        string input = Console.ReadLine().Trim();
        if (input == "q")
        {
                Meniu(users, currentUser);
        }
        if (input != "q")
        {
            RulesDisplay(users, currentUser);
        }
    }
        public static void StartGame(Dictionary<string, int> users, string currentUser)
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
            var answers = new List<int>
            {
                3, 
                2, 
                2, 
                1, 
                3, 
                3, 
                4, 
                3, 
                2, 
                2
            };
            var askedQuestions = new List<int>();
            int correct = 0;
            for (int i = 0; i < 5; i++)
            {
                var random = new Random();
                int question = random.Next(5, 10);
                               
                if (!askedQuestions.Contains(question))
                {
                    askedQuestions.Add(question);
                    Console.WriteLine(questions[question]);
                    Console.Write(choices[question]);
                    int input = int.Parse(Console.ReadLine());
                    if (input == answers[question])
                    {
                        correct++;                        
                    }                    
                }
                else
                {
                    i--;
                    continue;
                }
            } 
                
            }
        }
            
        }
   


