using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculateArithmeticExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = Regex.Replace(input, "\\(", "( ");
            input = Regex.Replace(input, "\\)", " )");
            string[] expression = input.Split(' ');

            Queue<string> forCalculation = ReversePolish(expression);
            Stack<string> result = new Stack<string>();

            while (forCalculation.Count>0)
            {
                string current = forCalculation.Dequeue();
                switch (current)
                {
                    case "/":
                        double second = double.Parse(result.Pop());
                        double first = double.Parse(result.Pop());
                        double divide = first/second;
                        result.Push(divide.ToString());
                        break;
                    case "*":
                        double f = double.Parse(result.Pop());
                        double s = double.Parse(result.Pop());
                        double multiple = f * s;
                        result.Push(multiple.ToString());
                        break;
                    case "+":
                        double addition = double.Parse(result.Pop()) + double.Parse(result.Pop());
                        result.Push(addition.ToString());
                        break;
                    case "-":
                        double sec = double.Parse(result.Pop());
                        double fir = double.Parse(result.Pop());
                        double minus = fir - sec;
                        result.Push(minus.ToString());
                        break;
                    default:
                        result.Push(current);
                        break;
                }
            }

            Console.WriteLine(result.Pop());
        }

        private static Queue<string> ReversePolish(string[] expression)
        {
            Queue<string> outputqQueue = new Queue<string>();
            Stack<string> operatorStack = new Stack<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case ")":
                        while (operatorStack.Peek()!="(")
                        {
                            outputqQueue.Enqueue(operatorStack.Pop());
                        }
                        operatorStack.Pop();
                        break;
                    case "(":
                        operatorStack.Push(expression[i]);
                        break;
                    case "/":
                    case "*":
                        if (operatorStack.Count==0)
                        {
                           operatorStack.Push(expression[i]);
                        }
                        else if (expression[i] == "*" && operatorStack.Peek() == "/")
                        {
                            outputqQueue.Enqueue(operatorStack.Pop());
                            operatorStack.Push(expression[i]);
                        }
                        else if (expression[i] == "/" && operatorStack.Peek() == "*")
                        {
                            outputqQueue.Enqueue(operatorStack.Pop());
                            operatorStack.Push(expression[i]);
                        }
                        else
                        {
                            operatorStack.Push(expression[i]);
                        }
                        break;
                    case "+":
                    case "-":
                        if (operatorStack.Count == 0)
                        {
                            operatorStack.Push(expression[i]);
                        }
                        else if (operatorStack.Peek() == "/" || operatorStack.Peek() == "*")
                        {
                            while (operatorStack.Peek() == "/" || operatorStack.Peek() == "*")
                            {
                                outputqQueue.Enqueue(operatorStack.Pop());
                            }

                            operatorStack.Push(expression[i]);
                        }
                        else
                        {
                            operatorStack.Push(expression[i]);
                        }
                        break;
                    default:
                        outputqQueue.Enqueue(expression[i]);
                        break;
                }
            }

            while (operatorStack.Count>0)
            {
                outputqQueue.Enqueue(operatorStack.Pop());
            }

            return outputqQueue;
        }
    }
}
