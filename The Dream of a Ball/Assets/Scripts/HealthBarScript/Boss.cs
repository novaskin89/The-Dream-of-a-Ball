using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss instance;
    [SerializeField] private GameObject boss;
    public Shake shake;
    public GameObject BossArea;
    public GameObject BossArea2;
    public GameObject[] healthSpawned;
    public int BossHealth = 33;
    public int DamageToBoss = 10;
    public Material fullHealth;
    public Material lowHealth;
    public Renderer rend;
    public bool lerpColors = true;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = fullHealth;

        if (lerpColors)
        {
            rend.material = fullHealth;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))

        {
            BossHealth = BossHealth - DamageToBoss;
        }

        if (Input.GetKeyDown(KeyCode.E))

        {
            BossHealth = BossHealth + DamageToBoss;
        }

        if (lerpColors)
        {
            rend.material.Lerp(lowHealth, fullHealth, BossHealth * Time.deltaTime);
        }

        if (BossHealth == 3)
        {
            shake.shake1 = true;
        }

        if (BossHealth == 2)
        {
            shake.shake2 = true;
        }

        if (BossHealth == 1)
        {
            shake.shake3 = true;
        }

        if (BossHealth == 0)
        {
            BossArea.SetActive(false);
            BossArea2.SetActive(true);
            {
                healthSpawned = GameObject.FindGameObjectsWithTag("FallingHealthUp");
                foreach (GameObject FallingHealthUp in healthSpawned)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
