using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PN_MilkNaming : MonoBehaviour
{
    public List<Milk_IT_Naming> NamingList = new List<Milk_IT_Naming>();
    public UIGrid gr_Naming = null;
    public UILabel lb_Msg = null;
    public GameObject Bottom = null;

    float opentime = 9999;

    public void Awake()
    {
        for (int i = 0; i < gr_Naming.transform.childCount; i++)
        {
            NamingList.Add(gr_Naming.transform.GetChild(i).GetComponent<Milk_IT_Naming>());
            gr_Naming.transform.GetChild(i).GetComponent<Milk_IT_Naming>().SetData(i);
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
        GameManager.OpenType = Common.opentype.milk;
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
            MilkMgr.Instance.AlertUI.Show();
        }
        else
        {
            MilkMgr.Instance.NamingComplete();
        }

    }
}
