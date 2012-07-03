##This Fork##
Uses json.net for serialization so DT_RowId and DT_RowClass can be used (a dictionary was required).

Adds a property getter/setter and binds DataTable.aoData.  This dictionary contains all other key value pairs that are not specially handled; meaning you can retreive any key value pairs added to aoData via the fnServerParams (see [http://datatables.net/release-datatables/examples/server_side/custom_vars.html])

##How to Use (Properly)##

In Global.asax.cs during Application_Start:

    ModelBinders.Binders.Add(typeof(DataTable), new DataTableModelBinder());

##QA Build Environment##

I'm using this project with another solution that has a QA build environment and VS requires the build environments be stored in the .csproj file; for now this is temporary until I disconnect this project from the solution.  You have been warned.

##Original README##

This projects supplies C# classes for ASP.NET MVC 3 if jQuery DataTables is used as a data grid component and server side processing is enabled.

The projects comes with a DataTables model binder, to have a convenient C# data structure to bind the DataTables server request and a DataTableResult to generate the neccesary JSON data strucuture needed by DataTables as result.

For more information see Mvc3Application.AppSpike from source.
