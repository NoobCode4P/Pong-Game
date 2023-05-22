using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int sceneID)
    {
        ScenesManager.GetInstance().ChangeToScene(sceneID);
    }
}