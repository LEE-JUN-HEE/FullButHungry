using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PN_Ingame : MonoBehaviour 
{
    public List<UISprite> sp_Energy = new List<UISprite>();
    public List<UILabel> lb_Atk = new List<UILabel>();
    public UILabel lb_Count = null;
    public UIInput Input = null;
    System.Action func;

    void Awake()
    {
        func = update_Empty;
    }

    void Update()
    {
        if (ChocoMgr.Instance.isPause) return;

        for(int i =0; i< ChocoMgr.Instance.EnergyTime / 10; i++)
        {
            sp_Energy[i].spriteName = "energy";
        }

        for(int i = (int)ChocoMgr.Instance.EnergyTime / 10; i<5; i++)
        {
            sp_Energy[i].spriteName = "energy_empty";
        }

        lb_Count.text = ChocoMgr.Instance.EnemyCnt.ToString();
        

    }

    void update_Empty() { }

    void update_Check()
    {
        if (!TouchScreenKeyboard.visible)
        {
            TouchScreenKeyboard.Open(null);
            func = update_Empty;
        }
    }

    public void OnClick_Pause()
    {
        ChocoMgr.Instance.Pause(!ChocoMgr.Instance.isPause);
    }

    public void OnClick_Plus()
    {
        ChocoMgr.Instance.Mission();
    }

    public void OnSubmit_Atk()
    {
        ChocoMgr.Instance.CheckString(Input.value);
        Input.value = "";
        Input.isSelected = true;
        func = update_Check;
        Debug.Log("submit");
    }
}
