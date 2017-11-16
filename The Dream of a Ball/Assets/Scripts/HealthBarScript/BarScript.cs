using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    [SerializeField] private float fillAmount;
    [SerializeField] private GameObject boss;
    public float MaxValue { get; set; }
    public int BossHealth = 100;
    public int DamageToBoss = 1;
    public Material fullHealth;
    public Material lowHealth;
    public Renderer rend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))

        {
            BossHealth = BossHealth - DamageToBoss;
            Debug.Log("Boss Healt" + BossHealth);
            rend.material.Lerp(lowHealth, fullHealth, BossHealth*Time.deltaTime);

        }
        //HealthPool();


    }
    //private void HealthPool()
    //{
    //    GetComponent<Renderer>().material.color = fillAmount;
    //}


}
