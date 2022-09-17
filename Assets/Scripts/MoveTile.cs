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
                print("enter");
                StartCoroutine(fr.followTheRoute(0));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (fr.coroutineAllowed)
            {
                print("exit");
                StartCoroutine(fr.followTheRoute(1));
            }
        }
    }
}
