﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    private Rigidbody rb;
    public float speed;
    public Text PickUpText;
    public Text LivesText;
    [HideInInspector] public int count;
    public int lives;
    [Header("Health Settings")] public int health;
    public GameObject Player;
    public Color fullHealth;
    public Color midHealth;
    public Color LowHealth;
    [SerializeField] private Transform RespawnPoint;
    [SerializeField] private Transform PlayerTransform;
    bool hasplayed2Hp = false;
    bool hasplayed1Hp = false;
    bool hasFallen = false;
    public AudioClip DamageSound;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetPickUpText();
        health = 3;
        lives = 3;
    }

    // Update is called once per frames

    void Update()
    {
        if (health == 3)
        {
            GetComponent<Renderer>().material.color = fullHealth;
        }

        if (health == 2)
        {
            GetComponent<Renderer>().material.color = midHealth;
            damagesound2Hp();
        }

        if (health == 1)
        {
            GetComponent<Renderer>().material.color = LowHealth;
            damagesound1Hp();
        }

        if (health == 0)
        {
            PlayerTransform.transform.position = RespawnPoint.transform.position;
            health = 3;
            lives = lives - 1;
            hasplayed2Hp = false;
            hasplayed1Hp = false;
            bool hasFallen = false;
            SetLivesText();
        }

        if (lives == 2)
        {
            hasFallen = false;
        }

        if (lives == 1)
        {
            hasFallen = false;
        }

        if (lives == 0)
        {
            hasFallen = false;
        }
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetPickUpText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
        }

        if (other.gameObject.CompareTag("DeathTrigger"))
        {
            lives = lives - 1;
            SetLivesText();
            health = 3;
            Invoke("PlayerRespawn()", 5);
        }             
    }

    void SetPickUpText()

    {
        PickUpText.text = "PickUp: " + count.ToString() + "/100";
        if (count >= 9)
        {

        }
    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + lives.ToString();
    }

    void damagesound2Hp()
    {
        if (hasplayed2Hp == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = DamageSound;
            audio.Play();
            hasplayed2Hp = true;
        }
    }

    void damagesound1Hp()

    {

        if (hasplayed1Hp == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = DamageSound;
            audio.Play();
            hasplayed1Hp = true;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 400;

        // If the object we hit is the enemy
        if (c.gameObject.tag == "Enemy")
        {
            // Calculate Angle Between the collision point and the p2\2layer
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force);
        }

       
    }

    void PlayerRespawn()
    {
        PlayerTransform.transform.position = RespawnPoint.transform.position;
    }
}

