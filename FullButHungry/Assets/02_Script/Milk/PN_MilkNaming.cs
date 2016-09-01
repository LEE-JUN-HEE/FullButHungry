using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PN_MilkNaming : MonoBehaviour
{
    public List<IT_Naming> NamingList = new List<IT_Naming>();
    public UIGrid gr_Naming = null;
    public UILabel lb_Msg = null;

    public void Awake()
    {
        for (int i = 0; i < gr_Naming.transform.childCount; i++)
        {
            NamingList.Add(gr_Naming.transform.GetChild(i).GetComponent<IT_Naming>());
            gr_Naming.transform.GetChild(i).GetComponent<IT_Naming>().SetData(i);
        }
        lb_Msg.text = "지금 널 괴롭히는 감정의\n악당들이 여기 숨어있어\n어떤 악당인지 찾아줘!";
    }

    public void OnClick_Back()
    {
        SceneManager.LoadScene("01_Lobby");
    }

    public void OnClick_Go()
    {
        int cnt = 0;
        for (int i = 0; i < NamingList.Count; i++)
        {
            if (NamingList[i].isSelect) cnt++;
        }

        if (cnt == 0)
        {
            //ChocoMgr.Instance.AlertUI.Show();
        }
        else
        {
            //ChocoMgr.Instance.NamingComplete(KingNameInput.value);
        }

    }
}
