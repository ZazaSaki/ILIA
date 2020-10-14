using UnityEngine;

public abstract class Tool : MonoBehaviour, IActivatable{
    protected Component comp;

    public abstract void Action();
    public void setComponent(Component toset){
        Debug.Log("setting comp in tool");
        comp = toset;
    }
    //public abstract void Action();
}
