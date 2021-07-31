using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed= 80.0f;

    GameObject player;
    Vector3 playerDirection;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("GameController");
        playerDirection = player.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(playerDirection * Time.deltaTime * speed);
    }
}
