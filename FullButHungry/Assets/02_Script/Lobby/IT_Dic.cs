using UnityEngine;
using System.Collections;

public class IT_Dic : MonoBehaviour 
{
    public UISprite sp_BG = null;
    public UILabel lb_Text = null;
    public UISprite sp_Lock = null;
    public bool isLock = false;
    int index = -1;

    public void SetData(int _index)
    {
        index = _index;
        switch (_index)
        {
            case 0:
                lb_Text.text = "정서적 허기란?";
                isLock = false;
                break;
            case 1:
                lb_Text.text = "나의 허기로부터 자유로워 지기";
                isLock = false;
                break;

            case 2:
                lb_Text.text = "마음일기 쓰기";
                isLock = true;
                break;
            case 3:
                lb_Text.text = "음식없이 나를 위로하기";
                isLock = true;
                break;
            case 4:
                lb_Text.text = "마음 단련법";
                isLock = true;
                break;
            case 5:
                lb_Text.text = "긍정의 말";
                isLock = true;
                break;
            case 6:
                lb_Text.text = "음식을 갈망하는 속마음";
                isLock = true;
                break;
        }

        sp_BG.spriteName = (_index % 2 == 0) ? "Dick_Bar2" : "Dic_Bar1";
        sp_Lock.gameObject.SetActive(isLock);
    }

    public void OnClick_This()
    {
        if (isLock) return;

        LobbyManager.Instance.DicInfoUI.Show(index, lb_Text.text);
    }
}
