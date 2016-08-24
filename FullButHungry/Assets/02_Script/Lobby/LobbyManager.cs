using UnityEngine;
using System.Collections;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance = null;

    public UI_Base BaseUI = null;
    public UI_EmotionStorage EmotionStorageUI = null;
    public UI_HungryCheck HungryCheckUI = null;
    public UI_SelectFood SelectFoodUI = null;
    public UI_Mission MissionUI = null;
    public UI_Dic DicUI = null;


    //////////////////////////////////////////////////
    
    
    void Awake()
    {
        Instance = this;
        BaseUI.Init();
    }

}