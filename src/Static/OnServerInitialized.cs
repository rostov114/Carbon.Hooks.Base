﻿using System;
using System.ComponentModel.Composition;
using API.Events;
using API.Hooks;
using CompanionServer.Handlers;

/*
 *
 * Copyright (c) 2022-2023 Carbon Community
 * All rights reserved.
 *
 */

namespace Carbon.Hooks;
#pragma warning disable IDE0051

public partial class Category_Static
{
	public partial class Static_ServerMgr
	{
		[HookAttribute.Patch("OnServerInitialized", "OnServerInitialized", typeof(ServerMgr), "OpenConnection", new System.Type[] { })]
		[HookAttribute.Options(HookFlags.Static | HookFlags.IgnoreChecksum)]

		[MetadataAttribute.Info("Called after the server startup has been completed and is awaiting connections.")]
		[MetadataAttribute.Info("Also called for plugins that are hotloaded while the server is already started running.")]
		[MetadataAttribute.Parameter("initialLoad", typeof(bool), true)]

		public class OnServerInitialized : Patch
		{
			public static void Postfix()
				=> Events.Trigger(CarbonEvent.OnServerInitialized, EventArgs.Empty);
		}
	}
}
