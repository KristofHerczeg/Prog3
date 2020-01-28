namespace HerczegKristofFejlabuak
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using HerczegKristofFejlabuak.Data;
    using HerczegKristofFejlabuak.Logic;

    class Program
    {
        static void Main(string[] args)
        {
            MenuExecute();
            Console.ReadKey();
        }

        private static void MenuExecute()
        {
            Logic.LogicOther logicOther = new LogicOther();
            ILogic<species> logicS = new Logic<species>();
            ILogic<classification> logicC = new Logic<classification>();
            ILogic<subclass> logicSub = new Logic<subclass>();
            ConsoleKeyInfo c;
            do
            {
                Menu();
                c = Console.ReadKey();
                Console.Clear();
                switch (c.Key)
                {
                    case ConsoleKey.D1:
                        switch (SegedMenu())
                        {
                            case 1:
                                Console.WriteLine("Sub class name: ");
                                string subcassname = Console.ReadLine();
                                Console.WriteLine("belso szavazas eredmenye: (int)");
                                int a = int.Parse(Console.ReadLine());
                                Console.WriteLine("External shell: (1 vagy 0)");
                                int b = int.Parse(Console.ReadLine());
                                Console.WriteLine("Kihalt: (1 vagy 0)");
                                int ki = int.Parse(Console.ReadLine());
                                Console.WriteLine("megjelenes Idoszaka: ");
                                Console.WriteLine("Megtalálás éve: (int)");
                                short ev = (short)int.Parse(Console.ReadLine());
                                string megjelenes = Console.ReadLine();
                                subclass spr = new subclass() { subclass_name = subcassname, belso_szavazas_eredmenye = a, external_shell = (byte)b, kihalt = (byte)ki, megjelenes_idoszaka = megjelenes, megtalalas_eve = ev };
                                logicSub.Create(spr);
                                break;
                            case 2:
                                Console.WriteLine("Genus name: ");
                                string genusN = Console.ReadLine();
                                Console.WriteLine("Special Apparence: ");
                                string spApparance = Console.ReadLine();
                                Console.WriteLine("Chuthulu approved: (1 vagy 0)");
                                int chuth = int.Parse(Console.ReadLine());
                                Console.WriteLine("Kihalt: (1 vagy 0)");
                                int deep_ab = int.Parse(Console.ReadLine());
                                Console.WriteLine("Subclass name: ");
                                string subname = Console.ReadLine();
                                Console.WriteLine("Order: ");
                                string orderN = Console.ReadLine();
                                Console.WriteLine("Family: ");
                                string family = Console.ReadLine();
                                classification cl = new classification() { genus_name = genusN, deep_able = (byte)deep_ab, cthulh_aproved = (byte)chuth, special_apparance = spApparance, subclass_name = subname, family = family, order_ = orderN, };
                                logicC.Create(cl);
                                break;
                            case 3:
                                Console.WriteLine("Specie Name: ");
                                string speciename = Console.ReadLine();
                                Console.WriteLine("Átlagos Meret: (string)");
                                string atlagosmeret = Console.ReadLine();
                                Console.WriteLine("Felfedezés: (int)");
                                short felfedees = (short)int.Parse(Console.ReadLine());
                                Console.WriteLine("Cute: (1 vagy 0)");
                                byte cute1= (byte)int.Parse(Console.ReadLine());
                                Console.WriteLine("Genus name: ");
                                string genusNev = Console.ReadLine();
                                Console.WriteLine("Legnagyobb Meret: ");
                                string Lmeret = Console.ReadLine();
                                species sp = new species() { species_name = speciename, atlagos_meret = atlagosmeret, cute = cute1, felfedezes = felfedees, genus_name=genusNev, legnagyobb_meret = Lmeret, };
                                logicS.Create(sp);
                                break;
                            case 0:
                                break;
                        }

                        break;
                    case ConsoleKey.D2:
                        switch (SegedMenu())
                        {
                            case 1:
                                Console.WriteLine("egyet vagy mindegyiket ki szeretné iratni?");
                                Console.WriteLine("nyomjon y ha csak egyet, entert ha mindet");
                                if (Console.ReadLine() == "y")
                                {
                                    Console.WriteLine("Subclass name: ");
                                    Console.WriteLine(logicSub.ReadOne(Console.ReadLine()));
                                }
                                else
                                {
                                    var a = logicSub.GetAll();
                                    foreach (var item in a)
                                    {
                                        Console.WriteLine(subclassConverter(item as subclass));
                                    }
                                }

                                break;
                            case 2:
                                Console.WriteLine("egyet vagy mindegyiket ki szeretné iratni?");
                                Console.WriteLine("nyomjon y ha csak egyet, entert ha mindet");
                                if (Console.ReadLine() == "y")
                                {
                                    Console.WriteLine("Genus name: ");
                                    Console.WriteLine(classificationConverter(logicC.ReadOne(Console.ReadLine())));
                                }
                                else
                                {
                                    var a = logicC.GetAll();
                                    foreach (var item in a)
                                    {
                                        Console.WriteLine(classificationConverter(item as classification));
                                    }
                                }
                                break;
                            case 3:
                                Console.WriteLine("egyet vagy mindegyiket ki szeretné iratni?");
                                Console.WriteLine("nyomjon y ha csak egyet, entert ha mindet");
                                if (Console.ReadLine() == "y")
                                {
                                    Console.WriteLine("Specie name: ");
                                    Console.WriteLine(speciesConverter(logicS.ReadOne(Console.ReadLine())));
                                }
                                else
                                {
                                    var a = logicSub.GetAll();
                                    foreach (var item in a)
                                    {
                                        Console.WriteLine(subclassConverter(item as subclass));
                                    }
                                }
                                break;
                            case 0:
                                break;
                        }

                        break;
                    case ConsoleKey.D3:
                        switch (SegedMenu())
                        {
                            case 1:
                                Console.WriteLine("melyiket szeretnéd updatelni?");
                                string USub = Console.ReadLine();
                                var UpdatelendoSubClass = logicSub.ReadOne(USub);
                                Console.WriteLine("Sub class name: ");
                                string subcassname = Console.ReadLine();
                                Console.WriteLine("belso szavazas eredmenye: (int)");
                                int a = int.Parse(Console.ReadLine());
                                Console.WriteLine("External shell: (1 vagy 0)");
                                int b = int.Parse(Console.ReadLine());
                                Console.WriteLine("Kihalt: (1 vagy 0)");
                                int ki = int.Parse(Console.ReadLine());
                                Console.WriteLine("megjelenes Idoszaka: ");
                                Console.WriteLine("Megtalálás éve: (int)");
                                short ev = (short)int.Parse(Console.ReadLine());
                                string megjelenes = Console.ReadLine();
                                subclass spr = new subclass() { subclass_name = subcassname, belso_szavazas_eredmenye = a, external_shell = (byte)b, kihalt = (byte)ki, megjelenes_idoszaka = megjelenes, megtalalas_eve = ev };
                                logicSub.Update(spr, USub);
                                break;
                            case 2:
                                Console.WriteLine("melyiket szeretnéd updatelni?");
                                string UCl = Console.ReadLine();
                                var Updatelendoclassification = logicC.ReadOne(UCl);
                                Console.WriteLine("Genus name: ");
                                string genusN = Console.ReadLine();
                                Console.WriteLine("Special Apparence: ");
                                string spApparance = Console.ReadLine();
                                Console.WriteLine("Chuthulu approved: (1 vagy 0)");
                                int chuth = int.Parse(Console.ReadLine());
                                Console.WriteLine("Kihalt: (1 vagy 0)");
                                int deep_ab = int.Parse(Console.ReadLine());
                                Console.WriteLine("Subclass name: ");
                                string subname = Console.ReadLine();
                                Console.WriteLine("Order: ");
                                string OrderN = Console.ReadLine();
                                Console.WriteLine("Family: ");
                                string family = Console.ReadLine();
                                classification cl = new classification() { genus_name = genusN, deep_able = (byte)deep_ab, cthulh_aproved = (byte)chuth, special_apparance = spApparance, subclass_name = subname, family = family, order_ = OrderN, };
                                logicC.Update(cl, UCl);
                                break;
                            case 3:
                                Console.WriteLine("melyiket szeretnéd updatelni?");
                                string uSp = Console.ReadLine();
                                Console.WriteLine("Specie Name: ");
                                string speciename = Console.ReadLine();
                                Console.WriteLine("Átlagos Meret: (string)");
                                string atlagosmeret = Console.ReadLine();
                                Console.WriteLine("Felfedezés: (int)");
                                short felfedees = (short)int.Parse(Console.ReadLine());
                                Console.WriteLine("Cute: (1 vagy 0)");
                                byte cute1 = (byte)int.Parse(Console.ReadLine());
                                Console.WriteLine("Genus name: ");
                                string genusNev = Console.ReadLine();
                                Console.WriteLine("Legnagyobb Meret: ");
                                string lmeret = Console.ReadLine();
                                species sp = new species() { species_name = speciename, atlagos_meret = atlagosmeret, cute = cute1, felfedezes = felfedees, genus_name = genusNev, legnagyobb_meret = lmeret, };
                                logicS.Update(sp, uSp);
                                break;
                            case 0:
                                break;
                        }

                        break;
                    case ConsoleKey.D4:
                        switch (SegedMenu())
                        {
                            case 1:
                                Console.WriteLine("Írja be annak a nevét, amelyiket törölni szeretné:");
                                logicSub.Delete(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Írja be annak a nevét, amelyiket törölni szeretné:");
                                logicC.Delete(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("Írja be annak a nevét, amelyiket törölni szeretné:");
                                logicS.Delete(Console.ReadLine());
                                break;
                            case 0:
                                break;
                        }

                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("1. Teljes Fa kiírás");
                        Console.WriteLine("2. Családok alatti falyok számának kiírása");
                        Console.WriteLine("3. Alosztály(sub class) alatiak számának kiírása");
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Adja meg mit akar kiírni:");
                                Console.WriteLine(logicOther.BranchWriteout(Console.ReadLine()));
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.WriteLine(logicOther.FamilyCount());
                                break;
                            case 3:
                                Console.WriteLine(logicOther.SpeciesUnderSubClassCount());
                                Console.WriteLine(logicOther.GroupSpecies());

                                break;
                            case 0:
                                break;
                        }

                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Size(in mm): ");
                        string size = Console.ReadLine();
                        XDocument xDoc = XDocument.Load($"http://localhost:8080/JavaVegePont/NewServlet?Nev={name}&Size={size}");

                        foreach (var item in xDoc.Descendants("meret"))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine(item.Value + "mm");
                        }

                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Nyomd meg az entert a tovább haladáshoz");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (c.Key != ConsoleKey.D0);
        }

        private static void Menu()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("\n- 1. create                                   -");
            Console.WriteLine("\n- 2. reade                                    -");
            Console.WriteLine("\n- 3. update                                   -");
            Console.WriteLine("\n- 4. delete                                   -");
            Console.WriteLine("\n- 5. Egyéb Metódusok                          -");
            Console.WriteLine("\n- 6. Java Vegpont                             -");
            Console.WriteLine("\n- 0. Kilépés                                  -");
            Console.WriteLine("\n-----------------------------------------------");
        }

        private static string speciesConverter(species a)
        {
            return "Name: "+ a.species_name + " Genus Name: " + a.genus_name + " Átlagos Meret: " + a.atlagos_meret + " Legnagyobb meret: " + a.legnagyobb_meret + " Cute: " + a.cute + " felfedezes: " + a.felfedezes + " Megjelenes: " + a.megjelenes;
        }

        private static string subclassConverter(subclass sb)
        {
            return "Name: " + sb.subclass_name + " Megjelenes idöszaka: " + sb.megjelenes_idoszaka + " Megtalálás éve: " + sb.megtalalas_eve + " Kihalt: " + sb.kihalt + " External Shell: " + +sb.external_shell;
        }

        private static string classificationConverter(classification cl)
        {
            return "Genus Name: " + cl.genus_name + " Subclass name: " + cl.subclass_name + " Family: " + cl.family + " Order: " + cl.order_ + " Cthulhu approved " + cl.cthulh_aproved + " Deep able: " + cl.deep_able;
        }

        private static int SegedMenu()
        {
            Console.WriteLine("melyik táblában?");
            Console.WriteLine("\n- 1. Sub Class");
            Console.WriteLine("\n- 2. Classification");
            Console.WriteLine("\n- 3. Species");
            Console.WriteLine("\n- 0. Kilépés");
            int seged = int.Parse(Console.ReadLine());
            while (seged > 3 || seged < 0)
            {
                Console.WriteLine("adjon meg egy 0-3 közötti számot");
                seged = int.Parse(Console.ReadLine());
            }
            return seged;
        }
    }
}
