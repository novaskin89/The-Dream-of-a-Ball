using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSphere2 : MonoBehaviour
{
    public Boss boss;

    public Transform bossSoul;
    public float speed = 30f;
    public bool attack = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attack == true)
        {
            Attack();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attack = true;
        }
        if (other.gameObject.CompareTag("BossSoul2"))
        {
            boss.BossHealth -= 10;
        }
    }

    void Attack()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, bossSoul.position, step);
    }
}