using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAbleItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Animator charUIAnimator;
    public Image image;
    public GameObject addGameOBJ;
    private bool isActive = true;
    [HideInInspector] public Transform parentAfterDrag;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isActive)
            {
               //Kích hoạt hoặc hiển thị GameObject bổ sung
                if (addGameOBJ != null)
                {
                    addGameOBJ.SetActive(true);
                }
            }
            else
            {
                // SetActive(false) khi ấn chuột phải lần thứ hai
                if (addGameOBJ != null)
                {
                    addGameOBJ.SetActive(false);
                }
            }

            isActive = !isActive;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    IEnumerator ResetEatAnimation()
    {
        yield return new WaitForSeconds(1.6f); // Đợi 2 giây
        if (charUIAnimator != null)
        {
            charUIAnimator.SetBool("Eat", false);
        }
    }

    public void EatFood()
    {
        charUIAnimator.SetBool("Eat", true);
        StartCoroutine(ResetEatAnimation());
    }
}

