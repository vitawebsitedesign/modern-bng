using BallisticNG.Gamemodes;
using BallisticNG.RaceUI;
using BallisticSource.Mods;
using GameData;
using ModernBng.Core;
using ModernBng.Core.Models;

namespace ModernBngGamemode
{
    public class ModernBngGamemodeRegister : ModRegister
    {
        public override void OnRegistered()
        {
            GamemodeRegistry.RegisterGamemode("Modern BNG (experimental)", new ModernBngGamemode(true));
        }
    }

    public class ModernBngGamemode : Gamemode
    {
        #region Vars
        ScriptableMenu _pauseInterface;
        ScriptableMenu _eliminatedInterface;
        ScriptableMenu _eventCompleteInterface;
        ScriptableHud[] _speedAndShieldHud;
        ScriptableHud[] _notificationHud;
        ScriptableHud[] _timeHud;
        ScriptableHud[] _positionHud;
        ScriptableHud[] _lapHud;
        ScriptableHud[] _weaponHud;
        ScriptableHud[] _nowPlayingHud;
        #endregion

        #region Constructors/destructors
        public ModernBngGamemode()
        {
        }

        public ModernBngGamemode(bool manualConfiguration) : base(manualConfiguration)
        {
        }
        #endregion

        public async override void OnShipTriggerStartLine(ShipRefs ship)
        {
            if (ship.IsPlayer)
            {
                await ModernBngCore.TryApplyModernGfx(ship, new UnityScene
                {
                    SceneNameWithUnityLighting = "TestStdShader",
                    SunObject = "main-sun",
                    ModernSceneryObject = "modern-scenery",
                    SkyMaterialObject = "sky-material-ref",
                    PostProcessingObject = "post-processing-ref"
                });
            }
        }

        #region Default BNG overrides
        public override void OnAwake()
        {
            base.OnAwake();
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override void OnGamePaused()
        {
            base.OnGamePaused();
        }

        public override void OnGameUnpaused()
        {
            base.OnGameUnpaused();
        }

        public override void LoadInterfaces()
        {
            /*---Menus---*/
            _pauseInterface = InterfaceLoader.LoadMenu(InterfaceLoader.Menus.EventPause, false);
            _eliminatedInterface = InterfaceLoader.LoadMenu(InterfaceLoader.Menus.Eliminated, false);
            _eventCompleteInterface = InterfaceLoader.LoadMenu(Campaign.PlayingCampaign ? InterfaceLoader.Menus.EventCompleteStandardCampaign : InterfaceLoader.Menus.EventCompleteStandard, false);

            /*---HUDs---*/
            _speedAndShieldHud = CreateNewHuds(InterfaceLoader.Huds.SpeedAndShield);
            _notificationHud = CreateNewHuds(InterfaceLoader.Huds.NotificationBuffer);
            _timeHud = CreateNewHuds(InterfaceLoader.Huds.TimeStandard);
            _positionHud = CreateNewHuds(InterfaceLoader.Huds.Position);
            _lapHud = CreateNewHuds(InterfaceLoader.Huds.Lap);
            _weaponHud = CreateNewHuds(InterfaceLoader.Huds.Weapon);
            _nowPlayingHud = CreateNewHuds(InterfaceLoader.Huds.NowPlaying);
        }

        public override void DestroyInterfaces()
        {
            /*---Menus---*/
            if (_pauseInterface) UnityEngine.Object.Destroy(_pauseInterface.gameObject);
            if (_eliminatedInterface) UnityEngine.Object.Destroy(_eliminatedInterface.gameObject);
            if (_eventCompleteInterface) UnityEngine.Object.Destroy(_eventCompleteInterface.gameObject);

            /*---HUDs---*/
            if (_speedAndShieldHud != null) DestroyHuds(_speedAndShieldHud);
            if (_notificationHud != null) DestroyHuds(_notificationHud);
            if (_timeHud != null) DestroyHuds(_timeHud);
            if (_positionHud != null) DestroyHuds(_positionHud);
            if (_lapHud != null) DestroyHuds(_lapHud);
            if (_weaponHud != null) DestroyHuds(_weaponHud);
            if (_nowPlayingHud != null) DestroyHuds(_nowPlayingHud);
        }
        #endregion
    }
}
