using System;

namespace zadanie10
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> l1 = new DoublyLinkedList<int>();
            l1.Add(1);
            l1.Add(2);
            l1.Add(4);
            l1.Add(6);
            l1.Add(7);
            l1.Add(8);
            l1.PrintList();
            l1.ShowSum();
        }
    }
}
