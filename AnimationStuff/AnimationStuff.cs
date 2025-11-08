using UnityEngine;
using System.Linq;

namespace BepInExTemplates.AnimationStuff;

public class AnimationStuff
{
    // call it like this:
    // StartAnim(rend, [Assets.Stunned0, Assets.Stunned1, Assets.Stunned2], 0.125f);


    /*
    public void StartAnim(
        SpriteRenderer rend,
        System.Collections.Generic.IEnumerable<LoadableResourceAsset> assets,
        float frameInterval)
        => Coroutines.Start(DoAnim(rend, assets.Select(a => a.LoadAsset()), frameInterval));
    */

    public System.Collections.IEnumerator DoAnim(SpriteRenderer rend, Sprite[] sprites, float frameInterval)
    {
        while (true)
        {
            foreach (var sprite in sprites)
            {
                rend.sprite = sprite;
                yield return new WaitForSeconds(frameInterval);
            }
        }
    }
}
