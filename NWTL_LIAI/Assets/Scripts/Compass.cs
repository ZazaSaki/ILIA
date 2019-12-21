using UnityEngine;
using UnityEngine.UI;
public class Compass : MonoBehaviour{

    public Vector3 north;
    public Transform player;
    
    public Transform missionPlace;
    public Quaternion mission;//*/
 
    public RectTransform northLayer;
    public RectTransform missionLayer;
    // Update is called once per frame
    void Update()
    {
        changeNorth();
        if (missionPlace != null)
            changeMission();
        else
            missionLayer.localEulerAngles = northLayer.localEulerAngles;
    }

    public void changeNorth(){
        north.z = player.eulerAngles.y;
        northLayer.localEulerAngles = north;

    }

    
    
    public void changeMission(){
        //Director vector to quaternion
        Vector3 vectorDirector = player.position - missionPlace.position;
        mission = Quaternion.LookRotation(vectorDirector);


        //global Quaternion to local Quaternion
        mission.z = -mission.y;
        mission.x= 0;
        mission.y = 0;

        missionLayer.localRotation = mission * Quaternion.Euler(north);
    }//*/
}
