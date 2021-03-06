﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class GameWorldBase : WorldBase
{
    public override Type[] GetSystemTypes()
    {
        Type[] gameSystems = GameSystems();
        Type[] systemSystem = SystemSystem();

        Type[] types = new Type[systemSystem.Length + gameSystems.Length];

        int index = 0;

        for (int i = 0; i < gameSystems.Length; i++)
        {
            types[index++] = gameSystems[i];
        }

        for (int i = 0; i < systemSystem.Length; i++)
        {
            types[index++] = systemSystem[i];
        }

        return types;
    }

    //服务器系统
    public Type[] SystemSystem()
    {
        return new Type[]
           {
            typeof(CloseConnectTestSystem),
            
            typeof(ConnectSystem),
            typeof(PlayerInputSystem),
            typeof(ServiceSyncSystem),

            //Debug
            typeof(SyncDebugSystem),
           };
    }

    //游戏逻辑
    public abstract Type[] GameSystems();
}
