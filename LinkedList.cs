using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinkedListTask
{
    public class LinkedList : IEnumerable
    {
        // the first element
        public ListNode head { get; private set; }
        // the last element
        public ListNode tail { get; private set; } 
        public int figuresQuantity { get; private set; }
        int count;
        public Func <ListNode , ListNode , ListNode> AddList;

        public LinkedList(bool flag)
        {
            if (flag)
            {
                Console.WriteLine("Enter a number of figures");
                int temp1 = 0;
                if (int.TryParse(Console.ReadLine(), out temp1))
                    figuresQuantity = temp1;
                else
                    temp1 = 0;
            }
        }

        public void AddAll()
        {
            Regex regex = new System.Text.RegularExpressions.Regex(@"(?<![0-9])[0-9](?![0-9])");
            for (int i = 0; i <= figuresQuantity - 1; i++)
            {
                Console.WriteLine("Enter a figure from 0 to 9");
                try
                {
                    var temp1 = int.Parse(Console.ReadLine());
                    if (!regex.IsMatch(temp1.ToString()))
                    {
                        throw new FormatException();
                    }
                    Add(temp1);
                }

                catch (FormatException)
                {
                    Console.WriteLine("Wrong format!!!");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // Reload of+ operator
        public static LinkedList operator +(LinkedList linkList1, LinkedList linkList2)
        {
            LinkedList resultList = new LinkedList(false);
            ListNode firstHead;
            ListNode secondHead;
            int[] maxValues = { linkList1.count, linkList2.count };
            int maxCount = maxValues.Max();
            bool isFirstMax = (linkList1.count == maxCount ? true : false);
            if (isFirstMax)
            {
                firstHead = linkList1.head;
                secondHead = linkList2.head;
            }
            else
            {
                firstHead = linkList2.head;
                secondHead = linkList1.head;
            }
            for (int i = 0; i <= maxCount - 1; i++)
            {
                resultList.Add(true, firstHead, secondHead);
                firstHead = firstHead.next;
                secondHead = secondHead.next;
                if (firstHead == null)
                {
                    firstHead = new ListNode(0);
                }
                else
                if (secondHead == null)
                {
                    secondHead = new ListNode(0);
                }
            }
            foreach (ListNode item in resultList)
            {
                if (item.Discharge!=0)
                {
                    item.next.val += item.Discharge;
                }
            }
            return resultList;
        }

        public static ListNode AddedNode(Func<ListNode, ListNode, ListNode> AddList, ListNode node1, ListNode node2)
        {            
            return AddList(node1, node2); ;
        }

        public   void Add<T>(T data, params ListNode[] arguments)
        {
            ListNode node;
            if (data is int)
            {
                node = new ListNode(int.Parse(data.ToString()));
            }
            else
            {
                node = new ListNode();
                node = AddedNode(ListNode.AddOur2Lists, arguments[0], arguments[1]);
            }


            if (head == null)
                head = node;
            else
                tail.next = node;
            tail = node;

            count++;
        }
               
        IEnumerator IEnumerable.GetEnumerator()
        {
            ListNode current = head;
            while (current != null)
            {
                yield return current;
                current = current.next;
            }
        }
    }
}

