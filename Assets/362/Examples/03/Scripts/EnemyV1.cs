using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV1 : MonoBehaviour
{
    PlayerV1 player;
    // Start is called before the first frame update
    [SerializeField]
    float MoveSpeed = 1f;
    void Start()
    {
        player = FindFirstObjectByType<PlayerV1>();
        Debug.Log("Enemy Created");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * MoveSpeed);
    }

    void OnDestroy()
    {
        Debug.Log("Enemy Destroyed");
    }
}
