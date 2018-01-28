using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveArrowDisplayer : MonoBehaviour
{
	private SpriteRenderer[] sprites;

	private void Awake()
	{
		sprites = GetComponentsInChildren<SpriteRenderer>();
		ObjectShooter.onAvailableArrowsChange += UpdateRemainingArrows;
	}

	private void UpdateRemainingArrows(int amount)
	{
		if (amount > sprites.Length)
			amount = Mathf.Clamp(amount, 0, sprites.Length);

		for (int i = 0; i < sprites.Length; i++)
		{
			sprites[i].enabled = amount > 0;
			amount--;
		}
	}
}
