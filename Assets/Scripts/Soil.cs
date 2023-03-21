using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    
    private GameManager gameManager;
    private GameObject plant;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Debug.Log("Clicked down");
        if (GameObject.Find("Game Manager").GetComponent<GameManager>().IsPlanting && !GameData.Instance.isUIOpen)
        {
            if (plant == null)
            {
                plant = gameManager.InputPlant(gameObject);

            }
        }
        

        
    }
}
