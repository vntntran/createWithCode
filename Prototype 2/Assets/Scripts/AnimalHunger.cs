using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    public int amountToBeFed;
    private int currentAmountFed = 0;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void FeedAnimal(int amount)
    {
        currentAmountFed += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentAmountFed;

        if(currentAmountFed >= amountToBeFed)
        {
            // Add score = amountToBeFed (example if amountToBeFed = 3, then score += 3)
            gameManager.addScore(amountToBeFed);
            Destroy(gameObject, 0.1f);
            Debug.Log("Score :" + gameManager.score);
        }
    }
}