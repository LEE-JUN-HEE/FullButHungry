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
    public UISprite sp_Main = null;
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
                transform.Translate(new Vector2(-1, -1));
                break;

            case position.LT:
                transform.Translate(new Vector2(-1, 1));
                break;

            case position.RB:
                transform.Translate(new Vector2(1, -1));
                break;

            case position.RT:
                transform.Translate(new Vector2(1, 1));
                break;
        }
    }

    public void SetData(position _pos, int _index)
    {
        pos = _pos;
        tw_rot.enabled = false;
        func = update_empty;
    }

    public void Died()
    {
        tw_rot.enabled = true;
        func = update_real;
    }
}
