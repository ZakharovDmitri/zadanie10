using System;
using System.Collections.Generic;
using System.Text;

namespace zadanie10
{
    public class DoublyNode<T>
    {
        public DoublyNode(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }

        public override string ToString()
        {
            return Data + " ";
        }
    }

    public class DoublyLinkedList<T>  // двусвязный список
    {
        DoublyNode<int> head; // головной/первый элемент
        DoublyNode<int> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке
        int sum = 0;

        // добавление элемента
        public void Add(int data)
        {
            DoublyNode<int> node = new DoublyNode<int>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(int data)
        {
            DoublyNode<int> node = new DoublyNode<int>(data);
            DoublyNode<int> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        // удаление
        public bool Remove(int data)
        {
            DoublyNode<int> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(int data)
        {
            DoublyNode<int> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void PrintList()
        {
            if (head == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            DoublyNode<int> p = head;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.Next;
            }
        }

        public void ShowSum()
        {
            int number = 0;
            if(count%2!=0)
            {
                Console.WriteLine("Нечетное кол-во элементов!");
            }
            else
            {
                DoublyNode<int> p = head;
                DoublyNode<int> n = tail;
                do
                {   
                    sum += 2*(p.Data * n.Data);
                    p = p.Next;
                    n = n.Previous;
                    number++;
                } while (number != count / 2);
                Console.WriteLine(sum);

            }
        }
    }
}
