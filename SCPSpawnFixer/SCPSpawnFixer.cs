namespace SCPSpawnFixer
{
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using PluginAPI.Events;
    
    public class SCPSpawnFixer
    {
        public static SCPSpawnFixer Instance { get; private set; }

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("SCPSpawnFixer", "1.0.3", "A plugin that fixes scp spawn blackout.", "VORTEX")]
        void LoadPlugin()
        {
            Instance = this;
            EventManager.RegisterEvents<EventHandlers>(this);
        }
    }
}