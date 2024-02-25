using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField PlayerNameInput;

    public void GoToMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdatePlayerName()
    {
        string updateText = PlayerNameInput.text;
        ScoreboardManager.Instance.UpdatePlayerName(updateText);
    }
}
