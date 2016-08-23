using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    static public GameManager Instance = null;
    
	void Awake () 
    {
        Instance = this;
        DontDestroyOnLoad(this);

        UserInfo.Init();
        SceneManager.LoadScene("01_Lobby");
	}
}
