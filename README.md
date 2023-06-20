# forum-winform-1651
This is a simple Forum application, using .NET (Winform) and MongoDB
Class diagram
![classDiagram](https://github.com/vclong2003/forum-winform-1651/assets/53139311/85d7f87a-a936-4bdb-98b5-f4a75c93420e)

Login
![image](https://github.com/vclong2003/forum-winform-1651/assets/53139311/8e823c1b-1ed3-411b-8459-55c6596b4614)

Register
![image](https://github.com/vclong2003/forum-winform-1651/assets/53139311/861a4c62-af39-4380-89ba-213e386dfc5f)

Main page
![image](https://github.com/vclong2003/forum-winform-1651/assets/53139311/8ef27a70-ae37-4f7c-900f-e1c52917f843)

Select a Subforum
![image](https://github.com/vclong2003/forum-winform-1651/assets/53139311/08fb45bc-c7d3-4e7b-ba88-89d8d6d34152)

Create new thread
![image](https://github.com/vclong2003/forum-winform-1651/assets/53139311/92109014-242b-4098-b336-71d0746856bb)

Select a thread
![image](https://github.com/vclong2003/forum-winform-1651/assets/53139311/03500319-4e8b-4708-afc8-379578035901)

Add a new post
![image](https://github.com/vclong2003/forum-winform-1651/assets/53139311/3ac03f34-bb8a-496a-b866-f9eec70d56d6)

This program is an example of implementing Singleton pattern. Why?
Singleton pattern is best for managing database connections because it ensures that there is only one instance of the class responsible for managing the connection. This helps to avoid issues such as creating multiple connections and consuming more resources than necessary, or inconsistent states of the database due to multiple connections modifying the same data. Additionally, the Singleton pattern ensures that the database connection object is thread-safe and can be accessed concurrently by multiple threads without any issues.
Apply to the implemented codes, using the Singleton pattern ensures that only one instance of the DBHandler class exists throughout the entire application's lifecycle. This help preventing multiple threads from accessing and modifying the same database concurrently. Moreover, it helps to reduce the memory footprint of the application by preventing unnecessary object creation.
