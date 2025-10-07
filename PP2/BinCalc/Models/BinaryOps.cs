using System;
using System.Collections.Generic;

namespace BinCalc.Models
{
    public static class BinaryOps
    {
        public static string PadToByte(string bin) =>
            string.IsNullOrEmpty(bin) ? "00000000" :
            bin.Length >= 8 ? bin.PadLeft(bin.Length, '0')[^8..] : bin.PadLeft(8, '0');

        public static string NormalizeLeft(string a, string b, char padChar = '0')
        {
            int max = Math.Max(a.Length, b.Length);
            return a.PadLeft(max, padChar);
        }

        public static void NormalizeBoth(ref string a, ref string b)
        {
            int max = Math.Max(a.Length, b.Length);
            a = a.PadLeft(max, '0');
            b = b.PadLeft(max, '0');
        }

        // Operaciones bit a bit sobre strings (sin Convert)
        public static string And(string a, string b)
        {
            NormalizeBoth(ref a, ref b);
            var chars = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
                chars[i] = (a[i] == '1' && b[i] == '1') ? '1' : '0';
            return TrimLeadingZeros(new string(chars));
        }

        public static string Or(string a, string b)
        {
            NormalizeBoth(ref a, ref b);
            var chars = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
                chars[i] = (a[i] == '1' || b[i] == '1') ? '1' : '0';
            return TrimLeadingZeros(new string(chars));
        }

        public static string Xor(string a, string b)
        {
            NormalizeBoth(ref a, ref b);
            var chars = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
                chars[i] = (a[i] != b[i]) ? '1' : '0';
            return TrimLeadingZeros(new string(chars));
        }

        // Aritméticas
        public static int ToInt(string bin) => Convert.ToInt32(bin, 2);
        public static string FromIntToBin(int val) => Convert.ToString(val, 2);

        public static string Sum(string a, string b)
        {
            int r = ToInt(a) + ToInt(b);
            return FromIntToBin(r);
        }

        public static string Product(string a, string b)
        {
            int r = ToInt(a) * ToInt(b);
            return FromIntToBin(r);
        }

        // Conversión de bases para mostrar en tabla
        public static string ToOct(string bin)  => Convert.ToString(ToInt(bin), 8);
        public static string ToDec(string bin)  => ToInt(bin).ToString();
        public static string ToHex(string bin)  => Convert.ToString(ToInt(bin), 16).ToUpperInvariant();

        // Mostrar "0" en vez de vacío
        public static string TrimLeadingZeros(string bin)
        {
            if (string.IsNullOrEmpty(bin)) return "0";
            var t = bin.TrimStart('0');
            return string.IsNullOrEmpty(t) ? "0" : t;
        }
    }
}
