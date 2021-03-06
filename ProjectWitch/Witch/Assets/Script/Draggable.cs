﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;
    private bool isDragable = false;
	GameObject placeholder = null;
    public Vector3 showTemp;
    
    public bool dragging = false;
	public void OnBeginDrag(PointerEventData eventData) {
        if (isDragable)
        {
            dragging = true;
            placeholder = new GameObject();
            placeholder.transform.SetParent(this.transform.parent, false);
            LayoutElement le = placeholder.AddComponent<LayoutElement>();

            
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            le.flexibleWidth = 0;
            le.flexibleHeight = 0;

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            
            parentToReturnTo = this.transform.parent;
            
            placeholderParent = parentToReturnTo;
            this.transform.SetParent(this.transform.parent.parent,false);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
	}
	
	public void OnDrag(PointerEventData eventData) {
        if (isDragable)
        {

            this.transform.position = eventData.position;
            showTemp = this.transform.position;

            if (placeholder.transform.parent != placeholderParent)
                placeholder.transform.SetParent(placeholderParent);

            int newSiblingIndex = placeholderParent.childCount;

            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (this.transform.position.x < placeholderParent.GetChild(i).position.x
                    && this.transform.position.y < placeholderParent.GetChild(i).position.y)
                {

                    newSiblingIndex = i;

                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;

                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);
            
        }
    }
	
	public void OnEndDrag(PointerEventData eventData) {
        if (isDragable) {
            //Debug.Log("OnEndDrag");
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(placeholder);
            dragging = false;
        }
	}


    public void updateToTrueIsDragable()
    {
        isDragable = true;
    }
    public void updateToFalseIsDragable()
    {
        isDragable = false;
    }

    public void updateIsDragable()
    {
    
        if(isDragable == true)
        {
            isDragable = false;
        }
        else
        {
            isDragable = true;
        }
    }
	
	
}
