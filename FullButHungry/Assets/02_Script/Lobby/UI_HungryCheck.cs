using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_HungryCheck : MonoBehaviour
{
    public List<IT_Check> ITList = new List<IT_Check>();
    public UIScrollView sv_Check = null;

    public void Show()
    {
        if (UserInfo.HungryCheck == false)
        {
            //질문 세팅
            for (int i = 0; i < 10; i++)
            {
                ITList[i].SetData(i, "질문 " + i, false);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                ITList[i].SetData(i, "질문 " + i, UserInfo.Hungry[i]);
            }
        }
        sv_Check.ResetPosition();
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Stop()
    {
        Hide();
    }

    public void OnClick_OK()
    {
        UserInfo.HungryCheck = true;
        if (UserInfo.Hungry.Count == 0)
        {
            for (int i = 0; i < 10; i++)
                UserInfo.Hungry.Add(ITList[i].isYes);
        }
        else
        {
            for (int i = 0; i < 10; i++)
                UserInfo.Hungry[i] = ITList[i].isYes;
        }
        LobbyManager.Instance.BaseUI.Refresh();
        Hide();
    }
}
