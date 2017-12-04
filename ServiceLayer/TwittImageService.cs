using BusinessObjectLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TwittImageService
    {
        private readonly TwittsImageDataProvider _TwittsImageDataProvider;

        private readonly FaceDetectionApiService _FaceDetectionApiService;

        public TwittImageService(TwittsImageDataProvider TwittsImageDataProvider, FaceDetectionApiService FaceDetectionApiService)
        {
            _TwittsImageDataProvider = TwittsImageDataProvider;
            _FaceDetectionApiService = FaceDetectionApiService;
        }
        public async Task<List<TwitImage>> DetectFacesIntoredTwittsImages(string track)
        {
            var undetectedImages = _TwittsImageDataProvider.getFirsttN(a => a.Detected == false && a.Track.Contains(track), 10);
            foreach (var image in undetectedImages)
            {
                var detectionResult = await _FaceDetectionApiService.DetectFaces(image.Url);

                image.Detected = true;

                if (detectionResult.Count > 0)
                    image.HasFace = true;

                image.MaleCount = (short)detectionResult.Where(f => f.FaceAttributes.Gender == "male").Count();
                image.FemaleCount = (short)detectionResult.Where(f => f.FaceAttributes.Gender == "female").Count();
            }

            _TwittsImageDataProvider.Update(undetectedImages);
            var res = undetectedImages.Where(i => i.HasFace).ToList();

            return res;
        }

        public List<TwitImage> GetLastTenPicture(string track)
        {
            return _TwittsImageDataProvider.getLastN(i => i.Detected && i.HasFace && i.Track.Contains(track), 10);
        }

        public Tuple<int, int> GetHourlyGenderAverage(string track)
        {
            return new Tuple<int, int>
                 (
                   (int)_TwittsImageDataProvider.GetHourlyGenderAverage(track, "male"),
                   (int)_TwittsImageDataProvider.GetHourlyGenderAverage(track, "female")
                 );
        }
    }
}
