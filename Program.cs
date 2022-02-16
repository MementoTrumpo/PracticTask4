using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomMatix();
            Console.WriteLine(SearchingMinElementInSequence());
            GuessTheNumber();

            Console.ReadKey();
        }



        /// <summary>
        /// Выводит на экран матрицу заданных размеров из случайных чисел и сумму всех ее элементов
        /// </summary>
        public static void RandomMatix()//Вывод матрицы из случайных целых чисел
        {
            Console.WriteLine("************ Программа для вывода случайной матрицы **************");
            Console.WriteLine("Введите пожалуйста количество стобцов вашей будущей матрицы");
            int column = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пожалуйста количество строк вашей будущей матрицы");
            int line = Convert.ToInt32(Console.ReadLine());
            int amountOfElements = 0;

            Random rand = new Random();

            for(int i = 0; i < column; i++)
            {
                for(int j = 0; j < line; j++)
                {
                    int num = rand.Next(0, 200);
                    Console.Write($"{num} ");
                    amountOfElements += num;
                }
                Console.Write("\n");
            }
            Console.WriteLine($"Сумма всех элементов матрицы равна: {amountOfElements}");
            
        }

        /// <summary>
        /// Поиск наименьшего числа в последовательности элементов
        /// </summary>
        /// <returns>Возвращает наименьшее число последновательности int значений</returns>
        public static int SearchingMinElementInSequence()
        {
            Console.WriteLine("*************** Программа для определения наименьшего значения в последовательности *****************");
            Console.WriteLine("Введите пожалуйста размер последовательности:");

            int size = Convert.ToInt32(Console.ReadLine());

            int[] sequence = new int[size];
            
            for (int i = 0; i < sequence.Length; i++)//Заполнение массива числами
            {
                sequence[i] = Convert.ToInt32(Console.ReadLine());
            }

            int min = int.MaxValue;
            for(int i = 0; i < sequence.Length; i++)//Поиск наименьшего числа
            {
                if(sequence[i] < min)
                {
                    min = sequence[i];
                }
            }
            return min;

        }

        /// <summary>
        /// Игра "Угадай число"
        /// </summary>
        public static void GuessTheNumber()//Игра "Угадай число"
        {
            Console.WriteLine("*************** Игра \"Угадай число\" ***************** ");

            Console.WriteLine("Введите число, которое будет верхней границей для числа, которое вам предстоит угадать: (нижней границей является 0 :)");
            int upperNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Вводите число до тех пор, пока не угадаете. Если же вы устали или вам надоело угадывать, просто нажмите Пробел, а затем Enter");

            Random rand = new Random();

            int randomNumber = rand.Next(0, upperNumber);

            while (true)
            { 
                string enteredNumber = Console.ReadLine();//Введенное пользователем числоы

                if(enteredNumber == " ")//Если игрок хочет выйти из игры
                {
                    Console.WriteLine("К сожаление, вы не смогли угадать загаданное число. Не хотите сыграть еше раз?");
                    Console.WriteLine("Введите YES, если хотите продолжить игру и NO, если окончательно хотите выйти из игры.");

                    string leaveGame = Console.ReadLine();//Строка проверки выхода из игры

                    if (leaveGame == "YES" && string.IsNullOrEmpty(leaveGame) == false)
                    {
                        Console.WriteLine("Введите пожалуйста новую верхнюю границу вашего числа:");
                        upperNumber = Convert.ToInt32(Console.ReadLine());//Задание новой верхней границы загаданного числа
                        randomNumber = rand.Next(0, upperNumber);
                        continue;
                    }
                    
                    else if(leaveGame == "NO" && string.IsNullOrEmpty(leaveGame) == false)
                    {
                        Console.WriteLine("Всего хорошего, надеюсь еще увидимся в нашей захватывающей игре!");
                        break;
                    }
                }
                else
                {
                    int enteredNum = Convert.ToInt32(enteredNumber);//Преобразование введенного числа к int

                    if (enteredNum > randomNumber && enteredNum.GetType() == typeof(int))//Проверка на то что введенное число больше загаданного
                    {
                        Console.WriteLine("Введенное число больше заданного. Попробуйте еще раз!");
                    }

                    else if (enteredNum < randomNumber && enteredNum.GetType() == typeof(int))//Проверка на то что введенное число меньше загаданного
                    {
                        Console.WriteLine("Введенное число меньше заданного. Попробуйте еще раз!");
                    }
                    else if (enteredNum == randomNumber && enteredNum.GetType() == typeof(int))//Проверка на равенство введенного числа и загаданного
                    {
                        Console.WriteLine("Ура! Поздравляем! Вы отгадали число. Хотите сыграть еше раз?");

                        Console.WriteLine("Введите YES, если хотите продолжить игру и NO, если окончательно хотите выйти из игры.");

                        string leaveGame = Console.ReadLine();//Строка проверки выхода из игры

                        if (leaveGame == "YES" && string.IsNullOrEmpty(leaveGame) == false)//Если игрок хочет продолжить играть
                        {
                            Console.WriteLine("Введите пожалуйста новую верхнюю границу вашего числа:");
                            upperNumber = Convert.ToInt32(Console.ReadLine());//Задание новой верхней границы загаданного числа
                            randomNumber = rand.Next(0, upperNumber);
                            continue;
                        }

                        else if (leaveGame == "NO" && string.IsNullOrEmpty(leaveGame) == false)//Если игрок хочет завершить игру окончательно
                        {
                            Console.WriteLine("Всего хорошего, надеюсь еще увидимся в нашей захватывающей игре!");
                            break;
                        }
                    }
                }
                
                
            }
            
        }

    }
}
