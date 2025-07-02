using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject effect; // Reference to the effect prefab

    public void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.coin++; // Increment the coin count in PlayerController
            Destroy(gameObject); // Destroy the coin when collected 
            
            Instantiate(effect, transform.position, Quaternion.identity); // Instantiate the effect at the coin's position
        }
        {

        }


    }







}