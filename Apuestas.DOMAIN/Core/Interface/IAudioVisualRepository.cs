using ApuestasDepor.DOMAIN.Core.Entities;

namespace ApuestasDepor.DOMAIN.Core.Interface
{
    public interface IAudioVisualRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<AudioVisual>> GetAudioVisual();
        Task<AudioVisual> GetAudioVisualById(int id);
        Task<bool> Insert(AudioVisual audioVisual);
        Task<bool> Update(AudioVisual audioVisual);
    }
}