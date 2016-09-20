using UnityEngine;
using System.Collections;

public class PN_CandyMission : MonoBehaviour {

    public void OnClick_Submit()
    {
        CandyMgr.Instance.MissionComplete();
        gameObject.SetActive(false);
    }
}
