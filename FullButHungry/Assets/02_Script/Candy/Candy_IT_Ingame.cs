using UnityEngine;
using System.Collections;

public class Candy_IT_Ingame : MonoBehaviour
{
    public SpriteRenderer sp_Main = null;

    bool isReady = false;
    bool isDead = false;

    public void SetData()
    {

    }

    IEnumerator Ready()
    {
        yield return null;
    }

    IEnumerator Dead()
    {
        yield return null;
    }

    public void OnClick_Hit()
    {
        if (isReady == false || isDead == true) return;
    }
}
