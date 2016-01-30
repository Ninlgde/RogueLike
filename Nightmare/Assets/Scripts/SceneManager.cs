using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewSceneManager : MonoBehaviour
{

    private string currentSceneName;
    private int currentSceneIndex;

    private static NewSceneManager _instance;
    public static NewSceneManager GetInstance()
    {
        if (_instance == null)
            return new NewSceneManager();
        return _instance;
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public string GetCurScene()
    {
        return SceneManager.GetActiveScene().name;
    }



}
