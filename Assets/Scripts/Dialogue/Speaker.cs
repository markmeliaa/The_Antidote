#pragma warning disable 0649
using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/New Speaker")]
public class Speaker : ScriptableObject
{
    [SerializeField] private string speakerName;
    [SerializeField] private Sprite speakerSprite;
    [SerializeField] private Sprite speakerBox;

    public string GetName()
    {
        return speakerName;
    }

    public Sprite GetSpeakerSprite()
    {
        return speakerSprite;
    }

    public Sprite GetSpeakerBox()
    {
        return speakerBox;
    }
}
