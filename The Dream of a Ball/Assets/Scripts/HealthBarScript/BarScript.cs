using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    public int BossHealth = 100;
    public int DamageToBoss = 1;
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

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))

        {
            BossHealth = BossHealth - DamageToBoss;
        }

        if (Input.GetKeyDown(KeyCode.W))

        {
            BossHealth = BossHealth + DamageToBoss;
        }

        if (lerpColors)
        {
            Debug.Log("Boss Healt" + BossHealth);
            rend.material.Lerp(lowHealth, fullHealth, BossHealth * Time.deltaTime);
        }

    }
}
