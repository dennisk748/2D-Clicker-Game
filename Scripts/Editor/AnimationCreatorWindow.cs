using UnityEditor;
using UnityEngine;

public class AnimationCreatorWindow : EditorWindow
{
    SerializedObject obj;

    public SerializedProperty animController;
    public SerializedProperty animMapping;
    public SerializedProperty quickFolder;
    public SerializedProperty FPS;

    [MenuItem("Window/Animations Creator Window")]
    public static void ShowWindow()
    {
        GetWindow<AnimationCreatorWindow>("Animations Creator Window");
    }

    private void OnEnable()
    {
        obj = new SerializedObject(GameStateManager.Instance.m_animationWindowRefManager);

        animController = obj.FindProperty("AnimatorController");
        animMapping = obj.FindProperty("animationMapping");
        quickFolder = obj.FindProperty("QuickCreateFolder");
        FPS = obj.FindProperty("FPS");
    }

    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(FPS);

        EditorGUILayout.PropertyField(animController);
        RuntimeAnimatorController controller = GameStateManager.Instance.m_animationWindowRefManager.AnimatorController;

        if (controller)
        {
            for (int i = 0; i < controller.animationClips.Length; i++)
            {
                EditorGUILayout.LabelField(controller.animationClips[i].name);
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(animMapping);



        foreach (AnimationWindowReference.CharacterAnimationMapping am in GameStateManager.Instance.m_animationWindowRefManager.animationMapping)
        {
            if (am.animationFolder.Count < controller.animationClips.Length)
            {
                int diff = controller.animationClips.Length - am.animationFolder.Count;
                for (int k = 0; k < diff; k++)
                {
                    am.animationFolder.Add(new FolderReference());
                }
            }
        }

        if (GUILayout.Button("Begin Operations"))
        {
            obj.ApplyModifiedProperties();
            GameStateManager.Instance.m_animationWindowRefManager.StartOperation();
        }

        EditorGUILayout.Space(30);
        EditorGUILayout.PropertyField(quickFolder);

        if (GUILayout.Button("Quick Create"))
        {
            obj.ApplyModifiedProperties();
            GameStateManager.Instance.m_animationWindowRefManager.UseQuickOperation();
        }

        if (EditorGUI.EndChangeCheck())
            obj.ApplyModifiedProperties();
    }



    public static string GetCurrentAssetDirectory()
    {
        foreach (var obj in Selection.GetFiltered<Object>(SelectionMode.Assets))
        {
            var path = AssetDatabase.GetAssetPath(obj);
            if (string.IsNullOrEmpty(path))
                continue;

            if (System.IO.Directory.Exists(path))
                return path;
            else if (System.IO.File.Exists(path))
                return System.IO.Path.GetDirectoryName(path);
        }

        return "Assets";
    }
}
