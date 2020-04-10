
using UnityEngine;

public class EnemieParentScript : MonoBehaviour{
    bool IsAttacking = false;
    float nextTimeToAttack = 0;
    float attackRate = 1;

    private void Update() {
        if (IsAttacking){
            if (Time.time >= nextTimeToAttack){
                IsAttacking = false;
            }
        }
    }
    public enum Type
    {
        Fast, Thank, Balanced
    }

    public enum Size
    {
        Small, Med, Big
    }

    public int level;
    public Type type;
    public Size size;


    public float attackRange;
    public float damage;
    public virtual void attack(){
         if (Time.time >= nextTimeToAttack){
            nextTimeToAttack = Time.time + 1f/attackRate;
            IsAttacking = true;
        }else{
            return;
        }
        Debug.Log("attack");
    }

    

    //Check Stats Function
    public bool checkedStats(int l, Type t, Size s){return l == level && t.Equals(type) && s.Equals(size);}
    public bool checkedStats(int l, Type t){return l == level && t.Equals(type);}
    public bool checkedStats(Size s){return s.Equals(size);}
    public bool checkedStats(int l){ return l == level;}
    public bool checkedStats(Type t){return t.Equals(type);}
}
