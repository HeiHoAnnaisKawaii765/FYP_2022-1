using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnityController : EditorWindow
{
    public float moveScale = 10f;
    public bool modeSelecetion1, modeSelecetion2, modeSelecetion3;
    bool groupEnabled;
    int selection;



    [MenuItem("Move Tool/Set Move Scale")]
    static void Init()
    {
        UnityController window = (UnityController)EditorWindow.GetWindow(typeof(UnityController));
        window.Show();
        
        
        
    }
    [MenuItem("Move Tool/Set Move Scale/RunU _I")]
    static void Up()
    {
        UnityController window = (UnityController)EditorWindow.GetWindow(typeof(UnityController)); 
        switch (window.selection)
            {
                case 1:
                KeyboardMove.MoveSelectedYAxis(window.moveScale);
                break;
                case 2:
                KeyboardMove.TurnSelectedZAxis(window.moveScale * -1);
                break;
                case 3:
                KeyboardMove.ScaleOnYAxis(window.moveScale);
                break;
        
        
            }
        
    }
    [MenuItem("Move Tool/Set Move Scale/RunD _M")]
    static void Down()
    {
        UnityController window = (UnityController)EditorWindow.GetWindow(typeof(UnityController));

        switch (window.selection)
        {
            case 1:
                KeyboardMove.MoveSelectedYAxis(window.moveScale * -1);
                break;
            case 2:
                KeyboardMove.TurnSelectedZAxis(window.moveScale);

                break;
            case 3:
                KeyboardMove.ScaleOnYAxis(window.moveScale * -1);
                break;


        }
        
    }
    [MenuItem("Move Tool/Set Move Scale/RunL _J")]
    static void Left()
    {
        UnityController window = (UnityController)EditorWindow.GetWindow(typeof(UnityController));
        switch (window.selection)
        {
            case 1:
                KeyboardMove.MoveSelectedXAxis(window.moveScale * -1);
                break;
            case 2:
                KeyboardMove.TurnSelectedLeftRight(window.moveScale);

                break;
            case 3:
                KeyboardMove.ScaleOnXAxis(window.moveScale * -1);
                break;


        }
        
    }
    [MenuItem("Move Tool/Set Move Scale/RunR _;")]
    static void Right()
    {
        UnityController window = (UnityController)EditorWindow.GetWindow(typeof(UnityController));
        switch (window.selection)
        {
            case 1:
                KeyboardMove.MoveSelectedXAxis(window.moveScale);
                break;
            case 2:
                KeyboardMove.TurnSelectedLeftRight(window.moveScale * -1);
                break;
            case 3:
                KeyboardMove.ScaleOnXAxis(window.moveScale);
                break;


        }
        
    }
    [MenuItem("Move Tool/Set Move Scale/RunF _U")]
    static void Front()
    {
        UnityController window = (UnityController)EditorWindow.GetWindow(typeof(UnityController));
        switch (window.selection)
        {
            case 1:
                KeyboardMove.MoveSelectedZAxis(window.moveScale);
                break;
            case 2:

                KeyboardMove.TurnSelectedXAxis(window.moveScale);
                break;
            case 3:
                KeyboardMove.ScaleOnZAxis(-window.moveScale);
                break;


        }
        
    }
    [MenuItem("Move Tool/Set Move Scale/RunB _O")]
    static void Back()
    {
        UnityController window = (UnityController)EditorWindow.GetWindow(typeof(UnityController));
        switch (window.selection)
        {
            case 1:
                KeyboardMove.MoveSelectedZAxis(window.moveScale * -1);

                break;
            case 2:

                KeyboardMove.TurnSelectedXAxis(window.moveScale * -1);
                break;
            case 3:
                KeyboardMove.ScaleOnZAxis(window.moveScale * 1) ;
                break;


        }
        
    }
      




    private void OnGUI()
    {
        moveScale = EditorGUILayout.Slider("Move Distant", moveScale, 0, 100);
        groupEnabled = EditorGUILayout.BeginToggleGroup("Select mode", groupEnabled);
        modeSelecetion1 = EditorGUILayout.Toggle("Position", modeSelecetion1);
        modeSelecetion2 = EditorGUILayout.Toggle("Rotation", modeSelecetion2);
        modeSelecetion3 = EditorGUILayout.Toggle("Scale", modeSelecetion3);

        if (modeSelecetion1)
        {
            selection = 1;
            modeSelecetion2 = false;
            modeSelecetion3 = false;
        }
        else if (modeSelecetion2)
        {
            selection = 2;
            modeSelecetion1 = false;
            modeSelecetion3 = false;
        }
        else if(modeSelecetion3)
        {
            selection = 3;
            modeSelecetion1 = false;
            modeSelecetion2 = false;
        }
        else
        {
            selection = 0;
        }
    }
}
