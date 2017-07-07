using Core.Interfaces;
using MediaFiles.ConcreteFile;
using MediaFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MediaItem
{
    public class Initialize
    {
        public IEnumerable<IMediaItem> InitializeComponent()
        {
            var discList = new List<IDisc>();
            discList.Add(new MusicLocal("music d1 local disk", "Music D1 name", "disk d:"));
            discList.Add(new VideoLocal("video d1 local disk", "Video 1 name", "disk d:"));
            discList.Add(new PhotoLocal("photo d1 local disk", "Photo 1 name", "disk d:"));
            MediaDisc disc = new MediaDisc(discList);

            var list  = new List<IMediaItem>();
            list.Add(new MediaFile<MusicLocal>(new MusicLocal("music 1 local", "Music 1 name", "disk d:")));
            list.Add(new MediaFile<MusicWeb>(new MusicWeb ("music 2 web", "Music 2 name", "vk.com")));
            list.Add(new MediaFile<VideoLocal>(new VideoLocal("video 1 local", "Video 1 name", "disk d:")));
            list.Add(new MediaFile<VideoWeb>(new VideoWeb("video 2 web", "Video 2 name", "youtube")));
            list.Add(new MediaFile<PhotoLocal>(new PhotoLocal("photo 1 local", "Photo 1 name", "disk d:")));
            list.Add(new MediaFile<PhotoWeb>(new PhotoWeb("photo 2 web", "Photo 2 name", "instagram")));
            list.Add(new MediaFile<MusicLocal>(new MusicLocal("music 1 local", "Music 1 name", "disk d:")));
            list.Add(new MediaFile<MusicLocal>(new MusicLocal("music 1 web", "Music 1 name", "disk d:")));
            list.Add(disc);
            return list;
        }
    }
}
