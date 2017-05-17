using Game.Player.Controller;
using Game.Player.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Player.UI {
    public interface PlayerDataOutput {

        PlayerData GetPlayerData();

        void Log(string msg);

    }
}
