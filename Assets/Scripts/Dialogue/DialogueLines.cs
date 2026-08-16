using System;
using UnityEngine;

[System.Serializable]
public class DialogueLines
{
    public string name;
    public Sprite leftSprite;
    public Sprite rightSprite;
    [TextArea(3,5)]
    public string sentence;
    public bool onLeft;
}
