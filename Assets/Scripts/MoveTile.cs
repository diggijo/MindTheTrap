using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    [SerializeField] internal FollowRoute fr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (fr.coroutineAllowed)
            {
                StartCoroutine(fr.followTheRoute(fr.routeToGo));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (fr.coroutineAllowed)
            {
                StartCoroutine(fr.followTheRoute(fr.routeToGo));
            }
        }
    }
}
