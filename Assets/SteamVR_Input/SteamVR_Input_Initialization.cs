// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        public static void PreInitialize()
        {
            SteamVR_Actions.StartPreInitActionSets();
            SteamVR_Input.PreinitializeActionSetDictionaries();
            SteamVR_Actions.PreInitActions();
            SteamVR_Actions.InitializeActionArrays();
            SteamVR_Input.PreinitializeActionDictionaries();
            SteamVR_Input.PreinitializeFinishActionSets();
        }
    }
}
