using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogSettings : ScriptableObject
{
    
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentence> dialogues = new List<Sentence>();

}

[System.Serializable]
public class Sentence {

    public string actorName;

    public Sprite profile;

    public Language sentence;

}

[System.Serializable]
public class Language {

    public string portuguese;

    public string english;

    public string spanish;

}
