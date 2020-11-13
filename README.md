In this post, I’m going to discuss the CRUD (Create, Read, Update, and Delete) Operations in an ASP.NET MVC application by using raw ADO.NET. Most of the new learners, who started to learn MVC asked this frequently. That’s the main reason I wrote this tutorial. In this article, I'm going to explain step by step procedure from DB table creation to all MVC files.

Software Requirements
 
For this particular application, I have used the following configuration:
Visual Studio 2017
SQL Server Express
In order to keep my hand clean, I have used a simple table to do the CRUD operation.

SET ANSI_NULLS ON  
GO  
  
SET QUOTED_IDENTIFIER ON  
GO  
  
SET ANSI_PADDING ON  
GO  
  
CREATE TABLE[dbo]. [tblStudent](  
  [student_id][int] IDENTITY(1, 1) NOT NULL,  
  [student_name][varchar](50) NOT NULL,  
  [stduent_age][int] NOT NULL,  
  [student_gender][varchar](6) NOT NULL,  
  CONSTRAINT[PK_tblStudent] PRIMARY KEY CLUSTERED(  
    [student_id] ASC  
  ) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]  
) ON[PRIMARY]  
  
GO  
  
SET ANSI_PADDING OFF  
GO 



Step 2: Create an “Empty” ASP.NET MVC application in Visual Studio 2017.

Step 3:
 
Add an “Empty” Controller by right-clicking on the “Controller” folder. Select “Add” then select “Controller..”. In the popup select “MVC 5 Controller”, then click “Add”. In the next popup, you should give the name  “CRUDController”.


After adding the controller, you may notice as per the “convention” in ASP.NET MVC under the “Views” folder, a new folder named “CRUD” also created.

Step 4:
 At First add Nuget package for System.Data.SqlClient.
 
Our DB access code is going to be placed inside the “Models” folder. The model is just a “Class” file. So we are going to create a Model class for our purpose as below:
Right-click on the “Model” folder. In the context menu select “Add” then choose “New item..”.
In the popup, select “Code” then choose “Class” and name the class file as “CRUDModel” then click “Add”. That’s all!

Step 5:
 
Till now we created classes for “Controller” and “Model”. We didn’t create any views till now. In this step, we are going to create a view, which is going to act as a “home” page for our application. In order to create the view:
Right-click on the “CRUD” folder under the “Views” folder in the context menu select “Add” then choose “View..”.
In the popup, give “View name” and uncheck the “Use a layout page” checkbox. Finally, click the “Add” button.

Step 6:
 
We don’t have a controller named “Default”, which is specified in the “RouteConfig.cs” file. We need to change the controller’s name to “CRUD”, in the default route values.

After the above change, just press F5 in Visual Studio, to verify that our application works fine without any error.
 
Step 7:
 
In order to achieve the complete CRUD operation, I’m going to add a number of views as described in Step 5. Here is the complete list of views and it’s purpose.
View	Purpose
Home.cshtml	This is the default view. Loaded when the application launched. Will display all the records in the table
Create.cshtml	Displays control’s to insert the record. Will be rendered when the “Add New Record” button clicked on the “Home.cshtml” view.
Edit.cshtml	Displays control’s to edit the record. Will be rendered when the “Edit” button clicked on the “Home.cshtml” view.
 
Step 8:
 
The model class contains all the “Data Access” logic. In other words, it will interact with the Database and give it back to “View” through “Controller”.

CRUDController.cs
 
In an MVC application, controller is the entry point. The following code contains all the action methods for the complete CRUD operation.

Views
 
Views are a combination of markup as well as server-side code. As you noticed the views "Home" and "Edit" take the ADO.NET object Datatable as a model. Also, for simplicity, I don't use "Layout".

Readers, I hope you like this article. Let me know your thoughts as comments.
