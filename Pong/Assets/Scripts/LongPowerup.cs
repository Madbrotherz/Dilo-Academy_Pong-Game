using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongPowerup : MonoBehaviour
{
	public Image imageCooldown_1;
	public Image imageCooldown_2;
	public GameObject player1;
	public GameObject player2;
	public float powerupCooldown_1 = 5;
	public float powerupCooldown_2 = 5;
	bool isCooldown_1;
	bool isCooldown_2;
	
	void Start()
	{
	}
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isCooldown_1 == false)
		{
			isCooldown_1 = true;
			player1.transform.localScale += new Vector3(0, 1, 0);
			Debug.Log("Button 1 Pressed");
		}
		
		if(isCooldown_1)
		{
			imageCooldown_1.fillAmount += 1 / powerupCooldown_1 * Time.deltaTime;
			
			if(imageCooldown_1.fillAmount >= 1)
			{
				imageCooldown_1.fillAmount = 0;
				player1.transform.localScale -= new Vector3(0, 1, 0);
				isCooldown_1 = false;
			}
		}
		
		
		if(Input.GetKeyDown(KeyCode.P) && isCooldown_2 == false)
		{
			isCooldown_2 = true;
			player2.transform.localScale += new Vector3(0, 1, 0);
			Debug.Log("Button 2 Pressed");
		}
		
		
		if(isCooldown_2)
		{
			imageCooldown_2.fillAmount += 1 / powerupCooldown_2 * Time.deltaTime;
			
			if(imageCooldown_2.fillAmount >= 1)
			{
				imageCooldown_2.fillAmount = 0;
				player2.transform.localScale -= new Vector3(0, 1, 0);
				isCooldown_2 = false;
			}
		}
    }
}
