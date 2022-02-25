﻿using Content;
using System.Collections.Generic;
using Upgrade;

namespace Ship
{
    namespace SecondEdition.TIEInterceptor
    {
        public class SaberSquadronAce : TIEInterceptor
        {
            public SaberSquadronAce() : base()
            {
                PilotInfo = new PilotCardInfo25
                (
                    "Saber Squadron Ace",
                    "",
                    Faction.Imperial,
                    4,
                    4,
                    7,
                    extraUpgradeIcons: new List<UpgradeType>()
                    {
                        UpgradeType.Talent,
                        UpgradeType.Missile
                    },
                    tags: new List<Tags>
                    {
                        Tags.Tie
                    },
                    seImageNumber: 105,
                    skinName: "Red Stripes"
                );
            }
        }
    }
}