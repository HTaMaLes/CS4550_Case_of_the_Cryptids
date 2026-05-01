using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        if (fov == null) return;

        Vector3 pos = fov.transform.position;

        // Draw detection radius
        Handles.color = Color.white;
        Handles.DrawWireDisc(pos, Vector3.up, fov.radius);

        // Draw FOV boundary lines
        Vector3 leftBoundary = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle * 0.5f);
        Vector3 rightBoundary = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle * 0.5f);

        Handles.color = Color.yellow;
        Handles.DrawLine(pos, pos + leftBoundary * fov.radius);
        Handles.DrawLine(pos, pos + rightBoundary * fov.radius);

        // Draw line to player when visible
        if (fov.canSeePlayer && fov.playerRef != null)
        {
            Handles.color = Color.green;
            Handles.DrawLine(pos, fov.playerRef.transform.position);
        }

        SceneView.RepaintAll();
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        float radians = (eulerY + angleInDegrees) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians));
    }
}