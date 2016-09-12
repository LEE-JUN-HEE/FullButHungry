using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PN_Ingame : MonoBehaviour
{
    public List<UISprite> sp_Energy = new List<UISprite>();
    public List<UILabel> lb_Atk = new List<UILabel>();
    public UILabel lb_Count = null;
    public UISprite sp_Input = null;
    public UIInput Input = null;
    public UILabel debug = null;
    bool isSubmit = false;
    
    void Update()
    {
        if (ChocoMgr.Instance.isPause) return;

        for (int i = 0; i < ChocoMgr.Instance.EnergyTime / 10 + 1 ; i++)
            if(i < 5)  sp_Energy[i].spriteName = "energy";

        for (int i = (int)ChocoMgr.Instance.EnergyTime / 10  + 1; i < 5; i++)
            if (i < 5) sp_Energy[i].spriteName = "energy_empty";

        lb_Count.text = ChocoMgr.Instance.EnemyCnt.ToString();

        sp_Input.spriteName = (Input.isSelected) ? "Atk_P" : "Atk";
        sp_Input.height = (Input.isSelected) ? 127 : 147;

        if(ChocoMgr.Instance.IsBoss == false)
        {
            lb_Atk[0].text = ChocoMgr.Instance.AtkString[0];
            lb_Atk[1].text = ChocoMgr.Instance.AtkString[1];
            lb_Atk[2].text = ChocoMgr.Instance.AtkString[2];
        }
        else
        {
            lb_Atk[0].text = "";
            lb_Atk[1].text = ChocoMgr.Instance.AtkString[0];
            lb_Atk[2].text = "";
        }
    }

    //void update_Empty() { }

    //void update_real()
    //{
    //    ChocoMgr.Instance.CheckString(Input.value);
    //    Input.value = "";

    //    while (TouchScreenKeyboard.visible)
    //        return;

    //    Input.isSelected = true;
    //    func = update_Empty;
    //    isSubmit = false;
    //    Debug.Log("Open");
    //}

    public void OnClick_Pause()
    {
        ChocoMgr.Instance.PauseUI.Show();
    }

    public void OnClick_Plus()
    {
        ChocoMgr.Instance.Mission();
    }

    public void OnSubmit_Atk()
    {
        ChocoMgr.Instance.CheckString(Input.value);
        Input.value = "";
    }
}
