# assignment-3-erensapci

# Waste Collection System with .NET5, NHibernate and PostgreSql

All of the packages used in the project are as in the image shown below:

<img width="483" alt="Package" src="https://user-images.githubusercontent.com/43892645/187087283-5214c4a5-adb6-493d-b327-d4e7aff34ba0.PNG">

Two separate database tables were created in the project. From these tables, the vehicleId in the container table is defined as the foreign key.
In this way, a connection is provided with our other table, the vehicles table. 
The components in the tables are shown to the user with the following 3 images.

Containers:

<img width="677" alt="ContainersProperties" src="https://user-images.githubusercontent.com/43892645/187087466-8c3c08dc-37ce-40f1-a76d-94bdf3a3249a.PNG">

Vehicles:

<img width="676" alt="VehicleProperties" src="https://user-images.githubusercontent.com/43892645/187087500-0be42dff-31f1-4a2a-bb08-e65442b0c072.PNG">

Schemas:

<img width="799" alt="Schemas" src="https://user-images.githubusercontent.com/43892645/187087512-b346c662-5043-4b29-bde8-f08f6315f483.png">

A few problems were encountered while connecting the database to the project. 
The most important ones were that the data types did not match and that all the components in the database should be lowercase.
After making the necessary adjustments, the project and the database are connected without any problems.

Image of all controllers in swagger:

<img width="1008" alt="Capture" src="https://user-images.githubusercontent.com/43892645/187088194-4d105885-f425-4e58-b51f-483a93b92a50.PNG">

Some of images about methods:

Post a new Vehicle:

<img width="803" alt="PostnewVehiclePNG" src="https://user-images.githubusercontent.com/43892645/187088244-16443ea3-b821-4d32-a602-7e92c5d2b7fc.PNG">

After post a new vehicle:

<img width="800" alt="AfterPostNewVehicle" src="https://user-images.githubusercontent.com/43892645/187088255-2fbede6e-160a-4a9b-9262-27698e5bf714.PNG">

Delete Vehicle: 

<img width="798" alt="DeleteVehicle" src="https://user-images.githubusercontent.com/43892645/187088269-20c95810-d973-43d8-a82f-e695ed66bc83.PNG">

Containers Table GetByVehicleId:

<img width="800" alt="GetByVehicleId" src="https://user-images.githubusercontent.com/43892645/187088303-0c3ff0ff-73dd-45c1-9f1c-1ea2cadb7f39.PNG">

Grouping algorithm:

<img width="794" alt="Grouping1" src="https://user-images.githubusercontent.com/43892645/187089934-36f94626-878d-45d8-8cdb-c5e8bcaa2efe.PNG">

<img width="790" alt="Grouping2" src="https://user-images.githubusercontent.com/43892645/187089939-a26069da-f70d-4a34-aec1-4db89c3bdfd5.PNG">
