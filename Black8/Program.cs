using System;

namespace Black8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fin = true;
            int jetonsjoueur = 100;
            while (fin == true)
            {
                Console.Clear();
                //Variable

                int jetonsmise = 0;


                int carterandom()
                {
                    Random aleatoire = new Random();
                    int carte = aleatoire.Next(1, 14);
                    return carte;
                }
                int couleurrandom()
                {
                    Random aleatoire = new Random();
                    int couleur = aleatoire.Next(1, 5);
                    return couleur;
                }
                //Mes CArtes
                int GenenerCarte()
                {
                    int carteJoueur = 0;
                    switch (carterandom())

                    {
                        case 1: carteJoueur = 1; break;
                        case 2: carteJoueur = 2; break;
                        case 3: carteJoueur = 3; break;
                        case 4: carteJoueur = 4; break;
                        case 5: carteJoueur = 5; break;
                        case 6: carteJoueur = 6; break;
                        case 7: carteJoueur = 7; break;
                        case 8: carteJoueur = 8; break;
                        case 9: carteJoueur = 9; break;
                        case 10: carteJoueur = 10; break;
                        case 11: carteJoueur = 11; break;
                        case 12: carteJoueur = 12; break;
                        case 13: carteJoueur = 13; break;
                    }
                    return carteJoueur;
                }


                void AfficherCarte(int _sorte, int _valeur)
                {
                    string numcarte = "";
                    string couleurcarte = "";

                    switch (_sorte)
                    {
                        case 1: couleurcarte = " de Coeur"; break;
                        case 2: couleurcarte = " de Pique"; break;
                        case 3: couleurcarte = " de Carreau"; break;
                        case 4: couleurcarte = " de Trefle"; break;
                    }
                    if (_valeur == 1)
                    {
                        numcarte = "Un As";
                    }
                    else if (_valeur > 1 && _valeur < 11)
                    {
                        numcarte = "Un " + _valeur.ToString();
                    }
                    else if (_valeur == 11)
                    {
                        numcarte = "Un Valet";
                    }
                    else if (_valeur == 12)
                    {
                        numcarte = "Une Dame";
                    }
                    else if (_valeur == 13)
                    {
                        numcarte = "Un Roi";
                    }
                    Console.WriteLine(numcarte + couleurcarte);
                }


                // carte aleatoire


                int carte1joueur = GenenerCarte();
                int carte2joueur = GenenerCarte();
                int carte3joueur = GenenerCarte();
                int carte1IA = GenenerCarte();
                int carte2IA = GenenerCarte();
                int carte3IA = GenenerCarte();
                //Valeur carte
                int cartevaleur1 = carte1joueur;
                int cartevaleur2 = carte2joueur;
                int cartevaleur3 = carte3joueur;
                int cartevaleur4 = carte1IA;
                int cartevaleur5 = carte2IA;
                int cartevaleur6 = carte3IA;

                int determinerValeur(int _valeur)
                {
                    if (_valeur >= 10)
                        return 10;
                    else if (_valeur == 1)
                        return 11;
                    else
                        return _valeur;
                }


                {
                    //Début code

                    Console.WriteLine("Bonjour Joueur. Vous avez " + jetonsjoueur + "  jetons.");
                    Console.WriteLine("Combiens allez vous misez?");
                    jetonsmise = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Vos carte sont:");
                    AfficherCarte(couleurrandom(), carte1joueur);
                    AfficherCarte(couleurrandom(), carte2joueur);
                    Console.WriteLine("Carte enemie:");
                    AfficherCarte(couleurrandom(), carte1IA);
                    Console.WriteLine("1-Pigez 2-Arreter");
                    int choix1 = Convert.ToInt32(Console.ReadLine());
                    int valeurcartejoueur = determinerValeur(cartevaleur1) + determinerValeur(cartevaleur2);

                    if (choix1 == 1)
                    {
                        Console.WriteLine("Vos cartes sont maintenants: ");
                        AfficherCarte(couleurrandom(), carte1joueur);
                        AfficherCarte(couleurrandom(), carte2joueur);
                        AfficherCarte(couleurrandom(), carte3joueur);
                        int valeurcartejoueur2 = determinerValeur(cartevaleur1) + determinerValeur(cartevaleur2) + determinerValeur(cartevaleur3);
                        valeurcartejoueur = valeurcartejoueur2;
                    }

                    //Tour de l'IA
                    int valeurcarteIA = determinerValeur(cartevaleur4) + determinerValeur(cartevaleur5);
                    if (valeurcartejoueur > valeurcarteIA && valeurcartejoueur <= 21 && valeurcarteIA < 20)
                    {
                        valeurcarteIA = determinerValeur(cartevaleur4) + determinerValeur(cartevaleur5) + determinerValeur(cartevaleur6);
                        Console.WriteLine("Le dealer a pigé une carte");
                    }

                    //Déterminer le gagant

                    Console.WriteLine("Dealer :" + valeurcarteIA + ", Joueur:" + valeurcartejoueur);

                    if (valeurcarteIA > valeurcartejoueur && valeurcarteIA < 21 || valeurcartejoueur > 21)
                    {
                        Console.WriteLine("Le dealer a gagné!");
                        jetonsjoueur = jetonsjoueur - jetonsmise;
                        Console.WriteLine("Vous avez :" + jetonsjoueur + " jetons");

                    }
                    else if (valeurcartejoueur > valeurcarteIA && valeurcartejoueur < 21 || valeurcarteIA > 21)
                    {
                        Console.WriteLine("Le joeur a gagné(e)!");
                        jetonsjoueur = jetonsjoueur + jetonsmise;
                        Console.WriteLine("Vous avez :" + jetonsjoueur + " jetons");
                    }
                    else if (valeurcartejoueur > valeurcarteIA && valeurcartejoueur == 21)
                    {
                        Console.WriteLine("Cest le BlackJack!");
                        jetonsjoueur = jetonsjoueur + jetonsmise;
                        Console.WriteLine("Vous avez :" + jetonsjoueur + " jetons");
                    }
                    else if (valeurcarteIA == 21)
                    {
                        Console.WriteLine("Le dealer a gagné avec un BlackJack!");
                        jetonsjoueur = jetonsjoueur - jetonsmise;

                        Console.WriteLine("Vous avez :" + jetonsjoueur + " jetons");
                    }
                    else if (valeurcartejoueur > 21 && valeurcarteIA > 21)
                    {
                        Console.WriteLine("Les deux ont perdus.");
                        Console.WriteLine("Vous avez :" + jetonsjoueur + "jetons. Vous n'avez rien perdu!");
                    }
                    else if (valeurcartejoueur == valeurcarteIA)
                    {
                        Console.WriteLine("Its a draw!");
                        Console.WriteLine("Vous avez :" + jetonsjoueur + "jetons. Vous n'avez rien perdu!");
                    }
                    Console.WriteLine("Voulez vous rejouer? Tapez oui ou non");
                    string choix2 = "";
                    choix2 = Console.ReadLine();
                    if (choix2 == "non")
                    {
                        fin = false;
                    }
                }

            }
        }
    }
}
