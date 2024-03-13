using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DialogueChoiceItem
{
    [SerializeField]
    public int index;
    [SerializeField]
    public string message;
    [SerializeField]
    public string author;
    [SerializeField]
    public string choiceIsNext;
    
}
