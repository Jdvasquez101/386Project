using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitPool))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    int maxEnemiesSpawned = 100, spawnsPerSecond = 1;
    [SerializeField]
    public bool usePooling = false;
    [SerializeField]
    GameObject enemyPrefab;
    public UnitPool pool {get; protected set;}
    float timer = 0;
    [SerializeField]
    int curSpawned = 0;//Should increment up to maxEnemiesSpawned
    [SerializeField]
    bool unique_Material = false;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<UnitPool>();
        player = FindObjectOfType<Player>().transform;
    }

    public void EnemyKilled(GameObject enemy)
    {
        curSpawned--;
        Debug.Log("Enemy Killed");
        if(usePooling)
            pool.pool.Release(enemy);
        else
            Destroy(enemy);
    }

    GameObject SpawnEnemy()
    {
        GameObject go;
        if(usePooling)
        {
            go = pool.pool.Get();
            go.GetComponent<Enemy>().Ready();
        }
        else
        {
            go = Instantiate(enemyPrefab, transform);
        }
        go.transform.position = new Vector3(player.position.x + Random.Range(-8f, 8), 
            player.position.y + Random.Range(-8f, 8));
            
        if(unique_Material)
        {
            //This code block automatically instantiates the materials and makes them unique to this renderer. It is your responsibility to destroy the materials when the game object is being destroyed. 
            go.GetComponent<SpriteRenderer>().material.color = Random.ColorHSV();
        }
        //go.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        curSpawned++;
        return go;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * Time.timeScale;
        while(curSpawned < maxEnemiesSpawned && timer > 1f/spawnsPerSecond)
        {
            SpawnEnemy();
            timer -= 1f/spawnsPerSecond;
        }
    }
}
