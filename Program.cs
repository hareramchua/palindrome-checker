using System;
using System.Collections;
public class SamplesStack
{
    public static void Main()
    {
        int option = 0;
        do
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("PDA Menu");
            Console.WriteLine("1. Balance Symbols");
            Console.WriteLine("2. Palindrome");
            Console.WriteLine();
            Console.Write("Select Option 1 or 2: ");
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    BalanceSymbol();
                    break;
                case 2:
                    Palindrome();
                    break;
                default:
                    break;
            }
        } while (option < 3);
    }
    private static void BalanceSymbol()
    {
        // Creates and initializes a new Stack.
        Stack<char> myStack = new Stack<char>();
        Console.WriteLine("Please do not enter any blank lines.");
        Console.Write("Enter punctuation: ");
        string text = Console.ReadLine();
        int i;
        bool checker = false;
        for (i = 0; i < text.Length; i++)
        {
            if (text[i] == '(' || text[i] == '{' || text[i] == '[')
            {
                myStack.Push(text[i]);                
            }
            else
            {
                if (myStack.Count != 0) //stack has elements
                {
                    if (text[i] == ')' && myStack.Pop() == '(')
                    {
                        checker = true;
                        continue;
                    }
                    if (text[i] == '}' && myStack.Pop() == '{')
                    {
                        checker = true;
                        continue;
                    }
                    if (text[i] == ']' && myStack.Pop() == '[')
                    {
                        checker = true;
                        continue;
                    }                    
                    checker = false;
                    break;
                }
                else //if empty
                {
                    if (text[i] == ')' || text[i] == '}' || text[i] == ']')
                    {
                        checker = false;
                        break;
                    }
                    else
                    {
                        checker = true;
                        break;
                    }
                }
            }
        }
        // Displays the Stack.
        Console.WriteLine("-------------------------------");
        Console.Write("Stack result:");
        PrintValues(myStack, '\t');
        if (myStack.Count != 0)
        {
            Console.WriteLine("Unbalanced");
        }
        else
        {
            if (checker == false)
            {
                Console.WriteLine("Unbalanced");
            }
            else
            {
                Console.WriteLine("Balanced");
            }
        }
    }

    private static void Palindrome()
    {
        // Creates and initializes a new Stack.
        Stack<char> myStack = new Stack<char>();
        Console.WriteLine("Please do not enter any blank lines.");
        Console.Write("Enter a word: ");
        string text = Console.ReadLine();
        int i;
        for (i = 0; i < text.Length; i++)
        {
            myStack.Push(text[i]);
        }
        if (isPalindrome(myStack,text) == true)
        {
            Console.WriteLine("Palindrome");
        }
        else
        {
            Console.WriteLine("Not Palindrome");
        }
    }

    private static bool isPalindrome(Stack<char> myStack, string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (myStack.Pop() != input[i])
            {
                return false;
            }
        }
        return true;
    }

    public static void PrintValues(IEnumerable myCollection, char mySeparator)
    {
        foreach (Object obj in myCollection)
            Console.Write("{0}{1}", mySeparator, obj);
        Console.WriteLine();
    }
}