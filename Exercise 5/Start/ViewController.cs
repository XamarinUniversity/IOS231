﻿using System;

using UIKit;
using MapKit;
using CoreLocation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BananaFinder
{
	public partial class ViewController : UIViewController
	{
		public static CLLocationCoordinate2D currentLocation = new CLLocationCoordinate2D (49.28275, -123.12); 

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			map.Camera.CenterCoordinate = currentLocation;
			map.Camera.Altitude = 10000;

			var mapDelegate = new GroceryMapDelegate ();

			map.Delegate = mapDelegate;
		}

        void AddStoreAnnotations(List<GroceryStore> stores)
        {
            foreach (var store in stores)
            {
                var storeAnnotation = new StoreAnnotation(store);
                //make sure we dont already have the annotation
                bool alreadyContainsAnnotation = false;
                foreach (var annotation in map.Annotations)
                {
                    StoreAnnotation mapAnnotationAsStore = annotation as StoreAnnotation;
                    if (mapAnnotationAsStore != null)
                    {
                        if (mapAnnotationAsStore.Address == store.Address)
                        {
                            alreadyContainsAnnotation = true;
                            break;
                        }
                    }
                }
                if (!alreadyContainsAnnotation)
                    map.AddAnnotation(storeAnnotation);
            }
        }
	}
}

