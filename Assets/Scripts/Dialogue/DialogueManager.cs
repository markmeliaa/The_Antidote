using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue;
    public Image speakerSprite, listenerSprite1, listenerSprite2, speakerBox;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;
    private Animator speakeranim, listeneranim1, listeneranim2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public static void StartConversation(Conversation convo)
    {
        instance.anim.SetBool("isOpen", true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";

        instance.ReadNext();
    }

    public void ReadNext()
    {
        speakeranim = speakerSprite.GetComponent<Animator>();
        listeneranim1 = listenerSprite1.GetComponent<Animator>();
        listeneranim2 = listenerSprite2.GetComponent<Animator>();

        if (speakeranim.GetBool("showCharacter") == false)
        {
            speakeranim.SetBool("showCharacter", true);
        }

        // Show first listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener1.GetName() != "No one")
        {
            listeneranim1.SetBool("showCharacter2", true);
        }

        // Hide first listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener1.GetName() == "No one")
        {
            listeneranim1.SetBool("showCharacter2", false);
        }

        // Show second listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener2.GetName() != "No one")
        {
            listeneranim2.SetBool("showCharacter3", true);
        }

        // Hide second listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener2.GetName() == "No one")
        {
            listeneranim2.SetBool("showCharacter3", false);
        }

        if (currentIndex > currentConvo.GetLength())
        {
            instance.anim.SetBool("isOpen", false);
            speakeranim.SetBool("showCharacter", false);
            return;
        }

        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
        
        if(typing == null)
        {
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }
        else
        {
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }
        
        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSpeakerSprite();
        speakerBox.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSpeakerBox();
        currentIndex++;
    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;

        while (!complete)
        {
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);

            if(index == text.Length)
            {
                complete = true;
            }
        }

        typing = null;
    }
}
