using System;
using System.Globalization;
using System.Linq;

namespace ImdbConsole
{
    class Validate
    {
        private static readonly Services _services = new Services();
        public static bool Year(string str)
        {
            if (int.TryParse(str, out int num))
            {
                if (num <= DateTime.Today.Year)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Date(string str)
        {
            try
            {
                Convert.ToDateTime(str, new CultureInfo("es-ES"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ProducerIndex(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool MovieIndex(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool NumberList(string[] strings)
        {
            try
            {
                strings.Select(int.Parse).ToList();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}