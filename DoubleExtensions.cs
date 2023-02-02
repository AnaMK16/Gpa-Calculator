namespace GpaCalculator.Api;

public static class DoubleExtensions
{
    public static double GetGps(this double score)
    {
        if (score <= 60 && score>51)
        {
            return 0.5;
        }
        if (score <= 70 && score>61)
        {
            return 1;
        }
        if (score <= 80 && score>71)
        {
            return 2;
        }
        if (score <= 90 && score>81)
        {
            return 3;
        }
        if (score <= 100 && score>91)
        {
            return 4;
        }
        return 0;
    }
}