using UnityEngine;
using System.Collections;

public class PN_Empty : MonoBehaviour 
{
    public void Show()
    {
        ChocoMgr.Instance.Pause(true);
        gameObject.SetActive(true);
    }

    public void OnClick_Continue()
    {
        gameObject.SetActive(false);
        ChocoMgr.Instance.InGameUI.ts_Bt.enabled = true;
    }
}
