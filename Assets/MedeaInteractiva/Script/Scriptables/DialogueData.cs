using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/DialogueData")]
public class DialogueData : ScriptableObject
{
    public Sprite spriteMoment;
    public Dialogue[] dialogue;    
}

[System.Serializable]
public struct Dialogue
{
    [TextArea(4,4)] public string dialogue;
    public AudioClip audio;
}
