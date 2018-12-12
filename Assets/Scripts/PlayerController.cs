using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public static PlayerController player;
    public float maxHealth = 2;
    public float health;
    public int heldPickles;
    public float score = 0;
    Rigidbody2D bod;
    Animator anim;
    public float spd;
    Vector2 input;
    public Text scoreText;
    public Text helpText;
    public Text helpButtonText;
    public GameObject gameOver;
    public Vector3 startPos;
    float iframes = 0;
    public Text pickleText;

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
        startPos = transform.position;
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        score = 0;
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

        }
        else
        {

        }

        if (scoreText == null) scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        if (helpButtonText == null) helpButtonText = GameObject.FindGameObjectWithTag("HelpButton").GetComponent<Text>();
        if (helpText == null) helpText = GameObject.FindGameObjectWithTag("Help").GetComponent<Text>();
        if (gameOver == null) gameOver = GameObject.FindGameObjectWithTag("GameOver");

        if (scoreText != null) scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        helpButtonText.text = (helpText.text == "") ? "Enable help text" : "Disable help text";

        if (health > 0 && gameOver.activeInHierarchy) gameOver.SetActive(false);

        if (health <= 0)
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
        }

        pickleText.text = (heldPickles > 0) ? "x" + heldPickles.ToString() : "";
        anim.SetInteger("pickles", heldPickles);
        if (iframes > 0) iframes -= Time.deltaTime;
    }

    public void TakeDamage(float amt)
    {
        if (iframes <= 0)
        {
            if (heldPickles > 0)
            {
                heldPickles = 0;
                iframes = 0.75f;
            }
            else
            {
                health = 0;
            }
        }
    }
}
