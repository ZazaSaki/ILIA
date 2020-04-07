
using UnityEngine;

public class EnemieParentScript : MonoBehaviour{

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

    public void attack(){
        //Debug.Log("attack");
    }

    

    //Check Stats Function
    public bool checkedStats(int l, Type t, Size s){return l == level && t.Equals(type) && s.Equals(size);}
    public bool checkedStats(int l, Type t){return l == level && t.Equals(type);}
    public bool checkedStats(Size s){return s.Equals(size);}
    public bool checkedStats(int l){ return l == level;}
    public bool checkedStats(Type t){return t.Equals(type);}
}
