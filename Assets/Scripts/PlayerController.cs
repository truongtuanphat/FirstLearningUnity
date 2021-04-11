using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public int speed = 2000;
    public int turningSpeed = 50;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        rb = GetComponent<Rigidbody>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(0, rb.velocity.y, -movement * turningSpeed * Time.deltaTime * 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))  
        {
            Destroy(other.gameObject);
            AddScore();
        }

        if (other.CompareTag("Fall"))
        {
            SceneManager.LoadScene("GameOver");
        }

        if (other.CompareTag("Finish"))
        {
            PlayerPrefs.SetString("FinishScore", scoreText.text);
            SceneManager.LoadScene("Finish");
        }
    }
    
    private void AddScore()
    {
        scoreText.text = (Int32.Parse(scoreText.text) + 1).ToString();
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Ground")
        {   
            rb.AddForce(speed * Time.deltaTime * 10f, 0, 0);
            this.enabled = true;
        }
    }
}
