using UnityEngine;

public class FlipWithOwner : MonoBehaviour
{
    private SpriteRenderer ownerRenderer;

    void Awake()
    {
        ownerRenderer = GetComponentInParent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        Vector3 s = transform.localScale;
        s.x = Mathf.Abs(s.x) * (ownerRenderer.flipX ? -1 : 1);
        transform.localScale = s;
    }

}
