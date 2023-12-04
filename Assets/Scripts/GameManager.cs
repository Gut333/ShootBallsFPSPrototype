using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public Camera mainCamera;
    public string playerName;
    public bool isGameActive = false;

    public GameObject menuState;
    public GameObject gameState;


    [SerializeField] private TextMeshProUGUI m_playerNameText;


    
    private void Awake()
    {
        GameManagerInstance();
        SetMainMenuCameraPos();
       // bestScore = GameManager.gameManagerInstance.GetBestScore();
       // bestScorePlayerName = GameManager.gameManagerInstance.GetBestScorePlayerName();

    }


    private void GameManagerInstance()
    {
        if (gameManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        gameManagerInstance = this;
        DontDestroyOnLoad(gameObject);
    }

 

    public void SetMainMenuCameraPos()
    {
        mainCamera.transform.position = new Vector3(28, 1.25f, 0f);

    }

    public void SetGameCameraPos()
    {
        mainCamera.transform.position = new Vector3(18f, -1f, 0f);
        //just for test
        gameState.SetActive(true);

    }


    public void ExitGame(){Application.Quit();}


    private void Update()
    {
       // UpdatePlayerName();
       // BestScoreUpdate();
    }


    public void UpdatePlayerName()
    {
        m_playerNameText.SetText("Player : " + GameManager.gameManagerInstance.GetPlayerName());
    }

    public bool GetGameStatus(){return isGameActive;}

    public void SetGameStatus(bool isActive)
    {
        isGameActive = isActive;
    }


    public void SetPlayerName(string pName)
    {
        playerName = pName;
    }

    public string GetPlayerName()
    {
        if (playerName == null) { Debug.Log("No name stored."); }
        return playerName;
    }



}
