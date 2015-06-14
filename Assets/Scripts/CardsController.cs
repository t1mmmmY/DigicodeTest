using UnityEngine;
using System.Collections;

public class CardsController : MonoBehaviour 
{
	public static System.Action<int> onChangeCardsCount;

	int cardsCount = 0;

	void Start()
	{
		cardsCount = CONST.INIT_CARDS_COUNT;

		if (onChangeCardsCount != null)
		{
			onChangeCardsCount(cardsCount);
		}
	}

	public void AddCard()
	{
		ChangeCardsCount(1);
	}

	public void RemoveCard()
	{
		ChangeCardsCount(-1);
	}

	void ChangeCardsCount(int difference)
	{
		int newCardsCount = cardsCount + difference;
		if (newCardsCount >= CONST.MIN_CARDS_COUNT && newCardsCount <= CONST.MAX_CARDS_COUNT)
		{
			cardsCount = newCardsCount;

			if (onChangeCardsCount != null)
			{
				onChangeCardsCount(cardsCount);
			}
		}
		else
		{
			Debug.Log("Out of bounds");
		}

	}
}
