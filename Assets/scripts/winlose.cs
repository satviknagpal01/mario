﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winlose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(0);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
