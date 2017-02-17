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
