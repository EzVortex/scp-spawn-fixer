﻿using System;
using System.Collections.Generic;
using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace SCPSpawnFixer
{
    public class EventHandlers
    {
        private static List<String> _players = new();
        private bool _isRoundStarted;
        
        [PluginEvent(ServerEventType.PlayerSpawn)]
        public void OnPlayerSpawn(Player player, RoleTypeId role)
        {
            if (String.IsNullOrEmpty(player.UserId) || player.Role == RoleTypeId.Scp0492 || _players.Contains(player.UserId) || _isRoundStarted)
                return;
            
            _players.Add(player.UserId);

            Timing.CallDelayed(5f, () =>
            {
                if (player.Position.y < -1000f)
                {
                    Log.Info($"{player.Nickname} has spawned in the void! Respawning it.");
                    player.SetRole(role, RoleChangeReason.None);
                }
            });
        }
        
        [PluginEvent(ServerEventType.RoundRestart)]
        public void OnRoundRestart()
        {
            _players.Clear();
            _isRoundStarted = false;
        }

        [PluginEvent(ServerEventType.RoundStart)]
        public void OnRoundStart()
        {
            Timing.CallDelayed(30f, () => _isRoundStarted = true);
        }
    }
}