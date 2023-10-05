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
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restart;
    private int count = 0;

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        isGameActive = true;
        InvokeRepeating("BlankPointsSpawner", 2, 3);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene");
    }

    private void BlankPointsSpawner()
    {
        randomZ = Random.Range(-2,2);
        randomY = Random.Range(2,11);
        blankRandomPos = new Vector3(transform.position.x, randomY, randomZ);
        Instantiate(blankPoints[0],blankRandomPos,blankPoints[0].transform.rotation);
    }
    public void UpdateCount()
    {
        count++;
        countText.SetText("Count : " + count);
    }

    public bool GetGameStatus()
    {
        return isGameActive;
    }



}
