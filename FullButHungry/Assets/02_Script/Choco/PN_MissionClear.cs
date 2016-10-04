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
        gameObject.SetActive(false);
    }
}
