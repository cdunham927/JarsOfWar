using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
    public float baseMult = 10;
    //Save vectors for where the spawn can move

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TurnInPickles();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
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
        if (pickles > 0)
        {
            switch (pickles)
            {
                case 1:
                    PlayerController.player.score += baseMult * pickles;
                    PlayerController.player.heldPickles = 0;
                    break;
                case 2:
                    PlayerController.player.score += baseMult * pickles * 1.125f;
                    PlayerController.player.heldPickles = 0;
                    break;
                case 3:
                    PlayerController.player.score += baseMult * pickles * 1.25f;
                    PlayerController.player.heldPickles = 0;
                    break;
                case 4:
                    PlayerController.player.score += baseMult * pickles * 1.5f;
                    PlayerController.player.heldPickles = 0;
                    break;
                default:
                    PlayerController.player.score += baseMult * pickles * 1.75f;
                    PlayerController.player.heldPickles = 0;
                    break;
            }

            //Change position

        }
    }
}
