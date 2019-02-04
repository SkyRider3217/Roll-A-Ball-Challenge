using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text livesText;
    public Text winText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        score = 0;
        SetScoreText();
        lives = 3;
        SetLivesText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (count == 12) 
        {
            transform.position = new Vector3(24.39f, transform.position.y, transform.position.z);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        { 
            if (lives <= 0)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                score = score + 1;
                SetCountText();
                SetScoreText();
            }

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (lives <= 0)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                other.gameObject.SetActive(false);
                lives = lives - 1;
                score = score - 1;
                SetLivesText();
                SetScoreText();
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 20)
        {
            winText.text = "You Win!";
        }

    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "Game Over";
        }
    }
}
