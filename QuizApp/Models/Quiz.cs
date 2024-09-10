namespace QuizApp.Models
{
	public class Quiz
	{
		public int Id { get; set; }
		public string Question { get; set; }
		public List<string> Answers { get; set; } 
		public string CorrectAnswer { get; set; } 
		public Quiz()
		{
			Answers = new List<string>();
		}
		public Quiz(int id, string question, List<string> answers, string correctAnswer) {
			Id = id;
			Question = question;
			Answers = answers;
			CorrectAnswer = correctAnswer;
		}
	}
}
