using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumExample : MonoBehaviour
{
    public enum EnemyState { Searching, Attacking, Dead }
    public EnemyState currentEnemyState;
    // Use this for initialization
    void Start()
    {
        currentEnemyState = EnemyState.Searching;

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentEnemyState)
        {
            case EnemyState.Attacking:
                Debug.Log("Attacking");
                break;

            case EnemyState.Searching:
                Debug.Log("Searching");
                break;

            case EnemyState.Dead:
                Debug.Log("Dead");
                break;


        }
    }
}
