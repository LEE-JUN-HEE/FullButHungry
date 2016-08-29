using UnityEngine;
using System.Collections;

public class KeyInput : MonoBehaviour 
{
    public UIInput Input = null;
    public System.Action callback = null;

    public void Init()
    {
        Input.SendMessage("OnClick");
        Input.transform.localPosition = new Vector2(0 ,TouchScreenKeyboard.area.yMax);
        Input.gameObject.SetActive(true);
    }

    public void OnClick_Submit()
    {
        Input.value = "";
    }
}
