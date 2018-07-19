using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGenerator.AutonomousAgent
{
    /// <summary>
    /// An autonomous agent is an entity that moves by itself based on it's environnement
    /// </summary>
    interface IAutonomousAgent
    {
        int _x { get; set; }
        int _y { get; set; }

        int _lifetimeDeathChance { get; set; }
        int _minLifetime { get; set; }
        int _maxLifetime { get; set; }
        int _age { get; set; }

        void NextAction();
    }
}
