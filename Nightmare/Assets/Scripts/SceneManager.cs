using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : SceneManager {

    private string currentSceneName;
    private int currentSceneIndex;

    private static GameManager _instance;
    public static GameManager GetInstance()
    {
        if (_instance == null)
            return new GameManager();
        return _instance;
    }
        
    void Start()
    {
        InitGame();    
    } 

    void InitGame()
    {

    }

}
