using UnityEngine;
using System.Collections;

public class PN_Boom : MonoBehaviour {

    float StartTime = 0;

    void Start () 
    {
        StartTime = Time.unscaledTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (StartTime + 4 < Time.unscaledTime)
        {
            gameObject.SetActive(false);
        }
	}
}
