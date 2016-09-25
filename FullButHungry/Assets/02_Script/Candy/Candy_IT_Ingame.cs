using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Candy_IT_Ingame : MonoBehaviour
{
    public SpriteRenderer sp_Main = null;
    List<Sprite> sprite = new List<Sprite>();

    float starttime = 0;
    public bool isReady = false;
    public bool isDead = false;

    void Update()
    {
        if (CandyMgr.Instance.isPause == true) return;
        if (isReady == false) return;

        if(starttime + 3f < Time.time)
        {
            if(isDead == false) StartCoroutine(Hide());
        }
    }

    public void SetData(int index)
    {
        Debug.Log(index);
        sprite.Clear();
        sprite.Add(Resources.Load<Sprite>(string.Format("Candy/{0}_{1}", index, 1)));
        sprite.Add(Resources.Load<Sprite>(string.Format("Candy/{0}_{1}", index, 2)));
        sprite.Add(Resources.Load<Sprite>(string.Format("Candy/{0}_{1}", index, 3)));
        sprite.Add(Resources.Load<Sprite>(string.Format("Candy/{0}_{1}", index, "D")));
        gameObject.SetActive(true);
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
        starttime = Time.time;
    }

    IEnumerator Dead()
    {
        isReady = false;
        isDead = true;
        sp_Main.sprite = sprite[3];

        CandyMgr.Instance.EnemyCnt++;

        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i<10; i++)
        {
            sp_Main.color = new Color(1, 1, 1, (255 - 25f * i) / 255f);
            yield return null;
        }

    
        Destroy(gameObject);
    }

    IEnumerator Hide()
    {
        isReady = false;

        sp_Main.sprite = sprite[2];

        for (int i = 0; i < 10; i++)
        {
            sp_Main.color = new Color(1, 1, 1,  (255 - 25f * i)/255f);
            yield return null;
        }

        Destroy(gameObject);
    }

    public void OnClick_Hit()
    {
        if (isReady == false || isDead == true) return;
        StartCoroutine(Dead());
    }
}
