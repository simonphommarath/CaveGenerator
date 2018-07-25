namespace _2DProceduralContentGenerator.AutonomousAgent
{
    /// <summary>
    /// An autonomous agent is an entity that moves by itself based on it's environnement
    /// </summary>
    interface IAutonomousAgent
    {
        int _x { get; set; }
        int _y { get; set; }

        double _lifetimeDeathChance { get; set; }
        int _minLifetime { get; set; }
        int _maxLifetime { get; set; }
        int _age { get; set; }
        bool _isAlive { get; set; }

        void NextAction();
    }
}
