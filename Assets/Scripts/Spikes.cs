using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller2D;
    [SerializeField] private GameHandler gh;

    void Start()
    {

    }

    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !controller2D.isDead)
        {
            controller2D.isDead = true;
            gh.Respawn();
        }
    }
}
