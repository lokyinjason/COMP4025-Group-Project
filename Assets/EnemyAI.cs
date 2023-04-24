using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 origin;
    [SerializeField] float chaseRange;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    NavMeshAgent navMeshAgent;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject killCamera;
    [SerializeField] GameObject lighting;
    [SerializeField] AudioSource killSound; 
    bool kill = false;
    void Start()
    {
        AudioSource startbgm = GetComponent<AudioSource>();
        startbgm.Play();
        Debug.Log(startbgm.isPlaying);
        navMeshAgent = GetComponent<NavMeshAgent>();
        origin = transform.position;
    }
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) {
            engage();
        }
        else if (kill) {
            GetComponent<Animator>().SetBool("scream", false);
            GetComponent<Animator>().SetTrigger("idle");
        }
        else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
        else if (Vector3.Distance(transform.position, origin) <= 1) {
            GetComponent<Animator>().SetTrigger("idle");
        }
    }
    private void engage() {
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            isProvoked = false;
            kill = true;
            GetComponent<Animator>().SetBool("scream", true);
            killPlayer();
        }
        else if (distanceToTarget >= chaseRange) {
            GetComponent<Animator>().SetBool("scream", false);
            GetComponent<Animator>().SetTrigger("move");
            navMeshAgent.SetDestination(origin);
            Debug.Log(navMeshAgent.destination);
        }
        else if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            GetComponent<Animator>().SetBool("scream", false);
            GetComponent<Animator>().SetTrigger("move");
            navMeshAgent.SetDestination(target.position);
        }

        if (Vector3.Distance(transform.position, origin) <= 1) {
            isProvoked = false;
        }
    }

    private void killPlayer() {
        AudioSource bgm = GetComponent<AudioSource>();
        bgm.Stop();
        killSound.Play();
        killCamera.SetActive(true);
        mainCamera.SetActive(false);
        lighting.SetActive(true);
    }
}
