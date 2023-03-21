using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = "Coins: " + GameData.Instance.coins.ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
