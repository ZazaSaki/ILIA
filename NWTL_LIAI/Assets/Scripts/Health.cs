using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float health;
    public float maxhealth;
    
    private void Start() {
        health = maxhealth;
    }
    
    public void TakeDamage(float amount){
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die (){
        Destroy(gameObject); 
    }
}
