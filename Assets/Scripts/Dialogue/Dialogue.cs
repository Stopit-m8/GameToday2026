using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public List<DialogueLines> dialogueLines = new();
    public bool changeScene;
    public string sceneName;
}
