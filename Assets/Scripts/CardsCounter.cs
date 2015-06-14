using UnityEngine;
using System.Collections;

public class CardsCounter : MonoBehaviour 
{
	[SerializeField] UILabel cardsCountLabel;

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
		cardsCountLabel.text = count.ToString();
	}
}
