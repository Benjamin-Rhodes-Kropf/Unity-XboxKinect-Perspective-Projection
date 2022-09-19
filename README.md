
# XboxKinect-PerspectiveProjection
This is a Unity project built on the back of Microsoft's Kinect for Windows SDK 2.0. The project itself uses perspective projection and head tracking to fake 3D depth on a 2D screen!

## Requirements
- Unity 20.20.21 or later
- Xbox Kinect SDK 
- Kinect Adapter for Xbox One S,Xbox One X 
- Windows 8/8.1/10

## Demo


https://user-images.githubusercontent.com/85074410/163735232-982fe0c4-acb8-48e7-9a14-53c3ca268162.mp4  


https://user-images.githubusercontent.com/85074410/163735230-61a49f94-22e9-4794-9ff5-aa42ed9a1b1d.mp4


## Modifications Made to Kinect SDK
- added hand tracking and geasture control (open/closed hand)
- added rotation tracking for all joints of kinect body
- added toggle mode for showing kinect character in world scene

## Areas for Further Improvment
- projection script causes shadow clipping in game view
- implimentation of hand pointing (i.e raycast from elbow through hand location to get world space directional point)
- additional demo scenes with further intagration of gesture control (i.e the grabbing of various game objects or a reaction other then just color change when hand closed)

## Acknowledgements
 - [Oblique Projection To Quad: code based on Robert Kooima's publication "Generalized Perspective Projection," 2009](http://160592857366.free.fr/joe/ebooks/ShareData/Generalized%20Perspective%20Projection.pdf)
 - [Getting Started with Xbox Kinect](https://www.youtube.com/watch?v=aHGlLxh6a88&t=73s)
 - [Kinect Adapter for Xbox One S,Xbox One X and Windows 8/8.1/10](https://www.amazon.com/gp/product/B07GBGYHG9/ref=ppx_yo_dt_b_search_asin_title?ie=UTF8&psc=1)
 - [Optical Illusion STL file](https://www.thingiverse.com/thing:547580/files)

## Similar Projects
-[The Cylindrical Varrier, a high-resolution parallax-barrier autostereo VR display](https://www.researchgate.net/figure/The-Cylindrical-Varrier-a-high-resolution-parallax-barrier-autostereo-VR-display_fig1_221402769)
