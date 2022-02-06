using System.Collections;
using Packages.SceneLoading.Runtime.Loaders;
using Packages.SceneLoading.Runtime.SceneInfos;
using Packages.UniKit.Runtime.PersistentVariables;
using UnityEngine;

namespace Assets.Scripts.MainSceneScripts
{
    public class MasterSceneScript : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        public GameplayInfo gameplayToLoad;
        
        public RoomInfo firstRoomToLoad;
        
        [Header("References")]
        public PersistentString playerCurrentRoom;
        
        // -- Class
        
        IEnumerator Start()
        {
            playerCurrentRoom.Value = firstRoomToLoad.ScenePath;
            
            yield return SceneManagerExt.LoadSubSceneAsync(firstRoomToLoad.ScenePath);
            yield return SceneManagerExt.LoadSubSceneAsync(gameplayToLoad.ScenePath);
        }
    }
}