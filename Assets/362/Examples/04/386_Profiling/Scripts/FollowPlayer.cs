using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float z;
    [SerializeField]
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, z);
    }
}
