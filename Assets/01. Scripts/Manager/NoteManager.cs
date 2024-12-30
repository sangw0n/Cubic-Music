// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

// # Project

public class NoteManager : MonoBehaviour
{ 
	public int bpm = 0; // 1분에 N개의 비트
	
	private double currentTime = 0d;

	[SerializeField] 
	private Transform  tfNoteAppear = null;
	[SerializeField]
	private GameObject goNote		= null;

	private void Update()
	{
		currentTime += Time.deltaTime;

		if (currentTime >= 60d / bpm)
		{
			GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
			t_note.transform.SetParent(this.transform);

			// 0으로 초기화 안해주고 빼주는 이유
			// Time.deltaTime 을 더해주면서 0.51005551.. 이런식으로 오차가 발생하게 됨.
			// 0으로 초기화 해주면 이 소숫점 값이 손실돼 노트가 밀려 음악이랑 노트가 안 맞게 됨. 
			currentTime -= 60d / bpm;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Note"))
		{
			Destroy(collision.gameObject);
		}
	}
}
