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
        _ShowMenu(gameManager.GetGameStatus());
        
    }

    public void OnPressedExitButton()
    {
        gameManager.ExitGame();
    }

    private void _ShowMenu(bool isGameActive)
    {
        if (isGameActive)
        {
            //startButton.gameObject.SetActive(false);
            //exitButton.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

}
