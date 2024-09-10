using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Pages
{
    public class QuestionsModel : PageModel
    {
        public readonly QuizService _quizService;
        public QuestionsModel(QuizService quizService)
        {
            _quizService = quizService;
        }
        public List<Quiz> Quizzies { get; set; }

        //Binding New Quiz
        [BindProperty]
        public Quiz NewQuiz { get; set; }
        [BindProperty]
        public string NewQuizAnswerList { get; set; }

        


		public void OnGet()
        {
            Quizzies = _quizService.GetQuestions;

        }
        public IActionResult OnPostDelete(int id)
        {
            _quizService.DeleteQuiz(id);
            return RedirectToPage();

        }
        public IActionResult OnPostAdd()
        {
            var answers = NewQuizAnswerList.Split(',').ToList();
            NewQuiz.Id = _quizService.GetQuestions.Count + 1;
            NewQuiz.Answers = answers;
            _quizService.AddQuiz(NewQuiz);
            return RedirectToPage();

		}
       
    }
}
