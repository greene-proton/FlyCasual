﻿using Ship;
using Upgrade;
using Tokens;

namespace UpgradesList.FirstEdition
{
    public class AdvancedOptics : GenericUpgrade
    {
        public AdvancedOptics() : base()
        {
            UpgradeInfo = new UpgradeCardInfo(
                "Advanced Optics",
                UpgradeType.Tech,
                cost: 2,
                abilityType: typeof(Abilities.FirstEdition.AdvancedOpticsAbility)
            );
        }        
    }
}

namespace Abilities.FirstEdition
{
    public class AdvancedOpticsAbility : GenericAbility
    {
        public override void ActivateAbility()
        {
            HostShip.BeforeTokenIsAssigned += AdvancedOpticsRestriction;
            HostShip.OnTokenIsAssigned += AdvancedOpticsBonus;

            ToggleBonusOfExistingFocusTokens(true);
        }

        public override void DeactivateAbility()
        {
            HostShip.BeforeTokenIsAssigned -= AdvancedOpticsRestriction;
            HostShip.OnTokenIsAssigned -= AdvancedOpticsBonus;

            ToggleBonusOfExistingFocusTokens(false);
        }

        private void AdvancedOpticsRestriction(GenericShip ship, GenericToken token)
        {
            if (token is FocusToken && ship.Tokens.HasToken(typeof(FocusToken)))
            {
                Messages.ShowError("Advanced Optics: This ship cannot have more than 1 Focus token");
                ship.Tokens.TokenToAssign = null;
            }
        }

        private void AdvancedOpticsBonus(GenericShip ship, GenericToken token)
        {
            if (token is FocusToken)
            {
                ToggleBonusOfExistingFocusTokens(true);
            }
        }

        private void ToggleBonusOfExistingFocusTokens(bool isActive)
        {
            FocusToken FocusToken = (FocusToken)HostShip.Tokens.GetToken(typeof(FocusToken));
            if (FocusToken != null)
            {
                FocusToken.Temporary = !isActive;
            }
        }
    }
}