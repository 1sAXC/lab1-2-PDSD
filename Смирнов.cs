using System.Xml.Linq;

namespace lab1
{
    internal class Смирнов
    {
        static void Main(string[] args)
        {
            /*Random random = new Random();
            int ran = random.Next(7,10);
            Node node = Create(ran, 50, 100);
            Console.WriteLine("Создано множество А - " + Print(node, ','));
            Console.WriteLine("Мощность множества А - " + Mosh(node).ToString());
            Console.WriteLine("Вывод множества А - " + Print(node, ','));
            Delete(ref node);
            Console.WriteLine("Удалено сножетсво А - ");
            Console.WriteLine("Мощность множества А - " + Mosh(node).ToString());
            Console.WriteLine("Вывод множества А - " + Print(node, ','));*/

            Node a = CreateEmpty();
            a = Add(10, a);
            a = Add(20, a);

            Node b = CreateEmpty();
            b = Add(10, b);
            b = Add(20, b);
            b = Add(30, b);

            Node ab = Unite(a, b);

            Console.WriteLine("A: " + Print(a, ';'));
            Console.WriteLine("B: " + Print(b, ';'));
            Console.WriteLine("\n");
            Console.WriteLine("А подмножество B: " + IfConsists(a,b));
            Console.WriteLine("A подмножество A: " + IfConsists(a, a));
            Console.WriteLine("\n");
            Console.WriteLine("А равно B: " + isEqual(a, b));
            Console.WriteLine("A равно A: " + isEqual(a, a));
            Console.WriteLine("\n");
            Console.WriteLine("Объединение A и B: " + Print(ab, ';'));
            Console.WriteLine("\n");
            Console.WriteLine("Пересечение А и B: " + Print(Intersection(a, b), ';'));
            Console.WriteLine("\n");
            Console.WriteLine("Разность A и B: " + (Print(Difference(a, b), ';')));
            Console.WriteLine("Разность B и A: " + (Print(Difference(b, a), ';')));
            Console.WriteLine("\n");
            Console.WriteLine("Симметричная разность A и B: " + (Print(SpecularDifference(a, b), ';')));
            Console.WriteLine("\n");
            Console.WriteLine("Множество с параметром A: " + (Print(CreateWithParametr('A'), ';')));
            Console.WriteLine("Множество с параметром A: " + (Print(CreateWithParametr('A'), ';')));
            Console.WriteLine("\n");
            Console.WriteLine("Множество с параметром Б: " + (Print(CreateWithParametr('B'), ';')));
            Console.WriteLine("Множество с параметром Б: " + (Print(CreateWithParametr('B'), ';')));
        }


        //Создать пустое множество
        static Node CreateEmpty()
        {
            return null;
        }


        //Проверка на пустое множество
        static bool IsEmpty(Node node)
        {
            if (node == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Проверка на наличие элемента множества
        static bool Check(int value, Node node)
        {
            if (IsEmpty(node) || node == null)
            {
                return false;
            }
            Node current = node;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //Добавить элемент в множество
        static Node Add(int value, Node node)
        {
            if (Check(value,node))
            {
                return node;
            }
            Node newNode = new Node();
            newNode.Value = value;
            newNode.Next = node;
            return newNode;
        }

        //Создать множество
        static Node Create(int count, int min, int max)
        {
            Random random = new Random();
            Node node = CreateEmpty();
            if ((max - min) < count || max <= min)
            {
                Console.WriteLine("Неправильно указан диапазон");
                return CreateEmpty();
            }
            if (count <= 0)
            {
                Console.WriteLine("Неправильно указан размер");
                return CreateEmpty();
            }
            Node current = node;
            for (int i = 0; i < count;)
            {
                Node currentNode = node;
                node = Add(random.Next(min, max), current);
                if (currentNode == node)
                {
                    continue;
                }
                current = node;
                i++;
            }
            return node;
        }

        static Node CreateWithParametr(char x)
        {
            Random random = new Random();
            if (x == 'A')
            {
                int count = random.Next(6, 10);
                int min = 10;
                int max = 30;
                Node currentReturn = CreateEmpty();
                for (int i = 0; i < count;)
                {
                    int key = random.Next(min,max);
                    Node currentNode = currentReturn;
                    if ((key % 10) <= 3)
                    {
                        currentReturn = Add(key + 4, currentReturn);
                    }
                    else
                    {
                        currentReturn = Add(key, currentReturn);
                    }
                    if (currentNode == currentReturn)
                    {
                        continue;
                    }
                    i++;
                }
                return currentReturn;         
            }
            else if (x == 'B')
            {
                int count = random.Next(6, 10);
                int min = 10;
                int max = 99;
                Node currentReturn = CreateEmpty();
                for (int i = 0; i < count;)
                {
                    int key = random.Next(min, max);
                    Node currentNode = currentReturn;
                    if ((key % 10) >= 8)
                    {
                        currentReturn = Add(key - 3, currentReturn);
                    }
                    else
                    {
                        currentReturn = Add(key, currentReturn);
                    }
                    if (currentNode == currentReturn)
                    {
                        continue;
                    }
                    i++;
                }
                return currentReturn;
            }
            else
            {
                Console.WriteLine("Неправильно указан параметр");
                return CreateEmpty();
            }
        }

        //Мощность множества
        static int Mosh(Node node)
        {
            if (IsEmpty(node))
            {
                return 0;
            }
            int count = 0;
            Node current = node;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;

        }

        //Вывести множество
        static String Print(Node node, char symbol)
        {
            String str = "";
            if (IsEmpty(node))
            {
                return str;
            }
            Node current = node;
            int count = Mosh(node);
            for (int i = 0; i < count; i++)
            {
                str += current.Value.ToString();
                str += symbol;
                current = current.Next;
            }
            str = str.Remove(str.Length - 1, 1);
            return str;
        }

        //Удалить множество
        static Node Delete(ref Node node)
        {
            node = null;
            return node;
        }

        //Подмножество А-Б
        static bool IfConsists(Node a, Node b)
        {
            if (IsEmpty(a) || Mosh(a) > Mosh (b))
            {
                return false;
            }
            bool isFind = false;
            Node currentA = a;
            Node currentB = b;
            for (int i = 0; i < Mosh(a); i++)
            {
                currentB = b;
                for (int j = 0; j < Mosh(b); j++)
                {
                    if (currentA.Value == currentB.Value)
                    {
                        isFind = true;
                        break;
                    }
                    else
                    {
                        currentB = currentB.Next;
                    }
                }
                if (!isFind)
                {
                    return false;
                }
                isFind = false;
                currentA = currentA.Next;   
            }
            return true;
        }

        //Равенство множеств
        static bool isEqual(Node a, Node b)
        {
            if (IfConsists(a,b) && IfConsists(b,a))
            {
                return true;
            }
            return false;
        }

        //Объединение множеств
        static Node Unite (Node a, Node b)
        {
            if (IsEmpty(a))
            {
                return b;
            }
            if (IsEmpty(b))
            {
                return a;
            }

            Node currentA = a;
            Node currentB = b;
            for (int i = 0; i < Mosh(currentB); i++)
            {
                currentA = Add(currentB.Value, currentA);
                currentB = currentB.Next;
            }
            return currentA;
        }

        //Пересечение множеств

        static Node Intersection (Node a, Node b)
        {
            if (IsEmpty(a) || IsEmpty(b))
            {
                return null;
            }

            Node current = CreateEmpty();
            Node currentB = b;
            Node currentA = a;
            for (int i = 0; i < Mosh(a); i++)
            {
                for (int j = 0; j < Mosh(b); j++)
                {
                    if (currentA.Value == currentB.Value)
                    {
                        current = Add(currentA.Value, current);
                        break;
                    }
                    currentB = currentB.Next;
                }
                currentA = currentA.Next;
                currentB = b;
            }
            return current;
        }

        //разность множества
        static Node Difference(Node a, Node b)
        {
            if (IsEmpty(b))
            {
                return a;
            }

            Node currentA = a;
            Node currentB = b;
            Node currentReturn = CreateEmpty();
            bool isFind = false;

            for (int i = 0; i < Mosh(a); i++)
            {
                for (int j = 0; j < Mosh(b); j++)
                {
                    if (currentA.Value == currentB.Value)
                    {
                        isFind = true;
                    }
                    currentB = currentB.Next;
                }
                if (!isFind)
                {
                    currentReturn = Add(currentA.Value, currentReturn);
                }
                currentA = currentA.Next;
                currentB = b;
            }
            return currentReturn;
        }

        static Node SpecularDifference(Node a, Node b)
        {
            if (Mosh(Intersection(a,b)) == 0)
            {
                return Unite(a, b);
            }
            Node differenceA = Difference(a,b);
            Node differenceB = Difference(b,a);
            return Unite(differenceA, differenceB);
        }


    }
}