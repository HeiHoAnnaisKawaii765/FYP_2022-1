using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class KeyboardMove : EditorWindow
{

    
    
    public static void MoveSelectedXAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.position += Vector3.right * moveSpeed;
    }
    
    public static void MoveSelectedZAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.position += Vector3.forward * moveSpeed;
    }
    
    public static void MoveSelectedYAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.position += Vector3.up * moveSpeed;
    }
    

    public static void TurnSelectedLeftRight(float moveSpeed)
    {
        Selection.activeGameObject.transform.Rotate(0, -moveSpeed, 0f);
    }

    public static void TurnSelectedZAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.Rotate(0, 0, moveSpeed);
    }
    public static void TurnSelectedXAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.Rotate(moveSpeed, 0, 0);
    }
    public static void ScaleOnXAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.localScale += new Vector3(moveSpeed, 0, 0);
    }
    public static void ScaleOnYAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.localScale += new Vector3(0, moveSpeed, 0);
    }
    public static void ScaleOnZAxis(float moveSpeed)
    {
        Selection.activeGameObject.transform.localScale += new Vector3(0, 0, moveSpeed);
    }


}
