using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public GameObject shopItemPrefab;
    public int countOnEachRow = 5;
    public float positionIncrement = 310;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = new Vector3(-766, 352, 0);
        int count = 0;
        foreach (GameObject plantPrefab in GameData.Instance.plants)
        {
            Vector3 position = transform.position + startPos + new Vector3(count % countOnEachRow * positionIncrement, -count / countOnEachRow * positionIncrement);
            GameObject item = Instantiate(shopItemPrefab, position, shopItemPrefab.transform.rotation, gameObject.transform);
            item.GetComponent<ShopItem>().plantPrefab = plantPrefab;
            count++;
            
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + GameData.Instance.coins;
        
    }
}
