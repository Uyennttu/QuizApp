using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Pages
{
    public class QuizModel : PageModel
    {
        private readonly QuizService _quizService;

        public List<Quiz> Quizzies { get; set; }
        [BindProperty]
        public Dictionary<int,string> UserAnswers { get; set; }
       
        public int Score { get; set; }

        public QuizModel(QuizService quizService)
        {
            _quizService = quizService;
        }

        public void OnGet()
        {
            Quizzies = _quizService.GetQuestions;
        }

        public IActionResult OnPost() {
            List<int> quizIds = UserAnswers.Keys.ToList();
            List<string> userAnswers = UserAnswers.Values.ToList()  ;

            Score = _quizService.CheckScore(quizIds, userAnswers);
            return RedirectToPage("/Result", new { score = Score });
        }
    }
}