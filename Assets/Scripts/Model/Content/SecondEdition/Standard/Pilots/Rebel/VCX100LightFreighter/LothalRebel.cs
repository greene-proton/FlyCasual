﻿using Content;
using System.Collections.Generic;

namespace Ship
{
    namespace SecondEdition.VCX100LightFreighter
    {
        public class LothalRebel : VCX100LightFreighter
        {
            public LothalRebel() : base()
            {
                PilotInfo = new PilotCardInfo25
                (
                    "Lothal Rebel",
                    "",
                    Faction.Rebel,
                    2,
                    7,
                    8,
                    tags: new List<Tags>
                    {
                        Tags.Freighter
                    },
                    seImageNumber: 76
                );
            }
        }
    }
}
