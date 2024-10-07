using System.Collections.Generic;
using UnityEngine;

public enum SkeletonHand
{
    Left,
    Right
}

public class SkeletonTransformCopier : MonoBehaviour
{
    public SkeletonHand hand = SkeletonHand.Left;
    private Transform sourceSkeletonRoot; // Root of the source skeleton (must have the same hierarchy as target)
    public Transform targetSkeletonRoot; // Root of the target skeleton (must have the same hierarchy as source)

    List<(Transform,Transform)> pairedBones = new List<(Transform, Transform)>();

    private void PairChildren(Transform source, Transform target) 
    {
        Dictionary<string, Transform> sourceChildren = new Dictionary<string, Transform>();
        foreach (Transform child in source)
        {
            sourceChildren.Add(child.name, child);
        }

        foreach (Transform child in target)
        {
            if (sourceChildren.ContainsKey(child.name))
            {
                pairedBones.Add((sourceChildren[child.name], child));
                PairChildren(sourceChildren[child.name], child);
            }
        }
    }

    public void OnEnable()
    {
        if (hand == SkeletonHand.Left)
        {
            sourceSkeletonRoot = HandsIdentifier.leftHand;
        }
        else
        {
            sourceSkeletonRoot = HandsIdentifier.rightHand;
        }

        pairedBones.Clear();
        pairedBones.Add((sourceSkeletonRoot, targetSkeletonRoot));
        PairChildren(sourceSkeletonRoot, targetSkeletonRoot);
    }

    private void Update()
    {
        // Check if both skeleton roots are assigned
        if (sourceSkeletonRoot == null || targetSkeletonRoot == null)
        {
            Debug.LogError("Please assign both the source and target skeleton root Transforms.");
            return;
        }

        // Start copying the transforms from the source to the target
        CopySkeletonBones();
        //CopySkeletonTransforms(sourceSkeletonRoot, targetSkeletonRoot);
    }

    void CopySkeletonBones()
    {
        foreach (var pair in pairedBones)
        {
            pair.Item2.localPosition = pair.Item1.localPosition;
            pair.Item2.localRotation = pair.Item1.localRotation;
            pair.Item2.localScale = pair.Item1.localScale;
        }
    }
    /// <summary>
    /// NOT BEING USED! Recursively copies the transform (position, rotation, and scale) from one skeleton to another.
    /// </summary>
    /// <param name="source">The source transform to copy from.</param>
    /// <param name="target">The target transform to copy to.</param>
    void CopySkeletonTransforms(Transform source, Transform target)
    {
        if (source == null || target == null)
        {
            Debug.LogError("Source or target transform is null, cannot copy transforms.");
            return;
        }

        // Copy position, rotation, and scale from source to target
        target.localPosition = source.localPosition;
        target.localRotation = source.localRotation;
        target.localScale = source.localScale;

        // Recursively copy the transforms of all children
        for (int i = 0; i < source.childCount; i++)
        {
            // Ensure the target has the same number of children as the source
            if (i < target.childCount)
            {
                // Recursively copy transforms from the source child to the corresponding target child
                CopySkeletonTransforms(source.GetChild(i), target.GetChild(i));
            }
            else
            {
                Debug.LogError($"Target skeleton does not match the source skeleton hierarchy at child {source.GetChild(i)} ({i} / {target.childCount})");
                break;
            }
        }
    }
}
