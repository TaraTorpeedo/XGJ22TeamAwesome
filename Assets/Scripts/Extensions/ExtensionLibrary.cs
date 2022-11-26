using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Extensions
{


    public static class ExtensionLibrary
    {
        static string _colorTag = "<color=";
        static string _colorClosingTag = "</color>";

        static string _methodTypeColor = "#569cd6";
        static string _methodNameColor = "#dcdca0"; //yellow
        static string _classColor = "#4ec9b0"; // green
        static string _interfaceColor = "#86be72"; //light green
        static string _argumentColor = "#9cdcfe"; //light blue
        static string _stringColor = "#d59d85";
        static string _returnColor = "#d8a0df";
        static string _autocomplete = "#7d7d7d";
        static string AppendColor(string color)
        {
            return _colorTag + color + ">";
        }

        public static string ApplyMethodTypeColor(this string str)
        {
            return AppendColor(_methodTypeColor) + str + _colorClosingTag;
        }

        public static string ApplyPublicMethodColor(this string str)
        {
            return AppendColor(_methodNameColor) + str + _colorClosingTag;
        }

        public static string ApplyClassColor(this string str)
        {
            return AppendColor(_classColor) + str + _colorClosingTag;
        }

        public static string ApplyInterfaceColor(this string str)
        {
            return AppendColor(_interfaceColor) + str + _colorClosingTag;
        }

        public static string ApplyArgumentColor(this string str)
        {
            return AppendColor(_argumentColor) + str + _colorClosingTag;
        }

        public static string ApplyStringColorAndQuotes(this string str)
        {
            return AppendColor(_stringColor) + "\"" + str + "\""+ _colorClosingTag;
        }

        public static string ApplyReturnColor(this string str)
        {
            return AppendColor(_returnColor) + str + _colorClosingTag;
        }
        public static string ApplySuggestionColor(this string str)
        {
            return AppendColor(_autocomplete) + str + _colorClosingTag;
        }


        public static void Indent(this StringBuilder sb)
        {
            sb.Append("".PadLeft(5));
        }
        public static void AddWhiteSpace(this StringBuilder sb)
        {
            sb.Append(' ');
        }
        public static void AddSemiColon(this StringBuilder sb)
        {
            sb.AppendLine(";");
        }

        public static void WrapInParenthesis(this StringBuilder sb, string value)
        {
            sb.Append('(');
            sb.Append(value);
            sb.Append(')');
        }

        public static void WrapInAngleBrackets(this StringBuilder sb, string value)
        {
            sb.Append('<');
            sb.Append(value);
            sb.Append('>');
        }
    }

}