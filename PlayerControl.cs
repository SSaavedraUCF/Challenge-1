using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText();
        SetLivesText();
    }

   void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce(movement*speed);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp")) // Plus Score
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy")) // Minus Lives
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }

        if (count == 12) 
        {
            transform.position = new Vector2(62.41f, 0f); 
        }

        if (lives == 0 || count >= 20) // Lose condition forces the player to stop moving, but is also triggered for the win condition so that the player does not lose after winning
        {
            Destroy(this);
       
        }
        
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); //Win condition
        if (count >= 20)
        {
            winText.text = "You win! Game created by Sebastian Saavedra";
        }
    }

    void SetLivesText() //Lose Condition
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            winText.text = "You lose!";
        }
        

    }
}
