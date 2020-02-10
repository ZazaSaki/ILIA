using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{   

    //test_vars
    public bool NoDamage;
    //*test_vars

    public float health;
    public float maxhealth;
    
    private void Start() {
        health = maxhealth;
    }
    
    public void TakeDamage(float amount){
        
        if (NoDamage) return;   
        
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    public void heal(float amount){
        health += amount;
        health = (health > maxhealth)? maxhealth : health;
    }

    void Die (){
        Destroy(gameObject); 
    }
}
