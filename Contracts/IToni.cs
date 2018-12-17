using System;

namespace a1.TestsTypes
{
    public interface IToni
    {
        int GetScoreByBirthDateAndRowData(DateTime birthDate, int rowScore);
        int GetScoreByMonthsAgeAndRowData(int months, int rowScore);
        string GetTexualScore(int finalScore);
    }
}