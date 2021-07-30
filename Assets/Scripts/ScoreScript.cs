using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public Text score;
    int poin;
    public AudioSource audioBenar, audioSalah;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (poin < 0)
        {
            SceneManager.LoadScene("GameOver"); // load scene game over
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == collision.tag)
        {
            audioBenar.Play();
            Destroy(collision.gameObject); // destroy gameobject
            poin += 10; // increase score point
            score.text = poin.ToString(); // show point that user get
        }
        else
        {
            audioSalah.Play();
            Destroy(collision.gameObject);
            poin -= 15;
            score.text = poin.ToString();
        }
    }
}
