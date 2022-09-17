using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpikes : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] Rigidbody2D rb;

    private void Update()
    {
        dropSpikes();
    }
    void dropSpikes()
    {
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, range);

        Debug.DrawRay(transform.position, Vector2.down * range, Color.red);

        if (hitDown.transform != null)
        {
            if (hitDown.transform.tag == "Player")
            {
                rb.gravityScale = 1.5f;
            }
        }
    }
}
