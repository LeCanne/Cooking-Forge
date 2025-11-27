using System.Collections;
using UnityEngine;

public class WeaponPartIdentifier : MonoBehaviour
{
    public int id;
    public AssemblingMinigame assemblingMinigame;
    bool validate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out WeaponPart idW)) 
        {
            if (idW.id == id && validate == false)
            {
                
                idW.GetComponent<DragObject>().notInteractable = true;
                idW.GetComponent<DragObject>().ForceUp();
                validate = true;
               StartCoroutine(DoAnim(idW));
            }
        }
    }

    IEnumerator DoAnim(WeaponPart part)
    {
        Vector3 originalPos = part.transform.position;
        yield return null;
        float duration = 1;
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            part.gameObject.transform.position = Vector3.Lerp(originalPos, transform.position, time/duration);    
            yield return null; 
        }
        assemblingMinigame.ValidateWeaponPart();
    }
}
