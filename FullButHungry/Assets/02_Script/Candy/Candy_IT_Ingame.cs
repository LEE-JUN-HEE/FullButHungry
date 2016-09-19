using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Candy_IT_Ingame : MonoBehaviour
{
    public SpriteRenderer sp_Main = null;
    List<Sprite> sprite = new List<Sprite>();

    bool isReady = false;
    bool isDead = false;

    void Update()
    {

    }

    public void SetData(int index)
    {
        sprite.Clear();
        sprite.Add(Resources.Load<Sprite>(string.Format("MainCharacter/Candy/{0}_{1}", index, 1)));
        sprite.Add(Resources.Load<Sprite>(string.Format("MainCharacter/Candy/{0}_{1}", index, 2)));
        sprite.Add(Resources.Load<Sprite>(string.Format("MainCharacter/Candy/{0}_{1}", index, 3)));
        sprite.Add(Resources.Load<Sprite>(string.Format("MainCharacter/Candy/{0}_{1}", index, "D")));

        StartCoroutine(Ready());
    }

    IEnumerator Ready()
    {
        sp_Main.sprite = sprite[0];

        yield return new WaitForSeconds(0.5f);
        sp_Main.sprite = sprite[1];

        yield return new WaitForSeconds(0.5f);
        sp_Main.sprite = sprite[2];

        isReady = true;
    }

    IEnumerator Dead()
    {
        isReady = false;
        isDead = true;
        sp_Main.sprite = sprite[3];

        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i<10; i++)
        {
            sp_Main.color = new Color(0, 0, 0, 255 - 25f * 10);
            yield return null;
        }

        Destroy(this);
    }

    public void OnClick_Hit()
    {
        if (isReady == false || isDead == true) return;
    }
}
