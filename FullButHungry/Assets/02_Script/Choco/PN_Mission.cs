using UnityEngine;
using System.Collections;

public class PN_Mission : MonoBehaviour {
    
    public void OnClick_Submit()
    {
        ChocoMgr.Instance.MissionComplete();
        gameObject.SetActive(false);
    }
}
