using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    NavMeshAgent player;
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                player.destination = hit.point;
            }
        }
    }
}
