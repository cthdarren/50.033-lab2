using UnityEngine;

public class Geralt : NPC, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController controller;
    public override void Interact()
    {
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        playerData.isMovementDisabled = true;
        bool conversationEnded =  controller.DisplayNextParagraph(dialogueText);
        if (conversationEnded) playerData.isMovementDisabled = false;

    }
}
