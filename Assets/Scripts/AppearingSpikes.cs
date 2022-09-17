using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingSpikes : Spikes
{
    [SerializeField] private float range;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    void Update()
    {
        showSpikes();
    }

    private void showSpikes()
    {
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, range);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, range);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, range);

        /*Debug.DrawRay(transform.position, Vector2.left * range, Color.red);
        Debug.DrawRay(transform.position, Vector2.up * range, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * range, Color.red);*/

        if (hitLeft.transform != null)
        {
            if (hitLeft.transform.tag == "Player")
            {
                sr.enabled = true;
            }
        }

        if (hitUp.transform != null)
        {
            if (hitUp.transform.tag == "Player")
            {
                if(!sr.enabled)
                {
                    sr.enabled = true;
                }
            }
        }

        if (hitRight.transform != null)
        {
            if (hitRight.transform.tag == "Player")
            {
                if (!sr.enabled)
                {
                    sr.enabled = true;
                }
            }
        }
    }
}
