using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilManager : MonoBehaviour
{
    public int soilRow = 4;
    public int soilCol = 3;
    public GameObject soilPrefab;
    public float soilWidth = 5;
    public float soilLength = 5;
    public float spacing = 0.5f;
    private void Awake()
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < soilRow; i++)
        {
            pos.z += soilWidth + spacing;
            for (int j = 0; j < soilCol; j++)
            {
                pos.x += soilLength + spacing;
                CreatSoil(pos);
            }
            pos.x = transform.position.x;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatSoil(Vector3 position)
    {
        Instantiate(soilPrefab, position, soilPrefab.transform.rotation);
    }
}
