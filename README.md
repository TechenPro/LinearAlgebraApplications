# Cube Drawer
An application that builds a representation of a cube in 3D cartesian space, and draws a projection of this cube into the XY-Plane. Support for transforming the cube through rotation and translation.

This application is built with the MAUI Multi-PLatform Framework

The models for a 4x4 matrix and a Vector3 have many more capabilities than just the rotation and translation of a cube. The Vector3 and Matrix4x4 classes can be used to model anything that can be represented as a collection of points and/or vectors, and then can be used to transform these structures.

## Running the app
---
### With Visual Studio:
In order to run the app, you will need an Visual Studio that has the .NET MAUI workload installed.

Clone this repository and open the `LinearAlgebraApplications.sln` solution file with Visual Studio.

### From the MSIX:
Ensure you have the latest WindowsAppRuntime installed. Attempt to install the application from the `LinearAlgebraApplications_1.0.0.0_x64.msix` file.
If you are unable to run the application, you may have to first install the provided certificate.
