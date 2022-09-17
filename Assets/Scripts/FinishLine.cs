using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller2D;
    [SerializeField] private GameHandler gh;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !controller2D.isDead)
        {
            print("You finished the level");
            print("You died " + gh.deaths + " times");
        }
    }
}
