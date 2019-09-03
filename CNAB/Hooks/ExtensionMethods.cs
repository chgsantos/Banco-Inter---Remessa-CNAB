using System;
using System.Text.RegularExpressions;

namespace CNAB.Hooks
{
    public static class ExtensionMethods
    {
        public static string SomenteNumeros(this string input)
        {
            return Regex.Replace(input, "[^0-9]", "");
        }

        public static string LimiteCaracteresEsquerda(this string input, int limite, char caractere)
        {
            return input
                .LimiteCaracteres(limite)
                .PadLeft(limite, caractere);
        }

        public static string LimiteCaracteresDireita(this string input, int limite, char caractere)
        {
            return input
                .LimiteCaracteres(limite)
                .PadRight(limite, caractere);
        }
        
        public static string LimiteCaracteres(this string input, int limite)
        {
            return input.Substring(0, input.Length > limite ? limite : input.Length);
        }

        public static string FormatarValor(this decimal input, int limite, char caractere)
        {
            return $"{(input * 100):0}".LimiteCaracteresEsquerda(limite, caractere);
        }

        public static string FormatarData(this DateTime input)
        {
            return input.ToString("ddMMyyyy");
        }

        public static string FormatarDataHora(this DateTime input)
        {
            return input.ToString("ddMMyyyyHHmmss");
        }
    }
}