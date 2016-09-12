using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PN_MilkIngame : MonoBehaviour
{
    public List<UISprite> sp_Energy = new List<UISprite>();
    public List<UILabel> lb_Atk = new List<UILabel>();
    public UILabel lb_Count = null;
    public UIInput Input = null;
    public UISprite sp_Input = null;
    public UILabel debug = null;
    bool isSubmit = false;

    void Update()
    {
        if (MilkMgr.Instance.isPause) return;

        for (int i = 0; i < MilkMgr.Instance.EnergyTime / 10 + 1; i++)
            if (i < 5) sp_Energy[i].spriteName = "energy";

        for (int i = (int)MilkMgr.Instance.EnergyTime / 10 + 1; i < 5; i++)
            if (i < 5) sp_Energy[i].spriteName = "energy_empty";

        lb_Count.text = (MilkMgr.Instance.EnemyCnt * 4).ToString();

        sp_Input.spriteName = (Input.isSelected) ? "Atk_P" : "Atk";
        sp_Input.height = (Input.isSelected) ?  127 : 147;

        if (MilkMgr.Instance.IsBoss == false)
        {
            lb_Atk[0].text = MilkMgr.Instance.AtkString[0];
            lb_Atk[1].text = MilkMgr.Instance.AtkString[1];
            lb_Atk[2].text = MilkMgr.Instance.AtkString[2];
        }
        else
        {
            lb_Atk[0].text = "";
            lb_Atk[1].text = MilkMgr.Instance.AtkString[0];
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
        MilkMgr.Instance.PauseUI.Show();
    }

    public void OnClick_Plus()
    {
        MilkMgr.Instance.Mission();
    }

    public void OnSubmit_Atk()
    {
        MilkMgr.Instance.CheckString(Input.value);
        Input.value = "";
    }
}
