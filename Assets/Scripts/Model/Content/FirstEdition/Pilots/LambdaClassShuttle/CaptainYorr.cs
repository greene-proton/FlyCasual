﻿using Ship;
using SubPhases;
using System;
using Tokens;

namespace Ship
{
    namespace FirstEdition.LambdaClassShuttle
    {
        public class CaptainYorr : LambdaClassShuttle
        {
            public CaptainYorr() : base()
            {
                PilotInfo = new PilotCardInfo(
                    "Captain Yorr",
                    4,
                    24,
                    isLimited: true,
                    abilityType: typeof(Abilities.FirstEdition.CaptainYorrAbility)
                );
            }
        }
    }
}

namespace Abilities.FirstEdition
{
    public class CaptainYorrAbility : GenericAbility
    {

        public override void ActivateAbility()
        {
            GenericShip.BeforeTokenIsAssignedGlobal += CaptainYorrPilotAbility;
        }

        public override void DeactivateAbility()
        {
            GenericShip.BeforeTokenIsAssignedGlobal -= CaptainYorrPilotAbility;
        }

        private void CaptainYorrPilotAbility(GenericShip ship, GenericToken token)
        {
            if (token is StressToken
                && ship.Owner == HostShip.Owner
                && ship != HostShip
                && HostShip.Tokens.CountTokensByType(typeof(StressToken)) <= 2)
            {

                BoardTools.DistanceInfo positionInfo = new BoardTools.DistanceInfo(ship, HostShip);
                if (positionInfo.Range <= 2)
                {
                    TargetShip = ship;
                    RegisterAbilityTrigger(TriggerTypes.OnBeforeTokenIsAssigned, ShowDecision);
                }
            }
        }

        private void ShowDecision(object sender, EventArgs e)
        {
            AskToUseAbility(
                HostShip.PilotInfo.PilotName,
                NeverUseByDefault,
                UseCaptainYorrAbility,
                descriptionLong: "Do you want to receive Stress token instead of the friendly ship?",
                imageHolder: HostShip
            );
        }

        private void UseCaptainYorrAbility(object sender, System.EventArgs e)
        {
            HostShip.Tokens.AssignToken(TargetShip.Tokens.TokenToAssign, delegate {
                TargetShip.Tokens.TokenToAssign = null;
                TargetShip = null;
                DecisionSubPhase.ConfirmDecision();
            });
        }

    }
}
