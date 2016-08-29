using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PN_Ingame : MonoBehaviour 
{
    public List<UISprite> sp_Energy = new List<UISprite>();
    public List<UILabel> lb_Atk = new List<UILabel>();
    public UILabel lb_Count = null;

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

    public void OnClick_Pause()
    {
        ChocoMgr.Instance.Pause(!ChocoMgr.Instance.isPause);
    }
}
