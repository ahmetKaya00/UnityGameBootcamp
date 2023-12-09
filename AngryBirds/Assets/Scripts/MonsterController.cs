using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShoulDieFromCollision(collision))
        {
            Die();
        }
    }
    private bool ShoulDieFromCollision(Collision2D collision)
    {
        BirdsController birs = collision.gameObject.GetComponent<BirdsController>();

        if (birs != null)
            return true;

        if (collision.contacts[0].normal.y <= -0.5)
            return true;

        return false;
    }
    void Die()
    {
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
       // gameObject.SetActive(false);
    }
}
