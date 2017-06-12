using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTask
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public int Discharge { get;private set; }

        public ListNode()
        {

        }

        public ListNode(int x) { val = x; }
        
        public ListNode(int x, int y)
        {
            val = x;
            Discharge = y;
        }
        public static ListNode operator +(ListNode l1, ListNode l2)
        {
            return new ListNode((l1.val + l2.val) >= 10 ? (l1.val + l2.val-10) : (l1.val + l2.val), (l1.val + l2.val)>=10?1:0);
        }

        public static  ListNode AddOur2Lists (ListNode l1, ListNode l2)
        {
            return l1+l2;
        }
            
    }
}
