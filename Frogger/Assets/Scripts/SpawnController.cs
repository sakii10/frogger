using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject platform;
    private Vector3 water_1 = new Vector3(53.5f, 23, 0);

    public GameObject car_1;
    public GameObject car_2;

    private Vector3 land_1 = new Vector3(25, 25, 75);
    private Vector3 land_2 = new Vector3(73, 25, 15);

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            if(Random.Range(0, 2) == 1)
                Instantiate(platform, water_1, Quaternion.identity);
            
            if(Random.Range(0, 2) == 1)
                Instantiate(car_1, land_1, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            
            if(Random.Range(0, 2) == 1)
                Instantiate(car_2, land_2, Quaternion.identity);
        }
    }

}
