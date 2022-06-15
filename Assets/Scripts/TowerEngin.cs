using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEngin : MonoBehaviour
{
    Transform enemyTRN;
    GameObject enemy;
    public GameObject bullet;
    GameObject bulletInst;
    float startTimeShoot, timeShoot;
    // Start is called before the first frame update
    void Start()
    {
        startTimeShoot = 1.5f;
        timeShoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TextAndBuildSystem.isLost)
        {
            if (enemy == null)
            {
                enemy = FindClosestEnemy("Mummy");
                enemy = FindClosestEnemy("StoneMonster", enemy);
                if (enemy != null)
                    enemyTRN = enemy.transform;
            }
            else if (Vector3.Distance(enemyTRN.position, transform.position) <= 10)
            {
                transform.LookAt(enemyTRN);

                if (timeShoot <= 0)
                {
                    bulletInst = Instantiate(bullet, transform.position, Quaternion.identity);
                    bulletInst.GetComponent<BulletEngin>().Target(enemy);
                    timeShoot = startTimeShoot;
                }
                else
                    timeShoot -= Time.deltaTime;
            }
            else if (Vector3.Distance(enemyTRN.position, transform.position) >= 10)
            {
                enemy = FindClosestEnemy("Mummy");
                enemy = FindClosestEnemy("StoneMonster", enemy);
                if (enemy != null)
                    enemyTRN = enemy.transform;
            }
        }
    }
    GameObject FindClosestEnemy(string name) //find closest enemy
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(name);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            float dis = Vector3.Distance(go.transform.position, position);
            if (dis < distance)
            {
                closest = go;
                distance = dis;
            }
        }
        return closest;
    }
    GameObject FindClosestEnemy(string name, GameObject closestEnemy) //find closest enemy with comparison
    {
        if (closestEnemy == null)
            return FindClosestEnemy(name);
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(name);
        GameObject closest = closestEnemy;
        Vector3 position = transform.position;
        float distance = Vector3.Distance(closestEnemy.transform.position, position);
        foreach (GameObject go in gos)
        {
            float dis = Vector3.Distance(go.transform.position, position);
            if (dis < distance)
            {
                closest = go;
                distance = dis;
            }
        }
        return closest;
    }
}
