using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector3 startPos;
    public Transform coins;
    public Transform collectedCoins;
    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (transform.position.y <= 23)
        {
            SceneManager.LoadScene(0);
        }
        if (coins.childCount == 0)
            StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Platform")
        {
            GetComponent<CharacterController>().Move(
                hit.transform.forward * (PlatformController.moveSpeed / 4f) * Time.deltaTime);
        }

        if(hit.gameObject.tag == "Car")
            SceneManager.LoadScene(0);

        if(hit.gameObject.name.Contains("Coin") && hit.transform.parent == coins)
        {
            hit.gameObject.GetComponent<Renderer>().material.color = Color.red;
            hit.transform.parent = collectedCoins;
            transform.position = startPos;
        }
    } 
}
