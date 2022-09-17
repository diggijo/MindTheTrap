using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRoute : MonoBehaviour
{
    [SerializeField] Transform[] routes;
    private int routesLeft;
    private float timeCounter;
    private Vector2 tilePosition;
    private float moveSpeed;
    internal bool coroutineAllowed;
    
    void Start()
    {
        routesLeft = 0;
        timeCounter = 0f;
        moveSpeed = 0.65f;
        coroutineAllowed = true;
    }
    
    internal IEnumerator followTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while (timeCounter < 1)
        {
            timeCounter += Time.deltaTime * moveSpeed;

            tilePosition = Mathf.Pow(1 - timeCounter, 3) * p0 +
                3 * Mathf.Pow(1 - timeCounter, 2) * timeCounter * p1 +
                3 * (1 - timeCounter) * Mathf.Pow(timeCounter, 2) * p2 +
                Mathf.Pow(timeCounter, 3) * p3;

            transform.position = tilePosition;
            yield return new WaitForEndOfFrame();
        }

        timeCounter = 0f;

        routesLeft++;

        if(routesLeft > routes.Length - 1)
        {
            routesLeft = 0;
        }

        coroutineAllowed = true;
    }
}
