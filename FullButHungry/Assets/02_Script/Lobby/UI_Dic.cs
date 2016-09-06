using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Dic : MonoBehaviour
{
    public List<IT_Dic> DicList = new List<IT_Dic>();

    public void Show()
    {
        for (int i = 0; i < DicList.Count; i++)
            DicList[i].SetData(i);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Back()
    {
        Hide();
    }
}
