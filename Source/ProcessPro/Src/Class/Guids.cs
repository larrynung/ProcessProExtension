// Guids.cs
// MUST match guids.h
using System;

namespace LevelUp.ProcessPro
{
	static class GuidList
	{
		public const string guidProcessProPkgString = "57bfc20f-3038-4e9f-8d78-7b1339ce96de";
		public const string guidProcessProCmdSetString = "b917a578-2990-4e88-8101-9c42c336211d";
		public const string guidToolWindowPersistanceString = "c847869b-46ac-4a63-b1d2-4e01db327409";

		public static readonly Guid guidProcessProCmdSet = new Guid(guidProcessProCmdSetString);
	};
}