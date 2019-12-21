using UnityEngine;

public class compassChanger : MonoBehaviour
{
    public Compass compass;


    public void PointTo(Transform newMission){
        compass.changeMission(newMission);
    }
}
