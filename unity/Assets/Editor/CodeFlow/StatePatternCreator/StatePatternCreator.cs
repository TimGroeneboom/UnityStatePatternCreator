using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using CodeFlow;

namespace CodeFlow.TemplateScripts
{
    public class StatePatternCreator : EditorWindow
    {
        [MenuItem("CodeFlow/State Pattern/Create Pattern")]
        public static void Test()
        {
            GetWindow(typeof(StatePatternCreator));
        }

        protected string _namespaceName = "CodeFlow";
        protected string _contextName = "Game";
        protected List<string> _stateNames = new List<string>
        {
            "Intro",
            "Playing",
            "Menu",
            "End"
        };

        void OnGUI()
        {
            EditorGUILayout.LabelField("NamespaceName");
            _namespaceName = EditorGUILayout.TextField(_namespaceName);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("ContextName");
            _contextName = EditorGUILayout.TextField(_contextName);
            EditorGUILayout.Space();

            if( GUILayout.Button("Add State") )
            {
                string stateName = "NewState";
                _stateNames.Add(stateName);
            }

            if( _stateNames.Count > 0 )
            {
                if (GUILayout.Button("Remove State"))
                {
                    _stateNames.RemoveAt(_stateNames.Count - 1);
                }
            }

            for (int i = 0; i < _stateNames.Count; i++)
            {
                _stateNames[i] = EditorGUILayout.TextField(_stateNames[i]);
            }

            EditorGUILayout.Space();

            if( _stateNames.Count > 0 )
            {
                if (GUILayout.Button("Generate Classes"))
                {
                    GenerateClasses(_namespaceName, _contextName, _stateNames.ToArray());

                    GetWindow(typeof(StatePatternCreator)).Close();
                }
            }
        }

        static public void GenerateClasses(string namespaceName, string contextName, string[] stateNames)
        {

            var namespacePath = namespaceName.Replace('.', '/');
            var relativePath = Path.Combine(Path.Combine("Scripts", namespacePath), contextName);
            var path = Path.Combine(Application.dataPath, relativePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            {
                /*
                 * Base Class
                 */
                var baseClassGenerator = new BaseStateClassGenerator(contextName, namespaceName, stateNames);
                var baseClassDefinition = baseClassGenerator.TransformText();
                try
                {
                    var scriptName = baseClassGenerator.ContextName + "BaseState.cs";
                    File.WriteAllText(Path.Combine(path, baseClassGenerator.ContextName + "BaseState.cs"), baseClassDefinition);
                    AssetDatabase.ImportAsset(Path.Combine(Path.Combine("Assets", relativePath), scriptName));
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }

            {
                /*
                 * State Classes
                 */
                foreach (var state in stateNames)
                {
                    var generator = new StateClassGenerator(state, contextName, namespaceName);

                    var definition = generator.TransformText();

                    try
                    {
                        var scriptName = generator.ContextName + generator.StateName + "State.cs";
                        File.WriteAllText(Path.Combine(path, scriptName), definition);
                        AssetDatabase.ImportAsset(Path.Combine(Path.Combine("Assets", relativePath), scriptName));
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(e.Message);
                    }
                }
            }

            {
                /*
                 * Context / Controller class
                 */
                var contextClassGenerator = new ContextClassGenerator(contextName, namespaceName, stateNames);
                var contextClassDefinition = contextClassGenerator.TransformText();
                try
                {
                    var scriptName = contextClassGenerator.ContextName + "Controller.cs";
                    File.WriteAllText(Path.Combine(path, scriptName), contextClassDefinition);
                    AssetDatabase.ImportAsset(Path.Combine(Path.Combine("Assets", relativePath), scriptName));
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }
    }
}
