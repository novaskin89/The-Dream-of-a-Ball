using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    private Rigidbody rb;
    public float speed;
    public Text PickUpText;
    public Text LivesText;
    private int count;
    public int lives;
    public int health;
    public GameObject Player;
    public Color fullHealth;
    public Color midHealth;
    public Color LowHealth;
    [SerializeField] private Transform RespawnPoint;
    [SerializeField] private Transform PlayerTransform;
    bool hasplayed2Hp = false;
    bool hasplayed1Hp = false;
    bool hasFallen = false;

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
        }

        if (other.gameObject.CompareTag("FallingTrigger"))
        {
            HasFallen();

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
            audio.Play();
            audio.PlayDelayed(44100);
            hasplayed2Hp = true;
        }
    }

    void damagesound1Hp()

    {

        if (hasplayed1Hp == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.PlayDelayed(44100);
            hasplayed1Hp = true;
        }
    }

    void HasFallen()

    {
        if (hasFallen == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.PlayDelayed(44100);
            hasFallen = true;
        }
    }
}

