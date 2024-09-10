using QuizApp.Models;

namespace QuizApp.Services
{
    public class QuizService
    {
        private readonly List<Quiz> _quizzes = new List<Quiz>
        {
            new Quiz(1,"What is the capital of Australia?", new List<string>{"Canberra","Sydney","Melbourne"}, "Canberra"),
            new Quiz(2,"How many states in Australia?",new List<string>{"3","5","7" }, "7"),
            new Quiz(3,"What programming language is the most popular in Australia?",new List<string>{"Java","C#","Python" }, "C#")
			/*new Quiz(4,"1+1?",new List<string>{"2","4","6" }, "2")*/
		};

        public List<Quiz> GetQuestions => _quizzes;

        public int CheckScore(List<int> quizIds, List<string> answers)
        {
            var score = 0;
            var selectedQuizzes = GetQuestions.Where(q => quizIds.Contains(q.Id))
                                                        .OrderBy(q => quizIds.IndexOf(q.Id))
                                                        .ToList();
            for (int i = 0; i < selectedQuizzes.Count; i++)
            {
                {
                    if (selectedQuizzes[i].CorrectAnswer == answers[i])
                    {

                        score++;
                    }
                }
            }
            return score;
        }

        public void DeleteQuiz(int quizId)
        {
            var quiz = _quizzes.FirstOrDefault(q => q.Id == quizId);
            if (quiz != null)
            {
                _quizzes.Remove(quiz);
            }

        }
        public void AddQuiz(Quiz quiz)
        {
            _quizzes.Add(quiz);
        }
        public void EditQuiz(int quizId, string newQuestion, List<string> newAnswers, string newCorrectAnswer)
        {
            var quiz = _quizzes.FirstOrDefault(q => q.Id == quizId);
            if (quiz != null)
            {
                quiz.Question = newQuestion;
                quiz.Answers = newAnswers;
                quiz.CorrectAnswer = newCorrectAnswer;
            }
        }
        public List<Quiz> GetRandomQuestions(int numberOfQuestions)
        {
            Random rng = new Random();
            return _quizzes.OrderBy(q => rng.Next()).Take(numberOfQuestions).ToList();
        }
    }


}