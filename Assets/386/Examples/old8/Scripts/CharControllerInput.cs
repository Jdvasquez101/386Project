using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllerInput : MonoBehaviour
{
    CharacterController charCon;
    [SerializeField] float playerSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charCon.Move(move * Time.deltaTime * playerSpeed);
    }
}
