using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public GameObject plantPrefab;
    public TextMeshProUGUI priceText;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = plantPrefab.GetComponent<Plant>().image;
        priceText.text = plantPrefab.GetComponent<Plant>().plantName + " " + plantPrefab.GetComponent<Plant>().buyPrice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        if (GameData.Instance.coins >= plantPrefab.GetComponent<Plant>().buyPrice)
        {
            GameData.Instance.coins -= plantPrefab.GetComponent<Plant>().buyPrice;

            
            GameData.Instance.storage[plantPrefab.GetComponent<Plant>().plantName] += 1;
            

            GameData.Instance.SaveData();
        }
    }
}
