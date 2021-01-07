using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Text speakerName, speakerName2, dialogue, dialogue2;
    public Image speakerSprite, speakerSprite2, speakerSprite3, speakerSprite4, speakerBox, speakerBox2;
    public bool InConvo = false;
    public Animator anim2;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;
    private Animator speakeranim, speakeranim2, speakeranim3, speakeranim4;
    private bool reading = false;
    private float textSpeed = 0.03f;

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

    public void NextButton()
    {
        if (reading)
            textSpeed = 0.00f;

        else
            ReadNext();

    }

    public static void StartConversation(Conversation convo)
    {
        instance.anim.SetBool("isOpen", true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.speakerName2.text = "";
        instance.dialogue.text = "";
        instance.dialogue2.text = "";
        instance.InConvo = true;
        instance.anim2.SetBool("isOpen", false);

        instance.ReadNext();
    }

    public void ReadNext()
    {
        reading = true;
        speakeranim = speakerSprite.GetComponent<Animator>();
        speakeranim2 = speakerSprite2.GetComponent<Animator>();
        speakeranim3 = speakerSprite3.GetComponent<Animator>();
        speakeranim4 = speakerSprite4.GetComponent<Animator>();

        if (speakeranim.GetBool("showCharacter") == false)
        {
            speakeranim.SetBool("showCharacter", true);
        }

        if (currentIndex > currentConvo.GetLength())
        {
            instance.anim.SetBool("isOpen", false);
            anim2.SetBool("isOpen", false);

            speakeranim.SetBool("showCharacter", false);
            speakeranim2.SetBool("showCharacter2", false);
            speakeranim3.SetBool("showCharacter3", false);
            speakeranim4.SetBool("showCharacter4", false);

            instance.InConvo = false;
            return;
        }

        // Show first listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener1.GetName() != "No one")
        {
            speakeranim2.SetBool("showCharacter2", true);
        }

        // Hide first listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener1.GetName() == "No one")
        {
            speakeranim2.SetBool("showCharacter2", false);
        }

        // Show second listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener2.GetName() != "No one")
        {
            speakeranim3.SetBool("showCharacter3", true);
        }

        // Hide second listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener2.GetName() == "No one")
        {
            speakeranim3.SetBool("showCharacter3", false);
        }

        // Show second listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener3.GetName() != "No one")
        {
            speakeranim4.SetBool("showCharacter4", true);
        }

        // Hide second listener
        if (instance.currentConvo.GetLineByIndex(currentIndex).listener3.GetName() == "No one")
        {
            speakeranim4.SetBool("showCharacter4", false);
        }


        if (typing == null)
        {
            if (currentConvo.GetLineByIndex(currentIndex).dialogue != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue, dialogue));
                speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
                speakerBox.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSpeakerBox();
                if (anim2.GetBool("isOpen"))
                {
                    anim2.SetBool("isOpen", false);
                    anim.SetBool("isOpen", true);
                }
            }


            else if (currentConvo.GetLineByIndex(currentIndex).dialogue2 != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue2, dialogue2));
                speakerName2.text = currentConvo.GetLineByIndex(currentIndex).listener1.GetName();
                speakerBox2.sprite = currentConvo.GetLineByIndex(currentIndex).listener1.GetSpeakerBox();
                if (anim.GetBool("isOpen"))
                {
                    anim.SetBool("isOpen", false);
                    anim2.SetBool("isOpen", true);
                }
            }


            else if (currentConvo.GetLineByIndex(currentIndex).dialogue3 != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue3, dialogue2));
                speakerName2.text = currentConvo.GetLineByIndex(currentIndex).listener2.GetName();
                speakerBox2.sprite = currentConvo.GetLineByIndex(currentIndex).listener2.GetSpeakerBox();
                if (anim.GetBool("isOpen"))
                {
                    anim.SetBool("isOpen", false);
                    anim2.SetBool("isOpen", true);
                }
            }

            else if (currentConvo.GetLineByIndex(currentIndex).dialogue4 != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue4, dialogue));
                speakerName.text = currentConvo.GetLineByIndex(currentIndex).listener3.GetName();
                speakerBox.sprite = currentConvo.GetLineByIndex(currentIndex).listener3.GetSpeakerBox();
                if (anim2.GetBool("isOpen"))
                {
                    anim2.SetBool("isOpen", false);
                    anim.SetBool("isOpen", true);
                }
            }
        }

        else
        {
            instance.StopCoroutine(typing);
            typing = null;
            if (currentConvo.GetLineByIndex(currentIndex).dialogue != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue, dialogue));
                speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
                speakerBox.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSpeakerBox();
                if (anim2.GetBool("isOpen"))
                {
                    anim2.SetBool("isOpen", false);
                    anim.SetBool("isOpen", true);
                }
            }


            else if (currentConvo.GetLineByIndex(currentIndex).dialogue2 != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue2, dialogue2));
                speakerName2.text = currentConvo.GetLineByIndex(currentIndex).listener1.GetName();
                speakerBox2.sprite = currentConvo.GetLineByIndex(currentIndex).listener1.GetSpeakerBox();
                if (anim.GetBool("isOpen"))
                {
                    anim.SetBool("isOpen", false);
                    anim2.SetBool("isOpen", true);
                }
            }


            else if (currentConvo.GetLineByIndex(currentIndex).dialogue3 != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue3, dialogue2));
                speakerName2.text = currentConvo.GetLineByIndex(currentIndex).listener2.GetName();
                speakerBox2.sprite = currentConvo.GetLineByIndex(currentIndex).listener2.GetSpeakerBox();
                if (anim.GetBool("isOpen"))
                {
                    anim.SetBool("isOpen", false);
                    anim2.SetBool("isOpen", true);
                }
            }

            else if (currentConvo.GetLineByIndex(currentIndex).dialogue4 != "")
            {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue4, dialogue));
                speakerName.text = currentConvo.GetLineByIndex(currentIndex).listener3.GetName();
                speakerBox.sprite = currentConvo.GetLineByIndex(currentIndex).listener3.GetSpeakerBox();
                if (anim2.GetBool("isOpen"))
                {
                    anim2.SetBool("isOpen", false);
                    anim.SetBool("isOpen", true);
                }
            }
        }
        
        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSpeakerSprite();
        speakerSprite2.sprite = currentConvo.GetLineByIndex(currentIndex).listener1.GetSpeakerSprite();
        speakerSprite3.sprite = currentConvo.GetLineByIndex(currentIndex).listener2.GetSpeakerSprite();
        speakerSprite4.sprite = currentConvo.GetLineByIndex(currentIndex).listener3.GetSpeakerSprite();

        currentIndex++;
    }

    private IEnumerator TypeText(string text, Text dialogueBox)
    {
        dialogueBox.text = "";
        bool complete = false;
        int index = 0;

        while (!complete)
        {
            dialogueBox.text += text[index];
            index++;
            yield return new WaitForSeconds(textSpeed);

            if(index == text.Length)
            {
                complete = true;
                reading = false;
                textSpeed = 0.03f;
            }
        }

        typing = null;
    }
}
