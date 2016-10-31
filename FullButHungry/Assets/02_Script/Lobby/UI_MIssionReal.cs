using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_MIssionReal : MonoBehaviour 
{
    public List<IT_Mission> List_Mission = null;
    public UILabel lb_Count = null;

    public void Show()
    {
        for(int i = 0; i < List_Mission.Count; i++)
        {
            List_Mission[i].SetData(i);
        }
        Refresh();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Refresh()
    {
        int cnt = 0;
        for (int i = 0; i < List_Mission.Count; i++)
        {
            if (List_Mission[i].isComplete)
                cnt++;
        }
        lb_Count.text = "(" + cnt + " / 3)";
    }
}
