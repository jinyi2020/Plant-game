using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public GameObject storageItemPrefab;
    public int countOnEachRow = 5;
    public float positionIncrement = 310;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + GameData.Instance.coins;
        Vector3 startPos = new Vector3(-766, 352, 0);
        int count = 0;
        Debug.Log(GameData.Instance.storage);
        foreach (GameObject plantPrefab in GameData.Instance.plants)
        {
            if (GameData.Instance.storage[plantPrefab.GetComponent<Plant>().plantName] > 0)
            {
                Vector3 position = transform.position + startPos + new Vector3(count % countOnEachRow * positionIncrement, -count / countOnEachRow * positionIncrement);
                GameObject item = Instantiate(storageItemPrefab, position, storageItemPrefab.transform.rotation, gameObject.transform);
                item.GetComponent<StorageItem>().plantPrefab = plantPrefab;
                count++;
            }



        }

    }
}
