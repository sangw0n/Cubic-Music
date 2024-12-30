// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

// # Project

public class NoteManager : MonoBehaviour
{ 
	public int bpm = 0; // 1�п� N���� ��Ʈ
	
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

			// 0���� �ʱ�ȭ �����ְ� ���ִ� ����
			// Time.deltaTime �� �����ָ鼭 0.51005551.. �̷������� ������ �߻��ϰ� ��.
			// 0���� �ʱ�ȭ ���ָ� �� �Ҽ��� ���� �սǵ� ��Ʈ�� �з� �����̶� ��Ʈ�� �� �°� ��. 
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
