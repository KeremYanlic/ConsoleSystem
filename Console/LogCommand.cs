using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Log Command", menuName = "Utilies/LogCommandSO")]
public class LogCommand : ConsoleCommand
{
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);
        Debug.Log(logText);

        return true;
    }

}
