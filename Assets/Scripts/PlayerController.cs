using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveInterval = 7.5f;
    private float limitmove = 15f;
    private GameManager gameManager;
    private SoundManager soundManager;

    public GameObject food;
    public GameObject gameoverUI;
    public ParticleSystem explosion_Particle;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Update()
    {
        if(gameManager.is_activate == true)
        {
            PlayerMove();
            PlayerThrowFood();
        }
    }

    void PlayerMove()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -limitmove)
        {
            transform.Translate(-moveInterval, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < limitmove)
        {
            transform.Translate(moveInterval, 0, 0);
        }
    }

    void PlayerThrowFood()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position, food.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            gameManager.is_activate = false;
            gameoverUI.SetActive(true);
            explosion_Particle.Play();
            Debug.Log("Game Over!");
            soundManager.GameOverSFX();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Stone"))
        {
            gameManager.is_activate = false;
            gameoverUI.SetActive(true);
            explosion_Particle.Play();
            Debug.Log("Game Over!");
            soundManager.GameOverSFX();
            Destroy(other.gameObject);
        }
    }
}
