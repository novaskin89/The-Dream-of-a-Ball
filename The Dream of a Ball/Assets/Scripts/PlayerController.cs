using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    public Rigidbody rb;
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
    public Color death;
    [SerializeField] private Transform RespawnPoint;
    [SerializeField] private Transform RespawnPoint2;
    [SerializeField] private Transform RespawnPoint3;
    [SerializeField] private Transform RespawnPoint4;
    [SerializeField] private Transform PlayerTransform;
    bool hasplayed2Hp = false;
    bool hasplayed1Hp = false;
    public AudioClip DamageSound;
    public Transform pauseCanvas;
    
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseCanvas.gameObject.activeInHierarchy == false)
            {
                pauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        if (health == 3)
        {
            Time.timeScale = 1;
            GetComponent<Renderer>().material.color = fullHealth;
            EnableRagdoll();
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
            //Time.timeScale = 0;
            GetComponent<Renderer>().material.color = death;
            DisableRagdoll();            
            Invoke("PlayerRespawn", 1);
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
            SetLivesText();
            health = 3;
            DisableRagdoll();
            Invoke("PlayerRespawn", 0.5f);
        }

        if (other.gameObject.CompareTag("RPUpdate"))
        {
            RespawnPoint.transform.position = RespawnPoint2.transform.position;
        }

        if (other.gameObject.CompareTag("RPUpdate2"))
        {
            RespawnPoint.transform.position = RespawnPoint3.transform.position;
        }

        if (other.gameObject.CompareTag("RPUpdate3"))
        {
            RespawnPoint.transform.position = RespawnPoint4.transform.position;
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

        // If the object we hit is the Enemy
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
        health = 3;
        hasplayed2Hp = false;
        hasplayed1Hp = false;
        EnableRagdoll();
        lives = lives - 1;
        SetLivesText();
    }

    void DisableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }
}

