﻿using System.Collections;
using System.Collections.Generic;

namespace Ship
{
    namespace SecondEdition.AuzituckGunship
    {
        public class KashyyykDefender : AuzituckGunship
        {
            public KashyyykDefender() : base()
            {
                PilotInfo = new PilotCardInfo(
                    "Kashyyyk Defender",
                    1,
                    44,
                    seImageNumber: 33
                );
            }
        }
    }
}
