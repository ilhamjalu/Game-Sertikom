using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] sampah; // array for gameobject
    public float delayTime = 2, timer = 0; // variable float for time

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // increase timer by deltatime

        if (timer > delayTime)
        {
            var random = Random.Range(0, sampah.Length); // take random gameobject from array
            Instantiate(sampah[random], transform.position, transform.rotation); // spawn gameobject
            timer = 0;
        }

    }
}
