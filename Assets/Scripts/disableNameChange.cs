using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class disableNameChange : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_InputField nameInput;

    public TMP_Text input;

    void Start()
    {
        if(PlayerPrefs.GetString("name") != "")
        {
            nameInput.enabled = false;
            nameInput.text = PlayerPrefs.GetString("name");
            input.enabled = false;

        }
    }

}
