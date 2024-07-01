namespace Sorting_Program_Prototype;
using System;

public class TimeCalculator
{
    static void Main6(string[] args)
    {
        
    }

    
    public static void AddTimeTogether(string time1, string time2) //input format should be dd:hh:mm:ss
    {
        // Split the time values into days, hours, minutes, and seconds
        string[] time1Parts = time1.Split(':');
        string[] time2Parts = time2.Split(':');

        // Convert the time parts to integers
        int days1 = Convert.ToInt32(time1Parts[0]);
        int hours1 = Convert.ToInt32(time1Parts[1]);
        int minutes1 = Convert.ToInt32(time1Parts[2]);
        int seconds1 = Convert.ToInt32(time1Parts[3]);

        int days2 = Convert.ToInt32(time2Parts[0]);
        int hours2 = Convert.ToInt32(time2Parts[1]);
        int minutes2 = Convert.ToInt32(time2Parts[2]);
        int seconds2 = Convert.ToInt32(time2Parts[3]);

        // Add the time values
        int totalDays = days1 + days2;
        int totalHours = hours1 + hours2;
        int totalMinutes = minutes1 + minutes2;
        int totalSeconds = seconds1 + seconds2;

        // Adjust for overflow
        totalDays += totalHours / 24;
        totalHours %= 24;

        totalDays += totalMinutes / 1440;
        totalMinutes %= 1440;

        totalDays += totalSeconds / 86400;
        totalSeconds %= 86400;

        // Output the total time
        Console.WriteLine("Total time: " + totalDays + ":" + totalHours + ":" + totalMinutes + ":" + totalSeconds);
    }

    public static void FloatToTimeConversion(string floatTime)
    {
        float timeValue = float.Parse(floatTime);

        // Convert the float time value to hours, minutes, and seconds
        int hours = (int)timeValue;
        int minutes = (int)((timeValue - hours) * 60);
        int seconds = (int)((((timeValue - hours) * 60) - minutes) * 60);

        // Print the time in the proper format
        Console.WriteLine("Time: {0}:{1}:{2}", hours, minutes, seconds);
    }
}