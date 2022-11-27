using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Script Factory", menuName = "Custom/Script Factory")]
public class ScriptFactory : ScriptableObject
{

    public void CreateRandom(Script script)
    {

        script.MethodType = GetRandom(_methodTypes);
        script.Name = GetRandom(_names);
        script.ArgumentType = GetRandom(_argumentTypes);
        script.Argument = GetRandom(_arguments);
        script.Member = GetRandom(_members);
        script.MemberFunction = GetRandom(_memberFunctions);
        
    }

    public void CreateRandomOfTypeT(Script script)
    {

        script.MethodType = GetRandom(_methodTypes);
        script.Name = GetRandom(_names);
        script.ArgumentType = "";
        script.Argument = "";
        script.Member = GetRandom(_memberFunctions);
        script.MemberFunction = GetRandom(_names);
        
    }

    public string GetRandom(string[] strings)
    {
        int res = Random.Range(0, strings.Length);
        return strings[res];
    }

    public static readonly string[] _methodTypes = new string[]
    {
        "void", "protected void", "virtual void"
    };
    public static readonly string[] _names = new string[]
    {
        "Update", "Start", "FixedUpdate", "OnEnable", "OnDestroy", "OnPressTab", "OnJump", "OnCommitAtrocities", "OnInteract", "Toggle", "GetServices"
    };
    public static readonly string[] _argumentTypes = new string[]
    {
        "int", "float", "string", "bool"
    };
    public static readonly string[] _arguments = new string[]
    {
        "state", "value", "currentValue", "arg", "asf", "foo", "bar", "baz", "val", "x", "y", "jumpForce"
    };
    public static readonly string[] _members = new string[]
    {
        "_input", "direction", "_direction", "myActions", "rb", "rigidBody", "fooBar", "animator", "player", "_player", "myController", "_services", "_gameService"
    };
    public static readonly string[] _memberFunctions = new string[]
    {
        "TabAction", "AddForce", "Jump", "Move", "Destroy", "Collide"
        , "GetDataContainers", "Init", "GetComponent", "FindObjectOfType"
        , "CommitAtrocities", "Toggle"
    };

}
