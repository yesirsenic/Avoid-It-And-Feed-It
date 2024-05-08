using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    float speed = 20f;
    float limitmove = 20f;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void FixedUpdate()
    {
        FoodMove();
    }

    private void Update()
    {
        DestroyFood();
    }

    void FoodMove()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void DestroyFood()
    {
        if(transform.position.z > 20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            soundManager.Feed_FoodSFX();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(other.CompareTag("Stone"))
        {
            soundManager.Food_Crash_StoneSFX();
            Destroy(gameObject);
        }
    }
}
