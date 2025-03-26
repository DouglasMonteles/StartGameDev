using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;

    public LayerMask playerLayer;

    public DialogSettings dialogSettings;

    private List<string> sentences = new List<string>();

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
            DialogueControl.INSTANCE.Speech(sentences.ToArray());
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
            sentences.Add(dialogSettings.dialogues[i].sentence.portuguese);
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
            DialogueControl.INSTANCE.dialogueObj.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
