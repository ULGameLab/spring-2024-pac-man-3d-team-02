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
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        myaudio = GetComponent<AudioSource>();
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f));
    }

    // Update is called once per frame
    void Update()
    {
       
        switch (state)
        {
            case EnemyState.DEFAULT:
                animator.SetBool("isWalking", false);
                if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
                {
                    state = EnemyState.CHASE;

                }
                else
                {
                    state = EnemyState.MOVING;
                    destination = transform.position + RandomPosition();
                    agent.SetDestination(destination);
                }
                break;
            case EnemyState.MOVING:
                animator.SetBool("isWalking", true);
                if (Vector3.Distance(transform.position, destination) < 0.05f)
                {
                    state = EnemyState.DEFAULT;
                }
                if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
                {
                    state = EnemyState.CHASE;
                }
                break;
            case EnemyState.CHASE:
                if (Vector3.Distance(transform.position, player.transform.position) > chaseDistance)
                {
                    state = EnemyState.DEFAULT;
                }
                agent.SetDestination(player.transform.position);
                animator.SetBool("isWalking", true);
                if (Vector3.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
                {
                    state = EnemyState.ATTACK;
                }
                break;
            case EnemyState.ATTACK:
                animator.SetBool("isWalking", false);
                if (Vector3.Distance(transform.position, player.transform.position) > agent.stoppingDistance)
                {
                    state = EnemyState.MOVING;
                }
                break;
            default:
                break;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && Player.hasMegachomp == true)
        {
            
            // Disable all Renderers and Colliders
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;

            StartCoroutine(PlayAndDestroy(myaudio.clip.length));
        }
    }

    private IEnumerator PlayAndDestroy(float waitTime)
    {
        myaudio.Play();
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }


}
