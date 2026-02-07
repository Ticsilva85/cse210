public class ReflectionActivity : Activity
{
    // Extra creativity: do not repeat prompts/questions until all have been used once.
    private readonly NonRepeatingPicker<string> _promptPicker;
    private readonly NonRepeatingPicker<string> _questionPicker;

    public ReflectionActivity(ActivityLogger logger)
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            logger)
    {
        _promptPicker = new NonRepeatingPicker<string>(new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });

        _questionPicker = new NonRepeatingPicker<string>(new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        });
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {_promptPicker.Next()} ---");

        Console.Write("\nWhen you have something in mind, press Enter to continue... ");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < end)
        {
            string question = _questionPicker.Next();
            Console.Write($"\n> {question} ");
            ShowSpinner(6); // pause with spinner after each question
        }
    }
}
