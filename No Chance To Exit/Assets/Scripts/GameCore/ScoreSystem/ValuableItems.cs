using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class ValuableItems : MonoBehaviour
    {
        [SerializeField] private int pointsValue;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private AudioSource itemCollected;



        public void OnCollisionEnter2D(Collision2D collision)
        {
            scoreSystem.AddPoints(pointsValue);
            itemCollected.Play();
            gameObject.SetActive(false);
        }


    } 


}
