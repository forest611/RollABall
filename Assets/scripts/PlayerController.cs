using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
    public float speed = 20;

    public Text scoreText;
    public Text resut;
    public Text watch;
    public int score;

    private Rigidbody rb;
    System.Diagnostics.Stopwatch sw;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody
        rb = GetComponent<Rigidbody>();
        score = 0;
        setCountText();
        resut.text = "";
        watch.text = "";

        //stop watch
        sw = new System.Diagnostics.Stopwatch();
        sw.Start();
    }

    private void setCountText()
    {
        scoreText.text = "Score:" + score.ToString();
        if (score == 12)
        {
            sw.Stop();
            watch.text = sw.Elapsed.ToString();
            resut.text = "Game Clear!";
        }
    }

    void Update()
    {
        // Get carsor input
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // set
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //if the bumped item is picking up 
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // hide the item
            other.gameObject.SetActive(false);

            score++;
            setCountText();
        }
    }
}
