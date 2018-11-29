using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController player;
    public float maxHealth = 2;
    private float health;
    public int heldPickles;
    Rigidbody2D bod;
    Animator anim;
    public float spd;
    Vector2 input;

	// Use this for initialization
	void Awake () {

        if (player == null)
            player = this;
        else if (player != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        bod = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update ()
    {// Check if we're moving to the side
        var horizontalSpeed = Input.GetAxis("Horizontal") * spd;
        var verticalSpeed = Input.GetAxis("Vertical") * spd;

        // If the mouse is held down (or the screen is tapped
        // on Mobile)
        if (Input.GetMouseButton(0))
        {
            // Converts to a 0 to 1 scale
            var worldPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float xMove = 0;
            float yMove = 0;

            // If we press the right side of the screen
            if (worldPos.x < 0.5f)
            {
                xMove = -1;
            }
            else
            {
                // Otherwise we're on the left
                xMove = 1;
            }

            if (worldPos.y < 0.5f)
            {
                yMove = -1;
            }
            else
            {
                yMove = 1;
            }

            // replace horizontalSpeed/verticalSpeed with our own value
            horizontalSpeed = xMove * spd;
            verticalSpeed = yMove * spd;
        }

        // Apply our auto-moving and movement forces
        bod.AddForce(new Vector2(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime));


        if (heldPickles > 0) {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
