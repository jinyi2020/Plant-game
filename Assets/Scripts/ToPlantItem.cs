using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToPlantItem : StorageItem
{
    public string plantModeImageName = "Plant Mode Image";
    public string plantPanelName = "Plant Panel";
    // Start is called before the first frame update


    public void SelectItem()
    {
        Debug.Log("Selected Item");
        GameObject.Find("Game Manager").GetComponent<GameManager>().plantPrefab = plantPrefab;
        GameObject.Find("Game Manager").GetComponent<GameManager>().IsPlanting = true;
        // GameObject plantPanel = GameObject.Find("Canvas").transform.Find("Plant Panel").gameObject;
        GameObject plantPanel = GameObject.Find("Canvas").transform.Find(plantPanelName).gameObject;
        
        GameObject.Find("Game Manager").GetComponent<GameManager>().CloseUI(plantPanel);
        GameObject.Find("Canvas").transform.Find(plantModeImageName).gameObject.SetActive(true);

    }
}
