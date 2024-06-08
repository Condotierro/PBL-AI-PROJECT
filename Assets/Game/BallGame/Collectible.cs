using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BallCollector")
        {
            Vector2 v = new Vector2(Random.RandomRange(-2.5f, 2.5f), Random.RandomRange(-2.5f, 2.5f));
            GameObject g = Instantiate(gameObject);
            g.transform.position = v;
            Destroy(gameObject);
            Debug.Log("Nice!");
        }
    }
}
