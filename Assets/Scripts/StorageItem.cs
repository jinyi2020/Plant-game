using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plantPrefab;
    public TextMeshProUGUI showText;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = plantPrefab.GetComponent<Plant>().image;
        showText.text = plantPrefab.GetComponent<Plant>().plantName + " " + GameData.Instance.storage[plantPrefab.GetComponent<Plant>().plantName];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
