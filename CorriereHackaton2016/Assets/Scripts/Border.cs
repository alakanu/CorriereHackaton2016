using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        EdgeCollider2D[] colliders = GetComponents<EdgeCollider2D>();

        Bounds b = GetComponent<SpriteRenderer>().sprite.bounds;
        Vector2 center = b.center;
        Vector2 extents = b.extents;
                
        float x = extents.x;
        float y = extents.y;
        Vector2 topLeft = center + new Vector2 (-x, y);
        Vector2 topRight = center + new Vector2 (x, y);
        Vector2 bottomLeft = center + new Vector2 (-x, -y);
        Vector2 bottomRight = center + new Vector2(x, -y);
        Vector2[] upside = { topLeft, topRight };
        Vector2[] downside = { bottomLeft, bottomRight };
        Vector2[] leftside = { bottomLeft, topLeft };
        Vector2[] rightside = { bottomRight, topRight };
        colliders[0].points = upside;
        colliders[1].points = downside;
        colliders[2].points = leftside;
        colliders[3].points = rightside;
    }
}
