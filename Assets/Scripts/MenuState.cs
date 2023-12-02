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
        gameManager.SetGameStatus(true);
        _ShowButtons(gameManager.GetGameStatus());
    }

    public void OnPressedExitButton()
    {
        gameManager.ExitGame();
    }

    private void _ShowButtons(bool isGameActive)
    {
        if (isGameActive)
        {
            startButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }

    }

}
