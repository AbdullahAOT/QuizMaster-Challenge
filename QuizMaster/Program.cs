
namespace QuizMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                startQuiz();
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
        public static void startQuiz()
        {
            string question1 = "Question 1: In which year did Jordan become independant?";
            string question2 = "Question 2: In which year did king Abdullah || become the king of Jordan?";
            string question3 = "Question 3: In which year did Jordan football national team reach Asian cup final?";
            string question4 = "Question 4: In which year did the battle of Karameh happen?";
            string question5 = "Question 5: In which year was the university of Jordan established?";
            string[] arrayOfQuestions = new string[] { question1, question2, question3, question4, question5 };
            int answer1 = 1946;
            int answer2 = 1999;
            int answer3 = 2023;
            int answer4 = 1968;
            int answer5 = 1962;
            int[] arrayOfAnswers = new int[] { answer1, answer2, answer3, answer4, answer5 };
            int userMark = 0;
            string? start = null;
            while (start != "start")
            {
                Console.Clear();
                Console.WriteLine("Welcome to Jordan history quiz, type start then press Enter to start !");
                start = Console.ReadLine();
            }
            for (int i = 0; i < arrayOfQuestions.Length; i++)
            {
                Console.WriteLine(arrayOfQuestions[i]);
                int? userAnswer=null;
                bool userAnswerIsValid = false;
                while (userAnswerIsValid == false)
                {
                    try
                    {
                        userAnswer = Convert.ToInt32(Console.ReadLine());
                        userAnswerIsValid = true;
                    }
                    catch (Exception e)
                    {
                        string exMessage = e.Message.Replace(".", "");
                        Console.WriteLine($"{exMessage}, please re-enter your answer");
                    }
                }
                if (userAnswer == arrayOfAnswers[i])
                {
                    userMark += 2;
                    Console.WriteLine("Your answer is correct :)");
                }
                else
                {
                    Console.WriteLine($"Your answer is wrong, the right answer is {arrayOfAnswers[i]}");
                }
                if(userAnswer != arrayOfAnswers[i] || userAnswer == null)
                {
                    Console.WriteLine("Time is up, moving to next question");
                }
            }
            Console.WriteLine($"Your final mark is {userMark}");
        }
    }
}