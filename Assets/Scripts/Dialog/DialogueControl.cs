using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [Header("Components")]
    public GameObject dialogueObj;

    public Image profileSprite;
    
    public Text speechText;

    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing;

    private int index;

    private string[] sentences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

    }

    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            // dialogue box
            dialogueObj.SetActive(true);
            sentences = txt;

            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }

}
