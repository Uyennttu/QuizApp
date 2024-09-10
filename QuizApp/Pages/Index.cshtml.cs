using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Services;
using QuizApp.Models;

namespace QuizApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly QuizService _quizService;

        public IndexModel(QuizService quizService)
        {
           _quizService = quizService;
        }

        public List<Quiz> Quizzes { get; set; }

        public void OnGet()
        {
            Quizzes = _quizService.GetQuestions;

		}
    }
}
