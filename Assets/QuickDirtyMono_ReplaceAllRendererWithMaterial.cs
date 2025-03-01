using UnityEngine;

public class QuickDirtyMono_ReplaceAllRendererWithMaterial : MonoBehaviour
{
    public Material m_toReplace;
    public Material m_replaceBy;
    public bool m_inverse;

    [ContextMenu("Change Sleepy")]
    public void ChangeSleepy()
    {
        if (m_toReplace == null || m_replaceBy == null)
        {
            Debug.LogWarning("Materials not assigned!");
            return;
        }

        Renderer[] allRenderersInScene = GameObject.FindObjectsOfType<Renderer>(true);

        foreach (Renderer r in allRenderersInScene)
        {
            if (r.sharedMaterials != null && r.sharedMaterials.Length > 0)
            {
                Material[] materials = r.sharedMaterials;

                for (int i = 0; i < materials.Length; i++)
                {
                    if ((m_inverse && materials[i] == m_replaceBy) || (!m_inverse && materials[i] == m_toReplace))
                    {
                        materials[i] = m_inverse ? m_toReplace : m_replaceBy;
                    }
                }

                r.sharedMaterials = materials; // Apply the modified material array
            }
        }

        Debug.Log("Material replacement completed.");
    }
}
