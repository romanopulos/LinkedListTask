using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTask
{
    class Program
    {
        static Action<LinkedList> OurAction;

        static void Main(string[] args)
        {
            Console.WriteLine("List № 1:");
            OurAction = (LinkedList lt) =>
            {
                foreach (ListNode item in lt)
                {
                    if (item == lt.tail)
                        Console.Write(item.val.ToString());
                    else
                        Console.Write(item.val.ToString() + "->");
                }
            };           
            LinkedList LinkList1 = new LinkedList(true);
            LinkList1.AddAll();
            OurAction(LinkList1);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("List № 2:");
            LinkedList LinkList2 = new LinkedList(true);
            LinkList2.AddAll();
            OurAction(LinkList2);
            Console.WriteLine("");
            LinkedList Result = LinkList1 + LinkList2;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("List № 3 (summ):");
            OurAction(Result);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
