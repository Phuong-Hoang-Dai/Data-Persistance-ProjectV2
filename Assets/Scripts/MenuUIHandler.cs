using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInput;
    public Text bestScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void Load()
    {
        Debug.Log(Application.persistentDataPath);
        Debug.Log("Load is called");
        PlayerManager.Instance.m_Name = nameInput.text;

        PlayerManager.Instance.LoadPlayer();
        if (PlayerManager.Instance.m_BestScore > 0)
            bestScore.text = "Best Score: " + 
                PlayerManager.Instance.m_BestScore.ToString();
    }
}
