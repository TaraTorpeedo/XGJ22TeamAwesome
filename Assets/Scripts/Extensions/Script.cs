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

    public static Script CreateRandom()
    {
        return new Script()
        {

            MethodType = GetRandom(_methodTypes),
            Name = GetRandom(_names),
            ArgumentType = GetRandom(_argumentTypes),
            Argument = GetRandom(_arguments),
            Member = GetRandom(_members),
            MemberFunction = GetRandom(_memberFunctions)
        };
    }

    public static Script CreateRandomOfTypeT()
    {
        return new Script()
        {

            MethodType = GetRandom(_methodTypes),
            Name = GetRandom(_names),
            ArgumentType = "",
            Argument = "",
            Member = GetRandom(_memberFunctions),
            MemberFunction = GetRandom(_names)
        };
    }

    public static string GetRandom(string[] strings)
    {
        return strings[Random.Range(0, strings.Length)];
    }

    static string[] _methodTypes = new string[]
    {
        "void", "protected void", "virtual void"
    };
    static string[] _names = new string[]
    {
        "Update", "Start", "FixedUpdate", "OnEnable", "OnDestroy", "OnPressTab", "OnJump", "OnCommitAtrocities", "OnInteract", "Toggle", "GetServices"
    };
    static string[] _argumentTypes = new string[]
    {
        "int", "float", "string", "bool"
    };
    static string[] _arguments = new string[]
    {
        "state", "value", "currentValue", "arg", "asf", "foo", "bar", "baz", "val", "x", "y", "jumpForce"
    };
    static string[] _members = new string[]
    {
        "_input", "direction", "_direction", "myActions", "rb", "rigidBody", "fooBar", "animator", "player", "_player", "myController", "_services", "_gameService"
    };
    static string[] _memberFunctions = new string[]
    {
        "TabAction", "AddForce", "Jump", "Move", "Destroy", "Collide"
        , "GetDataContainers", "Init", "GetComponent", "FindObjectOfType"
        , "CommitAtrocities", "Toggle"
    };



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
