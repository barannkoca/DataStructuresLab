using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParentheses 
{
    class MyStack<T>
    {
        private List<T> items;

        public MyStack()
        {
            items = new List<T>();
        }

        public int Count()
        {
            return items.Count;
        }
        public bool IsEmpty()
        {
            return Count() == 0;
        }
        public void Push(T item) { items.Add(item); }
        public T Pop() 
        {
            if (!IsEmpty()) {
                T item = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                return item;
            }
            else
            {
                throw new Exception("Stack is empty");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValid = IsValidParenthesis("(({}[]))");
            Console.WriteLine(isValid);
            Console.WriteLine(tersCevir("abcdef"));
            Console.ReadKey();
        }

        public static bool IsValidParenthesis(String str)
        {
            MyStack<char> stack = new MyStack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count() == 0)
                    {
                        return false;
                    }
                    char pop = stack.Pop();
                    if (pop == '(' && c != ')' || pop == '[' && c != ']' || pop == '{' && c != '}')
                    {
                        return false;
                    }
                }
            }
            if (stack.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static String tersCevir(String str)
        {
            String reversed = "";
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                stack.Push((char)str[i]);
            }
            while (stack.Count() > 0)
            {
                reversed += stack.Pop();
            }
            return reversed;
        }
    }
}
