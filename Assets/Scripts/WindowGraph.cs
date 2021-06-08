using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;


public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private RectTransform graphContainer;

    private void Awake()
    {
        List<int> valueList = new List<int>() { 5, 50, 53, 54, 56, 45, 23, 54, 23, 45, 23, 44, 45, 65, };
        ShowGraph(valueList);
    }

    private GameObject CreatreCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(10, 10);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    public void ShowGraph(List<int> valueList)
    {
        float graphHeingh = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 50f;

        GameObject lastCircleGmaeObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = i * xSize;
            float yPostition = (valueList[i]/yMaximum) * graphHeingh;
            GameObject circleGameobject = CreatreCircle(new Vector2(xPosition, yPostition));
            if (lastCircleGmaeObject != null)
            {
                CreateDotConnection(lastCircleGmaeObject.GetComponent<RectTransform>().anchoredPosition, circleGameobject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGmaeObject = circleGameobject;
        }
    }

    private void CreateDotConnection(Vector2 dotPostitionA, Vector2 dotPostitionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPostitionB - dotPostitionA).normalized;
        float distance = Vector2.Distance(dotPostitionA, dotPostitionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPostitionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }
}
