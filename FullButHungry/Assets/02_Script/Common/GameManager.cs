using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    

    static public GameManager Instance = null;
    static public Common.opentype OpenType = Common.opentype.none;

    public AudioSource AS_Bgm = null;
    public List<AudioClip> AC_Bgm = null;
    
	void Awake () 
    {
        Instance = this;
        DontDestroyOnLoad(this);

        UserInfo.Init();
        SceneManager.LoadScene("01_Lobby");
	}

    public void PlayBgm(int index, bool isLoop)
    {
        AS_Bgm.clip = AC_Bgm[index];
        AS_Bgm.loop = isLoop;
        AS_Bgm.Play();
    }
}
