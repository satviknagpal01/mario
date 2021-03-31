using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;

  //  public float offsetX;
    private void FixedUpdate()
    {
        float playerXPos = target.position.x;
        float cameraXPos = Mathf.Clamp(playerXPos, 5.99f, 214f);
        transform.position = new Vector3(cameraXPos, 2.3f, -10f);
    }
}
