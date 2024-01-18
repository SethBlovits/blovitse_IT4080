using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
//using UnityEngine.InputSystem;

public class PlayerMovementScript : NetworkBehaviour
{
    NetworkVariable<int> mySimpleValue = new NetworkVariable<int>();
    void Update(){
        if(!IsOwner)return;
        HandleMovement();
    }
    public override void OnNetworkSpawn()
    {
        mySimpleValue.Value = Random.Range(1,200);
        Debug.Log("My custom data"+ mySimpleValue.Value);
    }
    private void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDirection.z = +1f;
        if (Input.GetKey(KeyCode.S)) moveDirection.z = -1f;
        if (Input.GetKey(KeyCode.A)) moveDirection.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDirection.x = +1f;

        float moveSpeed = 3f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
