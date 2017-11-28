SQL Server Database Publishing Wizard
(c) Copyright Microsoft Corporation, 2008. All rights reserved.
Website: http://www.codeplex.com/sqlhost

=======================================
What is the Database Publishing Wizard?
=======================================

The Database Publishing Wizard enables the deployment of SQL Server databases 
(both schema and data) into a shared hosting environment.  The tool supports 
SQL Server 2008, 2005, and 2000 and does not require that source and target 
servers are the same version.

The tool provides two modes of deployment:

  1) It generates a single SQL script file which can be used to recreate
  a database when the only connectivity to a server is through a 
  web-based control panel with a script execution window.

  2) It connects to a web service provided by your hoster and directly
  creates objects on a specified hosted database

The tool may also be used by hosters to script out databases for backup or 
transfer purposes.

=====
Usage
=====

The Database Publishing Wizard provide both a graphical and a command-line
interface.  To use the graphical interface, simply execute "sqlpubwiz.exe"
without any arguments.

To retrieve details on the arguments supported by the command-line
interface, execute the following command:

  sqlpubwiz help


The tool also integrates directly into Visual Web Developer 2010 Express 
Edition and all non-Express SKUs of Visual Studio.  Right click on any
SQL Server database connecton and select "Publish to provider..." to launch
the wizard.

For further details on usage please see:

  http://www.codeplex.com/Wiki/View.aspx?ProjectName=sqlhost&title=Database%20Publishing%20Wizard

======================================
Simple Command Line Scripting Examples
======================================

The following command will script the FooDB database existing on the local
machine and default instance using the Windows credentials of the executing
user to C:\FooDB.sql:


  sqlpubwiz script -d FooDB C:\FooDB.sql


The following command will script the FooDB database from the default
instance on a machine named MYSERVER using SQL Server authentication with
the username "Alice" and the password "7h92-v6k3" to the file C:\FooDB.sql:

	
  sqlpubwiz script -d FooDB -S MYSERVER -U Alice -P 7h92-v6k3 C:\FooDB.sql

============
Known Issues
============

For a list of known issues, please see:
  http://www.codeplex.com/Wiki/View.aspx?ProjectName=sqlhost&title=DPW%20Known%20Issues

================================================
Support, Feedback, Bug Reports, Feature Requests
================================================

For support and any feedback on the tool, please use the following forum:
  http://www.codeplex.com/Project/ListThreads.aspx?ProjectName=sqlhost&ForumId=1807