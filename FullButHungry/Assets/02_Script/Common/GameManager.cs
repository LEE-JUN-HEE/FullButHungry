using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    static public GameManager Instance = null;
    
	void Awake () 
    {
        Instance = this;
        DontDestroyOnLoad(this);

        UserInfo.Init();
	}
}
