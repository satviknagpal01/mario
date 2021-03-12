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
        float cameraXPos = Mathf.Clamp(playerXPos, 0.2f, 100f);
        transform.position = new Vector3(cameraXPos, 0f, -10f);
    }
}
