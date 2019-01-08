using System.Collections;
using System.Collections.Generic;

interface AchievementManager {
	/// <summary>
	/// Checks the state of the achievement.
	/// </summary>
	void checkAchievementState ();

	/// <summary>
	/// Unlocks the achievement.
	/// </summary>
	void unlockAchievement ();
}
