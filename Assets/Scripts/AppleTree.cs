﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
	[Header("Set in	Inspector")]
	//	Prefab	for	instantiating	apples
	public GameObject applePrefab;
	//	Speed	at	which	the	AppleTree	moves
	public float speed = 1f;
	//	Distance	where	AppleTree	turns	around
	public float leftAndRightEdge = 10f;
	//	Chance	that	the	AppleTree	will	change	directions
	public float chanceToChangeDirections = 0.1f;
	//	Rate	at	which	Apples	will	be	instantiated
	public float secondsBetweenAppleDrops = 1f;
	void Start()
	{
		//	Dropping	apples	every	second
		Invoke("DropApple",2f);
	}

	void DropApple()
	{                                                                                                                                                                                                       //	b
		GameObject apple = Instantiate<GameObject>(applePrefab);//c
		apple.transform.position = transform.position;//d
		Invoke("DropApple", secondsBetweenAppleDrops);//e
	}


	void Update()
	{
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		if (pos.x < -leftAndRightEdge)
		{
			speed = Mathf.Abs(speed);
		}
		else if (pos.x > leftAndRightEdge)
		{
			speed = -Mathf.Abs(speed);
		}

	}

	void FixedUpdate()
	{
		if (Random.value < chanceToChangeDirections)
		{
			speed *= -1; //	Change	direction
		}
		
	}

}
