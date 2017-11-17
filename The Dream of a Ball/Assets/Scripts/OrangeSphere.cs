using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSphere : MonoBehaviour
{

    public PlayerController playerController;
    public BarScript boss;
    public Transform bossSoul;
    public float speed = 1f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(bossSoul.position, bossSoul.position, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BossSoul"))
        {
            boss.BossHealth -= 75;
        }
    }
}