using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(ActivityLogger logger)
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            logger)
    { }

    protected override void PerformActivity()
    {
        int elapsed = 0;

        while (elapsed < DurationSeconds)
        {
            Console.Write("\nBreathe in... ");
            int inhale = Math.Min(4, DurationSeconds - elapsed);
            ShowCountdown(inhale);
            elapsed += inhale;

            if (elapsed >= DurationSeconds) break;

            Console.Write("\nBreathe out... ");
            int exhale = Math.Min(6, DurationSeconds - elapsed);
            ShowCountdown(exhale);
            elapsed += exhale;
        }
    }
}
