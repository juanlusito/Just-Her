using Naninovel;
using Naninovel.Commands;
using UniRx.Async;
using UnityEngine;
[CommandAlias("fadeIn")]
public class FadeIn : Command
{
    Animator screenAnimator;
    public override UniTask ExecuteAsync(CancellationToken cancellationToken = default)
    {
        screenAnimator = GameObject.Find("BlackScreen").GetComponent<Animator>();
        screenAnimator.Play("FadeIn");
        return UniTask.CompletedTask;
    }
}