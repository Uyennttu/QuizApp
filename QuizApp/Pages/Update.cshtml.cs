using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Services;

namespace QuizApp.Pages
{
    public class UpdateModel : PageModel
    {
		public readonly QuizService _quizService;
		public UpdateModel(QuizService quizService)
		{
			_quizService = quizService;
		}
		//Binding update
		[BindProperty]
		public string Question { get; set; }
		[BindProperty]
		public string Answers { get; set; }
		[BindProperty]
		public string CorrectAnswer { get; set; }
		[BindProperty(SupportsGet = true)]
		public int Id { get; set; }

		public void OnGet(int id)
		{
			// Find the quiz with the given ID
			var quiz = _quizService.GetQuestions.FirstOrDefault(q => q.Id == id);
			if (quiz != null)
			{
				// Populate the fields with quiz data
				Question = quiz.Question;
				Answers = string.Join(",", quiz.Answers);
				CorrectAnswer = quiz.CorrectAnswer;
			}
		}
        public IActionResult OnPostEdit()
        {
            // Split the answers string into a list
            var answersList = Answers?.Split(',').Select(a => a.Trim()).ToList() ?? new List<string>();
            _quizService.EditQuiz(Id, Question, answersList, CorrectAnswer);

            // Redirect back to the questions list after saving
            return RedirectToPage("/Questions");
        }

    }
}
