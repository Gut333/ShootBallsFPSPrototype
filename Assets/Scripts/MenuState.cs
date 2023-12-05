using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : MonoBehaviour
{
    public GameManager gameManager;
    public Button startButton;
    public Button exitButton;

    private void OnEnable()
    {
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void OnPressedStartButton()
    {
        gameManager.SetGameCameraPos();
        gameManager.SetGameStatus(true);

        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void OnPressedExitButton()
    {
        gameManager.ExitGame();
    }

    private void _ShowMenu(bool isGameActive)
    {
        if (isGameActive)
        {
            startButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            //this.gameObject.SetActive(false);
        }
    }




}
