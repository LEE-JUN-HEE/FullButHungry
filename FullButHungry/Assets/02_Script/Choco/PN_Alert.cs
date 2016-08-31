using UnityEngine;
using System.Collections;

public class PN_Alert : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_this()
    {
        Hide();
    }
}
