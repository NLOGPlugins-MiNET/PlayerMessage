using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;

namespace PlayerMessage
{
    [Plugin]
    public class Class1 : Plugin
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            Context.Server.PlayerFactory.PlayerCreated += onPlayerCreated;
            Console.WriteLine("[PlayerMessage] 플러그인이 활성화 되었습니다!");
            Console.WriteLine("당신이 이 플러그인을 사용하면, 당신은 MIT 라이센스에 동의한 것이 됩니다");
            Console.WriteLine("ⓒ Copyright 2016-2017 NLOG, All Right Reserved | ParkChanSol");
        }
        public override void OnDisable()
        {
            base.OnDisable();
            Context.Server.PlayerFactory.PlayerCreated -= onPlayerCreated;
        }
        private void onPlayerCreated(object sender, PlayerEventArgs e)
        {
            e.Player.PlayerJoin += onPlayerJoin;
            e.Player.PlayerLeave += onPlayerLeave;
        }

        private void onPlayerLeave(object sender, PlayerEventArgs e)
        {
            var pl = e.Player;
            var name = pl.Username;
            if (pl == null) throw new NotImplementedException();
            pl.Level.BroadcastMessage($"§e{name}님이 게임을 떠났습니다");
            Console.WriteLine($"{name}님이 게임을 떠났습니다");
        }

        private void onPlayerJoin(object sender, PlayerEventArgs e)
        {
            var pl = e.Player;
            var name = pl.Username;
            if(pl == null) throw new NotImplementedException();
            pl.Level.BroadcastMessage($"§e{name}님이 게임에 참여했습니다");
            Console.WriteLine($"{name}님이 게임에 참여했습니다");
        }
    }
}
