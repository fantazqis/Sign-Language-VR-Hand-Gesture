using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureInput : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> input;
    public string userInput;

    public void Input(int index)
    {
        //alphabetText.text = alphabetChar[index];
        userInput = input[index];

    }
}
