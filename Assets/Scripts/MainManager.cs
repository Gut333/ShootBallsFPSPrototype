using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            DontDestroyOnLoad(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
    

}
