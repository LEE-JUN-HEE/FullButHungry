using UnityEngine;
using System.Collections;

public class PN_MilkMissionClear : MonoBehaviour 
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnClick_Continue()
    {
        MilkMgr.Instance.Pause(false);
        MilkMgr.Instance.MissionComplete();
        MilkMgr.Instance.InGameUI.ts_Bt.enabled = false;
        MilkMgr.Instance.InGameUI.ts_Bt.transform.localScale = Vector2.one;
        gameObject.SetActive(false);
    }
}
