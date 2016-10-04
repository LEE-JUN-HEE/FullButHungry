using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PN_CandyIngame : MonoBehaviour {

    public List<UISprite> sp_Energy = new List<UISprite>();
    public UILabel lb_Count = null;
    public TweenScale ts_Bt = null;

    void Update()
    {
        if (CandyMgr.Instance.isPause) return;

        for (int i = 0; i < CandyMgr.Instance.EnergyTime / 10 + 1; i++)
            if (i < 5 && i >= 0) sp_Energy[i].spriteName = "energy";

        for (int i = (int)CandyMgr.Instance.EnergyTime / 10 + 1; i < 5; i++)
            if (i < 5 && i >= 0) sp_Energy[i].spriteName = "energy_empty";

        lb_Count.text = (CandyMgr.Instance.EnemyCnt).ToString();
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
        CandyMgr.Instance.PauseUI.Show();
    }

    public void OnClick_Plus()
    {
        CandyMgr.Instance.Mission();
    }
}
