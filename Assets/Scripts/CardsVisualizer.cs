using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsVisualizer : MonoBehaviour 
{
	[SerializeField] UIGrid grid;
    [SerializeField] UIPanel scrollPanel;
	[SerializeField] Card cardPrefab;
    [SerializeField] float standardWidth = 330;

//	[Range(10, 200)]
//	[SerializeField] float cellWith = 100;
//	[Range(1, 20)]
//	[SerializeField] int cardsInHand = 5;

	List<Card> cards;

	Vector2 oldSize;

	void Awake()
	{
		cards = new List<Card>();
	}

	void OnEnable()
	{
		CardsController.onChangeCardsCount += OnChangeCardsCount;
	}
	
	void OnDisable()
	{
		CardsController.onChangeCardsCount -= OnChangeCardsCount;
	}

	void FixedUpdate()
	{
        Vector2 newSize = new Vector2(Screen.width, Screen.height);
        if (newSize != oldSize)
        {
            grid.transform.localScale = Vector3.one * scrollPanel.GetViewSize().y / standardWidth;
        }
        oldSize = newSize;
	}
	
	void OnChangeCardsCount(int count)
	{
		//if new cards count is more than we have now
		if (cards.Count < count)
		{
			for (int i = cards.Count; i < count; i++)
			{
				AddCard();
			}
		}
		else
		{
			for (int i = cards.Count; i > count; i--)
			{
				RemoveCard();
			}
		}

//		if (count != 0)
//		{
//			grid.cellWidth = cardsInHand / (float)count * cellWith;
//		}
		grid.Reposition();
	}

	void AddCard()
	{
		GameObject newCardGameObject = NGUITools.AddChild(grid.gameObject, cardPrefab.gameObject);
		Card newCard = newCardGameObject.GetComponent<Card>();
		if (newCard != null)
		{
			cards.Add(newCard);
		}
	}

	void RemoveCard()
	{
		Card cardToRemove = cards[cards.Count-1];
		cards.Remove(cardToRemove);
		Destroy(cardToRemove.gameObject);
	}

}
