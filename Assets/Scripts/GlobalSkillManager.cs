using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalSkillManager
{
    public static bool IsSkillActive { get; private set; } = false;
    public static bool IsOnCooldown { get; private set; } = false;

    private static List<BulletShot> registeredBulletShots = new();
    private static MonoBehaviour coroutineHost;

    public static void Register(BulletShot shooter)
    {
        if (!registeredBulletShots.Contains(shooter))
            registeredBulletShots.Add(shooter);
    }

    public static void Unregister(BulletShot shooter)
    {
        if (registeredBulletShots.Contains(shooter))
            registeredBulletShots.Remove(shooter);
    }

    public static void TryActivateSkill(MonoBehaviour host, float duration, float cooldown, float boostedInterval)
    {
        if (IsSkillActive || IsOnCooldown) return;

        coroutineHost = host;
        coroutineHost.StartCoroutine(ActivateSkill(duration, cooldown, boostedInterval));
    }

    private static IEnumerator ActivateSkill(float duration, float cooldown, float boostedInterval)
    {
        IsSkillActive = true;
        Debug.Log("Double fire rate activated!");

        foreach (var shooter in registeredBulletShots)
            shooter.SetFireRate(boostedInterval);

        yield return new WaitForSeconds(duration);

        foreach (var shooter in registeredBulletShots)
            shooter.ResetFireRate();

        IsSkillActive = false;
        IsOnCooldown = true;
        Debug.Log("Skill ended. Cooldown started.");

        yield return new WaitForSeconds(cooldown);
        IsOnCooldown = false;
        Debug.Log("Cooldown ended. Skill ready again.");
    }
}
