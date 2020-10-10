using System;
using System.Collections.Generic;

namespace home_work_s_sharp_generic
{
    class Program
    {
        //-----3
        public class PhoneBook
        {
            private Dictionary<int, string> phonebook;

            public PhoneBook()
            {
                phonebook = new Dictionary<int, string>();
            }

            public void Add_phone(string str, int key)
            {
                Console.WriteLine("enter phone");
                str = Console.ReadLine();
                Console.WriteLine("enter key");
                key = int.Parse(Console.ReadLine());
                bool ok = true;
                foreach (var item in phonebook)
                {
                    if (item.Key == key)
                    {
                        Console.WriteLine("Error!");
                        ok = false;
                    }
                }
                if (ok == true)
                {
                    phonebook.Add(key, str);
                }
            }
            public void Find_number_by_key(int find)
            {
                foreach (var item in phonebook)
                {
                    if (item.Key == find)
                    {
                        Console.WriteLine(item.Value);
                    }
                }
            }
    
            public void Change_number_by_key(int key, string str)
            {
                Delete_by_key(key);
                Add_phone(str, key);
            }
            public void Show_all_numbers_and_thear_keys()
            {
                foreach (var item in phonebook)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }
            public void Delete_by_key(int find)
            {
                bool ok = false;
                foreach (var item in phonebook)
                {
                    if (item.Key == find)
                    {
                        ok = true;
                    }
                }
                if (ok == true)
                {
                    phonebook.Remove(find);
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }

        }

        //-----4
        public class Card : IComparable<Card>
        {
            public string Name { get; set; }
            public string Mast { get; set; }
            public int count_sort;

            public Card(string name, string mast)
            {
                Name = name;
                Mast = mast;
                count_sort = -1;
            }

            public int CompareTo(Card other)
            {
                return count_sort.CompareTo(other.count_sort);
            }
            public int Count_sort
            {
                get { return count_sort; }
                set { count_sort = value; }
            }
            public override string ToString()
            {
                return ($"Name: {Name}" +
                    $"--Mast: {Mast}");
            }
           
        }

        public class Deck_of_cards
        {

            Queue<Card> deck_cards = new Queue<Card>(36);
            Card[] Cards = new Card[36];
            public Deck_of_cards()
            {
                deck_cards.Enqueue(new Card("6", "Hearts"));
                deck_cards.Enqueue(new Card("6", "Diamonds"));
                deck_cards.Enqueue(new Card("6", "Clubs"));
                deck_cards.Enqueue(new Card("6", "Spades "));
                deck_cards.Enqueue(new Card("7", "Hearts"));
                deck_cards.Enqueue(new Card("7", "Diamonds"));
                deck_cards.Enqueue(new Card("7", "Clubs"));
                deck_cards.Enqueue(new Card("7", "Spades "));
                deck_cards.Enqueue(new Card("8", "Hearts"));
                deck_cards.Enqueue(new Card("8", "Diamonds"));
                deck_cards.Enqueue(new Card("8", "Clubs"));
                deck_cards.Enqueue(new Card("8", "Spades "));
                deck_cards.Enqueue(new Card("9", "Hearts"));
                deck_cards.Enqueue(new Card("9", "Diamonds"));
                deck_cards.Enqueue(new Card("9", "Clubs"));
                deck_cards.Enqueue(new Card("9", "Spades "));
                deck_cards.Enqueue(new Card("10", "Hearts"));
                deck_cards.Enqueue(new Card("10", "Diamonds"));
                deck_cards.Enqueue(new Card("10", "Clubs"));
                deck_cards.Enqueue(new Card("10", "Spades "));
                deck_cards.Enqueue(new Card("Jackn", "Hearts"));
                deck_cards.Enqueue(new Card("Jack", "Diamonds"));
                deck_cards.Enqueue(new Card("Jack", "Clubs"));
                deck_cards.Enqueue(new Card("Jack", "Spades "));
                deck_cards.Enqueue(new Card("Queen", "Hearts"));
                deck_cards.Enqueue(new Card("Queen", "Diamonds"));
                deck_cards.Enqueue(new Card("Queen", "Clubs"));
                deck_cards.Enqueue(new Card("Queen", "Spades "));
                deck_cards.Enqueue(new Card("King", "Hearts"));
                deck_cards.Enqueue(new Card("King", "Diamonds"));
                deck_cards.Enqueue(new Card("King", "Clubs"));
                deck_cards.Enqueue(new Card("King", "Spades "));
                deck_cards.Enqueue(new Card("Ace", "Hearts"));
                deck_cards.Enqueue(new Card("Ace", "Diamonds"));
                deck_cards.Enqueue(new Card("Ace", "Clubs"));
                deck_cards.Enqueue(new Card("Ace", "Spades "));

            }

            public void Sort(IComparer<Card> comparer)
            {
                Array.Sort(Cards, comparer);
            }

            public void Shuffle_deck()
            {
                Random rnd = new Random();
                int random;

                foreach (var item in deck_cards)
                {
                    random = rnd.Next(0, 100);
                    item.Count_sort = random;
                }

                int num = 0;
                foreach (var item in deck_cards)
                {
                    Cards[num] = item;
                    num++;
                }

                Sort(new CompareByCount_to_sort());

                Queue<Card> temp = new Queue<Card>(36);
                foreach (var item in Cards)
                {
                    temp.Enqueue(item);
                }

                deck_cards = temp;
            }

            public void Get_card_from_deck()
            {
                deck_cards.Dequeue();
            }

            public void Get_6_cards()
            {
                for (int i = 0; i < 6; i++)
                {
                    Get_card_from_deck();
                }
            }

            public void Show_deck_of_card()
            {
                foreach (var item in deck_cards)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        class CompareByCount_to_sort : IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                return x.count_sort.CompareTo(y.count_sort);
            }
        }

        static void Main(string[] args)
        {
            //-----1

            //ArrayList list = new ArrayList();

            //list.Add(6);
            //list.Add(5);
            //list.Add(true);
            //list.Add(false);
            //list.Add(5.5);
            //list.Add(9.5);

            //List<bool> list_bool = new List<bool>();
            //List<int> list_int = new List<int>();
            //List<double> list_double = new List<double>();

            //foreach (var item in list)
            //{
            //    if (item is int)
            //    {
            //        list_int.Add((int)item);
            //    }
            //    else if (item is double)
            //    {
            //        list_double.Add((double)item);
            //    }
            //    else if (item is bool)
            //    {
            //        list_bool.Add((bool)item);
            //    }

            //}

            //foreach (var item in list_int)
            //{
            //    Console.Write($" "+item);
            //}
            //Console.WriteLine();
            //foreach (var item in list_double)
            //{
            //    Console.Write($" " + item);
            //}
            //Console.WriteLine();
            //foreach (var item in list_bool)
            //{
            //    Console.Write($" " + item);
            //}
            //Console.WriteLine();


            //-----2

            //List<string> list_string = new List<string>();

            //list_string.Add("wow");
            //list_string.Add("tydtrdtr");
            //list_string.Add("oydtrdtr6gtyf");
            //list_string.Add("aydtrdtr6gtyf");

            //int length = list_string[0].Length;
            //string value = list_string[0];

            //foreach (var item in list_string)
            //{
            //    if (item.Length > length)
            //    {
            //        value = item;
            //        length = item.Length;
            //    }
            //}

            //list_string.Sort();

            //foreach (var item in list_string)
            //{
            //    if (item.Length == length)
            //    {
            //        Console.WriteLine(item);
            //        break;
            //    }
            //}
          
            

        }
    }
}
