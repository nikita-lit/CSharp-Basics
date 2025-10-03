using NAudio.Wave;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public static partial class Program
    {
        public static WaveOutEvent OutputDevice = new();
        private static Dictionary<string, (WaveOutEvent device, AudioFileReader reader)> _soundCache = new();

        public static void PrecacheSound(string path)
        {
            try
            {
                string fullPath = Path.Combine(GetBaseDir(), $"sounds/{path}");
                if (!File.Exists(fullPath))
                    return;

                var reader = new AudioFileReader(fullPath);
                var device = new WaveOutEvent();
                device.Init(reader);

                _soundCache[path] = (device, reader);
            }
            catch { } // ignore
        }

        public static void PlaySound(string path)
        {
            if (!_soundCache.ContainsKey(path))
                return;

            var reader = _soundCache[path].reader;
            var device = _soundCache[path].device;

            reader.Position = 0;
            device.Play();
        }

        public static void StopSound(string path)
        {
            if (!_soundCache.ContainsKey(path))
                return;

            var device = _soundCache[path].device;
            var reader = _soundCache[path].reader;
            reader.Position = 0;
            device.Stop();
        }
    }
}
