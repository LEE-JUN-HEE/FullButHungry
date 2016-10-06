using UnityEngine;
using System.Collections;

public class PN_MissionClear : MonoBehaviour {

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnClick_Continue()
    {
        ChocoMgr.Instance.Pause(false);
        ChocoMgr.Instance.MissionComplete();
        ChocoMgr.Instance.InGameUI.ts_Bt.enabled = false;
        ChocoMgr.Instance.InGameUI.ts_Bt.transform.localScale = Vector2.one;
        gameObject.SetActive(false);
    }
}
