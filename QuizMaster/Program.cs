using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace QuizMaster
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await StartQuiz();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Quiz was taken successfully");
            }
        }

        private static async Task StartQuiz()
        {
            string question1 = "Question 1: In which country is Eiffel tower?";
            string question2 = "Question 2: What is the country known for making pizza?";
            string question3 = "Question 3: Which country won the last world cup in Qatar in 2022?";
            string question4 = "Question 4: What is the country that London is its capital?";
            string question5 = "Question 5: What is the country that doesn't exist?";
            string[] arrayOfQuestions = new string[] { question1, question2, question3, question4, question5 };
            string answer1 = "France";
            string answer2 = "Italy";
            string answer3 = "Argentina";
            string answer4 = "England";
            string answer5 = "Israel";
            string[] arrayOfAnswers = new string[] { answer1, answer2, answer3, answer4, answer5 };
            int userMark = 0;
            string start = "";

            Console.WriteLine("Welcome to countries quiz, you have 10 seconds to answer each question, type start then press Enter to start !");
            start = Console.ReadLine();
            while (start != "start")
            {
                Console.Clear();
                Console.WriteLine("Welcome to countries quiz, you have 10 seconds to answer each question, type start then press Enter to start !");
                start = Console.ReadLine();
            }

            for (int i = 0; i < arrayOfQuestions.Length; i++)
            {
                Console.WriteLine(arrayOfQuestions[i]);
                string userAnswer = await GetAnswerWithTimeout(10000);

                if (userAnswer == null)
                {
                    Console.WriteLine("Time's up, no answer provided. Moving to the next question.");
                    continue;
                }

                while (Regex.IsMatch(userAnswer, @"[^a-zA-Z]"))
                {
                    Console.WriteLine("Please enter a valid answer, do not use anything other than letters");
                    userAnswer = await GetAnswerWithTimeout(10000);
                    if (userAnswer == null)
                    {
                        Console.WriteLine("Time's up, no valid answer provided. Moving to the next question.");
                        break;
                    }
                }

                if (userAnswer != null && userAnswer.ToLower() == arrayOfAnswers[i].ToLower())
                {
                    userMark += 2;
                    Console.WriteLine("Your answer is correct :)");
                }
                else
                {
                    Console.WriteLine("Your answer is wrong :(");
                }
            }

            switch (userMark)
            {
                case 10:
                    Console.WriteLine($"Your final mark is {userMark}, Your countries knowledge is GREAT !");
                    break;
                case 8:
                    Console.WriteLine($"Your final mark is {userMark}, Your countries knowledge is very good !");
                    break;
                case 6:
                    Console.WriteLine($"Your final mark is {userMark}, Your countries knowledge is not that bad ;)");
                    break;
                case 4:
                    Console.WriteLine($"Your final mark is {userMark}, Your countries knowledge needs to be improved");
                    break;
                case 2:
                    Console.WriteLine($"Your final mark is {userMark}, Your countries knowledge is similar to my knowledge in kitchen XD");
                    break;
                default:
                    Console.WriteLine($"Your final mark is {userMark}, Bruh, do you even know what country you live in?");
                    break;
            }
        }

        private static async Task<string> GetAnswerWithTimeout(int timeout)
        {
            Task<string> getInputTask = Task.Run(() => Console.ReadLine());
            if (await Task.WhenAny(getInputTask, Task.Delay(timeout)) == getInputTask)
            {
                return await getInputTask;
            }
            else
            {
                return null;
            }
        }
    }
}
