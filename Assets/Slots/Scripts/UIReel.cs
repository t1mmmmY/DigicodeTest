using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIReel : MonoBehaviour 
{
    [SerializeField] UIWrapContent wrapContent;
    List<UIItem> itemsPrefab;

    [Range(3, 50)]
    [SerializeField] int countItems = 5;

    List<UIItem> listItems;

    UIScrollView scrollView;
    UICenterOnChild centerOnChild;

    void Start()
    {
        scrollView = GetComponent<UIScrollView>();
        if (scrollView == null)
        {
            Debug.LogError("Can not find scroll view " + gameObject.name);
        }

        centerOnChild = wrapContent.GetComponent<UICenterOnChild>();

        
    }

    public void Init(List<UIItem> itemsPrefab)
    {
        this.itemsPrefab = itemsPrefab;
        CreateItems();
    }

    void CreateItems()
    {
        listItems = new List<UIItem>();
        
        for (int i = 0; i < countItems; i++)
        {
            GameObject go = NGUITools.AddChild(wrapContent.gameObject, itemsPrefab[Random.Range(0, itemsPrefab.Count)].gameObject);
            UIItem newItem = go.GetComponent<UIItem>();
            if (newItem != null)
            {
                listItems.Add(newItem);
            }
            else
            {
                Debug.LogError("It is not a slot item " + go.name);
            }
        }

    }

    public void Spin(float time, int value)
    {
        //scrollView.dampenStrength = 30.0f;
        scrollView.SetScrollTime(time);
        scrollView.Scroll(value);
        scrollView.onMomentumMove += OnMomentumMove;
        
    }

    void OnMomentumMove()
    {
        //Debug.Log(scrollView.currentMomentum.magnitude.ToString());
        if (scrollView.currentMomentum.magnitude < 0.1f)
        {
            if (centerOnChild != null)
            {
                centerOnChild.Recenter();
                scrollView.currentMomentum = Vector2.zero;
            }

            scrollView.onMomentumMove -= OnMomentumMove;
        }
    }
}
