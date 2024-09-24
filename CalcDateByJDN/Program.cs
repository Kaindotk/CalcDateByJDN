namespace CalcDateByJDN;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Type date in next format: dd.mm.yyyy");
        string[] date = Console.ReadLine().Split('.');
        
        int day = Convert.ToInt32(date[0]);
        int month = Convert.ToInt32(date[1]);
        int year = Convert.ToInt32(date[2]);
        
        int nextDay = CalcJDN(year, month, day) + 1;
        
        PrintNextOneGregorianDate(nextDay);
    }

    static int CalcJDN(int year, int month, int day)
    {
        // Рахуємо коефіцієнти
        int a = (14 - month) / 12;

        int y = year + 4800 - a;

        int m = month + (12 * a) - 3;
        // ----------------------------
        
        // Рахуємо Юліанський день
        int jdn = day + (((153 * m) + 2) / 5) + (365 * y) + (y / 4) - (y / 100) + (y / 400) - 32045;
        // ----------------------------
        
        
        return jdn;
    }

    static void PrintNextOneGregorianDate(int jdn)
    {
        // Рахуємо коефіцієнти
        int a = jdn + 32044;

        int b = ((4 * a) + 3) / 146097;

        int c = a - ((146097 * b) / 4);

        int d = ((4 * c) + 3) / 1461;
        
        int e = c - ((1461 * d) / 4);

        int m = ((5 * e) + 2) / 153;
        // ----------------------------
        
        
        // Рахуємо дату Григоріанського календаря
        int day = e - (((153 * m) + 2) / 5) + 1;

        int month = m + 3 - 12 * (m / 10);

        int year = (100 * b) + d - 4800 + (m / 10);
        // ----------------------------
        
        Console.WriteLine($"The next date is: {day}.{month}.{year}.");
        
    }
}
