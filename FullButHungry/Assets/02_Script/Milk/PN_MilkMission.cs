using UnityEngine;
using System.Collections;

public class PN_MilkMission : MonoBehaviour
{
    public void OnClick_Submit()
    {
        MilkMgr.Instance.MissionComplete();
        gameObject.SetActive(false);
    }
}
