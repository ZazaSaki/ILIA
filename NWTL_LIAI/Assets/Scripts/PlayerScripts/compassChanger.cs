using UnityEngine;

public class compassChanger : MonoBehaviour
{
    public Compass compass;


    public void PointTo(Transform newMission){
        compass.changeMission(newMission);
    }
    
    public void PointTo(Vector3 newMission){
        compass.changeMission(newMission);
    }
}
