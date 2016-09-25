using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    // Update is called once per frame
    void OnEable()
    {
        StartCoroutine(Sound());
    }

    IEnumerator Sound()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        transform.Translate(0, 0.3f * Time.deltaTime, 0);
    }
}
