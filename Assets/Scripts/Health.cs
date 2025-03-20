using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int points = 5;
    public Vector3 respawnPosition;
    public TMP_Text healthText;
    public EndScreenAnimation gameOverScreen;

    private void Start()
    {
        respawnPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {

            Damage(1);
        }
        if(other.CompareTag("Checkpoint"))
        {

            respawnPosition = other.transform.position;
            respawnPosition.y = transform.position.y;
        }
    }


    //To remove some health points
    private void Damage(int value)
    {
        points = points - value;
        healthText.text = $"<i><b>Health</b>: {points}</i>";
        transform.position = respawnPosition;

        if (points < 1)
        {
            gameOverScreen.StartFade();
            Destroy(gameObject);
            //HW: do not destroy Move the player to the start and reset points to 5
        }
    }
}

