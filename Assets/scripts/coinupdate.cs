using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinupdate : MonoBehaviour
{
    public static int coin;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Coins = " + coin;
    }
}

