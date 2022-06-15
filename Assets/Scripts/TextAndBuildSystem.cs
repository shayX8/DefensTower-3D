using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAndBuildSystem : MonoBehaviour
{
    static int life, money;
    static Text lifeText, moneyText;
    static GameObject textStart;
    public GameObject tower1, tower2, tower3;
    public static int dmg;
    public static bool isLost;
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        life = 5;
        lifeText = GameObject.Find("Life").GetComponent<Text>();
        moneyText = GameObject.Find("Money").GetComponent<Text>();
        textStart = GameObject.Find("TextStart");
        dmg = 1;
        isLost = false;
    }

    // Update is called once per frame
    public static void RaisMoney()
    {
        money++;
        moneyText.text = "Money: " + money.ToString();
    }
    public static void HitLife()
    {
        life--;
        lifeText.text = "Life: " + life.ToString();
        if (life == 0)
        {
            textStart.GetComponent<Text>().text = "You Lost!!!";
            textStart.SetActive(true);
            isLost = true;
        }

    }
    public void RaisBuild()
    {
        
        if (tower1.activeSelf)
        {
            if (money >= 20)
            {
                money -= 21;
                RaisMoney();
                tower1.SetActive(false);
                tower2.SetActive(true);
                dmg = 2;
            }
        }
        else
        {
            if (money >= 20)
            {
                money -= 21;
                RaisMoney();
                tower2.SetActive(false);
                tower3.SetActive(true);
                GameObject.Find("ButtonUpBuilds").SetActive(false);
                dmg = 3;
            }
        }
    }

}
