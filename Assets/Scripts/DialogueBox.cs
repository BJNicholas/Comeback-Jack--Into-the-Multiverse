using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{

    [SerializeField] private GameObject dialogueBox;

    private bool isTriggered = false;

    // Start is called before the first frame update
    void Awake()
    {
        dialogueBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTriggered == false)
        {
            dialogueBox.SetActive(true);
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTriggered == true)
        {
            StartCoroutine(EndDialogue());
        }
    }

    IEnumerator EndDialogue()
    {

        yield return new WaitForSecondsRealtime(1f);

        dialogueBox.SetActive(false);
        isTriggered = false;

    }

}
