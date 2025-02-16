using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    // Start is called before the first frame update
    public List<EnemyController> Enemies = new List<EnemyController>();
    public List<Transform> PathNodes = new List<Transform>();
    void Start()
    {
        //·��
        foreach (var enemy in Enemies)
        {
            enemy.PatrolPath = this;
            enemy.transform.position = PathNodes[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addEnemy(EnemyController enemy)
    {
        Enemies.Add(enemy);
        enemy.PatrolPath = this;
        //enemy.transform.position = PathNodes[0].position;
    }

    public float GetDistanceToNode(Vector3 origin, int destinationNodeIndex)
    {
        if (destinationNodeIndex < 0 || destinationNodeIndex >= PathNodes.Count ||
            PathNodes[destinationNodeIndex] == null)
        {
            return -1f;
        }

        return (PathNodes[destinationNodeIndex].position - origin).magnitude;
    }

    public Vector3 GetPositionOfPathNode(int nodeIndex)
    {
        if (nodeIndex < 0 || nodeIndex >= PathNodes.Count || PathNodes[nodeIndex] == null)
        {
            return Vector3.zero;
        }

        return PathNodes[nodeIndex].position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < PathNodes.Count; i++)
        {
            int nextIndex = i + 1;
            if (nextIndex >= PathNodes.Count)
            {
                nextIndex -= PathNodes.Count;
            }

            Gizmos.DrawLine(PathNodes[i].position, PathNodes[nextIndex].position);
            Gizmos.DrawSphere(PathNodes[i].position, 0.1f);
        }
    }
}
