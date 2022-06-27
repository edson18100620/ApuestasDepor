using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using ApuestasDepor.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Infrastructure.Repositories
{
    public class AudioVisualRepository : IAudioVisualRepository
    {
        private readonly ApuestasV2Context _context;
        public AudioVisualRepository(ApuestasV2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AudioVisual>> GetAudioVisual()
        {
            return await _context.AudioVisual.ToListAsync();
        }
        public async Task<AudioVisual> GetAudioVisualById(int id)
        {
            var audioVisual = await _context.AudioVisual.FindAsync(id);

            if (audioVisual == null)
                throw new Exception("AudioVisual not  found");
            return audioVisual;
        }

        public async Task<bool> Insert(AudioVisual audioVisual)
        {
            await _context.AudioVisual.AddAsync(audioVisual);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
        public async Task<bool> Update(AudioVisual audioVisual)
        {
            _context.AudioVisual.Update(audioVisual);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }
        public async Task<bool> Delete(int id)
        {
            var audioVisual = await _context.AudioVisual.FindAsync(id);
            if (audioVisual == null)
                return false;
            _context.Remove(audioVisual);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }




    }
}
