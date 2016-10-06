using UnityEngine;
using System.Collections;

public class PN_CandyMissionClear : MonoBehaviour {


    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnClick_Continue()
    {
        CandyMgr.Instance.Pause(false);
        CandyMgr.Instance.MissionComplete();
        CandyMgr.Instance.InGameUI.ts_Bt.enabled = false;
        CandyMgr.Instance.InGameUI.ts_Bt.transform.localScale = Vector2.one;
        gameObject.SetActive(false);
    }
}
