using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    public GameObject mummey, StoneMonster, textStart;
    int level,num;
    bool leveldone, isLestLvl;
    public GameObject[] enemys;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        leveldone = true;
        num = 0;
        isLestLvl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TextAndBuildSystem.isLost)
        {
            //create level 1-3
            if (Input.GetKeyDown(KeyCode.Space) && leveldone)
            {
                level++;
                leveldone = false;
                textStart.SetActive(false);
                if (level == 1)
                {
                    StartCoroutine(CreatL1());
                }
                else if (level == 2)
                {
                    StartCoroutine(CreatL2());
                }
                else if (level == 3)
                {
                    StartCoroutine(CreatL3());
                }
            }
            if (isLestLvl) //win state
            {
                enemys = GameObject.FindGameObjectsWithTag("StoneMonster");
                if (enemys.Length == 0)
                {
                    textStart.GetComponent<Text>().text = "You Win!!!";
                    textStart.SetActive(true);
                }
                else
                    enemys = null;
            }
        }
    }
    IEnumerator CreatL1() //lvl1
    {
        yield return new WaitForSeconds(3);
        num++;
        Instantiate(mummey, transform.position, Quaternion.identity);
        if (num < 20)
            StartCoroutine(CreatL1());
        else
        {
            num = 0;
            leveldone = true;
            textStart.SetActive(true);
        }
    }
    IEnumerator CreatL2() //lvl2
    {
        yield return new WaitForSeconds(3);
        num++;
        if (num % 2 == 0)
            Instantiate(StoneMonster, transform.position, Quaternion.identity);
        else
            Instantiate(mummey, transform.position, Quaternion.identity);
        if (num < 20)
            StartCoroutine(CreatL2());
        else
        {
            num = 0;
            leveldone = true;
            textStart.SetActive(true);
        }
    }
    IEnumerator CreatL3() //lvl3
    {
        yield return new WaitForSeconds(3);
        num++;
        Instantiate(StoneMonster, transform.position, Quaternion.identity);
        if (num < 20)
            StartCoroutine(CreatL3());
        else
        {
            num = 0;
            isLestLvl = true;
        }
    }
}
