using UnityEngine;
using System.Collections;

public class PN_MilkEmpty : MonoBehaviour
{
    public void Show()
    {
        MilkMgr.Instance.Pause(true);
        gameObject.SetActive(true);
    }

    public void OnClick_Continue()
    {
        gameObject.SetActive(false);
        MilkMgr.Instance.InGameUI.ts_Bt.enabled = true;
    }
}