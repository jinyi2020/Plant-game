using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI LevelText;
    public Slider levelSlider;
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
        LevelText.text = "Level: " + GameData.Instance.level + string.Format("  {0:D}/{1:D}", GameData.Instance.exp, gameManager.levelSetting[GameData.Instance.level]);
        levelSlider.value = Mathf.Min( (float)GameData.Instance.exp / (float)gameManager.levelSetting[GameData.Instance.level] );
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
