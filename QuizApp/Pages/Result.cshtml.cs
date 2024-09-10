using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Pages
{
    public class ResultModel : PageModel
    {
        public int Score { get; set; }

		private readonly QuizService _quizService;

		public List<Quiz> Quizzies { get; set; }

        public ResultModel(QuizService quizService)
        {

        _quizService = quizService; }
		public void OnGet(int score)
        {
            Score = score;
            Quizzies = _quizService.GetQuestions;

		}
    }
}
