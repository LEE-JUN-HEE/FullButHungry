using UnityEngine;
using System.Collections;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance = null;

    public UI_Base BaseUI = null;
    public UI_EmotionStorage EmotionStorageUI = null;
    public UI_HungryCheck HungryCheckUI = null;
    public UI_SelectFood SelectFoodUI = null;

    //////////////////////////////////////////////////
    
    
    void Awake()
    {
        Instance = this;
        BaseUI.Init();
    }

}