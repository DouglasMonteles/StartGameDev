using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Security.Cryptography;

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

#if UNITY_EDITOR

[CustomEditor(typeof(DialogSettings))]
public class BuilderEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSettings dialogSettings = (DialogSettings) target;

        Language languageSettings = new Language();
        languageSettings.portuguese = dialogSettings.sentence;

        Sentence sentenceSettings = new Sentence();
        sentenceSettings.profile = dialogSettings.speakerSprite;
        sentenceSettings.sentence = languageSettings;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (dialogSettings.sentence != "")
            {
                dialogSettings.dialogues.Add(sentenceSettings);

                // clear fields
                dialogSettings.speakerSprite = null;
                dialogSettings.sentence = "";
            }
        }
    }

}

#endif
