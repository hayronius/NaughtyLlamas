using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public GameObject Confirmation;

    public void ShowConfirmation()
    {
        Confirmation.SetActive(true);
    }

    public void HideConfirmation()
    {
        Confirmation.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
