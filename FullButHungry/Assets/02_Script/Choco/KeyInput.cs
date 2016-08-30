using UnityEngine;
using System.Collections;

public class KeyInput : MonoBehaviour 
{
    public UIInput Input = null;
    public System.Action<string> callback = null;

    public TouchScreenKeyboard hi;

    void Update()
    {
        if (ChocoMgr.Instance.isPause) return;

        Input.value = hi.text;
    }

    public void Init()
    {
        hi = new TouchScreenKeyboard(null, TouchScreenKeyboardType.Default, false, false, false, false, null);
        TouchScreenKeyboard.Open(null);
        TouchScreenKeyboard.hideInput = true;

#if UNITY_IOS
        Input.transform.localPosition = new Vector2(0 ,TouchScreenKeyboard.area.yMax);
#else
        Input.transform.localPosition = new Vector2(0, -100);
#endif
        Input.gameObject.SetActive(true);
    }

    public void OnClick_Submit()
    {
        callback(hi.text);
        hi.text = "";
    }
}
