using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [System.Serializable]
    public enum Idiom {
        PT_BR,
        ENG,
        SPA,
    }

    public Idiom language;

    public static DialogueControl INSTANCE;

    [Header("Components")]
    public GameObject dialogueObj;

    public Image profileSprite;
    
    public Text speechText;

    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    [HideInInspector]
    public bool isShowing;

    private int index;

    private string[] sentences;

    private List<string> actorNames;

    private List<Sprite> actorSprites;

    private Player player;

    void Awake()
    {
        INSTANCE = this;
        player = FindFirstObjectByType<Player>();
    }

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
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;

                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                // theres no more dialogue text
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;

                player.isPaused = false;
            }
        }
    }

    public void Speech(string[] txt, List<string> actorNames, List<Sprite> actorProfiles)
    {
        if (!isShowing)
        {
            // dialogue box
            dialogueObj.SetActive(true);
            sentences = txt;

            this.actorNames = actorNames;
            actorSprites = actorProfiles;

            profileSprite.sprite = actorSprites[index];
            actorNameText.text = actorNames[index];

            StartCoroutine(TypeSentence());
            isShowing = true;

            player.isPaused = true;
        }
    }

}
