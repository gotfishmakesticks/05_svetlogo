using Godot;
using System;

public partial class MusicMixer : Node
{
    const float minDb = -40;

	[Export] private AudioStream normalMusic;
	[Export] private AudioStream overflowMusic;

    [Export] private AudioStreamPlayer normalPlayer;
    [Export] private AudioStreamPlayer overflowPlayer;

    [Export] private Timer restartTimer;

    [Export] private float fadeTime = 1.0f;

    private Tween tween;

    public override void _Ready()
    {
        normalPlayer.Stream = normalMusic;
        overflowPlayer.Stream = overflowMusic;

        normalPlayer.Play();
        overflowPlayer.Play();
        overflowPlayer.VolumeDb = minDb;
    }

    public void OnMusicStopped()
    {
        restartTimer.Start();
    }

    public void OnRestartMusic()
    {
        normalPlayer.Stop();
        normalPlayer.Play();
        overflowPlayer.Stop();
        overflowPlayer.Play();
    }

    public void ToggleOverflow(bool overflow)
    {
        if (tween != null)
        {
            tween.Kill();
        }
        tween = CreateTween().SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Cubic);

        if (overflow)
        {
            tween.TweenProperty(normalPlayer, "volume_db",minDb, fadeTime);
            tween.Parallel();
            tween.TweenProperty(overflowPlayer, "volume_db",0, fadeTime);
        }
        else
        {
            tween.TweenProperty(normalPlayer, "volume_db", 0, fadeTime);
            tween.Parallel();
            tween.TweenProperty(overflowPlayer, "volume_db", minDb, fadeTime);
        }
    }
}
