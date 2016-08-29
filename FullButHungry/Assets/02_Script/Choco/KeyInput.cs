using UnityEngine;
using System.Collections;

public class KeyInput : MonoBehaviour 
{
    public UIInput Input = null;
    public System.Action<string> callback = null;

    public void Init()
    {
        Input.isSelected = true;
#if UNITY_IOS
        Input.transform.localPosition = new Vector2(0 ,TouchScreenKeyboard.area.yMax);
#else
        Input.transform.localPosition = new Vector2(0, -200);
#endif
        Input.gameObject.SetActive(true);
    }

    public void OnClick_Submit()
    {
        callback(Input.value);
        Input.value = "";
    }
}
