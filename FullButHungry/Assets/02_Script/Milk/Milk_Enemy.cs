using UnityEngine;
using System.Collections;

public class Milk_Enemy : MonoBehaviour
{
    public enum position
    {
        LT,
        RT,
        LB,
        RB,
    }

    public position pos = position.LB;
    public Transform sp_Main = null;
    public TweenRotation tw_rot = null;

    System.Action func;

    void Awake()
    {
        func = update_empty;
    }

    void Update()
    {
        func();
    }

    void update_empty() { }

    void update_real()
    {
        switch (pos)
        {
            case position.LB:
                transform.parent.Translate(new Vector2(-1, -1) * Time.unscaledDeltaTime);
                break;

            case position.LT:
                transform.parent.Translate(new Vector2(-1, 1) * Time.unscaledDeltaTime);
                break;

            case position.RB:
                transform.parent.Translate(new Vector2(1, -1) * Time.unscaledDeltaTime);
                break;

            case position.RT:
                transform.parent.Translate(new Vector2(1, 1) * Time.unscaledDeltaTime);
                break;
        }
    }

    public void SetData(int _index)
    {
        Vector2 __pos;
        switch (pos)
        {
            case position.LB:
                __pos = new Vector2(-160, -25);
                break;

            case position.LT:
                __pos = new Vector2(-187, 206);
                break;

            case position.RB:
                __pos = new Vector2(236, -25);
                break;

            case position.RT:
                __pos = new Vector2(196, 206);
                break;

            default:
                __pos = Vector2.zero;
                break;
        }

        transform.parent.localPosition = __pos;
        sp_Main.localRotation = Quaternion.identity;
        tw_rot.enabled = false;
        sp_Main.GetComponent<SpriteRenderer>().sprite = MilkMgr.Instance.NormalSprite[_index];
        func = update_empty;
    }

    public void Died()
    {
        tw_rot.enabled = true;
        func = update_real;
    }
}
