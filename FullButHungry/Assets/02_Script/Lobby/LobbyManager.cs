using UnityEngine;
using System.Collections;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance = null;

    public UI_Base BaseUI = null;
    public UI_EmotionStorage EmotionStorageUI = null;
    public UI_HungryCheck HungryCheckUI = null;
    public UI_SelectFood SelectFoodUI = null;
    public UI_MIssionReal MissionUI = null;
    public UI_Dic DicUI = null;
    public UI_PreQA QA = null;
    public UI_QAResult QAResult = null;
    public UI_DicInfo DicInfoUI = null;
    public UI_MyInfo MyInfoUI = null;
    public UI_Mission NotReadyUI = null;

    //////////////////////////////////////////////////
    
    
    void Awake()
    {
        Instance = this;
        BaseUI.Init();
        GameManager.Instance.PlayBgm(0, true);
        switch (GameManager.OpenType)
        {
            case Common.opentype.choco:
                QAResult.Show(GameManager.OpenType, true);
                break;

            case Common.opentype.milk:
                QAResult.Show(GameManager.OpenType, true);
                break;

            case Common.opentype.candy:
                QAResult.Show(GameManager.OpenType, true);
                break;

            case Common.opentype.emotion:
                EmotionStorageUI.Show();
                break;

            case Common.opentype.none:
                break;
        }
        GameManager.OpenType = Common.opentype.none;
    }

}