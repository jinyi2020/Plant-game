using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject plantPrefab = null;
    public bool IsPlanting = false;
    public string plantModeImageName = "Plant Mode Image";
    public List<int> levelSetting = new List<int>() { 10, 20, 30, 50, 80, 130 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject InputPlant(GameObject soil)
    {
        if (GameData.Instance.storage[plantPrefab.GetComponent<Plant>().plantName] > 0)
        {
            GameData.Instance.storage[plantPrefab.GetComponent<Plant>().plantName] -= 1;
            return Instantiate(plantPrefab, soil.transform.position, plantPrefab.transform.rotation);
        }
        return null;
        
    }

    public void OutputPlant(GameObject plant)
    {
        Destroy(plant);
        GameData.Instance.coins += plant.GetComponent<Plant>().sellPrice;
        GameData.Instance.exp += plant.GetComponent<Plant>().expToEarn;
        CalculateLevel();
        GameData.Instance.SaveData();
    }


    public void OpenUI(GameObject panel)
    {
        panel.SetActive(true);
        GameData.Instance.isUIOpen = true;
    }

    public void CloseUI(GameObject panel)
    {
        panel.SetActive(false);
        GameData.Instance.isUIOpen = false;
    }

    public void StopPlant()
    {
        IsPlanting = false;
        plantPrefab = null;
        GameObject.Find("Canvas").transform.Find(plantModeImageName).gameObject.SetActive(false);
    }

    public void CalculateLevel()
    {
        
        while (GameData.Instance.exp >= levelSetting[GameData.Instance.level] && GameData.Instance.level<levelSetting.Count-1)
        {
            GameData.Instance.level++;
        }

    }
    

}
