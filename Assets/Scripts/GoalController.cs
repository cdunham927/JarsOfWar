using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TurnInPickles();
        }
    }

    void TurnInPickles()
    {
        //Give player points based on how many pickles they have
        //More pickles gives a higher multiplier
        int pickles = PlayerController.player.heldPickles;
        switch(pickles)
        {
            case 0:
                PlayerController.player.heldPickles = 0;
                break;
            case 1:
                PlayerController.player.heldPickles = 0;
                break;
            case 2:
                PlayerController.player.heldPickles = 0;
                break;
            case 3:
                PlayerController.player.heldPickles = 0;
                break;
            case 4:
                PlayerController.player.heldPickles = 0;
                break;
            default:
                PlayerController.player.heldPickles = 0;
                break;
        }
    }
}
