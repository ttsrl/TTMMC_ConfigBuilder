using System;
using System.ComponentModel;
using System.Configuration;

namespace TTMMC_ConfigBuilder
{
    public class DataItemFormat
    {

        public enum Divisors
        {
            [Description("")]
            Null,
            [Description(",")]
            Comma,
            [Description(".")]
            Point
        }

        private char fillZeroChar = '#';
        private static string emptyFormat = "-";

        private Divisors thousandsD;
        private Divisors decimalsD;
        private int digits = 1;
        private int decimals = 0;
        private bool fillZero = false;
        private bool empty = false;

        public Divisors ThousandsDivisor { get => thousandsD; set => thousandsAssign(value); }
        public Divisors  DecimalsDivisor { get => decimalsD; set => decimalsAssign(value); }
        public int Digits { get => digits; set { digits = (value <= 0) ? digits : value; } }
        public int Decimals { get => decimals; set { decimals = (value < 0 || value >= digits || decimalsD == Divisors.Null) ? 0 : value; } }
        public bool FillZero { get => fillZero; set => fillZero = value; }
        public bool IsEmpty { get => empty; set => empty = value; }

        public static DataItemFormat Empty { get; } = new DataItemFormat() { IsEmpty = true };

        private void thousandsAssign(Divisors divisor)
        {
            if(divisor == Divisors.Null)
            {
                thousandsD = divisor;
                return;
            }
            if (decimalsD != Divisors.Null && divisor == decimalsD)
            {
                if (divisor == Divisors.Comma)
                    decimalsD = Divisors.Point;
                else if (divisor == Divisors.Point)
                    decimalsD = Divisors.Comma;
            }
            thousandsD = divisor;
        }

        private void decimalsAssign(Divisors divisor)
        {
            if (divisor == Divisors.Null)
            {
                decimalsD = divisor;
                return;
            }
            if (thousandsD != Divisors.Null && divisor == thousandsD)
            {
                if (divisor == Divisors.Comma)
                    thousandsD = Divisors.Point;
                else if (divisor == Divisors.Point)
                    thousandsD = Divisors.Comma;
            }
            decimalsD = divisor;
        }

        public string GetFormat()
        {
            if (empty)
                return emptyFormat;
            var str = thousandsD.GetDescription() + new String('0', digits - decimals);
            if (decimals > 0)
                str += decimalsD.GetDescription() + new String('0', decimals);
            if (fillZero)
                str = fillZeroChar.ToString() + str;
            return str;
        }

        public override string ToString()
        {
            return GetFormat();
        }

        public static DataItemFormat Parse(string format)
        {
            try
            {
                if (format == emptyFormat)
                    return new DataItemFormat() { IsEmpty = true };
                var fillZ = format.Substring(0, 1) == "#";
                var thD = parseThousandsD(format);
                var digits = countDigits(format);
                var decD = parseDecimalsD(format);
                var decimals = countDecimals(format);
                return new DataItemFormat() { FillZero = fillZ, ThousandsDivisor = thD, Digits = digits, DecimalsDivisor = decD, Decimals = decimals, IsEmpty = false };
            }
            catch { throw new Exception("parsing error"); };
        }

        private static Divisors parseThousandsD(string format)
        {
            try
            {
                var index0 = format.IndexOf("0");
                if (index0 > 0)
                {
                    var bef0 = format.Substring(index0 - 1, 1);
                    if (bef0 == ",")
                        return Divisors.Comma;
                    else if (bef0 == ".")
                        return Divisors.Point;
                    else
                        return Divisors.Null;
                }
                else
                    return Divisors.Null;
            }
            catch { throw new Exception("parse thousands divisor error"); }
        }

        private static Divisors parseDecimalsD(string format)
        {
            try
            {
                var indexF0 = format.IndexOf("0");
                for (var i = indexF0; i < format.Length; i++)
                {
                    if (format[i] == '.')
                        return Divisors.Point;
                    else if (format[i] == ',')
                        return Divisors.Comma;
                }
                return Divisors.Null;
            }
            catch { throw new Exception("parse decimals divisor error"); }
        }

        private static int countDigits(string format)
        {
            int res = 0;
            foreach(var c in format)
            {
                if (c == '0')
                    res += 1;
            }
            if(res == 0)
                throw new Exception("count digits error");
            return res;
        }

        private static int countDecimals(string format)
        {
            try
            {
                var indexF0 = format.IndexOf("0");
                var decIndex = 0;
                for (var i = indexF0; i < format.Length; i++)
                {
                    if (format[i] == '.' || format[i] == ',')
                    {
                        decIndex = i + 1;
                        break;
                    }
                }
                if (decIndex == 0)
                    return 0;
                else
                    return format.Length - decIndex;
            }
            catch { throw new Exception("parse decimals divisor count"); }
        }

    }
}
