using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    public Transform player;
    private float startPos;
    
    void Start () {
        startPos = transform.position.y;
    }
    
    void Update () {
        transform.position = new Vector3(player.position.x, startPos, transform.position.z);
    }
}
