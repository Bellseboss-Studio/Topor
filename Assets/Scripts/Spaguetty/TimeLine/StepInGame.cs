using System;
using System.Collections.Generic;

[Serializable]
public class StepInGame
{
    public StepIdentifier stepIdentifier;
    public float timeOfStep { get; set; }
    public List<StepSpawnRatioEnemy> toposToSpawn { get; set; }
}