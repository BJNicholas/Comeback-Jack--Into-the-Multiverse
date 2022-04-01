using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;

    private bool isTriggered = false;

    // Start is called before the first frame update
    void Awake()
    {
        dialogueBox.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTriggered == false)
        {
            StartCoroutine(StartDialogue1());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTriggered == true)
        {
            StartCoroutine(EndDialogue());
        }
    }

    IEnumerator StartDialogue1()
    {
        dialogueBox.SetActive(true);
        isTriggered = true;

        yield return new WaitForSecondsRealtime(3f);

        StartCoroutine(StartDialogue2());

    }

    IEnumerator StartDialogue2()
    {
        text1.SetActive(false);
        text2.SetActive(true);

        yield return new WaitForSecondsRealtime(3f);

        StartCoroutine(StartDialogue3());

    }

    IEnumerator StartDialogue3()
    {
        text2.SetActive(false);
        text3.SetActive(true);

        yield return new WaitForSecondsRealtime(3f);

    }

    IEnumerator EndDialogue()
    {

        yield return new WaitForSecondsRealtime(1f);

        text3.SetActive(false);
        text1.SetActive(true);
        dialogueBox.SetActive(false);
        isTriggered = false;

        StopAllCoroutines();

    }

}

