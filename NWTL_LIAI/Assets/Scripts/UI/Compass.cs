﻿using UnityEngine;
using UnityEngine.UI;
public class Compass : UI_Widget{

    private Vector3 north;
    
    private Vector3 missionPlace;
    private Quaternion mission;//*/
 
    public RectTransform northLayer;
    public RectTransform missionLayer;
    // Update is called once per frame
    
    public Transform player(){
        return getUIManager().PlayerTransform;
    }

    void Update()
    {
        updateNorth();
        if (missionPlace != null)
            updateMission();
        else
            missionLayer.localEulerAngles = northLayer.localEulerAngles;
    }

    private void updateNorth(){
        north.z = player().eulerAngles.y;
        northLayer.localEulerAngles = north;

    }

    
    
    private void updateMission(){
        //Director vector to quaternion
        Vector3 vectorDirector = player().position - missionPlace;
        mission = Quaternion.LookRotation(vectorDirector);


        //global Quaternion to local Quaternion
        mission.z = -mission.y;
        mission.x= 0;
        mission.y = 0;

        missionLayer.localRotation = mission * Quaternion.Euler(north);
    }//*/

    public void changeMission(Transform newMission){
        missionPlace = newMission.position;
    }

    public void changeMission(Vector3 newMission){
        missionPlace = newMission;
    }
}
