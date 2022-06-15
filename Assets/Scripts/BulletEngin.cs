using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletEngin : MonoBehaviour
{
    public GameObject BulletExplode;
    NavMeshAgent agent;
    static GameObject goTarget;
    GameObject thistarget;
    bool isTarget;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = 5; 
        isTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TextAndBuildSystem.isLost)
            Destroy(this.gameObject);
        if (!isTarget && goTarget != null)
            thistarget = goTarget;
        if (thistarget != null)
        {
            agent.SetDestination(thistarget.transform.position);
            isTarget = true;
        }
        else if (isTarget && thistarget == null)
        {
            Destroy(this.gameObject);
            Instantiate(BulletExplode, transform.position, Quaternion.identity);
        }
        

    }
    public void Target(GameObject target)
    {
        goTarget = target;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mummy" || other.gameObject.tag == "StoneMonster")
        {
            Instantiate(BulletExplode, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            other.GetComponent<EnemyEngin>().TakeHit(TextAndBuildSystem.dmg);
        }
    }
}
