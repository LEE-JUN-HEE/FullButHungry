using UnityEngine;
using System.Collections;

public class UI_Mission : MonoBehaviour 
{
    public void Show()
    {
        gameObject.SetActive(true);
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
