using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyEngin : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    int life;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("House").transform;
        if (this.gameObject.tag == "Mummy")
            life = 2;
        else
            life = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //enemy get target
        agent.SetDestination(target.position);
        if (Vector3.Distance(transform.position, target.position) < 1.5f)
        {
            Destroy(this.gameObject);
            TextAndBuildSystem.HitLife();
        }
    }
    // taken damage
    public void TakeHit(int hitDmg)
    {
        life -= hitDmg;
        if (life <= 0)
        {
            Destroy(this.gameObject);
            TextAndBuildSystem.RaisMoney();
        }
    }
}

