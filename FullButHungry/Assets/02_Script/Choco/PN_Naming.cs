using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PN_Naming : MonoBehaviour
{
    public List<IT_Naming> NamingList = new List<IT_Naming>();
    public UIGrid gr_Naming = null;
    public UIInput KingNameInput = null;
    public UILabel lb_Msg = null;
    public GameObject Bottom = null;

    float opentime = 9999;

    public void Awake()
    {
        for (int i = 0; i < gr_Naming.transform.childCount; i++)
        {
            NamingList.Add(gr_Naming.transform.GetChild(i).GetComponent<IT_Naming>());
            gr_Naming.transform.GetChild(i).GetComponent<IT_Naming>().SetData(i);
        }
        lb_Msg.text = "지금 널 괴롭히는 감정의\n악당들이 여기 숨어있어\n어떤 악당인지 찾아줘!";
        opentime = Time.unscaledTime;
    }

    void Update()
    {
        if (opentime + 2f < Time.unscaledTime)
        {
            Bottom.SetActive(true);
        }
    }
    public void OnClick_Back()
    {
        SceneManager.LoadScene("01_Lobby");
    }

    public void OnClick_Go()
    {
        if (string.IsNullOrEmpty(KingNameInput.value))
        {
        }
        else
        {
            int cnt = 0;
            for (int i = 0; i < NamingList.Count; i++)
            {
                if (NamingList[i].isSelect) cnt++;
            }

            if (cnt == 0)
            {
                ChocoMgr.Instance.AlertUI.Show();
            }
            else
            {
                ChocoMgr.Instance.NamingComplete(KingNameInput.value);
            }
        }
    }

    public void OnFinished()
    {
        lb_Msg.text = "대왕악당은 네가 직접\n이름을 지어줄래?";
    }
}
