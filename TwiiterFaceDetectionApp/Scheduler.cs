//using DataAccessLayer;
//using FluentScheduler;
//using Microsoft.Extensions.DependencyInjection;
//using ServiceLayer;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using StructureMap;

//namespace TwiiterFaceDetectionApp
//{
//    public class Scheduler : FluentScheduler.Registry, IJob
//    {

//        public Scheduler()
//        {

//            Schedule<TwitterStreamListeneingTask>().ToRunNow();
//            Schedule<ImageDetectorTask>().ToRunEvery(1).Minutes();
//        }

//        public void Execute()
//        {
//            throw new NotImplementedException();
//        }
//    }

    

//    public class ImageDetectorTask : IJob
//    {
//        private readonly TwittImageService _TwittImageService;
//        public ImageDetectorTask(TwittImageService TwittImageService)
//        {
//            _TwittImageService = TwittImageService;
//        }
//        public void Execute()
//        {
//            _TwittImageService.DetectFacesIntoredTwittsImages().Wait();
//        }
//    }


//    public class TwitterStreamListeneingTask : IJob
//    {
//        private readonly TwitterApiServie _TwitterApiServie;
//        public TwitterStreamListeneingTask(TwitterApiServie TwitterApiServie)
//        {
//            _TwitterApiServie = TwitterApiServie;
//        }

//        public void Execute()
//        {
//            _TwitterApiServie.checkForPhotosInTwitsByText("radiohead").Wait();
//        }
//    }
//}
