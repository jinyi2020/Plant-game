using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject timerSliderObject;
    public Canvas canvas;
    private Slider timerSlider;
    private GameObject mainCamara;
    public GameObject seed;
    public GameObject fullGrow;


    
    public int timeHour, timeMinute, timeSecond;
    private TimeSpan growTimeSpan = new TimeSpan(0, 0, 3);
    private float growTime;
    private float currentTime = 0;
    public bool isComplete = false;
    private GameManager gameManager;
    public int sellPrice = 10;
    public int buyPrice = 1;
    public int expToEarn = 10;
    public string plantName = "Daikon";
    public Sprite image;
    public ParticleSystem fullGrowEffect;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        mainCamara = GameObject.Find("Main Camera");
        growTimeSpan = new TimeSpan(timeHour, timeMinute, timeSecond);

        timerSlider = timerSliderObject.GetComponent<Slider>();
        growTime = (float)growTimeSpan.TotalSeconds;
        timerText.enabled = true;
        timerSliderObject.SetActive(true);
        StartCoroutine(Grow());
        seed.SetActive(true);
        fullGrow.SetActive(false);
        fullGrowEffect.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.rotation = mainCamara.transform.rotation;
        // Debug.Log(currentTime + " " + growTime);
        if (currentTime < growTime)
        {
            currentTime += Time.deltaTime;
            UpdateTimer();
        }
        if (currentTime > growTime/2) {
            fullGrow.SetActive(true);
            seed.SetActive(false);
        }


    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(growTime);
        
        CompleteGrow();
    }

    void UpdateTimer()
    {
        TimeSpan currentTimeSpan = TimeSpan.FromSeconds(currentTime);
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2} / {3:D2}:{4:D2}:{5:D2}", 
            currentTimeSpan.Hours, currentTimeSpan.Minutes, currentTimeSpan.Seconds, 
            growTimeSpan.Hours, growTimeSpan.Minutes, growTimeSpan.Seconds);
        timerSlider.value = currentTime / growTime;
    }

    void CompleteGrow()
    {
        timerText.enabled = false;
        timerSliderObject.SetActive(false);
        fullGrowEffect.Play();
        isComplete = true;
        Debug.Log("grow complete");
    }

    private void OnMouseDown()
    {
        if (!GameData.Instance.isUIOpen)
        {
            Debug.Log("Clicked plant");
            if (isComplete)
            {
                gameManager.OutputPlant(gameObject);
            }
        }
        
    }
}
