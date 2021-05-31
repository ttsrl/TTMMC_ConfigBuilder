using System;
using System.ComponentModel;
using System.Configuration;

namespace TTMMC_ConfigBuilder
{
    public struct DataItemFormat
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

        private Divisors thousandsD;
        private Divisors decimalsD;
        private int digits;
        private int decimals;
        private bool fillZero;
        private bool empty;

        public Divisors ThousandsDivisor { get => thousandsD; set => thousandsAssign(value); }
        public Divisors DecimalsDivisor { get => decimalsD; set => decimalsAssign(value); }
        public int Digits { get => digits; }
        public int Decimals { get => decimals; }
        public bool FillZero { get => fillZero; set => fillZero = value; }
        public bool IsEmpty { get => empty; set { setEmpty(value); empty = value; } }

        public DataItemFormat(int digits, int decimals)
        {
            fillZero = false;
            empty = false;

            if (digits <= 0)
                this.digits = 1;
            else
                this.digits = digits;
            if (decimals < 0 || decimals >= digits)
                this.decimals = 0;
            else
                this.decimals = decimals;
            decimalsD = Divisors.Point;
            thousandsD = Divisors.Null;
        }

        public static DataItemFormat Empty { get; } = new DataItemFormat() { IsEmpty = true };

        public string GetFormat()
        {
            if (empty)
                return "-";
            var str = thousandsD.GetDescription() + new String('0', digits - decimals);
            if (decimals > 0)
                str += decimalsD.GetDescription() + new String('0', decimals);
            if (fillZero)
                str = '#'.ToString() + str;
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
                if (format == "-")
                    return new DataItemFormat() { IsEmpty = true };
                var fillZ = format.Substring(0, 1) == "#";
                var thD = parseThousandsD(format);
                var digits = countDigits(format);
                var decD = parseDecimalsD(format);
                var decimals = countDecimals(format);
                return new DataItemFormat(digits, decimals) { FillZero = fillZ, ThousandsDivisor = thD, DecimalsDivisor = decD, IsEmpty = false };
            }
            catch { throw new Exception("parsing error"); };
        }

        public static bool TryParse(string format, out DataItemFormat dif)
        {
            try
            {
                dif = Parse(format);
                return true;
            }
            catch { dif = Empty; return false; };
        }

        public static string SetToData(string format, object data)
        {
            try
            {
                var di = Parse(format);
                return di.SetToData(data);
            }
            catch { return null; }
        }

        public string SetToData(object data)
        {
            if (empty)
                return data.ToString();
            var dt = data.GetType();
            if (dt == typeof(ushort) || dt == typeof(short) || dt == typeof(uint) || dt == typeof(int) || dt == typeof(ulong) || dt == typeof(long))
                return setToDataInt(data);
            else if (dt == typeof(float) || dt == typeof(double) || dt == typeof(decimal))
                return setToDataDouble(data);
            else
                return data.ToString();
        }

        public static T GetObject<T>(string format, string value)
        {
            try
            {
                var di = Parse(format);
                return di.GetObject<T>(value);
            }
            catch { throw new Exception("converting type error"); }
        }

        public T GetObject<T>(string value)
        {
            try
            {
                if (typeof(T) == typeof(ushort) || typeof(T) == typeof(short) || typeof(T) == typeof(uint) || typeof(T) == typeof(int) || typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
                {
                    var d = thousandsD.GetDescription();
                    var f = decimalsD.GetDescription();
                    if (d != "")
                        value = value.Replace(d, "");
                    if (f != "")
                        value = value.Replace(f, ",");
                    var val = Convert.ToDouble(value) * Math.Pow(10, decimals);
                    return (T)Convert.ChangeType(val, typeof(T));
                }
                else if (typeof(T) == typeof(float) || typeof(T) == typeof(double) || typeof(T) == typeof(decimal))
                {
                    var d = thousandsD.GetDescription();
                    var f = decimalsD.GetDescription();
                    if (d != "")
                        value = value.Replace(d, "");
                    if (f != "")
                        value = value.Replace(f, ",");
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                else
                    return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex) { throw new Exception("converting type error"); }
        }


        private string setToDataInt(object data)
        {
            try
            {
                int thousands = digits - decimals;
                double val = 0.0;
                bool tryd = double.TryParse(data.ToString(), out val);
                if (tryd)
                {
                    var valDec = (decimals > 0) ? val / getDivisor(decimals) : val;
                    string strFormat = (fillZero) ? new String('0', thousands) : "0";
                    strFormat += (decimals > 0) ? decimalsD.GetDescription() + new string('0', decimals) : "";
                    string maxFormat = new string('9', thousands);
                    maxFormat += (decimals > 0) ? "," + new string('9', decimals) : "";
                    var maxD = double.Parse(maxFormat);
                    if (valDec > maxD)
                        return strFormat.Replace('0', '#');
                    var fin = valDec.ToString(strFormat);
                    fin = fin.Replace(",", decimalsD.GetDescription());
                    if (thousandsD != Divisors.Null)
                        fin = getThousands(fin);
                    return fin;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        private string setToDataDouble(object data)
        {
            try
            {
                int thousands = digits - decimals;
                double val = 0.0;
                bool tryd = double.TryParse(data.ToString(), out val);
                if (tryd)
                {
                    string strFormat = (fillZero) ? new String('0', thousands) : "0";
                    strFormat += (decimals > 0) ? decimalsD.GetDescription() + new string('0', decimals) : "";
                    string maxFormat = new string('9', thousands);
                    maxFormat += (decimals > 0) ? "," + new string('9', decimals) : "";
                    var maxD = double.Parse(maxFormat);
                    if (val > maxD)
                        return strFormat.Replace('0', '#');
                    var fin = val.ToString(strFormat);
                    fin = fin.Replace(",", decimalsD.GetDescription());
                    if (thousandsD != Divisors.Null)
                        fin = getThousands(fin);
                    return fin;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        private void thousandsAssign(Divisors divisor)
        {
            if (divisor == Divisors.Null)
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

        private int getDivisor(int decimals)
        {
            return Convert.ToInt32(Math.Pow(10, decimals));
        }

        private string getThousands(string number)
        {
            string out_ = "";
            var start = (decimalsD.GetDescription() != "" && number.Contains(decimalsD.GetDescription())) ? number.IndexOf(decimalsD.GetDescription()) - 1 : number.Length - 1;
            int count = 0;
            for (var x = start; x >= 0; x--)
            {
                if (count == 3)
                {
                    out_ = number[x] + "," + out_;
                    count = 0;
                }
                else
                    out_ = number[x] + out_;
                count++;
            }
            return out_ + number.Substring(start + 1);
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
            foreach (var c in format)
            {
                if (c == '0')
                    res += 1;
            }
            if (res == 0)
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

        private void setEmpty(bool empty)
        {
            if (empty)
            {
                digits = 1;
                decimals = 0;
                decimalsD = Divisors.Point;
                thousandsD = Divisors.Null;
            }
        }

    }

}
