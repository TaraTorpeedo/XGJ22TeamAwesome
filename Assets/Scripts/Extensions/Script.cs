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

    [TextArea(15,20)]
    public string CodeBlock;
    public string Member;
    public string MemberFunction;

    public string GenerateCode()
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
        sb.Append(MemberFunction.ApplyPublicMethodColor());
        sb.WrapInParenthesis(Argument.ApplyArgumentColor());

        sb.AddSemiColon();
        sb.AppendLine("}");
        return sb.ToString();
    }

}
