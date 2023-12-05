using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{
    [Header("General")]
    public GameManager gameManager;
    public MenuState menuState;
    public PlayerController player;
    public Button restartButton;

    [Header("Blank Point Spawner")]
    public List<GameObject> blankPoints;

    [Header("Text On Screen")]
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_bestScoreText;
    [SerializeField] private TextMeshProUGUI m_playerAmmoText;
    [SerializeField] private GameObject gameOverText;

    private int m_Score;
    private int m_BestScore;
    private float m_RandomZ;
    private float m_RandomY;
    private float m_RandomX;
    private Vector3 m_blankRandomPos;
    private string bestScorePlayerName;

    private void OnEnable()
    {
        StartCoroutine(BlankPointsSpawner());
        m_scoreText.gameObject.SetActive(true);
       // m_bestScoreText.gameObject.SetActive(true);
        m_playerAmmoText.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        GameObject obj = GameObject.Find("Target 2(Clone)");
        Destroy(obj);
    }

    private void Update()
    {
        player.OnInit();
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameManager.SetGameStatus(false);
    }

    public void OnRestartButtonPressed()
    {
        m_Score = 0;
        gameManager.SetGameStatus(true);
        gameManager.SetMainMenuCameraPos();
        restartButton.gameObject.SetActive(false);
        menuState.gameObject.SetActive(true);
        gameOverText.SetActive(false);
        this.gameObject.SetActive(false);
        
    }

    public void UpdatePlayerAmmo()
    {
         m_playerAmmoText.SetText("Ammo : " + player.GetAmmo());
    }


    public void UpdateScore()
    {
        m_Score = m_Score + 33;
        m_scoreText.SetText("Score : " + m_Score);
        BestScoreSaver();
    }

    public void BestScoreSaver()
    {
        if (m_Score > m_BestScore)
        {
            m_BestScore = m_Score;
            SetBestScore(m_BestScore);
        }
    }

    public void SetBestScore(int bestScore)
    {
        this.m_BestScore = bestScore;
    }

    public void BestScoreUpdate()
    {
        m_bestScoreText.SetText("best score : " + m_BestScore);
    }

    public int GetBestScore() { return m_BestScore; }

    public string GetBestScorePlayerName() { return bestScorePlayerName; }

    public void SetBestScorePlayerName(string bestScorePlayerName)
    {
        this.bestScorePlayerName = bestScorePlayerName;
    }

    private void _BlankPointsGenerator()
    {
        m_RandomZ = Random.Range(-2, 2);
        m_RandomY = Random.Range(1, 5);
        m_RandomX = Random.Range(1, 8);
        m_blankRandomPos = new Vector3(m_RandomX, m_RandomY, m_RandomZ);
        Instantiate(blankPoints[0], m_blankRandomPos, blankPoints[0].transform.rotation);
    }

    IEnumerator BlankPointsSpawner()
    {
        gameManager.SetGameStatus(true);
        while (gameManager.GetGameStatus())
        {
            yield return new WaitForSeconds(3);
            _BlankPointsGenerator();
        }
        StopCoroutine("BlankPointsSpawner");
    }
}
