using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static float moveSpeed = 5;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (transform.position.z > 75 && transform.name.Contains("Platform"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Shadow")
        {
            Destroy(gameObject);
        }
    }
}
