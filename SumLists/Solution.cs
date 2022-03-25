/*
You have two numbers represented by a linked list, where each node contains a single digit. 
The digits are stored in reverse order, such that the 1’s digit is at the head of the list. 
Write a function that adds the two numbers and returns the sum as a linked list.
(You are not allowed to "cheat" and just convert the linked list to an integer.)

EXAMPLE
 Input: (7->1->6) + (5->9->2). That is 617 + 295
 Output: 2->1->9. That is 912

*/
using System.Collections.Generic;

namespace SumLists
{
    public static class Solution
    {
        public static LinkedList<int> SumLists(LinkedList<int> number1, LinkedList<int> number2)
        {
            // Code goes here

            //dummy return
            var ret = new LinkedList<int>();
            ret.AddFirst(9);
            ret.AddFirst(1);
            ret.AddFirst(2);
            return ret;
        }


    }
}