using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { ATTACK, CHASE, MOVING, DEFAULT};
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float chaseDistance = 20.0f;
    protected EnemyState state = EnemyState.DEFAULT;
    protected Vector3 destination = new Vector3(0, 0, 0);
    Animator animator;
    AudioSource myaudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
