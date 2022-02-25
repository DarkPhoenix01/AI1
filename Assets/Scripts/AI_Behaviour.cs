using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behaviour : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;

    public Transform[] destinationCheckPoints;
    public int destinationIndex = 0;

    public bool fija;
    public bool random;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        fija = true;
        random = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fija==true)
        {
            PatrullaFija();
        }
        if(random==true) 
        {
            PatrullaRandom();
        }

        
    }


    void PatrullaFija()
    {
        if(Vector3.Distance(transform.position, player.position) < 7f)
        {
            agent.destination = player.position;

            if(Vector3.Distance(transform.position, player.position) < 3f)
            {
                Debug.Log("Ataque");
            }
        }else
            agent.destination = destinationCheckPoints[destinationIndex].position;

            if(Vector3.Distance(transform.position, destinationCheckPoints[destinationIndex].position) < 2f)
            {

                if(destinationIndex < destinationCheckPoints.Length-1)
                {
                    destinationIndex++;

                }else{

                    destinationIndex=0;
                }
            }
        
    }

    void PatrullaRandom()
    {
        if(Vector3.Distance(transform.position, player.position) < 7f)
        {
            agent.destination = player.position;

            if(Vector3.Distance(transform.position, player.position) < 3f)
            {
                Debug.Log("Ataque");
            }
        }
        else
        {
            //va a la posicion de patrulla actual
            agent.destination = destinationCheckPoints[destinationIndex].position;

            if(Vector3.Distance(transform.position, destinationCheckPoints[destinationIndex].position)<2f)
                {
                    destinationIndex=Random.Range(0, 4);
                }
        }
    }

    public void OrderPath()
    {
        fija = true;
        random = false;
    }

     public void RandomPath()
    {
        random = true;
        fija = false;
    }
}
