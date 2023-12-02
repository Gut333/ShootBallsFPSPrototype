using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public GameManager gameManager;
    public MenuState menuState;

    public Button restartButton;
    public GameObject gameOverText;

    public void OnRestartButtonPressed()
    {
        gameManager.SetGameStatus(true);
        gameManager.SetMainMenuCameraPos();
        restartButton.gameObject.SetActive(false);
        menuState.gameObject.SetActive(true);
        gameOverText.SetActive(false);
    }


}
