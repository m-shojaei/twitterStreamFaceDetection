using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FaceDetectionApiService
    {
        private readonly IFaceServiceClient faceServiceClient =
              new FaceServiceClient("847f907e15e34dc8be371207e6628501", "https://westcentralus.api.cognitive.microsoft.com/face/v1.0");

        public async Task<List<Face>> DetectFaces(string photoUrl)
        {
            IEnumerable<FaceAttributeType> faceAttributes =
                new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age };
            List<Face> faces = new List<Face>();

            try
            {
                Thread.Sleep(3500);
                var detectionResult = await faceServiceClient.DetectAsync(photoUrl, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);
                faces.AddRange(detectionResult.ToList());
                return faces;
            }

            catch (FaceAPIException f)
            {
                return faces;
            }
            // Catch and display all other errors.
            catch (Exception e)
            {
                return faces;
            }
        }

    }
}
