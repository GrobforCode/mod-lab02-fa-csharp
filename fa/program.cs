using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }
    // Задача 1: ровно один '0' и хотя бы одна '1'
    public class FA1
    {
        // Состояния
        private static State q0 = new State() { Name = "q0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State q1 = new State() { Name = "q1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State q2 = new State() { Name = "q2", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State q3 = new State() { Name = "q3", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };
        private static State q4 = new State() { Name = "q4", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

        private State InitialState = q0;

        public FA1()
        {
            // q0 - начальное, ни одного нуля, ноль единиц
            q0.Transitions['0'] = q1;  // встретили единственный 0, единиц пока 0
            q0.Transitions['1'] = q2;  // встретили 1, нулей 0, единиц >=1

            // q1 - ровно один 0, единиц пока 0
            q1.Transitions['0'] = q4;  // второй 0 -> ошибка
            q1.Transitions['1'] = q3;  // добавили 1, теперь ровно один 0 и >=1 единица

            // q2 - нулей 0, единиц >=1
            q2.Transitions['0'] = q3;  // первый 0, теперь ровно один 0 и >=1 единица
            q2.Transitions['1'] = q2;  // ещё единицы

            // q3 - допускающее: ровно один 0 и >=1 единица
            q3.Transitions['0'] = q4;  // второй 0 -> ошибка
            q3.Transitions['1'] = q3;  // больше единиц ок

            // q4 - "мусорное" состояние: более одного 0
            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q4;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                if (!current.Transitions.TryGetValue(c, out State next))
                    return null; // недопустимый символ
                current = next;
            }
            return current.IsAcceptState;
        }
    }

    // Задача 2: нечетное количество '0' и нечетное количество '1'
    public class FA2
    {
        // Состояния: (чётность нулей, чётность единиц) - 00, 01, 10, 11
        private static State s00 = new State() { Name = "00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State s01 = new State() { Name = "01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State s10 = new State() { Name = "10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State s11 = new State() { Name = "11", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };

        private State InitialState = s00;

        public FA2()
        {
            s00.Transitions['0'] = s10; // 0 меняет чётность нулей
            s00.Transitions['1'] = s01; // 1 меняет чётность единиц

            s01.Transitions['0'] = s11;
            s01.Transitions['1'] = s00;

            s10.Transitions['0'] = s00;
            s10.Transitions['1'] = s11;

            s11.Transitions['0'] = s01;
            s11.Transitions['1'] = s10;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                if (!current.Transitions.TryGetValue(c, out State next))
                    return null;
                current = next;
            }
            return current.IsAcceptState;
        }
    }

    // Задача 3: содержит подстроку "11"
    public class FA3
    {
        private static State q0 = new State() { Name = "q0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State q1 = new State() { Name = "q1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        private static State q2 = new State() { Name = "q2", IsAcceptState = true,  Transitions = new Dictionary<char, State>() };

        private State InitialState = q0;

        public FA3()
        {
            q0.Transitions['0'] = q0; // ещё не видели 1
            q0.Transitions['1'] = q1; // увидели первую 1

            q1.Transitions['0'] = q0; // сброс, если после 1 идёт 0
            q1.Transitions['1'] = q2; // вторая 1 подряд -> допускаем

            q2.Transitions['0'] = q2; // уже допущено, остаёмся
            q2.Transitions['1'] = q2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                if (!current.Transitions.TryGetValue(c, out State next))
                    return null;
                current = next;
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
