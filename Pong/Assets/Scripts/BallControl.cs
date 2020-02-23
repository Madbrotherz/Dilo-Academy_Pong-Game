using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
	  // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;
 
    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
	
	public float constantSpeed = 50;
	
	public GameObject fireBall;
	public bool isActiveFB = false;
	
	// Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;
	
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
 
		trajectoryOrigin = transform.position;
		
		isActiveFB = false;
 
        // Mulai game
        RestartGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * constantSpeed;
    }
	
	public void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;
 
        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
		
		fireBall.SetActive(false);
		isActiveFB = false;
    }
	
	 void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);
		
		float randomTimeSpawn = Random.Range(0, 2);
		
		

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
		SpawnFB();
    }
	
	public void SpawnFB(){
		if(isActiveFB == false){
			Debug.Log("Spawning Fireball");
			Invoke("SpawnFireball", Random.Range(4, 7));
			//Invoke("CooldownFireball", 12);
		}
	}
	
	void SpawnFireball()
	{
		fireBall.SetActive(true);
		//StartCoroutine(inactiveFireball());
		isActiveFB = true;
		Debug.Log("its active");
	}
	
	void CooldownFireball()
	{
		isActiveFB = false;
	}
	
	IEnumerator inactiveFireball()
	{
		Debug.Log("Waiting to destroy this fireball");
		yield return new WaitForSeconds(10);
		fireBall.SetActive(false);
	}
	
	public void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();
 
        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
		Debug.Log("Ball Pushed");
    }
	
	// Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
	
	 // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
