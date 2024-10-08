// using UnityEngine;
// using UnityEngine.Networking;
// using System.Collections;

// public class ModelLoader : MonoBehaviour
// {
//     public string modelName = "eyeball";
//     private string serverUrl = "http://localhost:5000/api/models/";

//     void Start()
//     {
//         StartCoroutine(DownloadAndLoadModel());
//     }

//     IEnumerator DownloadAndLoadModel()
//     {
//         // Download the .obj file
//         UnityWebRequest objRequest = UnityWebRequest.Get(serverUrl + modelName + ".obj");
//         yield return objRequest.SendWebRequest();

//         if (objRequest.result != UnityWebRequest.Result.Success)
//         {
//             Debug.LogError("Failed to download .obj file: " + objRequest.error);
//             yield break;
//         }

//         // Optionally, download the .mtl file if available
//         UnityWebRequest mtlRequest = UnityWebRequest.Get(serverUrl + modelName + ".mtl");
//         yield return mtlRequest.SendWebRequest();

//         if (mtlRequest.result == UnityWebRequest.Result.Success)
//         {
//             Debug.Log("Downloaded .mtl file: " + mtlRequest.downloadHandler.text);
//             // Optionally process the .mtl file here
//         }

//         // Now we have the .obj data, let's load it
//         string objData = objRequest.downloadHandler.text;

//         // Use a runtime OBJ loader to parse and load the .obj file
//         // Assuming you're using Runtime OBJ Loader or a similar package:
//         OBJLoader objLoader = new OBJLoader();
//         GameObject loadedObject = objLoader.Load(objData);
//         loadedObject.transform.position = Vector3.zero; // Adjust position if needed

//         Debug.Log("3D model loaded successfully!");
//     }
// }
