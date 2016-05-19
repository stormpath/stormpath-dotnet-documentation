.. _setup:


Quickstart
==========

This section walks you through adding Stormpath to a new |framework| project. By the end of this short tutorial you'll have working login and registration features added to your application!


Create a Stormpath Account
--------------------------

If you haven't already, the first thing you'll want to do is `create a new Stormpath account <https://api.stormpath.com/register>`_.


Create an API Key Pair
----------------------

Once you've created a new account, you need to create an API key pair. These are your credentials for the Stormpath API. A new API key pair is easily created by logging into your dashboard and clicking the "Create an API Key" button. This will generate a new key pair for you, and prompt you to download the key pair as a file.

.. note::
    Please keep the API key file safe!  This key and secret
    allows you to make Stormpath API requests, and should be properly protected.

We recommend storing your API credentials in local environment variables. Once you've downloaded your ``apiKey.properties`` file, open it in Notepad or your favorite text editor. Find the **API Key ID** and **API Key Secret** and run these commands in PowerShell (or your shell of choice):

.. code-block:: powershell

  setx STORMPATH_CLIENT_APIKEY_ID "[value from properties file]"
  setx STORMPATH_CLIENT_APIKEY_SECRET "[value from properties file]"

.. note::

  You can also load your credentials straight from the ``apiKey.properties`` file, or
  include them in your project code. See the :ref:`configuration` section for all the details.


Find Your Stormpath Application
-------------------------------

To get you up and running quickly, all new Stormpath Tenants come with a Stormpath Application called
"My Application". You'll generally want one application per project, and we can
use this default application to get started.

.. note::
  To learn more about Stormpath Applications, please see the
  `Application Resource`_ section of our REST API documentation.

Every Stormpath Application has unique URL, which looks something like this:

.. code-block:: none

    https://api.stormpath.com/v1/applications/l0ngr4nd0mstr1ngh3r3

From inside the `Admin Console`_, you can find the URL (also called the REST URL or href) by navigating to the "My Application" item in the Applications list.

We recommend saving this URL as an environment variable as well:

.. code-block:: powershell

  setx STORMPATH_APPLICATION_HREF "[your Application href]"

.. note::
  Your default Application will also have a Stormpath Directory mapped to it. The Directory is where Stormpath stores accounts. To learn more, please see `Directory Resource`_ and `Modeling Your User Base`_.


Now that your API credentials and Stormpath Application are ready, you're set to plug Stormpath into your project!


Example Projects
----------------

If you're feeling lazy (as all good programmers should!), you can download one of our example projects to get up and running super fast:

- `ASP.NET Core 1.0 MVC Example Project`_
- `ASP.NET MVC 5 Example Project`_

.. todo::
  Add Nancy example project when available


Create a New Project
--------------------

If you are adding Stormpath to an existing application, skip to the next section!

.. only:: aspnetcore

  If you are using Visual Studio, First, create a new project using the ASP.NET Core template:

  1. Click on **File - New Project**.
  2. Under **Visual C# - Web**, pick the **ASP.NET Web Application** template.
  3. In the New ASP.NET Project dialog, pick **Web Application** or **Web API** from **ASP.NET 5 Templates**.
  4. Click **Change Authentication** and pick **No Authentication**. (You'll be adding it yourself!)

  .. todo::

    Update "ASP.NET 5 Templates" when VS is updated.

  If you're on Mac or Linux, or just prefer the command line, you can use the `ASP.NET Yeoman Generator`_ to scaffold a new project instead:

  1. Run ``yo aspnet``.
  2. Pick the **Web Application Basic [without Membership and Authorization]** template. Done!

.. only:: aspnet

  First, create a new project using the ASP.NET template in Visual Studio:

  1. Click on **File - New Project**.
  2. Under **Visual C# - Web**, pick the **ASP.NET Web Application** template.
  3. In the New ASP.NET Project dialog, pick the **MVC** or **Web API** template.
  4. Click **Change Authentication** and pick **No Authentication**. (You'll be adding it yourself!)

.. only:: nancy

  .. todo::
    Add instructions


Install the Package
-------------------

.. only:: aspnetcore

  The ``Stormpath.AspNetCore`` package comes with everything you need to plug Stormpath into an ASP.NET Core project.

.. only:: aspnet

  The ``Stormpath.AspNet`` package comes with everything you need to plug Stormpath into an ASP.NET project.

.. only:: nancy

  .. todo::
    Add blurb.


The package can be installed with the NuGet Package Manager interface, or using the Package Manager Console:

.. only:: aspnetcore

  .. code-block:: none

    PM> install-package Stormpath.AspNetCore


.. only:: aspnet

  .. code-block:: none

    PM> install-package -pre Stormpath.AspNet

  .. todo::
    Remove -pre

  .. note::

    Older versions of NuGet will sometimes fail to install the package. If you get an error, make sure `NuGet is up to date <https://docs.nuget.org/consume/installing-nuget#updating-nuget-in-visual-studio>`_.


.. only:: nancy

  .. code-block:: none

    PM> install-package Stormpath.Nancy

It includes the `Stormpath .NET SDK`_, the Stormpath OWIN middleware, and pre-rendered views that work out of the box.


Initialize the Middleware
----------------------------

.. only:: aspnetcore

  Once the package is installed, you need to add it to your application in ``Startup.cs``. First, add the required services in ``ConfigureServices()``:

  .. literalinclude:: code/quickstart/aspnetcore/configure_services.cs
      :language: csharp

  Next, add Stormpath to your middleware pipeline in ``Configure()``:

  .. literalinclude:: code/quickstart/aspnetcore/configure.cs
      :language: csharp

  .. note:: It's important that the Stormpath middleware is added **before** any middleware that needs to be protected, such as MVC!

.. only:: aspnet

  Once the package is installed, you need to add it to your OWIN startup class (usually called ``Startup.cs``).

  .. tip::

    If you don't have a ``Startup.cs`` file, right-click on your project and select **Add - OWIN Startup class**.

  .. literalinclude:: code/quickstart/aspnet/startup.cs
    :language: csharp

.. only:: nancy

  .. todo::
    Add steps

  .. note:: It's important that the Stormpath middleware is added **before** any middleware that needs to be protected, such as <todo>!


With this minimal configuration, the library will do the following:

- Look for Stormpath API credentials and Application URL in your local environment variables.

- Discover your Stormpath Application and its configuration and account stores.

- Attach the :ref:`default_features` to your application, such as the
  login and registration routes.

That's it, you're ready to go! Compile and run your project, and try navigating to these URLs:

- http://localhost:50000/login
- http://localhost:50000/register

.. note::
  Your port number will differ. To find the port assigned to your project, right-click on the project in the Solution Explorer and choose **Properties**. Switch to the **Web** tab and check the URL listed in **Servers - Project Url**.

You should be able to register for an account and log in. The newly created
account will be placed in the directory that is mapped to "My Application".

.. note::

    By default, we don't require email verification for new accounts, but we
    highly recommend you use this workflow. See the :ref:`email_verification` section for details.

There are many more features beyond basic login and registration. You can jump to any of the features using the sidebar menu on the left, or continue to the next section to learn how to configure the library.


.. _Admin Console: https://api.stormpath.com/login
.. _Application Resource: https://docs.stormpath.com/rest/product-guide/latest/reference.html#application
.. _Directory Resource: https://docs.stormpath.com/rest/product-guide/latest/reference.html#directory
.. _ASP.NET Yeoman Generator: https://github.com/OmniSharp/generator-aspnet
.. _Modeling Your User Base: https://docs.stormpath.com/rest/product-guide/latest/accnt_mgmt.html#modeling-your-user-base
.. _ASP.NET Core 1.0 MVC Example Project: https://github.com/stormpath/stormpath-aspnetcore-example
.. _ASP.NET MVC 5 Example Project: https://github.com/stormpath/stormpath-aspnet-example
.. _Stormpath .NET SDK: https://github.com/stormpath/stormpath-sdk-dotnet
