// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

// # Project

public class CenterFlame : MonoBehaviour
{
    private AudioSource audioSource;

    private bool        isMusicStart;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(!isMusicStart)
        {
			if (collision.CompareTag("Note"))
			{
				audioSource.Play();
				isMusicStart = true;
			}
		}
	}
}
