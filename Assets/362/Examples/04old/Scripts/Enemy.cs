using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    [SerializeField]
    float MoveSpeed = 1f, MoveSpeedMultiplier = 1f;
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        Debug.Log("Enemy Created");
        Ready();
    }

    public void Ready()
    {
        MoveSpeedMultiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpeedMultiplier += Time.deltaTime * 0.5f;
        transform.position = 
            Vector2.MoveTowards(transform.position, player.transform.position, 
            Time.deltaTime * Time.timeScale * MoveSpeed * MoveSpeedMultiplier);
    }

    void OnDestroy()
    {
        Debug.Log("Enemy Destroyed");
    }
}
