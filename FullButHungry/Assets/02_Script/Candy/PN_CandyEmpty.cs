using UnityEngine;
using System.Collections;

public class PN_CandyEmpty : MonoBehaviour {

    public void Show()
    {
        CandyMgr.Instance.Pause(true);
        gameObject.SetActive(true);
    }

    public void OnClick_Continue()
    {
        gameObject.SetActive(false);
        CandyMgr.Instance.InGameUI.ts_Bt.enabled = true;
    }
}
