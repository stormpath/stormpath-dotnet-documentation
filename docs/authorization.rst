.. _authorization:

Authorization
==============

The Stormpath |framework| library provides two ways to easily enforce authorization in your application: group- (or role-) based access control, and permissions-based access control.

Which authorization approach you choose depends on the needs of your application. For most applications, a group-based approach is the fastest and easiest way to implement authorization.

Requiring Login
---------------

At the most simple level, you may want certain routes or controllers to only be accessible when a user is logged in.

.. only:: aspnetcore or aspnet

  To require a user to be logged in, simply use the ``[Authorize]`` attribute on your MVC or API routes:

  .. only:: aspnetcore

    .. literalinclude:: code/authorization/aspnetcore/protected_route.cs
        :language: csharp

  .. only:: aspnet

    .. literalinclude:: code/authorization/aspnet/protected_route.cs
        :language: csharp

.. only:: nancy

  .. todo::

    Description.

  .. .literalinclude:: code/authentication/nancy/protected_route.cs
      :language: csharp

If the user is not logged in, they will be redirected to the built-in login route (``/login`` by default) to log in or register. After authenticating, they will be redirected back to the original route automatically.


Groups and Roles
----------------

In Stormpath, an Account can belong to one or more Groups, which can represent claims or roles. Adding an Account to a Group can be thought of as adding that user to a role, or assigning a claim or label to the account.

.. note::

  You can create and assign Groups using the `Stormpath Admin Console`_, or via `C# <https://docs.stormpath.com/csharp/product-guide/latest/accnt_mgmt.html#groups>`_ or `Visual Basic <https://docs.stormpath.com/vbnet/product-guide/latest/accnt_mgmt.html#groups>`_ code and the Stormpath SDK.

For example, you might create an ``admin`` Group that Accounts with administrator access are assigned to. Then, in your |framework| project, you can restrict access to controllers and actions based on membership in that group.

Requiring a Group
.................

.. only:: aspnet

  You can use the ``[StormpathGroupsRequired]`` attribute, along with ``[Authorize]``, to require membership in one or more Groups.

  .. only:: aspnet

    .. literalinclude:: code/authorization/aspnet/require_single_group.cs
        :language: csharp

  The attribute can be placed on both controllers (to require Group membership for all actions) and on specific actions.

  .. warning::

    There are ``StormpathGroupsRequired`` attributes in two separate namespaces: ``Stormpath.AspNet.Mvc`` and ``Stormpath.AspNet.WebApi``. Make sure you import and use the correct object (depending on whether you are applying it to MVC or Web API controllers).

.. only:: aspnetcore

  In ASP.NET Core, authorization is handled by named policies defined in the ``Startup`` class. To create a policy that requires a Stormpath Group, use this code in the ``ConfigureServices`` method:

  .. literalinclude:: code/authorization/aspnetcore/require_single_group_startup.cs
      :language: csharp

  Then, you can use this policy in the ``Authorize`` attribute on controllers or routes:

  .. literalinclude:: code/authorization/aspnetcore/require_single_group_controller.cs
      :language: csharp

.. only:: nancy

  .. .literalinclude:: code/authorization/nancy/require_single_group.cs
      :language: csharp

It's possible to specify a Group by ``href`` instead of name, if you wish:

.. only:: aspnet

  .. literalinclude:: code/authorization/aspnet/require_group_by_href.cs
      :language: csharp

.. only:: aspnetcore

  .. literalinclude:: code/authorization/aspnetcore/require_group_by_href.cs
      :language: csharp

.. only:: nancy

  .. .literalinclude:: code/authorization/nancy/require_group_by_href.cs
      :language: csharp

It's also possible to specify multiple Group names or ``hrefs``. If the user is in **any** of the specified Groups, the authorization will succeed.

.. only:: aspnet

  .. literalinclude:: code/authorization/aspnet/require_any_group.cs
      :language: csharp

.. only:: aspnetcore

  .. literalinclude:: code/authorization/aspnetcore/require_any_group.cs
      :language: csharp

.. only:: nancy

  .. .literalinclude:: code/authorization/nancy/require_any_group.cs
      :language: csharp

Requiring Multiple Groups
.........................

To require the user to be in more than one Group, apply the syntax twice:

.. only:: aspnet

  .. literalinclude:: code/authorization/aspnet/require_multiple_groups.cs
      :language: csharp

.. only:: aspnetcore

  .. literalinclude:: code/authorization/aspnetcore/require_multiple_groups.cs
      :language: csharp

.. only:: nancy

  .. .literalinclude:: code/authorization/nancy/require_multiple_groups.cs
      :language: csharp


Fine-Grained Permissions
------------------------

.. todo::
  customData


.. _Stormpath Admin Console: https://api.stormpath.com/login
