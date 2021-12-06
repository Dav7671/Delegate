using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        delegate void Message();
        delegate int Calculator(int x, int y);
        delegate void GetMessage();
        delegate T Operation<T, K>(K val);

        static void Main(string[] args)
        {
            Message mes;
            if (DateTime.Now.Hour < 12)
            {
                mes = GoodMorning;
            }

            else
            {
                mes = GoodEvening;
            }
                mes();

            Message mes1 = Hello;
            mes1 += Hello;
            mes1 += Hello;
            mes1 += Hello;
            mes1 += Hello;
            mes1 -= Hello;
            mes1 += HowAreYou;
            Message mes2 = HowAreYou;
            Message mes3 = mes1 + mes2;

            mes1();

            Calculator calculate = Add; 
            int result = calculate(4, 5); 
            Console.WriteLine(result);

            calculate = Multiply;
            result = calculate(4, 5); 
            Console.WriteLine(result);

            Calculator calculate1 = Multiply;
            var res = calculate1?.Invoke(6, 8);
            Console.WriteLine(res);

            if (DateTime.Now.Hour < 12)
            {
                Show_Message(GoodMorning);
            }
            else
            {
                Show_Message(GoodEvening);
            }


            Operation<decimal, int> op = Square;
            var res1 = op?.Invoke(5);
            Console.WriteLine(res1);


            Account account = new Account(300);
            account.RegisterHandler(new Account.AccountStateHandler(Show_Message));
            account.Withdraw(100);
            account.Withdraw(150);


            Console.ReadKey();
        }
        private static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }
        static decimal Square(int n)
        {
            return n * n;
        }

        private static void Show_Message(GetMessage _del)
        {
            _del?.Invoke();
        }
        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static void Hello()
        {
            Console.WriteLine("Hello");
        }
        private static void HowAreYou()
        {
            Console.WriteLine("How are you?");
        }
    }

}