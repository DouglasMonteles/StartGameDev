using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;

    public LayerMask playerLayer;

    public DialogSettings dialogSettings;

    private List<string> sentences = new List<string>();

    private List<string> actorNames = new List<string>();

    private List<Sprite> actorSprites = new List<Sprite>();

    bool playerHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetNPCInfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.INSTANCE.Speech(sentences.ToArray(), actorNames, actorSprites);
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogSettings.dialogues.Count; i++)
        {
            switch (DialogueControl.INSTANCE.language)
            {
                case DialogueControl.Idiom.PT_BR:
                    sentences.Add(dialogSettings.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.Idiom.ENG:
                    sentences.Add(dialogSettings.dialogues[i].sentence.english);
                    break;

                case DialogueControl.Idiom.SPA:
                    sentences.Add(dialogSettings.dialogues[i].sentence.spanish);
                    break;
            }

            actorNames.Add(dialogSettings.dialogues[i].actorName);
            actorSprites.Add(dialogSettings.dialogues[i].profile);
        }
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
