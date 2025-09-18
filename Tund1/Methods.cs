namespace CSharpBasics.Tund1
{
    internal class Methods
    {
        public static float Calculator(float num1, float num2)
        {
            float result = num1 * num2;
            return result;
        }

        public static string GetMonthName(int num)
        {
            switch(num)
            {
                case 1: return "Jaanuar";
                case 2: return "Veebruar";
                case 3: return "Märts";
                case 4: return "Aprill";
                case 5: return "Mai";
                case 6: return "Juuni";
                case 7: return "Juuli";
                case 8: return "August";
                case 9: return "September";
                case 10: return "Oktoober";
                case 11: return "November";
                case 12: return "Detsember";
            }

            return "???";
        }

        public static string GetSeasonName(int monthNum)
        {
            if (monthNum <= 2 || monthNum == 12)
                return "Talv";

            if (monthNum >= 3 && monthNum <= 5)
                return "Kevad";

            if (monthNum >= 6 && monthNum <= 8)
                return "Suvi";

            if (monthNum >= 9 && monthNum <= 11)
                return "Sügis";

            return "???";
        }
    }
}
