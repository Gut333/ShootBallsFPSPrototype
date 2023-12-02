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
    public List<GameObject> blankPoints;
    public string playerName;
    public bool isGameActive = false;

    public GameObject MenuState;


    private float randomZ;
    private float randomY;
    private Vector3 blankRandomPos;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_playerAmmoText;
    [SerializeField] private TextMeshProUGUI m_playerNameText;
    [SerializeField] private TextMeshProUGUI m_bestScoreText;
    [SerializeField] private Button m_startButton;
    [SerializeField] private Button m_restart;
    [SerializeField] private GameObject m_gameOverText;
    [SerializeField] private GameObject m_scoreTextCanvas;
    [SerializeField] private GameObject m_ammoTextCanvas;
    [SerializeField] private GameObject m_playerNameTextCanvas;
    [SerializeField] private PlayerController m_playerScript;
    private int score = 0;
    private int bestScore;
    private string bestScorePlayerName;
    
    private void Awake()
    {
        GameManagerInstance();
        
        mainCamera.transform.position = new Vector3(28, 1.25f, 0f);
        ShowCanvas(false);
        bestScore = GameManager.gameManagerInstance.GetBestScore();
        bestScorePlayerName = GameManager.gameManagerInstance.GetBestScorePlayerName();

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

    public void StartGame()
    {
        SetGameCameraPos();
        ShowCanvas(true);
        ShowButtons(false);
        isGameActive = true;
        MenuState.gameObject.SetActive(false);
        m_gameOverText.gameObject.SetActive(false);
        StartCoroutine(BlankPointsSpawner());
    }

    public void SetMainMenuCameraPos()
    {
        mainCamera.transform.position = new Vector3(28, 1.25f, 0f);
    }

    public void SetGameCameraPos()
    {
        mainCamera.transform.position = new Vector3(18f, -1f, 0f);
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    private void ShowCanvas(bool isVisible)
    {
        m_scoreTextCanvas.gameObject.SetActive(isVisible);
        m_ammoTextCanvas.gameObject.SetActive(isVisible);
       // m_playerNameTextCanvas.gameObject.SetActive(isVisible);
    }

    private void ShowButtons(bool isVisible)
    {
        m_startButton.gameObject.SetActive(isVisible);
        m_restart.gameObject.SetActive(isVisible);
    }

    private void Update()
    {
        UpdatePlayerName();
        BestScoreUpdate();
    }

    public void GameOver()
    {
        m_restart.gameObject.SetActive(true);
        m_gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Restart()
    {
        m_restart.gameObject.SetActive(true);
        m_gameOverText.gameObject.SetActive(false);
        SetMainMenuCameraPos();
        isGameActive = false;
        MenuState.gameObject.SetActive(true);
        ShowButtons(true);
        ShowCanvas(true);
    }

    private void BlankPointsGenerator()
    {
        randomZ = Random.Range(-2,2);
        randomY = Random.Range(2,8);
        blankRandomPos = new Vector3(transform.position.x, randomY, randomZ);
        Instantiate(blankPoints[0],blankRandomPos,blankPoints[0].transform.rotation);
    }
    public void UpdateScore()
    {
        score = score + 33;
        m_scoreText.SetText("Score : " + score);
        BestScoreSaver();
        
    }

    public void BestScoreSaver()
    {
        if (score > bestScore)
        {
            bestScore = score;
            GameManager.gameManagerInstance.SetBestScore(bestScore);
            bestScorePlayerName = GameManager.gameManagerInstance.GetPlayerName();
            GameManager.gameManagerInstance.SetBestScorePlayerName(bestScorePlayerName);
        }
    }

    public void BestScoreUpdate()
    {
        m_bestScoreText.SetText("best score : " + bestScore + " - " + bestScorePlayerName);
    }

    public int GetBestScore() { return bestScore; }

    public void UpdatePlayerAmmo()
    {
        m_playerAmmoText.SetText("Ammo : " + m_playerScript.GetAmmo());
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

    IEnumerator BlankPointsSpawner()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(3);
            BlankPointsGenerator();
        }

       
        

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

    public void SetBestScore(int bestScore)
    {
        this.bestScore = bestScore;
    }

    public string GetBestScorePlayerName() { return bestScorePlayerName; }

    public void SetBestScorePlayerName(string bestScorePlayerName)
    {
        this.bestScorePlayerName = bestScorePlayerName;
    }


}
