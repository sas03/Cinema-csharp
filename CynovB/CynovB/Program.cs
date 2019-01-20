using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynovB
{
    class Program
    {
        static string name;
        static string username;
        static string email;
        static string password;
        static int numerosalle;
        static int taillesalle;
        static string longmetragetitre;
        static int horairelongmetrage;
        
        static string serietitre;
        static int horaireserie;

        static string courtmetragetitre;
        static int horairecourtmetrage;
        //HoraireLongMetrage = new DateTime(2018, 5, 11, 8, 30, 52),//5/11/18 8:30:52 AM
        static bool troisd;
        static bool vo;

        static int Menu()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Bienvenue dans l'espace Cynov :\n" +
                    "1 - Créer un compte \n" +
                    "2 - Connexion \n" +
                    "3 - Quitter");
                Int32.TryParse(Console.ReadLine(), out choice);
            } while (choice == 0);
            return choice;
        }
        static int MenuAddFilm()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Bienvenue dans l'espace admin :\n" +
                    "1 - Ajouter un long metrage \n" +
                    "2 - Ajouter un court metrage \n" +
                    "3 - Ajouter une serie \n" +
                    "4 - Quitter \n");
                Int32.TryParse(Console.ReadLine(), out choice);
            } while (choice == 0);
            return choice;
        }
        static void Compte()
        {
            MyDbContext db = new MyDbContext();
            var database = from client in db.Clients
                               //where client.Email == email
                           select new { client.Email };
            try
            {
                foreach (var s in database)
                {
                    Console.WriteLine("Entrez votre nom: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Entrez votre username");
                    username = Console.ReadLine();
                    Console.WriteLine("Entrez votre adresse email");
                    email = Console.ReadLine();
                    if (s.Email == email)
                    {
                        Console.WriteLine("Cet utilisateur existe deja.");
                        Compte();
                    }
                    else
                    {
                        MotDePasse();
                    }
                }
            }// Si une exception a eu lieu...
            catch (ClientException e)
            {
                // On affiche le message...
                Console.WriteLine(e.Message);
            }
        }
        static void MotDePasse()
        {
            try
            {
                Console.WriteLine("Entrez votre mot de passe");
                password = Console.ReadLine();
                ConfirmMdp();
            }
            catch (ClientException e)
            {
                // On affiche le message...
                Console.WriteLine(e.Message);
            }
        }
        static void ConfirmMdp()
        {
            MyDbContext db = new MyDbContext();
            Console.WriteLine("Confirmer votre mot de passe");
            string Confirm = Console.ReadLine();
            try
            {
                if (password == Confirm)
                {
                    Console.WriteLine("Mot de passe confirmé. \n" +
                        "Votre mot de passe est: " + password);
                    Client first = new Client()
                    {
                        Name = name,
                        Username = username,
                        Email = email,
                        Password = password
                    };

                    db.Clients.Add(first);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Les mots de passes ne coincident pas..");
                    Compte();
                }
            }
            catch (ClientException e)
            {
                // On affiche le message...
                Console.WriteLine(e.Message);
            }
        }

        // -- Paranthèse = requête vers la base de données --
        // Teacher renaud = teachers.Where(t => t.FirstName == "Renaud".First();
        // (from m in marks where m.Value == 12 select 3)
        // ou
        /*foreach (Mark m in marks.Where(mbox => mbox.Value == 12))
        {
            Console.WriteLine(m.Student + " . " + m.Value);
        }*/
        static int MenuChoixFilm()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Choisissez votre type de film :\n" +
                    "1 - Choix Long Metrage \n" +
                    "2 - Choix Court Metrage \n" +
                    "3 - Choix Serie \n" +
                    "4 - Quitter");
                Int32.TryParse(Console.ReadLine(), out choice);
            } while (choice == 0);
            return choice;
        }
        static void ChoixCourtMetrage()
        {
            MyDbContext db = new MyDbContext();
            var database = from film in db.Films
                               //where client.Email == email
                           select new { film.CourtMetrage};
            int i = 0;
            foreach(var s in database)
            {
                foreach(var d in s.CourtMetrage)
                {
                    i = i + 1;
                    Console.WriteLine(i + "- Titre du court metrage: " + d.CourtMetrageTitre + "\nHoraire du court metrage: " + d.HoraireCourtMetrage + "h\n");
                }
                //Console.WriteLine(s.CourtMetrage);
            }
        }
        static void ChoixLongMetrage()
        {
            MyDbContext db = new MyDbContext();
            var database = from film in db.Films
                               //where client.Email == email
                           select new { film.LongMetrage };
            int i = 0;
            foreach (var s in database)
            {
                foreach (var d in s.LongMetrage)
                {
                    i = i + 1;
                    Console.WriteLine(i + "- Titre du long metrage: " + d.LongMetrageTitre + "\nHoraire du long metrage: " + d.HoraireLongMetrage + "h\n");
                }
                //Console.WriteLine(s.CourtMetrage);
            }
        }
        static void ChoixSerie()
        {
            MyDbContext db = new MyDbContext();
            var database = from film in db.Films
                               //where client.Email == email
                           select new { film.Serie };
            int i = 0;
            foreach (var s in database)
            {
                foreach (var d in s.Serie)
                {
                    i = i + 1;
                    Console.WriteLine(i + "- Titre de la serie: " + d.SerieTitre + "\nHoraire de la serie: " + d.HoraireSerie + "h\n");
                }
                //Console.WriteLine(s.CourtMetrage);
            }
        }
        static void Connexion()
        {
            Console.WriteLine("Entrez votre email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe: ");
            string password = Console.ReadLine();
            MyDbContext db = new MyDbContext();
            var database = from client in db.Clients
                           //where client.Email == email
                           select new { client.Email, client.Password };
            try
            {
                foreach (var s in database)
                {
                    if ((s.Email == email) && (s.Password == password))
                    {
                        if (s.Email == "admin@ynov.com")
                        {
                            Console.WriteLine("connecte en tant qu'administrateur");
                            while (true)
                            {
                                switch (MenuAddFilm())
                                {
                                    case 1: AddLongMetrage(); break;
                                    case 2: AddCourtMetrage(); break;
                                    case 3: AddSerie(); break;
                                    case 4: Environment.Exit(0); break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("connecte en tant qu'utilisateur");
                            while (true)
                            {
                                switch (MenuChoixFilm())
                                {
                                    case 1: ChoixLongMetrage(); break;
                                    case 2: ChoixCourtMetrage(); break;
                                    case 3: ChoixSerie(); break;
                                    case 4: Environment.Exit(0); break;
                                }
                            }
                        }
                    }
                    //Console.WriteLine("Email={0}, Username={1}", s.Email, s.Username);
                }
            }
            catch (ClientException e)
            {
                // On affiche le message...
                Console.WriteLine(e.Message);
            }
        }
        static void AddLongMetrage() {
            MyDbContext db = new MyDbContext();

            /*
            foreach (Client client in db.Clients)
            {
                Console.WriteLine(client);
            }*/
            Console.WriteLine("Entrez votre numero de salle: ");
            string numsalle = Console.ReadLine();
            Console.WriteLine("Entrez la taille de la salle: ");
            string tsalle = Console.ReadLine();
            Console.WriteLine("Titre du long metrage: ");
            longmetragetitre = Console.ReadLine();
            Console.WriteLine("Horaire du long metrage: ");
            string hlongmetrage = Console.ReadLine();
            Console.WriteLine("3d? ");
            string td = Console.ReadLine();
            Console.WriteLine("VO? ");
            string v = Console.ReadLine();

            numerosalle = Int32.Parse(numsalle);
            taillesalle = Int32.Parse(tsalle);
            horairelongmetrage = Int32.Parse(hlongmetrage);
            troisd = bool.Parse(td);
            vo = bool.Parse(v);

            db.Films.Add(new Film()
            {
                //Ajoute les data dans la bdd Users après instanciation de la classe Users
                //--FirstName = "Jon",
                //--LastName = "Denon",
                //Instanciation de la classe adresse avec des données dans celle de Users
                Salle = new Salle()
                {
                    NumeroSalle = numerosalle,
                    TailleSalle = taillesalle
                },
                LongMetrage = new List<LongMetrage>()
                {
                    new LongMetrage()
                    {
                        LongMetrageTitre = longmetragetitre,
                        HoraireLongMetrage = horairelongmetrage,
                        //HoraireLongMetrage = new DateTime(2018, 5, 11, 8, 30, 52),//5/11/18 8:30:52 AM
                        TroisD = troisd,
                        VO = vo
                    }
                }
            });
            db.SaveChanges();
        }
        
        static void AddCourtMetrage()
        {
            MyDbContext db = new MyDbContext();

            /*
            foreach (Client client in db.Clients)
            {
                Console.WriteLine(client);
            }*/
            Console.WriteLine("Entrez votre numero de salle: ");
            string numsalle = Console.ReadLine();
            Console.WriteLine("Entrez la taille de la salle: ");
            string tsalle = Console.ReadLine();
            Console.WriteLine("Titre du court metrage: ");
            courtmetragetitre = Console.ReadLine();
            Console.WriteLine("Horaire du court metrage: ");
            string hcourtmetrage = Console.ReadLine();
            Console.WriteLine("3d? ");
            string td = Console.ReadLine();
            Console.WriteLine("VO? ");
            string v = Console.ReadLine();

            numerosalle = Int32.Parse(numsalle);
            taillesalle = Int32.Parse(tsalle);
            horairecourtmetrage = Int32.Parse(hcourtmetrage);
            troisd = bool.Parse(td);
            vo = bool.Parse(v);

            db.Films.Add(new Film()
            {
                Salle = new Salle()
                {
                    NumeroSalle = numerosalle,
                    TailleSalle = taillesalle
                },
                CourtMetrage = new List<CourtMetrage>()
                {
                    new CourtMetrage()
                    {
                        CourtMetrageTitre = courtmetragetitre,
                        HoraireCourtMetrage = horairecourtmetrage,
                        //HoraireLongMetrage = new DateTime(2018, 5, 11, 8, 30, 52),//5/11/18 8:30:52 AM
                        TroisD = troisd,
                        VO = vo
                    }
                }
            });
            db.SaveChanges();
        }
        static void AddSerie()
        {
            MyDbContext db = new MyDbContext();

            /*
            foreach (Client client in db.Clients)
            {
                Console.WriteLine(client);
            }*/
            Console.WriteLine("Entrez votre numero de salle: ");
            string numsalle = Console.ReadLine();
            Console.WriteLine("Entrez la taille de la salle: ");
            string tsalle = Console.ReadLine();
            Console.WriteLine("Titre de la serie: ");
            serietitre = Console.ReadLine();
            Console.WriteLine("Horaire de la serie: ");
            string hserie = Console.ReadLine();
            Console.WriteLine("3d? ");
            string td = Console.ReadLine();
            Console.WriteLine("VO? ");
            string v = Console.ReadLine();

            numerosalle = Int32.Parse(numsalle);
            taillesalle = Int32.Parse(tsalle);
            horaireserie = Int32.Parse(hserie);
            troisd = bool.Parse(td);
            vo = bool.Parse(v);

            db.Films.Add(new Film()
            {
                Salle = new Salle()
                {
                    NumeroSalle = numerosalle,
                    TailleSalle = taillesalle
                },
                Serie = new List<Serie>()
                {
                    new Serie()
                    {
                        SerieTitre = serietitre,
                        HoraireSerie = horaireserie,
                        //HoraireLongMetrage = new DateTime(2018, 5, 11, 8, 30, 52),//5/11/18 8:30:52 AM
                        TroisD = troisd,
                        VO = vo
                    }
                }
            });
            db.SaveChanges();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    //case 1: Pseudo(); break;
                    case 1: Compte(); break;
                    case 2: Connexion(); break;
                    case 3: Environment.Exit(0); break;
                }
            }
            
            /*
            foreach (Client client in db.Clients)
            {
                Console.WriteLine(client);
            }*/
            Console.ReadLine();
        }
    }
}
