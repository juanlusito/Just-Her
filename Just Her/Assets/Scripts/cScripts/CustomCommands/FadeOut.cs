using Naninovel;
using Naninovel.Commands;
using UniRx.Async;
using UnityEngine;
[CommandAlias("fadeOut")]
public class FadeOut : Command
{
    Animator screenAnimator;
    public override UniTask ExecuteAsync(CancellationToken cancellationToken = default)
    {
        screenAnimator = GameObject.Find("BlackScreen").GetComponent<Animator>();
        screenAnimator.SetTrigger("activateFadeOut");
        return UniTask.CompletedTask;
    }
}
