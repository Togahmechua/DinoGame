using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPassword : MonoBehaviour
{
    private InputField inputField;

    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    public void CheckPass()
    {
        switch (inputField.text)
        {
            case "3008" :
                SceneManager.LoadScene("Scene2");
                break;

            default :
                inputField.text = "";
                break;
                
        }
    }
}
