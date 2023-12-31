/****************************************************************************
 * Copyright (c) 2017 Thor Brigsted UNDER MIT LICENSE  see licenses.txt 
 * Copyright (c) 2022 liangxiegame UNDER Paid MIT LICENSE  see licenses.txt
 *
 * xNode: https://github.com/Siccity/xNode
 ****************************************************************************/

#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace QFramework.Pro
{
    /// <summary> Deals with modified assets </summary>
    class IMGUIGraphImporter : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets,
            string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (string path in importedAssets)
            {
                // Skip processing anything without the .asset extension
                if (Path.GetExtension(path) != ".asset") continue;

                // Get the object that is requested for deletion
                IMGUIGraph graph = AssetDatabase.LoadAssetAtPath<IMGUIGraph>(path);
                if (graph == null) continue;

                // Get attributes
                Type graphType = graph.GetType();
                IMGUIGraph.RequireNodeAttribute[] attribs = Array.ConvertAll(
                    graphType.GetCustomAttributes(typeof(IMGUIGraph.RequireNodeAttribute), true),
                    x => x as IMGUIGraph.RequireNodeAttribute);

                Vector2 position = Vector2.zero;
                foreach (IMGUIGraph.RequireNodeAttribute attrib in attribs)
                {
                    if (attrib.type0 != null) AddRequired(graph, attrib.type0, ref position);
                    if (attrib.type1 != null) AddRequired(graph, attrib.type1, ref position);
                    if (attrib.type2 != null) AddRequired(graph, attrib.type2, ref position);
                }
            }
        }

        private static void AddRequired(IMGUIGraph graph, Type type, ref Vector2 position)
        {
            if (!graph.nodes.Any(x => x.GetType() == type))
            {
                IMGUIGraphNode node = graph.AddNode(type);
                node.position = position;
                position.x += 200;
                if (node.name == null || node.name.Trim() == "")
                    node.name = IMGUIGraphUtilities.NodeDefaultName(type);
                if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(graph)))
                    AssetDatabase.AddObjectToAsset(node, graph);
            }
        }
    }
}
#endif