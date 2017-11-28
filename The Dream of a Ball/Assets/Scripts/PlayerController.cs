using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public static PlayerController playerController;
    public OpenGate opengate;
    public OpenGate2 opengate2;
    public OpenGate2 opengate3;
    public Rigidbody rb;
    public float speed;
    public Text PickUpText;
    public Text LivesText;
    //[HideInInspector]
    public int count;
    public int lives;
    [Header("Health Settings")] public int health;
    public GameObject Player;
    public Color fullHealth;
    public Color midHealth;
    public Color lowHealth;
    public Color death;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform respawnPoint2;
    [SerializeField] private Transform respawnPoint3;
    [SerializeField] private Transform respawnPoint4;
    [SerializeField] private Transform PlayerTransform;
    bool hasPlayed2Hp = false;
    bool hasPlayed1Hp = false;
    bool hasPlayedPickUp = false;
    bool hasPlayedfallingSound = false;
    private bool invulnerable = false;
    public bool hasPlayeddeath = false;
    bool isDead = false;
    public bool gameOver = false;
    public AudioClip damageSound;
    public AudioClip pickUp;
    public AudioClip fallingBall;
    public AudioClip deathSound;
    public Transform pauseCanvas;

    private void Awake()
    {
        playerController = this;
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        health = 3;
        lives = 3;
        count = PlayerPrefs.GetInt("PickUpCollected");
        lives = PlayerPrefs.GetInt("livesLeft");
        health = PlayerPrefs.GetInt("healthLeft");
        SetPickUpText();
        SetLivesText();
    }

    // Update is called once per frames

    void Update()
    {
        //cheat code
        if(Input.GetKeyDown(KeyCode.P))
        {
            health = 0;
            lives = 0;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            lives = lives + 1;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            health = health + 1;
        }

        switch (health)
        {
            case 3:
                isDead = false;
                GetComponent<Renderer>().material.color = fullHealth;
                EnableRagdoll();
                break;

            case 2:
                GetComponent<Renderer>().material.color = midHealth;
                Damagesound2Hp();
                break;

            case 1:
                GetComponent<Renderer>().material.color = lowHealth;
                Damagesound1Hp();
                break;

            case 0:

                if (isDead == false)
                {
                    isDead = true;
                    GetComponent<Renderer>().material.color = death;
                    DisableRagdoll();
                    Invoke("PlayerRespawn", 1.5f);
                    DieSound();
                }
                break;

            default:
                break;
        }

        //if (health == 3)
        //{
        //    isDead = false;
        //    // stefano: pausa non funzionava perche ci stava questa linea qui sotto! 
        //    //Time.timeScale = 1;
        //    GetComponent<Renderer>().material.color = fullHealth;
        //    EnableRagdoll();
        //}

        //if (health == 2)
        //{
        //    GetComponent<Renderer>().material.color = midHealth;
        //    Damagesound2Hp();
        //}

        //if (health == 1)
        //{
        //    GetComponent<Renderer>().material.color = lowHealth;
        //    Damagesound1Hp();
        //}

        //if (health == 0)
        //{
        //    // stefano: pausa non funzionava per colpa dei booleans, guarda la mia modifica per capire come ho fatto
        //    //ci sei andato vicino comunque
        //    // il boolean "isDead" lo resetto a falso nella linea 54
        //    if (isDead == false)
        //    {
        //        isDead = true;
        //        GetComponent<Renderer>().material.color = death;
        //        DisableRagdoll();
        //        Invoke("PlayerRespawn", 1.5f);
        //        DieSound();
        //    }
        //}
    }

    void FixedUpdate()
    {

        if (lives == 0)
        {
            gameOver = true;
        }

        if (Time.timeScale == 1)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
            rb.AddForce(movement * speed);
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (hasPlayedPickUp == false)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = pickUp;
                audio.Play();
                hasPlayed2Hp = true;
            }
            other.gameObject.SetActive(false);
            count = count + 1;
            SetPickUpText();
        }
        if (!invulnerable)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                health = health - 1;
                invulnerable = true;
                yield return new WaitForSeconds(1);  // wait until unpausing damage
                invulnerable = false;                     // unpause damage 
            }

            if (other.gameObject.CompareTag("BossSoul2"))
            {
                health = health - 1;
                invulnerable = true;
                yield return new WaitForSeconds(1);  // wait until unpausing damage
                invulnerable = false;                     // unpause damage 
            }
        }

        if (other.gameObject.CompareTag("DeathTrigger"))
        {
            SetLivesText();
            health = 3;
            DisableRagdoll();
            Invoke("PlayerRespawn", 0.5f);
        }

        if (other.gameObject.CompareTag("FallingTrigger"))
        {
            if (hasPlayedfallingSound == false)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = fallingBall;
                audio.Play();
                hasPlayedfallingSound = true;
                hasPlayedfallingSound = false;
            }
        }

        if (other.gameObject.CompareTag("DoorTrigger1"))
        {
            opengate.trigger = true;
        }

        if (other.gameObject.CompareTag("DoorTrigger2"))
        {
            opengate2.trigger = true;
            opengate3.trigger = true;
        }

        if (other.gameObject.CompareTag("RPUpdate"))
        {
            respawnPoint.transform.position = respawnPoint2.transform.position;
        }

        if (other.gameObject.CompareTag("RPUpdate2"))
        {
            respawnPoint.transform.position = respawnPoint3.transform.position;
        }

        if (other.gameObject.CompareTag("RPUpdate3"))
        {
            respawnPoint.transform.position = respawnPoint4.transform.position;
        }
    }

    void SetPickUpText()
    {
        PickUpText.text = "PickUp: " + count.ToString() + "/100";
    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + lives.ToString();
    }

    void Damagesound2Hp()
    {
        if (hasPlayed2Hp == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = damageSound;
            audio.Play();
            hasPlayed2Hp = true;
        }
    }

    void Damagesound1Hp()
    {
        if (hasPlayed1Hp == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = damageSound;
            audio.Play();
            hasPlayed1Hp = true;
        }
    }

    void DieSound()
    {
        if (hasPlayeddeath == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = deathSound;
            audio.Play();
            hasPlayeddeath = true;
            hasPlayeddeath = false;
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

        if (c.gameObject.tag == "BossSoul2")
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
        PlayerTransform.transform.position = respawnPoint.transform.position;
        health = 3;
        hasPlayed2Hp = false;
        hasPlayed1Hp = false;
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