using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vokabeltest : MonoBehaviour
{
    public int playerLifepoints = 5;
    public string playername = "hallo";
    public float playerDamage = 5.5f;

    private bool isDead = false;
    private string playerNAme = "Joe";

    public void GetVariable(int integer)
    {
        print(integer);
        Debug.Log(RetrunHealth());
    }

    public int RetrunHealth()
    {
        return playerLifepoints;
    }
}
