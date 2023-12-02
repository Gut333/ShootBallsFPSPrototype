using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : MonoBehaviour
{
    public GameManager gameManager;
    public Button startButton;
    public Button exitButton;

    public void OnPressedStartButton()
    {
        gameManager.SetGameCameraPos();
    }

    public void OnPressedExitButton()
    {
        gameManager.ExitGame();
    }

}
