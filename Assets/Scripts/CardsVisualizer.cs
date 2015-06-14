using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsVisualizer : MonoBehaviour 
{
	[SerializeField] UIGrid grid;
	[SerializeField] Card cardPrefab;

//	[Range(10, 200)]
//	[SerializeField] float cellWith = 100;
//	[Range(1, 20)]
//	[SerializeField] int cardsInHand = 5;

	List<Card> cards;

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
