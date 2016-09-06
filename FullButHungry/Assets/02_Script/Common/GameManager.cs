using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    

    static public GameManager Instance = null;
    static public Common.opentype OpenType = Common.opentype.none;
    
	void Awake () 
    {
        Instance = this;
        DontDestroyOnLoad(this);

        UserInfo.Init();
        SceneManager.LoadScene("01_Lobby");
	}
}
