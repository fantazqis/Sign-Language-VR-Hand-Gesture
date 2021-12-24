using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagers : MonoBehaviour
{

    [Header("Manager References")]
    public SoundManager soundManager;
    public GestureInput gestureInputAlphabet;
    public GestureInput gestureInputNumber;
    public GestureInput gestureInputInteraction;

    [Header("Displayed Dialogue")]
    [TextArea]
    public string[] dialogueText;

    [Header("Manipulated Objects")]
    public TextMeshPro speechText;
    public GameObject interactionImg;
    public GameObject[] sibiGuides;
    public GameObject[] gestureDetector;

    /// <summary> Dialogue index that needs to be played next </summary>
    private int currentDialogue = 0;

    /// <summary> Variable to know if its number or alphabet </summary>
    private string gameMode;

    /// <summary> Distance the player's arm must be extended for primary hand setting </summary>
    //private readonly float extendedValue = 0.44f;

    /// <summary> Used in the demo to track how many gestures have been made in the first test </summary>
    //private int numGestures = 0;

    /// <summary>
    /// Tracks if the demo is running. If the demo is not active, gesture coroutines stay on and turn themselves on after running
    /// </summary>
    //private bool demoActive = true;

    /// <summary>
    /// Tracks if the narrator is speaking due to gesture detection and prevents overlap if so
    /// </summary>
    private bool speaking = false;

    /// <summary> Rounds of rock paper scissors completed in the demo </summary>
    private int imgSibi = 0;

    /// <summary> What part of ASL portion the player is currently on </summary>
    private int repeatSibi = 0;

    void Start()
    {
        Debug.Log("Start " + currentDialogue);
        StartCoroutine(DelayDialogue(2, currentDialogue));
    }

    public void DialogueFinished(int i)
    {
        switch (i)
        {
            case 6:
                soundManager.PlayDing();
                interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                currentDialogue = 7;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 7: // ConfirmContinue for Demo
                gestureDetector[2].gameObject.SetActive(true);
                StartCoroutine(ChooseMode(i));
                break;

            case 11:
                DialogueMode(i);
                break;

            case 12:
                sibiGuides[0].GetComponent<SpriteRenderer>().enabled = true;
                gestureDetector[0].gameObject.SetActive(true);
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 13:
                StartCoroutine(DetectA());
                break;

            case 14:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectB());
                break;

            case 15:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectC());
                break;

            case 16:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectD());
                break;

            case 17:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectE());
                break;

            case 18:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectF());
                break;

            case 19:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 0) 
                { 
                    Debug.Log("Case 58 IF IF"); 
                    currentDialogue++;
                } 
                
                else 
                { 
                    Debug.Log("Case 58 IF ELSE "); 
                    currentDialogue = 21;
                    imgSibi++;
                }

                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;
            /// <summary>
            /// masih bingung kalimat setelah menyelesaikan huruf F
            /// </summary>
            /// <returns></returns>

            case 20:
                repeatSibi++;
                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                StopAllCoroutines();
                // ADD COROUTINE FOR SNAPPING
                StartCoroutine(DetectSnap());
                //baru sampe sini

                if (repeatSibi == 1)
                {
                    StartCoroutine(DetectA());

                }

                else if (repeatSibi == 2)
                {
                    StartCoroutine(DetectG());
                }
                
                else if (repeatSibi == 3)
                {
                    StartCoroutine(DetectM());
                }

                else
                {
                    StartCoroutine(DetectT());
                }
                break;

            case 21:
                sibiGuides[1].GetComponent<SpriteRenderer>().enabled = true;
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectG());
                break;

            case 22:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectH());
                break;

            case 23:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectI());
                break;

            case 24:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectJ());
                break;

            case 25:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectK());
                break;

            case 26:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectL());
                break;

            case 27:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 1)
                {
                    currentDialogue = 20;
                }

                else
                {
                    currentDialogue = 28;
                    imgSibi++;
                }

                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 28:
                sibiGuides[2].GetComponent<SpriteRenderer>().enabled = true;
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 31:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectM());
                break;

            case 32:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectN());
                break;

            case 33:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectO());
                break;

            case 34:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectP());
                break;

            case 35:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectQ());
                break;

            case 36:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectR());
                break;

            case 37:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectS());
                break;

            case 38:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 2)
                {
                    currentDialogue = 20;
                }

                else
                {
                    currentDialogue = 39;
                    imgSibi++;
                }

                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 39:
                sibiGuides[3].GetComponent<SpriteRenderer>().enabled = true;
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectT());
                break;

            case 40:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectU());
                break;

            case 41:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectV());
                break;

            case 42:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectW());
                break;

            case 43:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectX());
                break;

            case 44:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectY());
                break;

            case 45:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectZ());
                break;

            case 46:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 3)
                {
                    currentDialogue = 20;
                }

                else
                {
                    currentDialogue = 47;
                }

                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 49:
                //belum selesai pilihan mau main alfabet lagi atau angka
                StopAllCoroutines();
                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                gestureDetector[0].gameObject.SetActive(false);
                interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                repeatSibi = 0;
                currentDialogue = 7;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 60:
                sibiGuides[0].GetComponent<SpriteRenderer>().enabled = true;
                gestureDetector[1].gameObject.SetActive(true);
                imgSibi = 4;
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 61:
                StartCoroutine(Detect1());
                break;

            case 62:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect2());
                break;

            case 63:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect3());
                break;

            case 64:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect4());
                break;

            case 65:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect5());
                break;

            case 66:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 0)
                {
                    Debug.Log("Case 58 IF IF");
                    currentDialogue++;
                }

                else
                {
                    Debug.Log("Case 58 IF ELSE ");
                    currentDialogue = 68;
                    imgSibi++;
                }

                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 67:
                repeatSibi++;
                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                StopAllCoroutines();
                // ADD COROUTINE FOR SNAPPING
                StartCoroutine(DetectSnap());
                //baru sampe sini

                if (repeatSibi == 1)
                {
                    StartCoroutine(Detect1());

                }

                else if (repeatSibi == 2)
                {
                    StartCoroutine(Detect6());
                }
                break;

            case 68:
                sibiGuides[1].GetComponent<SpriteRenderer>().enabled = true;
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect6());
                break;

            case 69:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect7());
                break;

            case 70:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect8());
                break;

            case 71:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect9());
                break;

            case 72:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect10());
                break;

            case 73:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 1)
                {
                    currentDialogue = 67;
                }

                else
                {
                    currentDialogue = 74;
                }

                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 76:
                //belum selesai pilihan mau main alfabet lagi atau angka
                StopAllCoroutines();
                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                gestureDetector[1].gameObject.SetActive(false);
                interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                repeatSibi = 0;
                currentDialogue = 7;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            default:
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;
        }
    }

    IEnumerator DelayDialogue(int secs, int dialogue)
    {
        yield return new WaitForSeconds(secs);
        currentDialogue = dialogue;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    
    IEnumerator ChooseMode(int dialogue)
    {

        yield return new WaitUntil(() => gestureInputInteraction.userInput == "Thumbs Up" || gestureInputInteraction.userInput == "Grip");
        soundManager.PlayDing();
        interactionImg.GetComponent<SpriteRenderer>().enabled = false;

        if (gestureInputInteraction.userInput == "Thumbs Up")
        {
            Debug.Log("ChooseMode Alphabet");
            currentDialogue = 8;
            gameMode = "Alphabet";
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
        else if (gestureInputInteraction.userInput == "Grip")
        {
            Debug.Log("ChooseMode Number");
            currentDialogue = 8;
            gameMode = "Number";
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
        
    }

    void DialogueMode(int dialogue)
    {
        Debug.Log("DialogueMode");
        if (gameMode == "Alphabet")
        {
            Debug.Log("DialogueMode alphabet");
            currentDialogue = 12;
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
        else if (gameMode == "Number")
        {
            Debug.Log("DialogueMode number");
            currentDialogue = 60;
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
    }

    IEnumerator DetectA()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "A" && !speaking);
        speaking = true;
        currentDialogue = 14;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectB()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "B" && !speaking);
        speaking = true;
        //currentDialogue = 15;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectC()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "C" && !speaking);
        speaking = true;
        //currentDialogue = 16;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectD()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "D" && !speaking);
        speaking = true;
        //currentDialogue = 17;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectE()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "E" && !speaking);
        speaking = true;
        //currentDialogue = 18;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectF()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "F" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    /// <summary>
    /// masih belum pasti urutan current dialogue
    /// </summary>
    /// <returns></returns>
    IEnumerator DetectG()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "G" && !speaking);
        speaking = true;
        //current dialogue masih belum pasti
        currentDialogue = 22;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectH()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "H" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectI()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "I" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectJ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "J" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectK()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "K" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectL()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "L" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectM()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "M" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue = 31;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectN()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "N" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectO()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "O" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectP()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "P" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectQ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Q" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectR()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "R" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectS()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "S" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectT()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "T" && !speaking);
        speaking = true;
        currentDialogue = 40;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectU()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "U" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectV()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "V" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectW()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "W" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectX()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "X" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectY()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Y" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectZ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Z" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect1()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "1" && !speaking);
        speaking = true;
        currentDialogue = 62;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect2()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "2" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect3()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "3" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect4()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "4" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect5()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "5" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect6()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "6" && !speaking);
        speaking = true;
        currentDialogue = 69;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect7()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "7" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect8()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "8" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect9()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "9" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect10()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "10" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectSnap()
    {
        yield return new WaitUntil(() => gestureInputInteraction.userInput == "Okay" && !speaking);
        soundManager.PlayDing();
        sibiGuides[imgSibi].GetComponent<SpriteRenderer>().enabled = true;
        //rpsPic.GetComponent<MeshRenderer>().enabled = true;
        //speaking = true;
        //currentDialogue = 71;
        //speechText.text = dialogueText[currentDialogue];
        //soundManager.PlayDialogue(currentDialogue);
    }
}
