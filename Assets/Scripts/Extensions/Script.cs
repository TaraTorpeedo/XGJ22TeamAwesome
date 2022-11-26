using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Assets.Scripts.Extensions;

public struct Script
{

    public string MethodType { get; set; }
    public string Name { get; set; }
    public string ArgumentType { get; set; }
    public string Argument { get; set; }

    public string Member;
    public string MemberFunction;

    public Script(string methodType, string name, string argumentType, string argument, string member, string memberFunction)
    {
        MethodType = methodType;
        Name = name;
        ArgumentType = argumentType;
        Argument = argument;
        Member = member;
        MemberFunction = memberFunction;
    }

    public int CountCodeLength()
    {
        return MethodType.Length + MethodType.Length + Name.Length + ArgumentType.Length + Argument.Length + Member.Length + MemberFunction.Length;
    }

    public string GenerateMethodOfTypeT()
    {
        StringBuilder sb = new StringBuilder(MethodType.ApplyMethodTypeColor());
        sb.AddWhiteSpace();
        sb.Append(Name.ApplyPublicMethodColor());

        sb.AddWhiteSpace();

        sb.Append('(');
        sb.Append(ArgumentType.ApplyMethodTypeColor());

        sb.AddWhiteSpace();

        sb.Append(Argument.ApplyArgumentColor());
        sb.AppendLine(")");
        sb.AppendLine("{");

        sb.Indent();
        sb.Append(Member.ApplyPublicMethodColor());
        sb.WrapInAngleBrackets(MemberFunction.ApplyClassColor());

        sb.WrapInParenthesis(Argument.ApplyArgumentColor());

        sb.AddSemiColon();
        sb.AppendLine("}");


        return sb.ToString();
    }

    public string GenerateCode()
    {
        StringBuilder sb = new StringBuilder(MethodType.ApplyMethodTypeColor());
        sb.AddWhiteSpace();
        sb.Append(Name.ApplyPublicMethodColor());

        sb.AddWhiteSpace();

        sb.Append('(');
        sb.Append(ArgumentType.ApplyMethodTypeColor());

        sb.AddWhiteSpace();

        sb.Append(Argument.ApplyArgumentColor());
        sb.AppendLine(")");
        sb.AppendLine("{");

        sb.Indent();
        sb.Append(Member);
        sb.Append('.');
        sb.Append(MemberFunction.ApplyPublicMethodColor());
        sb.WrapInParenthesis(Argument.ApplyArgumentColor());

        sb.AddSemiColon();
        sb.AppendLine("}");


        return sb.ToString();
    }
    
    public string GetRawText()
    {
        StringBuilder sb = new StringBuilder(MethodType);
        sb.AddWhiteSpace();
        sb.Append(Name);

        sb.AddWhiteSpace();

        sb.Append('(');
        sb.Append(ArgumentType);

        sb.AddWhiteSpace();

        sb.Append(Argument);
        sb.AppendLine(")");
        sb.AppendLine("{");

        sb.Indent();
        sb.Append(Member);
        sb.Append('.');
        sb.Append(MemberFunction);
        sb.WrapInParenthesis(Argument);

        sb.AddSemiColon();
        sb.AppendLine("}");


        return sb.ToString();
    }

    public string PlaceholderText()
    {
        StringBuilder sb = new StringBuilder(MethodType.ApplyMethodTypeColor());
        sb.AddWhiteSpace();
        sb.Append(Name.ApplyPublicMethodColor());

        sb.AddWhiteSpace();

        sb.Append('(');
        sb.Append(ArgumentType.ApplyArgumentColor());

        sb.AddWhiteSpace();

        sb.Append(Argument);
        sb.AppendLine(")");
        sb.AppendLine("{");

        sb.Indent();
        sb.Append(Member);
        sb.Append('.');
        sb.Append(MemberFunction.ApplySuggestionColor());
        sb.WrapInParenthesis(Argument.ApplySuggestionColor());

        sb.AddSemiColon();
        sb.AppendLine("}");


        return sb.ToString();
    }

}
