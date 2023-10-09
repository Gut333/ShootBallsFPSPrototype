using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public List<GameObject> blankPoints;
    public bool isGameActive = false;
    private float randomZ;
    private float randomY;
    private Vector3 blankRandomPos;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI playerAmmoText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restart;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject scoreTextCanvas;
    [SerializeField] private GameObject ammoTextCanvas;
    [SerializeField] private GameObject playerNameTextCanvas;
    [SerializeField] private PlayerController playerScript;
    private int score = 0;
    //public static GameManager Instance;
    

    private void Awake()
    {
        scoreTextCanvas.gameObject.SetActive(false);
        ammoTextCanvas.gameObject.SetActive(false);
        playerNameTextCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        isGameActive = true;
        scoreTextCanvas.gameObject.SetActive(true);
        ammoTextCanvas.gameObject.SetActive(true);
        playerNameTextCanvas.gameObject.SetActive(true);
        StartCoroutine(BlankPointsSpawner());
    }

    private void Update()
    {
        UpdatePlayerName();
    }

    public void GameOver()
    {
        restart.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        restart.gameObject.SetActive(true);
    }

    private void BlankPointsGenerator()
    {
        randomZ = Random.Range(-2,2);
        randomY = Random.Range(2,11);
        blankRandomPos = new Vector3(transform.position.x, randomY, randomZ);
        Instantiate(blankPoints[0],blankRandomPos,blankPoints[0].transform.rotation);
    }
    public void UpdateScore()
    {
        score = score + 33;
        scoreText.SetText("Score : " + score);
    }

    public void UpdatePlayerAmmo()
    {
        playerAmmoText.SetText("Ammo : " + playerScript.GetAmmo());
    }

    public void UpdatePlayerName()
    {
        playerNameText.SetText("Player : " + MainManager.Instance.GetPlayerName());
    }

    public bool GetGameStatus(){return isGameActive;}

    IEnumerator BlankPointsSpawner()
    {
        while (isGameActive == true)
        {
            yield return new WaitForSeconds(3);
            BlankPointsGenerator();
        }

    }
        

}
