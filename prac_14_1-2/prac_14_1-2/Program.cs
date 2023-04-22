using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace prac_14_1_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //zadanie 1
            /*try
            {
                Console.WriteLine("Введите вместимость стека");
                int n = int.Parse(Console.ReadLine());
                if (n < 0) throw new Exception("Error");
                Stack<double> st = new Stack<double>();
                for (int i = 1; i <= n; i++)
                {
                    st.Push(i);
                }
                Console.WriteLine($"Размерность стека {st.Count}");
                Console.WriteLine($"Верхний элемент стека {st.Peek()}");
                Console.Write($"Содержимое стека =  ");
                int col = st.Count;
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{st.Pop()} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Новая размерность стека {st.Count}");
                Console.ReadKey();

            }
            catch
            {
                Console.WriteLine("Неправильный ввод");
                Console.ReadKey();
            }*/


            //zadanie2
            try
            {
                Console.WriteLine("Введите математическое выражение");
                string expression = Console.ReadLine();
                StreamWriter sw = File.AppendText("t.txt");
                sw.WriteLine(expression);
                for (int i = 0; i < expression.Length; i++)
                {
                    if (Char.IsLetter(expression[i])) throw new Exception("Error");
                }
                //zadanie 2a
                Stack<char> st = new Stack<char>();
                bool balance = true;
                int ind = 0;
                while (ind < expression.Length && balance==true)
                {
                    char ch = expression[ind];
                    if (ch == '(') { st.Push(ch); }
                    else if (ch == ')')
                    {
                        if (st.Count == 0) { balance = false; }
                        else st.Pop();
                    }
                    ind++;
                }
                if (balance && st.Count == 0) { Console.WriteLine("Скобки сбалансированы"); }
                else if (st.Count == 0) { Console.WriteLine($"Возможно лишняя ) скобка в позиции {ind}"); }
                else { Console.WriteLine($"Возможна лишняя ( скобка в позиции {expression.Length - st.Count}"); }
                Console.ReadKey();

                //zadanie 2b
                Stack<char> st1 = new Stack<char>();
                for (int i = 0; i < expression.Length; i++)
                {
                    char ch = expression[i];
                    if (ch == '(') { st1.Push(ch); }
                    else if (ch == ')')
                    {
                        if (st1.Count > 0 && st1.Peek() == '(') { st1.Pop(); }
                        else { st1.Push(ch); }
                    }
                }
                
                if(expression.Length>0 && expression[0] == ')')
                {
                    expression=expression.Remove(0,1);
                }

                if(expression.Length > 0 && expression[expression.Length-1] == '(')
                {
                    expression = expression.Remove(expression.Length-1, 1);
                }

                while (st1.Count > 0)
                {
                    char ch = st1.Pop();
                    if (ch == '(') { expression += ')'; }
                    else if (ch == ')') { expression = expression.Remove(expression.LastIndexOf(')'), 1); }
                }
                sw.WriteLine(expression);
                Console.WriteLine($"Новое выражение: {expression} - записано");
                sw.Close();
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Неправильный ввод");
                Console.ReadKey();
            }

        }
    }
}
