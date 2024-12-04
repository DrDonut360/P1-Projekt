using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Star panel")]
    [SerializeField] RectTransform uiPanel;
    private float lenghtPerStar = 500;
    [SerializeField] GameObject starPrefab;
    
    private int starCount = 0;
    private List<UnityEngine.UI.Image> starImages = new List<UnityEngine.UI.Image>();

    // Start is called before the first frame update
    private List<string> collected = new List<string>();
    void Start()
    {  
        DrawStarPanel();
    }

    void DrawStarPanel()
    {
        //counts amount of stars
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.GetComponent<IsStar>() != null)
            {
                starCount++;
            }
        }

        //resizes panel based on star count
        float newLenght = starCount * lenghtPerStar;
        Vector2 newSize = uiPanel.sizeDelta;
        newSize.x = newLenght;
        uiPanel.sizeDelta = newSize;

        //repositions panel based to adjust for size (genuine monkey code)
        Vector2 oldPos = uiPanel.GetComponent<RectTransform>().anchoredPosition;
        Vector2 newPos = new Vector2 (oldPos.x + ((newLenght / 2 - lenghtPerStar / 2) * 0.1f), oldPos.y); 
        uiPanel.GetComponent<RectTransform>().anchoredPosition = newPos;

        // draws stars
        for (int i = 0; i < starCount; i++)
        {
            GameObject star = Instantiate(starPrefab, uiPanel);
            RectTransform starRt = star.GetComponent<RectTransform>();

            starRt.anchorMin = new Vector2(0, 0.5f);
            starRt.anchorMax = new Vector2(0, 0.5f);
            starRt.pivot = new Vector2(0.5f, 0.5f);
            
            starRt.anchoredPosition = new Vector2(lenghtPerStar * i + (lenghtPerStar / 2), 0);      
            starRt.sizeDelta = new Vector2(lenghtPerStar * 0.9f, lenghtPerStar * 0.9f);

            UnityEngine.UI.Image starImage = star.GetComponent< UnityEngine.UI.Image>();
            starImage.color = Color.black;

            starImages.Add(starImage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int starNumber = 0;
    public void LightStar()
    {
        UnityEngine.UI.Image starImage = starImages[starNumber];
        starNumber++;

        starImage.color = Color.white;
    }

    public void AddCollectable(string collectable)
    {
        collected.Add(collectable);
        Debug.Log("Collected items: " + string.Join(", ", collected));
        if (collectable == "Star")
        {
            LightStar();
        }
    }
}
