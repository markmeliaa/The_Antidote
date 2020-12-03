using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker;
    [TextArea]
    public string dialogue;
    public Speaker listener1;
    [TextArea]
    public string dialogue2;
    public Speaker listener2;
    [TextArea]
    public string dialogue3;
}