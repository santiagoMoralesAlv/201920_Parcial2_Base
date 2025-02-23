﻿using UnityEngine;
using System.Collections;


namespace AI
{
	public class BehaviourRunner: MonoBehaviour
	{
		[SerializeField]
		private Node root;

		[SerializeField]
		private float stepTime;

		private float elapsedTime;

		private void Update ()
		{
            if (this.GetComponent<PlayerController>().CanMove)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= stepTime)
                {
                    root.Execute();
                    elapsedTime = 0f;
                }
            }
		}
	}
}
