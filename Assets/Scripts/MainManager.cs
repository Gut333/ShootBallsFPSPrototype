using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;
    private int bestScore;
    private string bestScorePlayerName;
        
    private void Awake()
    {
       if(Instance != null)
       {
            Destroy(gameObject);
            return;
       }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void SetPlayerName(string pName)
    {
        playerName = pName;
    }

    public string GetPlayerName()
    {
        if(playerName == null){Debug.Log("No name stored.");}
        return playerName;
    }

    public void SetBestScore(int bestScore)
    {
        this.bestScore = bestScore;
    }

    public int GetBestScore() { return bestScore; }
    
    public string GetBestScorePlayerName() { return bestScorePlayerName; }

    public void SetBestScorePlayerName(string bestScorePlayerName)
    {
        this.bestScorePlayerName = bestScorePlayerName;
    }

}
