using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 1, 0);


    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + player.forward * -5 + offset;
        transform.rotation = player.rotation;
    }

    // void OnLook(InputValue value){
    //     Vector2 v = value.Get<Vector2>();
    //     Debug.Log(v);

    //     transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(rotationSpeed * v.y, rotationSpeed * v.x, 0f));

    // }
}
